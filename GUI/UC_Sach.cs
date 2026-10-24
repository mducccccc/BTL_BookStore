using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;

namespace BTL.GUI
{
    public class UC_Sach : UserControl
    {
        private readonly SachBLL _sachBLL = new();
        private readonly DanhMucBLL _dmBLL = new();

        #region UI Controls
        private TextBox txtMaSach = null!;
        private TextBox txtTenSach = null!;
        private ComboBox cboLoaiSach = null!;
        private ComboBox cboLinhVuc = null!;
        private ComboBox cboTacGia = null!;
        private ComboBox cboNXB = null!;
        private ComboBox cboNgonNgu = null!;
        private ComboBox cboTinhTrang = null!;
        private NumericUpDown numSoTrang = null!;
        private NumericUpDown numSoLuong = null!;
        private NumericUpDown numGiaSach = null!;
        private NumericUpDown numDonGiaThue = null!;
        private TextBox txtGhiChu = null!;
        private TextBox txtAnh = null!;
        private PictureBox picAnh = null!;

        private Button btnThem = null!;
        private Button btnSua = null!;
        private Button btnXoa = null!;
        private Button btnLamMoi = null!;
        private Button btnChonAnh = null!;
        private Button btnXoaAnh = null!;

        private TextBox txtTimKiem = null!;
        private DataGridView dgvSach = null!;
        private Label lblTotal = null!;
        #endregion

        public UC_Sach()
        {
            InitializeComponent();
            LoadComboBoxes();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = UITheme.Page;
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            // 1. Top Title Panel
            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(20, 12, 20, 10),
                BackColor = Color.White
            };

            var lblTitle = new Label
            {
                Text = "QUẢN LÝ SÁCH TRUYỆN",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = UITheme.Navy,
                AutoSize = true,
                Location = new Point(18, 16)
            };

