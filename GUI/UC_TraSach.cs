using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;

namespace BTL.GUI
{
    public partial class UC_TraSach : UserControl
    {
        private readonly ThueTraBLL _thueTraBLL = new();
        private readonly NhanVienBLL _nvBLL = new();
        private readonly DanhMucBLL _dmBLL = new();

        private readonly List<ChiTietTraDTO> _gioTra = new();
        private DataTable _dtSachChuaTra = new();
        private DateTime _ngayThueCuaPhieu = DateTime.Today;
        private decimal _tienCocCuaPhieu = 0;

        public UC_TraSach()
        {
            InitializeComponent();
            UITheme.StyleDataGridView(dgvGioTra);
            UITheme.StyleDataGridView(dgvLichSuTra);
            UITheme.StyleDataGridView(dgvChiTietTra);
            dgvChiTietTra.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvChiTietTra.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvChiTietTra.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dgvChiTietTra.ColumnHeadersHeight = 28;
            dgvChiTietTra.RowTemplate.Height = 26;

            InitGioTraGrid();

            // Hook up events
            btnAutoMa.Click += (s, e) => txtMaTra.Text = _thueTraBLL.GenerateNewMaTra();
            cboMaThue.SelectedIndexChanged += CboMaThue_SelectedIndexChanged;
            dtpNgayTra.ValueChanged += (s, e) => TinhToanThanhTienPreview();
            cboSachChuaTra.SelectedIndexChanged += CboSachChuaTra_SelectedIndexChanged;
            cboViPham.SelectedIndexChanged += (s, e) => TinhToanThanhTienPreview();
            btnThemSachTra.Click += BtnThemSachTra_Click;
            btnXoaSachTra.Click += BtnXoaSachTra_Click;
            btnXacNhanTra.Click += BtnXacNhanTra_Click;
            btnLamMoi.Click += (s, e) => ResetForm();
            txtTimLichSu.TextChanged += (s, e) => FilterLichSu();
            dgvLichSuTra.CellClick += DgvLichSuTra_CellClick;

            LoadLookupData();
            LoadLichSuTra();
            ResetForm();
        }

        private void InitGioTraGrid()
        {
            dgvGioTra.Columns.Clear();
            dgvGioTra.Columns.Add("MaSach", "Mã Sách");
            dgvGioTra.Columns.Add("TenSach", "Tên Sách");
            dgvGioTra.Columns.Add("SoLuong", "SL");
            dgvGioTra.Columns.Add("SoNgayThue", "Số Ngày");
            dgvGioTra.Columns.Add("DonGiaThue", "Giá Thuê (đ/ngày)");
            dgvGioTra.Columns.Add("TenVP", "Lỗi Vi Phạm");
            dgvGioTra.Columns.Add("TienPhat", "Tiền Phạt (đ)");
            dgvGioTra.Columns.Add("ThanhTien", "Thành Tiền (đ)");

            dgvGioTra.Columns["DonGiaThue"].DefaultCellStyle.Format = "N0";
            dgvGioTra.Columns["TienPhat"].DefaultCellStyle.Format = "N0";
            dgvGioTra.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            dgvGioTra.Columns["MaSach"].Width = 80;
            dgvGioTra.Columns["SoLuong"].Width = 40;
            dgvGioTra.Columns["SoNgayThue"].Width = 65;
        }

        private void LoadLookupData()
        {
            try
            {
                var dtThue = _thueTraBLL.GetAllPhieuThue();
                cboMaThue.DataSource = dtThue;
                cboMaThue.DisplayMember = "MaThue";
                cboMaThue.ValueMember = "MaThue";

                cboNhanVien.DataSource = _nvBLL.GetAll();
                cboNhanVien.DisplayMember = "TenNV";
                cboNhanVien.ValueMember = "MaNV";
                if (SessionContext.CurrentNhanVien != null)
                {
                    cboNhanVien.SelectedValue = SessionContext.CurrentNhanVien.MaNV;
                }

                var dtVP = _dmBLL.GetViPham().Copy();
                var rNone = dtVP.NewRow();
                rNone["MaVP"] = "";
                rNone["TenVP"] = "Không vi phạm (Bình thường)";
                rNone["TienPhat"] = 0;
                dtVP.Rows.InsertAt(rNone, 0);

                cboViPham.DataSource = dtVP;
                cboViPham.DisplayMember = "TenVP";
                cboViPham.ValueMember = "MaVP";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load lookup error: " + ex.Message);
            }
        }

