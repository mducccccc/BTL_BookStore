using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;

namespace BTL.GUI
{
    public partial class UC_Sach : UserControl
    {
        private readonly SachBLL _sachBLL = new();
        private readonly DanhMucBLL _dmBLL = new();

        public UC_Sach()
        {
            InitializeComponent();
            UITheme.StyleDataGridView(dgvSach);

            // Hook up events
            btnAutoMa.Click += (s, e) => txtMaSach.Text = _sachBLL.GenerateNewMaSach();
            btnChonAnh.Click += BtnChonAnh_Click;
            btnXoaAnh.Click += (s, e) => { txtAnh.Clear(); if (picAnh.Image != null) { picAnh.Image.Dispose(); picAnh.Image = null; } };
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += (s, e) => ResetInputs();
            btnXuatExcel.Click += (s, e) => ExportExcelHelper.Export(dgvSach, "DanhSach_SachTruyen", "Danh Sách Kho Sách Truyện");
            txtTimKiem.TextChanged += (s, e) => FilterData();
            dgvSach.CellClick += DgvSach_CellClick;
            dgvSach.CellFormatting += DgvSach_CellFormatting;

            LoadComboBoxes();
            LoadData();
        }

        private void LoadComboBoxes()
        {
            try
            {
                cboLoaiSach.DataSource = _dmBLL.GetLoaiSach();
                cboLoaiSach.DisplayMember = "TenLoai";
                cboLoaiSach.ValueMember = "MaLoai";

                cboLinhVuc.DataSource = _dmBLL.GetLinhVuc();
                cboLinhVuc.DisplayMember = "TenLV";
                cboLinhVuc.ValueMember = "MaLV";

                cboTacGia.DataSource = _dmBLL.GetTacGia();
                cboTacGia.DisplayMember = "TenTG";
                cboTacGia.ValueMember = "MaTG";

                cboNXB.DataSource = _dmBLL.GetNXB();
                cboNXB.DisplayMember = "TenNXB";
                cboNXB.ValueMember = "MaNXB";

                cboNgonNgu.DataSource = _dmBLL.GetNgonNgu();
                cboNgonNgu.DisplayMember = "TenNN";
                cboNgonNgu.ValueMember = "MaNN";

                cboTinhTrang.DataSource = _dmBLL.GetTinhTrang();
                cboTinhTrang.DisplayMember = "TenTT";
                cboTinhTrang.ValueMember = "MaTT";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load Combobox error: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                var dt = _sachBLL.GetAll();
                dgvSach.DataSource = dt;

                if (dgvSach.Columns.Contains("MaSach")) dgvSach.Columns["MaSach"].HeaderText = "Mã Sách";
                if (dgvSach.Columns.Contains("TenSach")) dgvSach.Columns["TenSach"].HeaderText = "Tên Sách";
                if (dgvSach.Columns.Contains("TenLoai")) dgvSach.Columns["TenLoai"].HeaderText = "Loại Sách";
                if (dgvSach.Columns.Contains("TenLV")) dgvSach.Columns["TenLV"].HeaderText = "Lĩnh Vực";
                if (dgvSach.Columns.Contains("TenTG")) dgvSach.Columns["TenTG"].HeaderText = "Tác Giả";
                if (dgvSach.Columns.Contains("TenNXB")) dgvSach.Columns["TenNXB"].HeaderText = "NXB";
                if (dgvSach.Columns.Contains("SoLuong")) dgvSach.Columns["SoLuong"].HeaderText = "Tồn Kho";
                if (dgvSach.Columns.Contains("DonGiaThue"))
                {
                    dgvSach.Columns["DonGiaThue"].HeaderText = "Giá Thuê (đ/ngày)";
                    dgvSach.Columns["DonGiaThue"].DefaultCellStyle.Format = "N0";
                }
                if (dgvSach.Columns.Contains("GiaSach"))
                {
                    dgvSach.Columns["GiaSach"].HeaderText = "Giá Bìa (đ)";
                    dgvSach.Columns["GiaSach"].DefaultCellStyle.Format = "N0";
                }
                if (dgvSach.Columns.Contains("TenTT")) dgvSach.Columns["TenTT"].HeaderText = "Tình Trạng";

                string[] hideCols = { "MaLoai", "MaLV", "MaTG", "MaNXB", "MaNN", "MaTT", "TenNN", "SoTrang", "Anh", "GhiChu" };
                foreach (var c in hideCols)
                {
                    if (dgvSach.Columns.Contains(c)) dgvSach.Columns[c].Visible = false;
                }

                lblTotal.Text = $"Tổng: {dt.Rows.Count} đầu sách";
                ResetInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvSach_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSach.Columns[e.ColumnIndex].Name == "SoLuong" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int sl) && sl <= 0)
                {
                    e.CellStyle!.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        private void FilterData()
        {
            try
            {
                var dt = dgvSach.DataSource as DataTable;
                if (dt != null)
                {
                    string f = txtTimKiem.Text.Trim().Replace("'", "''");
                    if (string.IsNullOrEmpty(f))
                    {
                        dt.DefaultView.RowFilter = string.Empty;
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = $"TenSach LIKE '%{f}%' OR MaSach LIKE '%{f}%' OR TenTG LIKE '%{f}%' OR TenLV LIKE '%{f}%'";
                    }
                }
            }
            catch { }
        }

        private void DgvSach_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvSach.Rows.Count) return;
            var r = dgvSach.Rows[e.RowIndex];

