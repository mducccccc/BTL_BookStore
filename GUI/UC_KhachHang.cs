using System;
using System.Drawing;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;

namespace BTL.GUI
{
    public class UC_KhachHang : UserControl
    {
        private readonly KhachHangBLL _bll = new();

        private TextBox txtMaKH = null!;
        private TextBox txtTenKH = null!;
        private DateTimePicker dtpNgaySinh = null!;
        private ComboBox cboGioiTinh = null!;
        private TextBox txtDiaChi = null!;
        private TextBox txtTimKiem = null!;

        private Button btnThem = null!;
        private Button btnSua = null!;
        private Button btnXoa = null!;
        private Button btnLamMoi = null!;

        private DataGridView dgvKhachHang = null!;
        private Label lblTotal = null!;

        public UC_KhachHang()
        {
            InitializeComponent();
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
                Text = "QUẢN LÝ KHÁCH HÀNG",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = UITheme.Navy,
                AutoSize = true,
                Location = new Point(18, 16)
            };

            lblTotal = new Label
            {
                Text = "Tổng: 0 khách hàng",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Italic),
                ForeColor = Color.FromArgb(100, 116, 139),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                AutoSize = true,
                Location = new Point(800, 20)
            };

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblTotal);

            // 2. Input & Actions Panel
            var pnlInput = new Panel
            {
                Dock = DockStyle.Top,
                Height = 180,
                Padding = new Padding(20),
                BackColor = Color.White
            };

            // Labels & Inputs
            var lblMa = new Label { Text = "Mã khách hàng:", Location = new Point(25, 20), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtMaKH = new TextBox { Location = new Point(140, 16), Width = 150, ReadOnly = true, BackColor = Color.FromArgb(241, 245, 249) };

            var btnAutoMa = new Button
            {
                Text = "Tự sinh",
                Location = new Point(295, 15),
                Width = 75,
                Height = 27,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(226, 232, 240),
                Cursor = Cursors.Hand
            };
            btnAutoMa.Click += (s, e) => txtMaKH.Text = _bll.GenerateNewMaKH();

            var lblTen = new Label { Text = "Tên khách hàng:", Location = new Point(410, 20), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtTenKH = new TextBox { Location = new Point(530, 16), Width = 300 };

            var lblNgaySinh = new Label { Text = "Ngày sinh:", Location = new Point(25, 60), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            dtpNgaySinh = new DateTimePicker { Location = new Point(140, 56), Width = 150, Format = DateTimePickerFormat.Short };

            var lblGioiTinh = new Label { Text = "Giới tính:", Location = new Point(410, 60), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboGioiTinh = new ComboBox { Location = new Point(530, 56), Width = 120, DropDownStyle = ComboBoxStyle.DropDownList };
            cboGioiTinh.Items.AddRange(new object[] { "Nam (M)", "Nữ (F)" });
            cboGioiTinh.SelectedIndex = 0;

            var lblDiaChi = new Label { Text = "Địa chỉ:", Location = new Point(25, 100), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtDiaChi = new TextBox { Location = new Point(140, 96), Width = 690 };

            // Buttons
            btnThem = CreateButton("Thêm mới", UITheme.Blue, 25, 138);
            btnSua = CreateButton("Cập nhật", UITheme.Navy, 145, 138);
            btnXoa = CreateButton("Xóa", Color.FromArgb(220, 38, 38), 265, 138);
            btnLamMoi = CreateButton("Làm mới", UITheme.Muted, 385, 138);

            // Tìm kiếm
            var lblTim = new Label { Text = " Tìm kiếm:", Location = new Point(550, 142), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtTimKiem = new TextBox { Location = new Point(635, 138), Width = 195 };
            txtTimKiem.TextChanged += (s, e) => FilterData();

            pnlInput.Controls.AddRange(new Control[]
            {
                lblMa, txtMaKH, btnAutoMa, lblTen, txtTenKH,
                lblNgaySinh, dtpNgaySinh, lblGioiTinh, cboGioiTinh,
                lblDiaChi, txtDiaChi,
                btnThem, btnSua, btnXoa, btnLamMoi,
                lblTim, txtTimKiem
            });

            // 3. DataGridView Panel
            var pnlGrid = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 15, 20, 20)
            };

            dgvKhachHang = new DataGridView
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
            UITheme.StyleDataGridView(dgvKhachHang);

            dgvKhachHang.CellClick += DgvKhachHang_CellClick;

            pnlGrid.Controls.Add(dgvKhachHang);

            this.Controls.Add(pnlGrid);
            this.Controls.Add(pnlInput);
            this.Controls.Add(pnlTop);

            // Gán sự kiện
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
