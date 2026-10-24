using System;
using System.Drawing;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;

namespace BTL.GUI
{
    public class UC_NhanVien : UserControl
    {
        private readonly NhanVienBLL _bll = new();

        private TextBox txtMaNV = null!;
        private TextBox txtTenNV = null!;
        private NumericUpDown numNamSinh = null!;
        private ComboBox cboGioiTinh = null!;
        private TextBox txtDienThoai = null!;
        private TextBox txtDiaChi = null!;
        private NumericUpDown numLuongThang = null!;
        private TextBox txtTimKiem = null!;

        private Button btnThem = null!;
        private Button btnSua = null!;
        private Button btnXoa = null!;
        private Button btnLamMoi = null!;

        private DataGridView dgvNhanVien = null!;
        private Label lblTotal = null!;

        public UC_NhanVien()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            // 1. Top Panel
            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(20, 12, 20, 10),
                BackColor = Color.White
            };

            var lblTitle = new Label
            {
                Text = "👔 DANH MỤC NHÂN VIÊN",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                AutoSize = true,
                Location = new Point(18, 16)
            };

            lblTotal = new Label
            {
                Text = "Tổng: 0 nhân viên",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Italic),
                ForeColor = Color.FromArgb(100, 116, 139),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                AutoSize = true,
                Location = new Point(800, 20)
            };

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblTotal);

            // 2. Input Panel
            var pnlInput = new Panel
            {
                Dock = DockStyle.Top,
                Height = 210,
                Padding = new Padding(20),
                BackColor = Color.White
            };

            // Line 1: Mã NV + Tên NV
            var lblMa = new Label { Text = "Mã nhân viên:", Location = new Point(25, 20), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtMaNV = new TextBox { Location = new Point(135, 16), Width = 140, ReadOnly = true, BackColor = Color.FromArgb(241, 245, 249) };

            var btnAutoMa = new Button
            {
                Text = "⚡ Tự sinh",
                Location = new Point(280, 15),
                Width = 75,
                Height = 27,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(226, 232, 240),
                Cursor = Cursors.Hand
            };
            btnAutoMa.Click += (s, e) => txtMaNV.Text = _bll.GenerateNewMaNV();

            var lblTen = new Label { Text = "Tên nhân viên:", Location = new Point(390, 20), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtTenNV = new TextBox { Location = new Point(500, 16), Width = 310 };

            // Line 2: Năm sinh + Giới tính + Điện thoại
            var lblNamSinh = new Label { Text = "Năm sinh:", Location = new Point(25, 60), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            numNamSinh = new NumericUpDown { Location = new Point(135, 56), Width = 140, Minimum = 1950, Maximum = 2050, Value = 1998 };

            var lblGioiTinh = new Label { Text = "Giới tính:", Location = new Point(310, 60), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboGioiTinh = new ComboBox { Location = new Point(380, 56), Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
            cboGioiTinh.Items.AddRange(new object[] { "Nam (M)", "Nữ (F)" });
            cboGioiTinh.SelectedIndex = 0;

            var lblPhone = new Label { Text = "Điện thoại (Mật khẩu):", Location = new Point(500, 60), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtDienThoai = new TextBox { Location = new Point(660, 56), Width = 150 };

            // Line 3: Lương tháng + Địa chỉ
            var lblLuong = new Label { Text = "Lương tháng:", Location = new Point(25, 100), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            numLuongThang = new NumericUpDown { Location = new Point(135, 96), Width = 140, Minimum = 0, Maximum = 1000000000, Increment = 500000, ThousandsSeparator = true, Value = 7000000 };

            var lblDiaChi = new Label { Text = "Địa chỉ:", Location = new Point(310, 100), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtDiaChi = new TextBox { Location = new Point(380, 96), Width = 430 };

            // Line 4: Buttons
            btnThem = CreateButton("➕ Thêm mới", Color.FromArgb(16, 185, 129), 25, 150);
            btnSua = CreateButton("✏️ Cập nhật", Color.FromArgb(37, 99, 235), 145, 150);
            btnXoa = CreateButton("🗑️ Xóa", Color.FromArgb(239, 68, 68), 265, 150);
            btnLamMoi = CreateButton("🔄 Làm mới", Color.FromArgb(100, 116, 139), 385, 150);

            var lblTim = new Label { Text = "🔍 Tìm kiếm:", Location = new Point(540, 154), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtTimKiem = new TextBox { Location = new Point(625, 150), Width = 185 };
            txtTimKiem.TextChanged += (s, e) => FilterData();

            pnlInput.Controls.AddRange(new Control[]
            {
                lblMa, txtMaNV, btnAutoMa, lblTen, txtTenNV,
                lblNamSinh, numNamSinh, lblGioiTinh, cboGioiTinh, lblPhone, txtDienThoai,
                lblLuong, numLuongThang, lblDiaChi, txtDiaChi,
                btnThem, btnSua, btnXoa, btnLamMoi,
                lblTim, txtTimKiem
            });

            // 3. Grid Panel
            var pnlGrid = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 15, 20, 20)
            };

            dgvNhanVien = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                EnableHeadersVisualStyles = false
            };
            dgvNhanVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvNhanVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvNhanVien.ColumnHeadersHeight = 36;
            dgvNhanVien.RowTemplate.Height = 32;

            dgvNhanVien.CellClick += DgvNhanVien_CellClick;

            pnlGrid.Controls.Add(dgvNhanVien);

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