            txtMaSach.Text = r.Cells["MaSach"].Value?.ToString()?.Trim() ?? string.Empty;
            txtTenSach.Text = r.Cells["TenSach"].Value?.ToString() ?? string.Empty;

            if (r.Cells["MaLoai"].Value != DBNull.Value) cboLoaiSach.SelectedValue = r.Cells["MaLoai"].Value.ToString()?.Trim() ?? string.Empty;
            if (r.Cells["MaLV"].Value != DBNull.Value) cboLinhVuc.SelectedValue = r.Cells["MaLV"].Value.ToString()?.Trim() ?? string.Empty;
            if (r.Cells["MaTG"].Value != DBNull.Value) cboTacGia.SelectedValue = r.Cells["MaTG"].Value.ToString()?.Trim() ?? string.Empty;
            if (r.Cells["MaNXB"].Value != DBNull.Value) cboNXB.SelectedValue = r.Cells["MaNXB"].Value.ToString()?.Trim() ?? string.Empty;
            if (r.Cells["MaNN"].Value != DBNull.Value) cboNgonNgu.SelectedValue = r.Cells["MaNN"].Value.ToString()?.Trim() ?? string.Empty;
            if (r.Cells["MaTT"].Value != DBNull.Value) cboTinhTrang.SelectedValue = r.Cells["MaTT"].Value.ToString()?.Trim() ?? string.Empty;

            if (r.Cells["SoTrang"].Value != DBNull.Value && r.Cells["SoTrang"].Value != null)
                numSoTrang.Value = Convert.ToDecimal(r.Cells["SoTrang"].Value);

            if (r.Cells["SoLuong"].Value != DBNull.Value && r.Cells["SoLuong"].Value != null)
                numSoLuong.Value = Convert.ToDecimal(r.Cells["SoLuong"].Value);

            if (r.Cells["GiaSach"].Value != DBNull.Value && r.Cells["GiaSach"].Value != null)
                numGiaSach.Value = Convert.ToDecimal(r.Cells["GiaSach"].Value);

            if (r.Cells["DonGiaThue"].Value != DBNull.Value && r.Cells["DonGiaThue"].Value != null)
                numDonGiaThue.Value = Convert.ToDecimal(r.Cells["DonGiaThue"].Value);

            txtGhiChu.Text = r.Cells["GhiChu"].Value?.ToString() ?? string.Empty;

            string anhPath = r.Cells["Anh"].Value?.ToString() ?? string.Empty;
            txtAnh.Text = anhPath;
            LoadBookImage(anhPath);
        }