            lblTotal = new Label
            {
                Text = "Tổng: 0 đầu sách",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Italic),
                ForeColor = Color.FromArgb(100, 116, 139),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                AutoSize = true,
                Location = new Point(820, 20)
            };

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblTotal);

            // 2. Input Form Panel
            var pnlInput = new Panel
            {
                Dock = DockStyle.Top,
                Height = 275,
                Padding = new Padding(20, 15, 20, 10),
                BackColor = Color.White
            };

            // ===== CỘT 1 =====
            var lblMa = new Label { Text = "Mã sách:", Location = new Point(20, 15), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtMaSach = new TextBox { Location = new Point(100, 12), Width = 110, ReadOnly = true, BackColor = Color.FromArgb(241, 245, 249) };

            var btnAutoMa = new Button
            {
                Text = "Tự sinh",
                Location = new Point(215, 11),
                Width = 70,
                Height = 27,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(226, 232, 240),
                Cursor = Cursors.Hand
            };
            btnAutoMa.Click += (s, e) => txtMaSach.Text = _sachBLL.GenerateNewMaSach();

            var lblTen = new Label { Text = "Tên sách:", Location = new Point(20, 50), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtTenSach = new TextBox { Location = new Point(100, 47), Width = 185 };

            var lblLoai = new Label { Text = "Loại sách:", Location = new Point(20, 85), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboLoaiSach = new ComboBox { Location = new Point(100, 82), Width = 185, DropDownStyle = ComboBoxStyle.DropDownList };

            var lblLV = new Label { Text = "Lĩnh vực:", Location = new Point(20, 120), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboLinhVuc = new ComboBox { Location = new Point(100, 117), Width = 185, DropDownStyle = ComboBoxStyle.DropDownList };

            var lblTG = new Label { Text = "Tác giả:", Location = new Point(20, 155), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboTacGia = new ComboBox { Location = new Point(100, 152), Width = 185, DropDownStyle = ComboBoxStyle.DropDownList };

            // ===== CỘT 2 =====
            var lblNXB = new Label { Text = "Nhà XB:", Location = new Point(310, 15), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboNXB = new ComboBox { Location = new Point(395, 12), Width = 175, DropDownStyle = ComboBoxStyle.DropDownList };

            var lblNN = new Label { Text = "Ngôn ngữ:", Location = new Point(310, 50), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboNgonNgu = new ComboBox { Location = new Point(395, 47), Width = 175, DropDownStyle = ComboBoxStyle.DropDownList };

            var lblTT = new Label { Text = "Tình trạng:", Location = new Point(310, 85), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboTinhTrang = new ComboBox { Location = new Point(395, 82), Width = 175, DropDownStyle = ComboBoxStyle.DropDownList };

            var lblSoTrang = new Label { Text = "Số trang:", Location = new Point(310, 120), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            numSoTrang = new NumericUpDown { Location = new Point(395, 117), Width = 175, Minimum = 1, Maximum = 10000, Value = 150 };

            var lblSoLuong = new Label { Text = "Số lượng:", Location = new Point(310, 155), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
            numSoLuong = new NumericUpDown { Location = new Point(395, 152), Width = 175, Minimum = 0, Maximum = 10000, Value = 5 };

            // ===== CỘT 3 =====
            var lblGiaSach = new Label { Text = "Giá bìa (đ):", Location = new Point(595, 15), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            numGiaSach = new NumericUpDown { Location = new Point(690, 12), Width = 140, Minimum = 0, Maximum = 10000000, Increment = 5000, ThousandsSeparator = true, Value = 50000 };

            var lblDonGiaThue = new Label { Text = "Giá thuê/Day:", Location = new Point(595, 50), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
            numDonGiaThue = new NumericUpDown { Location = new Point(690, 47), Width = 140, Minimum = 0, Maximum = 1000000, Increment = 1000, ThousandsSeparator = true, Value = 3000 };

            var lblGhiChu = new Label { Text = "Ghi chú:", Location = new Point(595, 85), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtGhiChu = new TextBox { Location = new Point(690, 82), Width = 140, Height = 60, Multiline = true };

            txtAnh = new TextBox { Location = new Point(690, 152), Width = 140, ReadOnly = true, PlaceholderText = "Đường dẫn ảnh" };

            // ===== CỘT 4: ẢNH BÌA =====
            var pnlPicBorder = new Panel
            {
                Location = new Point(855, 10),
                Size = new Size(130, 170),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(248, 250, 252)
            };

            picAnh = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(248, 250, 252)
            };
            pnlPicBorder.Controls.Add(picAnh);

            btnChonAnh = new Button
            {
                Text = "Chọn ảnh",
                Location = new Point(855, 185),
                Size = new Size(65, 26),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(226, 232, 240),
                Font = new Font("Segoe UI", 8F),
                Cursor = Cursors.Hand
            };
            btnChonAnh.Click += BtnChonAnh_Click;

            btnXoaAnh = new Button
            {
                Text = "Bỏ ảnh",
                Location = new Point(922, 185),
                Size = new Size(63, 26),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(241, 245, 249),
                Font = new Font("Segoe UI", 8F),
                Cursor = Cursors.Hand
            };
            btnXoaAnh.Click += (s, e) => { txtAnh.Clear(); picAnh.Image = null; };

            // ===== HÀNG DƯỚI: NÚT THAO TÁC & TÌM KIẾM =====
            btnThem = CreateButton("Thêm mới", UITheme.Blue, 20, 225);
            btnSua = CreateButton("Cập nhật", UITheme.Navy, 140, 225);
            btnXoa = CreateButton("Xóa sách", Color.FromArgb(220, 38, 38), 260, 225);
            btnLamMoi = CreateButton("Làm mới", UITheme.Muted, 380, 225);

            var btnXuatExcel = new Button
            {
                Text = "Xuất Excel",
                Location = new Point(500, 225),
                Size = new Size(105, 32),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = UITheme.Navy,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXuatExcel.FlatAppearance.BorderColor = UITheme.Border;
            btnXuatExcel.FlatAppearance.BorderSize = 1;
            btnXuatExcel.Click += (s, e) => ExportExcelHelper.Export(dgvSach, "DanhSach_SachTruyen", "Danh Sách Kho Sách Truyện");

            var lblTim = new Label { Text = "Tìm nhanh:", Location = new Point(620, 230), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtTimKiem = new TextBox { Location = new Point(700, 226), Width = 180, PlaceholderText = "Nhập tên sách, tác giả..." };
            txtTimKiem.TextChanged += (s, e) => FilterData();

            pnlInput.Controls.AddRange(new Control[]
            {
                lblMa, txtMaSach, btnAutoMa, lblTen, txtTenSach, lblLoai, cboLoaiSach, lblLV, cboLinhVuc, lblTG, cboTacGia,
                lblNXB, cboNXB, lblNN, cboNgonNgu, lblTT, cboTinhTrang, lblSoTrang, numSoTrang, lblSoLuong, numSoLuong,
                lblGiaSach, numGiaSach, lblDonGiaThue, numDonGiaThue, lblGhiChu, txtGhiChu, txtAnh,
                pnlPicBorder, btnChonAnh, btnXoaAnh,
                btnThem, btnSua, btnXoa, btnLamMoi, btnXuatExcel,
                lblTim, txtTimKiem
            });

            // 3. DataGridView Panel
            var pnlGrid = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 10, 20, 20)
            };

            dgvSach = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            UITheme.StyleDataGridView(dgvSach);

            dgvSach.CellClick += DgvSach_CellClick;
            dgvSach.CellFormatting += DgvSach_CellFormatting;

            pnlGrid.Controls.Add(dgvSach);

            this.Controls.Add(pnlGrid);
            this.Controls.Add(pnlInput);
            this.Controls.Add(pnlTop);

            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += (s, e) => ResetInputs();
        }

        private Button CreateButton(string text, Color bg, int left, int top)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(left, top),
                Size = new Size(110, 32),
                FlatStyle = FlatStyle.Flat,
                BackColor = bg,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Loại sách
                cboLoaiSach.DataSource = _dmBLL.GetLoaiSach();
                cboLoaiSach.DisplayMember = "TenLoai";
                cboLoaiSach.ValueMember = "MaLoai";

                // Lĩnh vực
                cboLinhVuc.DataSource = _dmBLL.GetLinhVuc();
                cboLinhVuc.DisplayMember = "TenLV";
                cboLinhVuc.ValueMember = "MaLV";

                // Tác giả
                cboTacGia.DataSource = _dmBLL.GetTacGia();
                cboTacGia.DisplayMember = "TenTG";
                cboTacGia.ValueMember = "MaTG";

                // NXB
                cboNXB.DataSource = _dmBLL.GetNXB();
                cboNXB.DisplayMember = "TenNXB";
                cboNXB.ValueMember = "MaNXB";

                // Ngôn ngữ
                cboNgonNgu.DataSource = _dmBLL.GetNgonNgu();
                cboNgonNgu.DisplayMember = "TenNN";
                cboNgonNgu.ValueMember = "MaNN";

                // Tình trạng
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

                // Ẩn các cột mã nội bộ
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
                        // Đọc qua byte array để không khóa file ảnh trên ổ cứng
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

                    // Lưu đường dẫn tương đối
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
