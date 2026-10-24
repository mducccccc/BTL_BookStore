using System;
using System.Drawing;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;

namespace BTL.GUI
{
    public class UC_DanhMuc : UserControl
    {
        private readonly DanhMucBLL _bll = new();

        private TabControl tabDanhMuc = null!;

        #region Controls Vi Phạm
        private TextBox txtMaVP = null!;
        private TextBox txtTenVP = null!;
        private NumericUpDown numTienPhat = null!;
        private DataGridView dgvViPham = null!;
        #endregion

        #region Controls Tác Giả
        private TextBox txtMaTG = null!;
        private TextBox txtTenTG = null!;
        private DateTimePicker dtpNgaySinhTG = null!;
        private ComboBox cboGioiTinhTG = null!;
        private TextBox txtDiaChiTG = null!;
        private DataGridView dgvTacGia = null!;
        #endregion

        #region Controls NXB
        private TextBox txtMaNXB = null!;
        private TextBox txtTenNXB = null!;
        private TextBox txtDiaChiNXB = null!;
        private TextBox txtPhoneNXB = null!;
        private DataGridView dgvNXB = null!;
        #endregion

        #region Controls Ca Làm
        private TextBox txtMaCa = null!;
        private TextBox txtTenCa = null!;
        private DataGridView dgvCaLam = null!;
        #endregion

        public UC_DanhMuc()
        {
            InitializeComponent();
            LoadAllDanhMuc();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            tabDanhMuc = new TabControl
            {
                Dock = DockStyle.Fill,
                Padding = new Point(16, 8)
            };

            // Build các Tab
            var tabVP = BuildTabViPham();
            var tabTG = BuildTabTacGia();
            var tabNXB = BuildTabNXB();
            var tabCa = BuildTabCaLam();

            tabDanhMuc.TabPages.AddRange(new TabPage[] { tabVP, tabTG, tabNXB, tabCa });
            this.Controls.Add(tabDanhMuc);
        }

        #region 1. TAB VI PHẠM & TIỀN PHẠT
        private TabPage BuildTabViPham()
        {
            var tab = new TabPage("⚠️ Vi Phạm & Tiền Phạt") { BackColor = Color.White };

            var pnlTop = new Panel { Dock = DockStyle.Top, Height = 130, Padding = new Padding(20) };
            var lblMa = new Label { Text = "Mã vi phạm:", Location = new Point(20, 20), AutoSize = true };
            txtMaVP = new TextBox { Location = new Point(120, 16), Width = 120 };

            var lblTen = new Label { Text = "Tên vi phạm:", Location = new Point(270, 20), AutoSize = true };
            txtTenVP = new TextBox { Location = new Point(370, 16), Width = 300 };

            var lblTien = new Label { Text = "Tiền phạt:", Location = new Point(20, 60), AutoSize = true };
            numTienPhat = new NumericUpDown { Location = new Point(120, 56), Width = 150, Maximum = 10000000, Increment = 5000, ThousandsSeparator = true };

            var btnThem = CreateSmallBtn("➕ Thêm", Color.FromArgb(16, 185, 129), 300, 54);
            var btnSua = CreateSmallBtn("✏️ Sửa", Color.FromArgb(37, 99, 235), 390, 54);
            var btnXoa = CreateSmallBtn("🗑️ Xóa", Color.FromArgb(239, 68, 68), 480, 54);
            var btnMoi = CreateSmallBtn("🔄 Mới", Color.FromArgb(100, 116, 139), 570, 54);

            pnlTop.Controls.AddRange(new Control[] { lblMa, txtMaVP, lblTen, txtTenVP, lblTien, numTienPhat, btnThem, btnSua, btnXoa, btnMoi });

            dgvViPham = CreateGrid();
            dgvViPham.CellClick += (s, e) =>
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvViPham.Rows.Count) return;
                var r = dgvViPham.Rows[e.RowIndex];
                txtMaVP.Text = r.Cells["MaVP"].Value?.ToString()?.Trim() ?? string.Empty;
                txtTenVP.Text = r.Cells["TenVP"].Value?.ToString() ?? string.Empty;
                if (r.Cells["TienPhat"].Value != DBNull.Value) numTienPhat.Value = Convert.ToDecimal(r.Cells["TienPhat"].Value);
            };

