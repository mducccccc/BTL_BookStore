using System;
using System.Drawing;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;

namespace BTL.GUI
{
    public partial class UC_DanhMuc : UserControl
    {
        private readonly DanhMucBLL _bll = new();

        public UC_DanhMuc()
        {
            InitializeComponent();
            UITheme.StyleDataGridView(dgvViPham);
            UITheme.StyleDataGridView(dgvTacGia);
            UITheme.StyleDataGridView(dgvNXB);
            UITheme.StyleDataGridView(dgvCaLam);

            SetupEvents();
            LoadAllDanhMuc();
        }

        private void SetupEvents()
        {
            // 1. Vi Phạm
            dgvViPham.CellClick += (s, e) =>
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvViPham.Rows.Count) return;
                var r = dgvViPham.Rows[e.RowIndex];
                txtMaVP.Text = r.Cells["MaVP"].Value?.ToString()?.Trim() ?? string.Empty;
                txtTenVP.Text = r.Cells["TenVP"].Value?.ToString() ?? string.Empty;
                if (r.Cells["TienPhat"].Value != DBNull.Value) numTienPhat.Value = Convert.ToDecimal(r.Cells["TienPhat"].Value);
            };

            btnThemVP.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtMaVP.Text) || string.IsNullOrWhiteSpace(txtTenVP.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ Mã và Tên vi phạm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var vp = new ViPhamDTO { MaVP = txtMaVP.Text.Trim(), TenVP = txtTenVP.Text.Trim(), TienPhat = numTienPhat.Value };
                if (_bll.InsertViPham(vp)) { LoadViPham(); ResetVP(); }
            };

            btnSuaVP.Click += (s, e) =>
            {
                var vp = new ViPhamDTO { MaVP = txtMaVP.Text.Trim(), TenVP = txtTenVP.Text.Trim(), TienPhat = numTienPhat.Value };
                if (_bll.UpdateViPham(vp)) { LoadViPham(); ResetVP(); }
            };

            btnXoaVP.Click += (s, e) =>
            {
                if (_bll.DeleteViPham(txtMaVP.Text.Trim())) { LoadViPham(); ResetVP(); }
            };

            btnMoiVP.Click += (s, e) => ResetVP();

            // 2. Tác Giả
            dgvTacGia.CellClick += (s, e) =>
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvTacGia.Rows.Count) return;
                var r = dgvTacGia.Rows[e.RowIndex];
                txtMaTG.Text = r.Cells["MaTG"].Value?.ToString()?.Trim() ?? string.Empty;
                txtTenTG.Text = r.Cells["TenTG"].Value?.ToString() ?? string.Empty;
                if (r.Cells["NgaySinh"].Value != DBNull.Value && r.Cells["NgaySinh"].Value != null)
                    dtpNgaySinhTG.Value = Convert.ToDateTime(r.Cells["NgaySinh"].Value);
                string gt = r.Cells["GioiTinh"].Value?.ToString()?.Trim() ?? "M";
                cboGioiTinhTG.SelectedIndex = (gt == "F") ? 1 : 0;
                txtDiaChiTG.Text = r.Cells["DiaChi"].Value?.ToString() ?? string.Empty;
            };

            btnThemTG.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtMaTG.Text) || string.IsNullOrWhiteSpace(txtTenTG.Text)) return;
                var tg = new TacGiaDTO
                {
                    MaTG = txtMaTG.Text.Trim(),
                    TenTG = txtTenTG.Text.Trim(),
                    NgaySinh = dtpNgaySinhTG.Value,
                    GioiTinh = cboGioiTinhTG.SelectedIndex == 1 ? "F" : "M",
                    DiaChi = txtDiaChiTG.Text.Trim()
                };
                if (_bll.InsertTacGia(tg)) { LoadTacGia(); txtMaTG.Clear(); txtTenTG.Clear(); txtDiaChiTG.Clear(); }
            };

            btnSuaTG.Click += (s, e) =>
            {
                var tg = new TacGiaDTO
                {
                    MaTG = txtMaTG.Text.Trim(),
                    TenTG = txtTenTG.Text.Trim(),
                    NgaySinh = dtpNgaySinhTG.Value,
                    GioiTinh = cboGioiTinhTG.SelectedIndex == 1 ? "F" : "M",
                    DiaChi = txtDiaChiTG.Text.Trim()
                };
                if (_bll.UpdateTacGia(tg)) { LoadTacGia(); }
            };

            btnXoaTG.Click += (s, e) =>
            {
                if (_bll.DeleteTacGia(txtMaTG.Text.Trim())) { LoadTacGia(); }
            };

            btnMoiTG.Click += (s, e) => { txtMaTG.Clear(); txtTenTG.Clear(); txtDiaChiTG.Clear(); txtMaTG.Focus(); };

            // 3. NXB
            dgvNXB.CellClick += (s, e) =>
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvNXB.Rows.Count) return;
                var r = dgvNXB.Rows[e.RowIndex];
                txtMaNXB.Text = r.Cells["MaNXB"].Value?.ToString()?.Trim() ?? string.Empty;
                txtTenNXB.Text = r.Cells["TenNXB"].Value?.ToString() ?? string.Empty;
                txtDiaChiNXB.Text = r.Cells["DiaChi"].Value?.ToString() ?? string.Empty;
                txtPhoneNXB.Text = r.Cells["DienThoai"].Value?.ToString() ?? string.Empty;
            };

            btnThemNXB.Click += (s, e) =>
            {
                var nxb = new NXBDTO { MaNXB = txtMaNXB.Text.Trim(), TenNXB = txtTenNXB.Text.Trim(), DiaChi = txtDiaChiNXB.Text.Trim(), DienThoai = txtPhoneNXB.Text.Trim() };
                if (_bll.InsertNXB(nxb)) { LoadNXB(); }
            };

            btnSuaNXB.Click += (s, e) =>
            {
                var nxb = new NXBDTO { MaNXB = txtMaNXB.Text.Trim(), TenNXB = txtTenNXB.Text.Trim(), DiaChi = txtDiaChiNXB.Text.Trim(), DienThoai = txtPhoneNXB.Text.Trim() };
                if (_bll.UpdateNXB(nxb)) { LoadNXB(); }
            };

            btnXoaNXB.Click += (s, e) =>
            {
                if (_bll.DeleteNXB(txtMaNXB.Text.Trim())) { LoadNXB(); }
            };

            // 4. Ca Làm
            dgvCaLam.CellClick += (s, e) =>
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvCaLam.Rows.Count) return;
                var r = dgvCaLam.Rows[e.RowIndex];
                txtMaCa.Text = r.Cells["MaCa"].Value?.ToString()?.Trim() ?? string.Empty;
                txtTenCa.Text = r.Cells["TenCa"].Value?.ToString() ?? string.Empty;
            };

            btnThemCa.Click += (s, e) =>
            {
                var ca = new CaLamDTO { MaCa = txtMaCa.Text.Trim(), TenCa = txtTenCa.Text.Trim() };
                if (_bll.InsertCaLam(ca)) { LoadCaLam(); }
            };

            btnSuaCa.Click += (s, e) =>
            {
                var ca = new CaLamDTO { MaCa = txtMaCa.Text.Trim(), TenCa = txtTenCa.Text.Trim() };
                if (_bll.UpdateCaLam(ca)) { LoadCaLam(); }
            };

            btnXoaCa.Click += (s, e) =>
            {
                if (_bll.DeleteCaLam(txtMaCa.Text.Trim())) { LoadCaLam(); }
            };
        }

        private void ResetVP()
        {
            txtMaVP.Clear();
            txtTenVP.Clear();
            numTienPhat.Value = 0;
            txtMaVP.Focus();
        }

        private void LoadAllDanhMuc()
        {
            LoadViPham();
            LoadTacGia();
            LoadNXB();
            LoadCaLam();
        }

        private void LoadViPham()
        {
            try
            {
                dgvViPham.DataSource = _bll.GetViPham();
                if (dgvViPham.Columns.Contains("MaVP")) dgvViPham.Columns["MaVP"].HeaderText = "Mã Vi Phạm";
                if (dgvViPham.Columns.Contains("TenVP")) dgvViPham.Columns["TenVP"].HeaderText = "Tên Lỗi Vi Phạm";
                if (dgvViPham.Columns.Contains("TienPhat"))
                {
                    dgvViPham.Columns["TienPhat"].HeaderText = "Tiền Phạt (VNĐ)";
                    dgvViPham.Columns["TienPhat"].DefaultCellStyle.Format = "N0";
                }
            }
            catch { }
        }

        private void LoadTacGia()
        {
            try
            {
                dgvTacGia.DataSource = _bll.GetTacGia();
                if (dgvTacGia.Columns.Contains("MaTG")) dgvTacGia.Columns["MaTG"].HeaderText = "Mã Tác Giả";
                if (dgvTacGia.Columns.Contains("TenTG")) dgvTacGia.Columns["TenTG"].HeaderText = "Tên Tác Giả";
                if (dgvTacGia.Columns.Contains("NgaySinh")) dgvTacGia.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                if (dgvTacGia.Columns.Contains("GioiTinh")) dgvTacGia.Columns["GioiTinh"].HeaderText = "Giới Tính";
                if (dgvTacGia.Columns.Contains("DiaChi")) dgvTacGia.Columns["DiaChi"].HeaderText = "Quê Quán / Địa Chỉ";
            }
            catch { }
        }

        private void LoadNXB()
        {
            try
            {
                dgvNXB.DataSource = _bll.GetNXB();
                if (dgvNXB.Columns.Contains("MaNXB")) dgvNXB.Columns["MaNXB"].HeaderText = "Mã NXB";
                if (dgvNXB.Columns.Contains("TenNXB")) dgvNXB.Columns["TenNXB"].HeaderText = "Tên Nhà Xuất Bản";
                if (dgvNXB.Columns.Contains("DiaChi")) dgvNXB.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                if (dgvNXB.Columns.Contains("DienThoai")) dgvNXB.Columns["DienThoai"].HeaderText = "Điện Thoại";
            }
            catch { }
        }

        private void LoadCaLam()
        {
            try
            {
                dgvCaLam.DataSource = _bll.GetCaLam();
                if (dgvCaLam.Columns.Contains("MaCa")) dgvCaLam.Columns["MaCa"].HeaderText = "Mã Ca";
                if (dgvCaLam.Columns.Contains("TenCa")) dgvCaLam.Columns["TenCa"].HeaderText = "Tên Ca Làm Việc";
            }
            catch { }
        }
    }
}
