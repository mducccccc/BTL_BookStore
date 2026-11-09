using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;

namespace BTL.GUI
{
    public partial class UC_ThueSach : UserControl
    {
        private readonly ThueTraBLL _thueBLL = new();
        private readonly SachBLL _sachBLL = new();
        private readonly KhachHangBLL _khBLL = new();
        private readonly NhanVienBLL _nvBLL = new();
        private readonly DanhMucBLL _dmBLL = new();

        private readonly List<ChiTietThueDTO> _gioSach = new();
        private DataTable _dtSachConHang = new();

        public UC_ThueSach()
        {
            InitializeComponent();
            UITheme.StyleDataGridView(dgvGioSach);
            UITheme.StyleDataGridView(dgvLichSuThue);

            InitGioSachGrid();

            // Hook up events
            btnAutoMa.Click += (s, e) => txtMaThue.Text = _thueBLL.GenerateNewMaThue();
            cboSach.SelectedIndexChanged += CboSach_SelectedIndexChanged;
            btnThemSach.Click += BtnThemSach_Click;
            btnXoaSach.Click += BtnXoaSach_Click;
            btnLapPhieu.Click += BtnLapPhieu_Click;
            btnHuyPhieu.Click += (s, e) => ResetPhieuMoi();
            txtTimLichSu.TextChanged += (s, e) => FilterLichSu();

            LoadLookupData();
            LoadSachConHang();
            LoadLichSuThue();
            ResetPhieuMoi();
        }

        private void InitGioSachGrid()
        {
            dgvGioSach.Columns.Clear();
            dgvGioSach.Columns.Add("MaSach", "Mã Sách");
            dgvGioSach.Columns.Add("TenSach", "Tên Sách");
            dgvGioSach.Columns.Add("SoLuong", "Số Lượng");
            dgvGioSach.Columns.Add("DonGiaThue", "Đơn Giá (đ/ngày)");
            dgvGioSach.Columns["DonGiaThue"].DefaultCellStyle.Format = "N0";

            dgvGioSach.Columns["MaSach"].Width = 90;
            dgvGioSach.Columns["SoLuong"].Width = 80;
            dgvGioSach.Columns["DonGiaThue"].Width = 120;
        }

        private void LoadLookupData()
        {
            try
            {
                cboKhachHang.DataSource = _khBLL.GetAll();
                cboKhachHang.DisplayMember = "TenKH";
                cboKhachHang.ValueMember = "MaKH";

                cboNhanVien.DataSource = _nvBLL.GetAll();
                cboNhanVien.DisplayMember = "TenNV";
                cboNhanVien.ValueMember = "MaNV";
                if (SessionContext.CurrentNhanVien != null)
                {
                    cboNhanVien.SelectedValue = SessionContext.CurrentNhanVien.MaNV;
                }

                cboCaLam.DataSource = _dmBLL.GetCaLam();
                cboCaLam.DisplayMember = "TenCa";
                cboCaLam.ValueMember = "MaCa";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load lookup error: " + ex.Message);
            }
        }

        private void LoadSachConHang()
        {
            try
            {
                _dtSachConHang = _sachBLL.GetSachConHang();
                cboSach.DataSource = _dtSachConHang;
                cboSach.DisplayMember = "TenSach";
                cboSach.ValueMember = "MaSach";

                CboSach_SelectedIndexChanged(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load sach con hang error: " + ex.Message);
            }
        }

        private void CboSach_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboSach.SelectedItem is DataRowView drv)
            {
                int tonKho = Convert.ToInt32(drv["SoLuong"]);
                decimal donGia = Convert.ToDecimal(drv["DonGiaThue"]);

                lblTonKho.Text = $"Tồn kho: {tonKho} cuốn";
                lblDonGia.Text = $"Giá thuê: {donGia:N0} đ/ngày";
                numSoLuongThue.Maximum = tonKho > 0 ? tonKho : 1;
                numSoLuongThue.Value = 1;
            }
        }

        private void LoadLichSuThue()
        {
            try
            {
                var dt = _thueBLL.GetAllPhieuThue();
                dgvLichSuThue.DataSource = dt;

                if (dgvLichSuThue.Columns.Contains("MaThue")) dgvLichSuThue.Columns["MaThue"].HeaderText = "Mã Thuê";
                if (dgvLichSuThue.Columns.Contains("TenKH")) dgvLichSuThue.Columns["TenKH"].HeaderText = "Khách Hàng";
                if (dgvLichSuThue.Columns.Contains("TenNV")) dgvLichSuThue.Columns["TenNV"].HeaderText = "NV Lập";
                if (dgvLichSuThue.Columns.Contains("TenCa")) dgvLichSuThue.Columns["TenCa"].HeaderText = "Ca Trực";
                if (dgvLichSuThue.Columns.Contains("NgayThue")) dgvLichSuThue.Columns["NgayThue"].HeaderText = "Ngày Thuê";
                if (dgvLichSuThue.Columns.Contains("TienDatCoc"))
                {
                    dgvLichSuThue.Columns["TienDatCoc"].HeaderText = "Tiền Cọc (đ)";
                    dgvLichSuThue.Columns["TienDatCoc"].DefaultCellStyle.Format = "N0";
                }

                if (dgvLichSuThue.Columns.Contains("MaKH")) dgvLichSuThue.Columns["MaKH"].Visible = false;
                if (dgvLichSuThue.Columns.Contains("MaNV")) dgvLichSuThue.Columns["MaNV"].Visible = false;
                if (dgvLichSuThue.Columns.Contains("MaCa")) dgvLichSuThue.Columns["MaCa"].Visible = false;
            }
            catch { }
        }

