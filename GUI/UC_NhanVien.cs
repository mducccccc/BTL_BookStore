using System;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;

namespace BTL.GUI
{
    public partial class UC_NhanVien : UserControl
    {
        private readonly NhanVienBLL _bll = new();

        public UC_NhanVien()
        {
            InitializeComponent();
            UITheme.StyleDataGridView(dgvNhanVien);

            btnAutoMa.Click += (s, e) => txtMaNV.Text = _bll.GenerateNewMaNV();
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += (s, e) => ResetInputs();
            txtTimKiem.TextChanged += (s, e) => FilterData();
            dgvNhanVien.CellClick += DgvNhanVien_CellClick;

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var dt = _bll.GetAll();
                dgvNhanVien.DataSource = dt;

                if (dgvNhanVien.Columns.Contains("MaNV")) dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
                if (dgvNhanVien.Columns.Contains("TenNV")) dgvNhanVien.Columns["TenNV"].HeaderText = "Họ và Tên";
                if (dgvNhanVien.Columns.Contains("NamSinh")) dgvNhanVien.Columns["NamSinh"].HeaderText = "Năm Sinh";
                if (dgvNhanVien.Columns.Contains("GioiTinh")) dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
                if (dgvNhanVien.Columns.Contains("DiaChi")) dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                if (dgvNhanVien.Columns.Contains("DienThoai")) dgvNhanVien.Columns["DienThoai"].HeaderText = "Điện Thoại";
                if (dgvNhanVien.Columns.Contains("LuongThang"))
                {
                    dgvNhanVien.Columns["LuongThang"].HeaderText = "Lương Tháng (VNĐ)";
                    dgvNhanVien.Columns["LuongThang"].DefaultCellStyle.Format = "N0";
                }

                lblTotal.Text = $"Tổng: {dt.Rows.Count} nhân viên";
                ResetInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterData()
        {
            try
            {
                var dt = dgvNhanVien.DataSource as System.Data.DataTable;
                if (dt != null)
                {
                    string filter = txtTimKiem.Text.Trim().Replace("'", "''");
                    if (string.IsNullOrEmpty(filter))
                    {
                        dt.DefaultView.RowFilter = string.Empty;
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = $"TenNV LIKE '%{filter}%' OR MaNV LIKE '%{filter}%' OR DienThoai LIKE '%{filter}%'";
                    }
                }
            }
            catch { }
        }

        private void DgvNhanVien_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvNhanVien.Rows.Count) return;
            var row = dgvNhanVien.Rows[e.RowIndex];

            txtMaNV.Text = row.Cells["MaNV"].Value?.ToString()?.Trim() ?? string.Empty;
            txtTenNV.Text = row.Cells["TenNV"].Value?.ToString() ?? string.Empty;

            if (row.Cells["NamSinh"].Value != DBNull.Value && row.Cells["NamSinh"].Value != null)
            {
                numNamSinh.Value = Convert.ToDecimal(row.Cells["NamSinh"].Value);
            }

            string gt = row.Cells["GioiTinh"].Value?.ToString()?.Trim() ?? "M";
            cboGioiTinh.SelectedIndex = (gt == "F") ? 1 : 0;

            txtDienThoai.Text = row.Cells["DienThoai"].Value?.ToString() ?? string.Empty;
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? string.Empty;

            if (row.Cells["LuongThang"].Value != DBNull.Value && row.Cells["LuongThang"].Value != null)
            {
                numLuongThang.Value = Convert.ToDecimal(row.Cells["LuongThang"].Value);
            }
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            var nv = new NhanVienDTO
            {
                MaNV = txtMaNV.Text.Trim(),
                TenNV = txtTenNV.Text.Trim(),
                NamSinh = (int)numNamSinh.Value,
                GioiTinh = cboGioiTinh.SelectedIndex == 1 ? "F" : "M",
                DiaChi = txtDiaChi.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                LuongThang = numLuongThang.Value
            };

            if (_bll.Insert(nv, out string error))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nv = new NhanVienDTO
            {
                MaNV = txtMaNV.Text.Trim(),
                TenNV = txtTenNV.Text.Trim(),
                NamSinh = (int)numNamSinh.Value,
                GioiTinh = cboGioiTinh.SelectedIndex == 1 ? "F" : "M",
                DiaChi = txtDiaChi.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                LuongThang = numLuongThang.Value
            };

            if (_bll.Update(nv, out string error))
            {
                MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhân viên [{txtTenNV.Text}] (Mã: {txtMaNV.Text}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_bll.Delete(txtMaNV.Text.Trim(), out string error))
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại: " + error, "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ResetInputs()
        {
            txtMaNV.Text = _bll.GenerateNewMaNV();
            txtTenNV.Clear();
            numNamSinh.Value = 1998;
            cboGioiTinh.SelectedIndex = 0;
            txtDienThoai.Clear();
            numLuongThang.Value = 7000000;
            txtDiaChi.Clear();
            txtTimKiem.Clear();
            txtTenNV.Focus();
        }
    }
}
