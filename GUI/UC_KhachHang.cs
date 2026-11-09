using System;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;

namespace BTL.GUI
{
    public partial class UC_KhachHang : UserControl
    {
        private readonly KhachHangBLL _bll = new();

        public UC_KhachHang()
        {
            InitializeComponent();
            UITheme.StyleDataGridView(dgvKhachHang);

            btnAutoMa.Click += (s, e) => txtMaKH.Text = _bll.GenerateNewMaKH();
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += (s, e) => ResetInputs();
            txtTimKiem.TextChanged += (s, e) => FilterData();
            dgvKhachHang.CellClick += DgvKhachHang_CellClick;

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var dt = _bll.GetAll();
                dgvKhachHang.DataSource = dt;

                if (dgvKhachHang.Columns.Contains("MaKH")) dgvKhachHang.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
                if (dgvKhachHang.Columns.Contains("TenKH")) dgvKhachHang.Columns["TenKH"].HeaderText = "Họ và Tên";
                if (dgvKhachHang.Columns.Contains("NgaySinh")) dgvKhachHang.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                if (dgvKhachHang.Columns.Contains("GioiTinh")) dgvKhachHang.Columns["GioiTinh"].HeaderText = "Giới Tính";
                if (dgvKhachHang.Columns.Contains("DiaChi")) dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa Chỉ";

                lblTotal.Text = $"Tổng: {dt.Rows.Count} khách hàng";
                ResetInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterData()
        {
            try
            {
                var dt = dgvKhachHang.DataSource as System.Data.DataTable;
                if (dt != null)
                {
                    string filter = txtTimKiem.Text.Trim().Replace("'", "''");
                    if (string.IsNullOrEmpty(filter))
                    {
                        dt.DefaultView.RowFilter = string.Empty;
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = $"TenKH LIKE '%{filter}%' OR MaKH LIKE '%{filter}%' OR DiaChi LIKE '%{filter}%'";
                    }
                }
            }
            catch { }
        }

        private void DgvKhachHang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvKhachHang.Rows.Count) return;
            var row = dgvKhachHang.Rows[e.RowIndex];

            txtMaKH.Text = row.Cells["MaKH"].Value?.ToString()?.Trim() ?? string.Empty;
            txtTenKH.Text = row.Cells["TenKH"].Value?.ToString() ?? string.Empty;

            if (row.Cells["NgaySinh"].Value != DBNull.Value && row.Cells["NgaySinh"].Value != null)
            {
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            }

            string gt = row.Cells["GioiTinh"].Value?.ToString()?.Trim() ?? "M";
            cboGioiTinh.SelectedIndex = (gt == "F") ? 1 : 0;

            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? string.Empty;
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            var kh = new KhachHangDTO
            {
                MaKH = txtMaKH.Text.Trim(),
                TenKH = txtTenKH.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                GioiTinh = cboGioiTinh.SelectedIndex == 1 ? "F" : "M",
                DiaChi = txtDiaChi.Text.Trim()
            };

            if (_bll.Insert(kh, out string error))
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var kh = new KhachHangDTO
            {
                MaKH = txtMaKH.Text.Trim(),
                TenKH = txtTenKH.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                GioiTinh = cboGioiTinh.SelectedIndex == 1 ? "F" : "M",
                DiaChi = txtDiaChi.Text.Trim()
            };

            if (_bll.Update(kh, out string error))
            {
                MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khách hàng [{txtTenKH.Text}] (Mã: {txtMaKH.Text}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_bll.Delete(txtMaKH.Text.Trim(), out string error))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtMaKH.Text = _bll.GenerateNewMaKH();
            txtTenKH.Clear();
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);
            cboGioiTinh.SelectedIndex = 0;
            txtDiaChi.Clear();
            txtTimKiem.Clear();
            txtTenKH.Focus();
        }
    }
}