        private void FilterLichSu()
        {
            try
            {
                var dt = dgvLichSuThue.DataSource as DataTable;
                if (dt != null)
                {
                    string f = txtTimLichSu.Text.Trim().Replace("'", "''");
                    if (string.IsNullOrEmpty(f))
                    {
                        dt.DefaultView.RowFilter = string.Empty;
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = $"MaThue LIKE '%{f}%' OR TenKH LIKE '%{f}%' OR TenNV LIKE '%{f}%'";
                    }
                }
            }
            catch { }
        }

        private void BtnThemSach_Click(object? sender, EventArgs e)
        {
            if (cboSach.SelectedItem is not DataRowView drv)
            {
                MessageBox.Show("Vui lòng chọn cuốn sách cần thuê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSach = drv["MaSach"].ToString()?.Trim() ?? string.Empty;
            string tenSach = drv["TenSach"].ToString() ?? string.Empty;
            int tonKho = Convert.ToInt32(drv["SoLuong"]);
            decimal donGia = Convert.ToDecimal(drv["DonGiaThue"]);
            int soLuong = (int)numSoLuongThue.Value;

            var existing = _gioSach.Find(x => x.MaSach == maSach);
            if (existing != null)
            {
                if (existing.SoLuong + soLuong > tonKho)
                {
                    MessageBox.Show($"Tổng số lượng thuê ({existing.SoLuong + soLuong}) vượt quá tồn kho hiện có ({tonKho})!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                existing.SoLuong += soLuong;
            }
            else
            {
                if (soLuong > tonKho)
                {
                    MessageBox.Show($"Số lượng thuê vượt quá tồn kho hiện có ({tonKho})!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _gioSach.Add(new ChiTietThueDTO
                {
                    MaSach = maSach,
                    TenSach = tenSach,
                    SoLuong = soLuong,
                    DonGiaThue = donGia
                });
            }

            CapNhatGioSachGrid();
        }

        private void BtnXoaSach_Click(object? sender, EventArgs e)
        {
            if (dgvGioSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng sách cần bỏ trong giỏ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSach = dgvGioSach.SelectedRows[0].Cells["MaSach"].Value?.ToString() ?? string.Empty;
            _gioSach.RemoveAll(x => x.MaSach == maSach);
            CapNhatGioSachGrid();
        }

        private void CapNhatGioSachGrid()
        {
            dgvGioSach.Rows.Clear();
            int tongSL = 0;
            foreach (var item in _gioSach)
            {
                dgvGioSach.Rows.Add(item.MaSach, item.TenSach, item.SoLuong, item.DonGiaThue);
                tongSL += item.SoLuong;
            }

            lblTongSoCuon.Text = $"Tổng sách: {tongSL} cuốn ({_gioSach.Count} đầu sách)";
        }

        private void BtnLapPhieu_Click(object? sender, EventArgs e)
        {
            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng thuê sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên lập phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboCaLam.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn ca làm việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_gioSach.Count == 0)
            {
                MessageBox.Show("Giỏ thuê sách đang trống! Vui lòng chọn ít nhất 1 cuốn sách để thuê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var phieu = new ThueSachDTO
            {
                MaThue = txtMaThue.Text.Trim(),
                MaKH = cboKhachHang.SelectedValue.ToString() ?? string.Empty,
                MaNV = cboNhanVien.SelectedValue.ToString() ?? string.Empty,
                MaCa = cboCaLam.SelectedValue.ToString() ?? string.Empty,
                NgayThue = dtpNgayThue.Value,
                TienDatCoc = numTienCoc.Value
            };

            if (_thueBLL.LapPhieuThue(phieu, _gioSach, out string error))
            {
                MessageBox.Show($"Lập phiếu thuê sách [{phieu.MaThue}] thành công!\nTồn kho sách đã được tự động cập nhật.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadSachConHang();
                LoadLichSuThue();
                ResetPhieuMoi();
            }
            else
            {
                MessageBox.Show("Lập phiếu thuê thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetPhieuMoi()
        {
            txtMaThue.Text = _thueBLL.GenerateNewMaThue();
            dtpNgayThue.Value = DateTime.Today;
            numTienCoc.Value = 50000;
            _gioSach.Clear();
            CapNhatGioSachGrid();
            if (cboKhachHang.Items.Count > 0) cboKhachHang.SelectedIndex = 0;
            if (cboCaLam.Items.Count > 0) cboCaLam.SelectedIndex = 0;
        }
    }
}