            btnThem.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtMaVP.Text) || string.IsNullOrWhiteSpace(txtTenVP.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ Mã và Tên vi phạm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var vp = new ViPhamDTO { MaVP = txtMaVP.Text.Trim(), TenVP = txtTenVP.Text.Trim(), TienPhat = numTienPhat.Value };
                if (_bll.InsertViPham(vp)) { LoadViPham(); ResetVP(); }
            };

            btnSua.Click += (s, e) =>
            {
                var vp = new ViPhamDTO { MaVP = txtMaVP.Text.Trim(), TenVP = txtTenVP.Text.Trim(), TienPhat = numTienPhat.Value };
                if (_bll.UpdateViPham(vp)) { LoadViPham(); ResetVP(); }
            };

            btnXoa.Click += (s, e) =>
            {
                if (_bll.DeleteViPham(txtMaVP.Text.Trim())) { LoadViPham(); ResetVP(); }
            };

            btnMoi.Click += (s, e) => ResetVP();

            tab.Controls.Add(dgvViPham);
            tab.Controls.Add(pnlTop);
            return tab;
        }

        private void ResetVP()
        {
            txtMaVP.Clear();
            txtTenVP.Clear();
            numTienPhat.Value = 0;
            txtMaVP.Focus();
        }
        #endregion

        #region 2. TAB TÁC GIẢ
        private TabPage BuildTabTacGia()
        {
            var tab = new TabPage("✍️ Tác Giả") { BackColor = Color.White };

            var pnlTop = new Panel { Dock = DockStyle.Top, Height = 140, Padding = new Padding(20) };
            var lblMa = new Label { Text = "Mã TG:", Location = new Point(20, 20), AutoSize = true };
            txtMaTG = new TextBox { Location = new Point(80, 16), Width = 110 };

            var lblTen = new Label { Text = "Tên TG:", Location = new Point(220, 20), AutoSize = true };
            txtTenTG = new TextBox { Location = new Point(290, 16), Width = 200 };

            var lblGT = new Label { Text = "Giới tính:", Location = new Point(510, 20), AutoSize = true };
            cboGioiTinhTG = new ComboBox { Location = new Point(580, 16), Width = 90, DropDownStyle = ComboBoxStyle.DropDownList };
            cboGioiTinhTG.Items.AddRange(new object[] { "Nam (M)", "Nữ (F)" });
            cboGioiTinhTG.SelectedIndex = 0;

            var lblNS = new Label { Text = "Ngày sinh:", Location = new Point(20, 60), AutoSize = true };
            dtpNgaySinhTG = new DateTimePicker { Location = new Point(80, 56), Width = 130, Format = DateTimePickerFormat.Short };

            var lblDC = new Label { Text = "Địa chỉ:", Location = new Point(220, 60), AutoSize = true };
            txtDiaChiTG = new TextBox { Location = new Point(290, 56), Width = 380 };

            var btnThem = CreateSmallBtn("➕ Thêm", Color.FromArgb(16, 185, 129), 20, 98);
            var btnSua = CreateSmallBtn("✏️ Sửa", Color.FromArgb(37, 99, 235), 110, 98);
            var btnXoa = CreateSmallBtn("🗑️ Xóa", Color.FromArgb(239, 68, 68), 200, 98);
            var btnMoi = CreateSmallBtn("🔄 Mới", Color.FromArgb(100, 116, 139), 290, 98);

            pnlTop.Controls.AddRange(new Control[] { lblMa, txtMaTG, lblTen, txtTenTG, lblGT, cboGioiTinhTG, lblNS, dtpNgaySinhTG, lblDC, txtDiaChiTG, btnThem, btnSua, btnXoa, btnMoi });

            dgvTacGia = CreateGrid();
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

            btnThem.Click += (s, e) =>
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

            btnSua.Click += (s, e) =>
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

            btnXoa.Click += (s, e) =>
            {
                if (_bll.DeleteTacGia(txtMaTG.Text.Trim())) { LoadTacGia(); }
            };

            btnMoi.Click += (s, e) => { txtMaTG.Clear(); txtTenTG.Clear(); txtDiaChiTG.Clear(); txtMaTG.Focus(); };

            tab.Controls.Add(dgvTacGia);
            tab.Controls.Add(pnlTop);
            return tab;
        }
        #endregion

        #region 3. TAB NHÀ XUẤT BẢN
        private TabPage BuildTabNXB()
        {
            var tab = new TabPage("🏢 Nhà Xuất Bản") { BackColor = Color.White };

            var pnlTop = new Panel { Dock = DockStyle.Top, Height = 130, Padding = new Padding(20) };
            var lblMa = new Label { Text = "Mã NXB:", Location = new Point(20, 20), AutoSize = true };
            txtMaNXB = new TextBox { Location = new Point(90, 16), Width = 110 };

            var lblTen = new Label { Text = "Tên NXB:", Location = new Point(230, 20), AutoSize = true };
            txtTenNXB = new TextBox { Location = new Point(310, 16), Width = 230 };

            var lblPhone = new Label { Text = "Điện thoại:", Location = new Point(560, 20), AutoSize = true };
            txtPhoneNXB = new TextBox { Location = new Point(640, 16), Width = 140 };

            var lblDC = new Label { Text = "Địa chỉ:", Location = new Point(20, 60), AutoSize = true };
            txtDiaChiNXB = new TextBox { Location = new Point(90, 56), Width = 450 };

            var btnThem = CreateSmallBtn("➕ Thêm", Color.FromArgb(16, 185, 129), 560, 54);
            var btnSua = CreateSmallBtn("✏️ Sửa", Color.FromArgb(37, 99, 235), 645, 54);
            var btnXoa = CreateSmallBtn("🗑️ Xóa", Color.FromArgb(239, 68, 68), 730, 54);

            pnlTop.Controls.AddRange(new Control[] { lblMa, txtMaNXB, lblTen, txtTenNXB, lblPhone, txtPhoneNXB, lblDC, txtDiaChiNXB, btnThem, btnSua, btnXoa });

            dgvNXB = CreateGrid();
            dgvNXB.CellClick += (s, e) =>
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvNXB.Rows.Count) return;
                var r = dgvNXB.Rows[e.RowIndex];
                txtMaNXB.Text = r.Cells["MaNXB"].Value?.ToString()?.Trim() ?? string.Empty;
                txtTenNXB.Text = r.Cells["TenNXB"].Value?.ToString() ?? string.Empty;
                txtDiaChiNXB.Text = r.Cells["DiaChi"].Value?.ToString() ?? string.Empty;
                txtPhoneNXB.Text = r.Cells["DienThoai"].Value?.ToString() ?? string.Empty;
            };

            btnThem.Click += (s, e) =>
            {
                var nxb = new NXBDTO { MaNXB = txtMaNXB.Text.Trim(), TenNXB = txtTenNXB.Text.Trim(), DiaChi = txtDiaChiNXB.Text.Trim(), DienThoai = txtPhoneNXB.Text.Trim() };
                if (_bll.InsertNXB(nxb)) { LoadNXB(); }
            };

            btnSua.Click += (s, e) =>
            {
                var nxb = new NXBDTO { MaNXB = txtMaNXB.Text.Trim(), TenNXB = txtTenNXB.Text.Trim(), DiaChi = txtDiaChiNXB.Text.Trim(), DienThoai = txtPhoneNXB.Text.Trim() };
                if (_bll.UpdateNXB(nxb)) { LoadNXB(); }
            };

            btnXoa.Click += (s, e) =>
            {
                if (_bll.DeleteNXB(txtMaNXB.Text.Trim())) { LoadNXB(); }
            };

            tab.Controls.Add(dgvNXB);
            tab.Controls.Add(pnlTop);
            return tab;
        }
        #endregion

        #region 4. TAB CA LÀM VIỆC
        private TabPage BuildTabCaLam()
        {
            var tab = new TabPage("⏰ Ca Làm Việc") { BackColor = Color.White };

            var pnlTop = new Panel { Dock = DockStyle.Top, Height = 100, Padding = new Padding(20) };
            var lblMa = new Label { Text = "Mã ca:", Location = new Point(20, 20), AutoSize = true };
            txtMaCa = new TextBox { Location = new Point(90, 16), Width = 100 };

            var lblTen = new Label { Text = "Tên ca:", Location = new Point(220, 20), AutoSize = true };
            txtTenCa = new TextBox { Location = new Point(290, 16), Width = 250 };

            var btnThem = CreateSmallBtn("➕ Thêm", Color.FromArgb(16, 185, 129), 560, 14);
            var btnSua = CreateSmallBtn("✏️ Sửa", Color.FromArgb(37, 99, 235), 645, 14);
            var btnXoa = CreateSmallBtn("🗑️ Xóa", Color.FromArgb(239, 68, 68), 730, 14);

            pnlTop.Controls.AddRange(new Control[] { lblMa, txtMaCa, lblTen, txtTenCa, btnThem, btnSua, btnXoa });

            dgvCaLam = CreateGrid();
            dgvCaLam.CellClick += (s, e) =>
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvCaLam.Rows.Count) return;
                var r = dgvCaLam.Rows[e.RowIndex];
                txtMaCa.Text = r.Cells["MaCa"].Value?.ToString()?.Trim() ?? string.Empty;
                txtTenCa.Text = r.Cells["TenCa"].Value?.ToString() ?? string.Empty;
            };

            btnThem.Click += (s, e) =>
            {
                var ca = new CaLamDTO { MaCa = txtMaCa.Text.Trim(), TenCa = txtTenCa.Text.Trim() };
                if (_bll.InsertCaLam(ca)) { LoadCaLam(); }
            };

            btnSua.Click += (s, e) =>
            {
                var ca = new CaLamDTO { MaCa = txtMaCa.Text.Trim(), TenCa = txtTenCa.Text.Trim() };
                if (_bll.UpdateCaLam(ca)) { LoadCaLam(); }
            };

            btnXoa.Click += (s, e) =>
            {
                if (_bll.DeleteCaLam(txtMaCa.Text.Trim())) { LoadCaLam(); }
            };

            tab.Controls.Add(dgvCaLam);
            tab.Controls.Add(pnlTop);
            return tab;
        }
        #endregion

        #region HELPERS
        private Button CreateSmallBtn(string text, Color bg, int left, int top)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(left, top),
                Size = new Size(80, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = bg,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private DataGridView CreateGrid()
        {
            var dgv = new DataGridView
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
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 36;
            dgv.RowTemplate.Height = 30;
            return dgv;
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
        #endregion
    }
}