        private void LoadBookImage(string path)
        {
            if (picAnh.Image != null)
            {
                picAnh.Image.Dispose();
                picAnh.Image = null;
            }

            if (!string.IsNullOrWhiteSpace(path))
            {
                string fullPath = Path.IsPathRooted(path) ? path : Path.Combine(Application.StartupPath, path);
                if (File.Exists(fullPath))
                {
                    try
                    {
                        byte[] bytes = File.ReadAllBytes(fullPath);
                        using var ms = new MemoryStream(bytes);
                        picAnh.Image = Image.FromStream(ms);
                        return;
                    }
                    catch { }
                }
            }
            picAnh.Image = null;
        }

        private void BtnChonAnh_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Tệp hình ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Chọn ảnh bìa sách truyện"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string imagesDir = Path.Combine(Application.StartupPath, "Images");
                    if (!Directory.Exists(imagesDir)) Directory.CreateDirectory(imagesDir);

                    string ext = Path.GetExtension(ofd.FileName);
                    string newFileName = (string.IsNullOrWhiteSpace(txtMaSach.Text) ? Guid.NewGuid().ToString("N") : txtMaSach.Text.Trim()) + ext;
                    string destPath = Path.Combine(imagesDir, newFileName);

                    File.Copy(ofd.FileName, destPath, true);

                    txtAnh.Text = Path.Combine("Images", newFileName);
                    LoadBookImage(destPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lưu ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            var s = GetInputData();
            if (_sachBLL.Insert(s, out string error))
            {
                MessageBox.Show("Thêm sách mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng chọn sách cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var s = GetInputData();
            if (_sachBLL.Update(s, out string error))
            {
                MessageBox.Show("Cập nhật sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng chọn sách cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sách [{txtTenSach.Text}] (Mã: {txtMaSach.Text}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_sachBLL.Delete(txtMaSach.Text.Trim(), out string error))
                {
                    MessageBox.Show("Xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại: " + error, "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private SachDTO GetInputData()
        {
            return new SachDTO
            {
                MaSach = txtMaSach.Text.Trim(),
                TenSach = txtTenSach.Text.Trim(),
                MaLoai = cboLoaiSach.SelectedValue?.ToString() ?? string.Empty,
                MaLV = cboLinhVuc.SelectedValue?.ToString() ?? string.Empty,
                MaTG = cboTacGia.SelectedValue?.ToString() ?? string.Empty,
                MaNXB = cboNXB.SelectedValue?.ToString() ?? string.Empty,
                MaNN = cboNgonNgu.SelectedValue?.ToString() ?? string.Empty,
                MaTT = cboTinhTrang.SelectedValue?.ToString() ?? string.Empty,
                SoTrang = (int)numSoTrang.Value,
                SoLuong = (int)numSoLuong.Value,
                GiaSach = numGiaSach.Value,
                DonGiaThue = numDonGiaThue.Value,
                Anh = string.IsNullOrWhiteSpace(txtAnh.Text) ? null : txtAnh.Text.Trim(),
                GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim()
            };
        }

        private void ResetInputs()
        {
            txtMaSach.Text = _sachBLL.GenerateNewMaSach();
            txtTenSach.Clear();
            if (cboLoaiSach.Items.Count > 0) cboLoaiSach.SelectedIndex = 0;
            if (cboLinhVuc.Items.Count > 0) cboLinhVuc.SelectedIndex = 0;
            if (cboTacGia.Items.Count > 0) cboTacGia.SelectedIndex = 0;
            if (cboNXB.Items.Count > 0) cboNXB.SelectedIndex = 0;
            if (cboNgonNgu.Items.Count > 0) cboNgonNgu.SelectedIndex = 0;
            if (cboTinhTrang.Items.Count > 0) cboTinhTrang.SelectedIndex = 0;
            numSoTrang.Value = 150;
            numSoLuong.Value = 5;
            numGiaSach.Value = 50000;
            numDonGiaThue.Value = 3000;
            txtGhiChu.Clear();
            txtAnh.Clear();
            if (picAnh.Image != null)
            {
                picAnh.Image.Dispose();
                picAnh.Image = null;
            }
            txtTimKiem.Clear();
            txtTenSach.Focus();
        }
    }
}