        private void CboMaThue_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboMaThue.SelectedItem is DataRowView drv)
            {
                string maThue = drv["MaThue"].ToString()?.Trim() ?? string.Empty;
                string tenKH = drv["TenKH"].ToString() ?? string.Empty;
                _ngayThueCuaPhieu = Convert.ToDateTime(drv["NgayThue"]);
                _tienCocCuaPhieu = Convert.ToDecimal(drv["TienDatCoc"]);

                lblKhachHangInfo.Text = $"Khách hàng: {tenKH}";
                lblNgayThueInfo.Text = $"Ngày thuê: {_ngayThueCuaPhieu:dd/MM/yyyy}";
                lblTienCocInfo.Text = $"Tiền cọc: {_tienCocCuaPhieu:N0} đ";

                LoadSachChuaTra(maThue);
            }
        }

        private void LoadSachChuaTra(string maThue)
        {
            try
            {
                _dtSachChuaTra = _thueTraBLL.GetSachChuaTra(maThue);
                cboSachChuaTra.DataSource = _dtSachChuaTra;
                cboSachChuaTra.DisplayMember = "TenSach";
                cboSachChuaTra.ValueMember = "MaSach";

                if (_dtSachChuaTra.Rows.Count == 0)
                {
                    lblSLThue.Text = "Số lượng: 0";
                    lblDonGia.Text = "Giá thuê: 0 đ/ngày";
                    lblSoNgayThue.Text = "Số ngày: 0";
                    lblThanhTienTamTinh.Text = "Thành tiền: 0 đ (Đã trả hết sách)";
                }
                else
                {
                    CboSachChuaTra_SelectedIndexChanged(null, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load sach chua tra error: " + ex.Message);
            }
        }

        private void CboSachChuaTra_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboSachChuaTra.SelectedItem is DataRowView drv)
            {
                int sl = Convert.ToInt32(drv["SoLuong"]);
                decimal donGia = Convert.ToDecimal(drv["DonGiaThue"]);

                lblSLThue.Text = $"Số lượng: {sl} cuốn";
                lblDonGia.Text = $"Giá thuê: {donGia:N0} đ/ngày";

                TinhToanThanhTienPreview();
            }
        }

        private void TinhToanThanhTienPreview()
        {
            if (cboSachChuaTra.SelectedItem is not DataRowView drv) return;

            int sl = Convert.ToInt32(drv["SoLuong"]);
            decimal donGia = Convert.ToDecimal(drv["DonGiaThue"]);

            int soNgay = (dtpNgayTra.Value.Date - _ngayThueCuaPhieu.Date).Days;
            if (soNgay < 1) soNgay = 1;

            lblSoNgayThue.Text = $"Số ngày thuê: {soNgay} ngày";

            decimal tienPhat = 0;
            if (cboViPham.SelectedItem is DataRowView rVP && rVP["TienPhat"] != DBNull.Value)
            {
                tienPhat = Convert.ToDecimal(rVP["TienPhat"]);
            }
            lblTienPhat.Text = $"Tiền phạt: {tienPhat:N0} đ";

            decimal thanhTien = (donGia * soNgay * sl) + tienPhat;
            lblThanhTienTamTinh.Text = $"Thành tiền: {thanhTien:N0} đ";
        }

        private void BtnThemSachTra_Click(object? sender, EventArgs e)
        {
            if (cboSachChuaTra.SelectedItem is not DataRowView drv)
            {
                MessageBox.Show("Phiếu thuê này không còn cuốn sách nào chưa trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maSach = drv["MaSach"].ToString()?.Trim() ?? string.Empty;
            string tenSach = drv["TenSach"].ToString() ?? string.Empty;
            int sl = Convert.ToInt32(drv["SoLuong"]);
            decimal donGia = Convert.ToDecimal(drv["DonGiaThue"]);

            if (_gioTra.Exists(x => x.MaSach == maSach))
            {
                MessageBox.Show("Cuốn sách này đã được thêm vào danh sách trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soNgay = (dtpNgayTra.Value.Date - _ngayThueCuaPhieu.Date).Days;
            if (soNgay < 1) soNgay = 1;

            string maVP = string.Empty;
            string tenVP = "Không";
            decimal tienPhat = 0;

            if (cboViPham.SelectedItem is DataRowView rVP)
            {
                maVP = rVP["MaVP"].ToString()?.Trim() ?? string.Empty;
                tenVP = rVP["TenVP"].ToString() ?? "Không";
                if (rVP["TienPhat"] != DBNull.Value) tienPhat = Convert.ToDecimal(rVP["TienPhat"]);
            }

            decimal thanhTien = (donGia * soNgay * sl) + tienPhat;

            _gioTra.Add(new ChiTietTraDTO
            {
                MaSach = maSach,
                TenSach = tenSach,
                SoLuong = sl,
                SoNgayThue = soNgay,
                MaVP = string.IsNullOrEmpty(maVP) ? null : maVP,
                TenVP = tenVP,
                ThanhTien = thanhTien
            });

            CapNhatGioTraGrid();
        }

        private void BtnXoaSachTra_Click(object? sender, EventArgs e)
        {
            if (dgvGioTra.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn cuốn sách cần bỏ khỏi danh sách trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSach = dgvGioTra.SelectedRows[0].Cells["MaSach"].Value?.ToString() ?? string.Empty;
            _gioTra.RemoveAll(x => x.MaSach == maSach);
            CapNhatGioTraGrid();
        }

        private void CapNhatGioTraGrid()
        {
            dgvGioTra.Rows.Clear();
            decimal tongTien = 0;

            foreach (var item in _gioTra)
            {
                decimal donGia = 0;
                foreach (DataRow r in _dtSachChuaTra.Rows)
                {
                    if (r["MaSach"].ToString()?.Trim() == item.MaSach)
                    {
                        donGia = Convert.ToDecimal(r["DonGiaThue"]);
                        break;
                    }
                }

                decimal tienPhat = item.MaVP != null ? (item.ThanhTien - (donGia * item.SoNgayThue * item.SoLuong)) : 0;
                if (tienPhat < 0) tienPhat = 0;

                dgvGioTra.Rows.Add(item.MaSach, item.TenSach, item.SoLuong, item.SoNgayThue, donGia, item.TenVP, tienPhat, item.ThanhTien);
                tongTien += item.ThanhTien;
            }

            lblTongThanhTien.Text = $"Tổng tiền thuê & phạt: {tongTien:N0} đ";

            decimal chenhLech = tongTien - _tienCocCuaPhieu;
            if (chenhLech >= 0)
            {
                lblThanhToanCuoi.Text = $"Khách cần nộp thêm: {chenhLech:N0} đ (Sau khi trừ cọc)";
                lblThanhToanCuoi.ForeColor = Color.FromArgb(239, 68, 68);
            }
            else
            {
                lblThanhToanCuoi.Text = $"Hoàn trả cọc cho khách: {Math.Abs(chenhLech):N0} đ";
                lblThanhToanCuoi.ForeColor = Color.FromArgb(16, 185, 129);
            }
        }

        private void BtnXacNhanTra_Click(object? sender, EventArgs e)
        {
            if (cboMaThue.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu thuê cần trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên nhận trả sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_gioTra.Count == 0)
            {
                MessageBox.Show("Danh sách trả sách đang trống! Vui lòng chọn ít nhất 1 cuốn sách để trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var phieu = new TraSachDTO
            {
                MaTra = txtMaTra.Text.Trim(),
                MaThue = cboMaThue.SelectedValue.ToString() ?? string.Empty,
                MaNV = cboNhanVien.SelectedValue.ToString() ?? string.Empty,
                NgayTra = dtpNgayTra.Value
            };

            if (_thueTraBLL.LapPhieuTra(phieu, _gioTra, out string error))
            {
                MessageBox.Show($"Xác nhận trả sách phiếu [{phieu.MaTra}] thành công!\nSố lượng sách đã được tự động hoàn lại vào kho.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadLichSuTra();
                string curMaThue = phieu.MaThue;
                ResetForm();
                cboMaThue.SelectedValue = curMaThue;
            }
            else
            {
                MessageBox.Show("Xác nhận trả sách thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLichSuTra()
        {
            try
            {
                var dt = _thueTraBLL.GetAllPhieuTra();
                dgvLichSuTra.DataSource = dt;

                if (dgvLichSuTra.Columns.Contains("MaTra")) dgvLichSuTra.Columns["MaTra"].HeaderText = "Mã Trả";
                if (dgvLichSuTra.Columns.Contains("MaThue")) dgvLichSuTra.Columns["MaThue"].HeaderText = "Mã Thuê";
                if (dgvLichSuTra.Columns.Contains("TenKH")) dgvLichSuTra.Columns["TenKH"].HeaderText = "Khách Hàng";
                if (dgvLichSuTra.Columns.Contains("TenNV")) dgvLichSuTra.Columns["TenNV"].HeaderText = "NV Nhận";
                if (dgvLichSuTra.Columns.Contains("NgayTra")) dgvLichSuTra.Columns["NgayTra"].HeaderText = "Ngày Trả";
                if (dgvLichSuTra.Columns.Contains("TongTien"))
                {
                    dgvLichSuTra.Columns["TongTien"].HeaderText = "Tổng Tiền (đ)";
                    dgvLichSuTra.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                }

                if (dgvLichSuTra.Columns.Contains("MaNV")) dgvLichSuTra.Columns["MaNV"].Visible = false;

                if (dt.Rows.Count > 0)
                {
                    DgvLichSuTra_CellClick(null, new DataGridViewCellEventArgs(0, 0));
                }
            }
            catch { }
        }

        private void DgvLichSuTra_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvLichSuTra.Rows.Count) return;
            string maTra = dgvLichSuTra.Rows[e.RowIndex].Cells["MaTra"].Value?.ToString()?.Trim() ?? string.Empty;

            try
            {
                var dtCT = _thueTraBLL.GetChiTietTra(maTra);
                dgvChiTietTra.DataSource = dtCT;

                if (dgvChiTietTra.Columns.Contains("MaTra")) dgvChiTietTra.Columns["MaTra"].Visible = false;
                if (dgvChiTietTra.Columns.Contains("MaVP")) dgvChiTietTra.Columns["MaVP"].Visible = false;

                if (dgvChiTietTra.Columns.Contains("MaSach")) dgvChiTietTra.Columns["MaSach"].HeaderText = "Mã Sách";
                if (dgvChiTietTra.Columns.Contains("TenSach")) dgvChiTietTra.Columns["TenSach"].HeaderText = "Tên Sách";
                if (dgvChiTietTra.Columns.Contains("TenVP")) dgvChiTietTra.Columns["TenVP"].HeaderText = "Lỗi Vi Phạm";
                if (dgvChiTietTra.Columns.Contains("TienPhat"))
                {
                    dgvChiTietTra.Columns["TienPhat"].HeaderText = "Phạt (đ)";
                    dgvChiTietTra.Columns["TienPhat"].DefaultCellStyle.Format = "N0";
                }
                if (dgvChiTietTra.Columns.Contains("ThanhTien"))
                {
                    dgvChiTietTra.Columns["ThanhTien"].HeaderText = "Thành Tiền (đ)";
                    dgvChiTietTra.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }
            }
            catch { }
        }

        private void FilterLichSu()
        {
            try
            {
                var dt = dgvLichSuTra.DataSource as DataTable;
                if (dt != null)
                {
                    string f = txtTimLichSu.Text.Trim().Replace("'", "''");
                    if (string.IsNullOrEmpty(f))
                    {
                        dt.DefaultView.RowFilter = string.Empty;
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = $"MaTra LIKE '%{f}%' OR MaThue LIKE '%{f}%' OR TenKH LIKE '%{f}%' OR TenNV LIKE '%{f}%'";
                    }
                }
            }
            catch { }
        }

        private void ResetForm()
        {
            txtMaTra.Text = _thueTraBLL.GenerateNewMaTra();
            dtpNgayTra.Value = DateTime.Today;
            _gioTra.Clear();
            CapNhatGioTraGrid();
            if (cboMaThue.Items.Count > 0)
            {
                cboMaThue.SelectedIndex = 0;
                CboMaThue_SelectedIndexChanged(null, EventArgs.Empty);
            }
        }
    }
}
