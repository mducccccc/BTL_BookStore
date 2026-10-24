using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BTL.BLL;

namespace BTL.GUI
{
    public class UC_TimKiem : UserControl
    {
        private readonly SachBLL _sachBLL = new();
        private readonly NhanVienBLL _nvBLL = new();
        private readonly DanhMucBLL _dmBLL = new();

        private TabControl tabSearch = null!;

        #region Controls Tìm Kiếm Sách (Yêu cầu 5)
        private TextBox txtTimTenSach = null!;
        private ComboBox cboTimLinhVuc = null!;
        private ComboBox cboTimTacGia = null!;
        private ComboBox cboTimNXB = null!;
        private Button btnTimSach = null!;
        private Button btnDatLaiSach = null!;
        private DataGridView dgvKetQuaSach = null!;
        private Label lblDemSach = null!;
        private PictureBox picPreviewSach = null!;
        #endregion

        #region Controls Tìm Kiếm Nhân Viên (Yêu cầu 6)
        private TextBox txtTimTenNV = null!;
        private ComboBox cboTimCaLam = null!;
        private ComboBox cboTimGioiTinh = null!;
        private Button btnTimNV = null!;
        private Button btnDatLaiNV = null!;
        private DataGridView dgvKetQuaNV = null!;
        private Label lblDemNV = null!;
        #endregion

        public UC_TimKiem()
        {
            InitializeComponent();
            LoadLookupData();
            ThucHienTimSach();
            ThucHienTimNV();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            tabSearch = new TabControl
            {
                Dock = DockStyle.Fill,
                Padding = new Point(16, 8)
            };

            var tabSach = BuildTabTimSach();
            var tabNV = BuildTabTimNhanVien();

            tabSearch.TabPages.AddRange(new TabPage[] { tabSach, tabNV });
            this.Controls.Add(tabSearch);
        }

        #region 1. TAB TÌM KIẾM SÁCH TRUYỆN (YÊU CẦU 5)
        private TabPage BuildTabTimSach()
        {
            var tab = new TabPage("Tra Cứu Sách Truyện (Yêu cầu 5)") { BackColor = Color.White };

            // Panel bộ lọc phía trên
            var pnlFilter = new Panel
            {
                Dock = DockStyle.Top,
                Height = 135,
                Padding = new Padding(20, 15, 20, 10),
                BackColor = Color.White
            };

            var lblHeader = new Label
            {
                Text = "BỘ LỌC ĐA TIÊU CHÍ SÁCH TRUYỆN (Tên sách, Lĩnh vực, Tác giả, Nhà xuất bản)",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(37, 99, 235),
                Dock = DockStyle.Top,
                Height = 25
            };

            // Hàng 1: Tên sách & Lĩnh vực
            var lblTen = new Label { Text = "Tên sách:", Location = new Point(20, 42), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtTimTenSach = new TextBox { Location = new Point(90, 39), Width = 230, PlaceholderText = "Nhập tên sách cần tìm..." };
            txtTimTenSach.TextChanged += (s, e) => ThucHienTimSach();

            var lblLV = new Label { Text = "Lĩnh vực:", Location = new Point(350, 42), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboTimLinhVuc = new ComboBox { Location = new Point(420, 39), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cboTimLinhVuc.SelectedIndexChanged += (s, e) => ThucHienTimSach();

            // Hàng 2: Tác giả & NXB
            var lblTG = new Label { Text = "Tác giả:", Location = new Point(20, 80), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboTimTacGia = new ComboBox { Location = new Point(90, 77), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList };
            cboTimTacGia.SelectedIndexChanged += (s, e) => ThucHienTimSach();

            var lblNXB = new Label { Text = "Nhà XB:", Location = new Point(350, 80), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboTimNXB = new ComboBox { Location = new Point(420, 77), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cboTimNXB.SelectedIndexChanged += (s, e) => ThucHienTimSach();

            // Nút bấm
            btnTimSach = new Button
            {
                Text = "Tìm kiếm",
                Location = new Point(650, 45),
                Size = new Size(100, 32),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnTimSach.FlatAppearance.BorderSize = 0;
            btnTimSach.Click += (s, e) => ThucHienTimSach();

            btnDatLaiSach = new Button
            {
                Text = "Đặt lại",
                Location = new Point(650, 82),
                Size = new Size(100, 28),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(226, 232, 240),
                ForeColor = Color.FromArgb(51, 65, 85),
                Font = new Font("Segoe UI", 8.5F),
                Cursor = Cursors.Hand
            };
            btnDatLaiSach.FlatAppearance.BorderSize = 0;
            btnDatLaiSach.Click += (s, e) =>
            {
                txtTimTenSach.Clear();
                if (cboTimLinhVuc.Items.Count > 0) cboTimLinhVuc.SelectedIndex = 0;
                if (cboTimTacGia.Items.Count > 0) cboTimTacGia.SelectedIndex = 0;
                if (cboTimNXB.Items.Count > 0) cboTimNXB.SelectedIndex = 0;
                ThucHienTimSach();
            };

            lblDemSach = new Label
            {
                Text = "Tìm thấy: 0 cuốn sách",
                Location = new Point(780, 52),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(16, 185, 129)
            };

            pnlFilter.Controls.AddRange(new Control[]
            {
                lblHeader, lblTen, txtTimTenSach, lblLV, cboTimLinhVuc,
                lblTG, cboTimTacGia, lblNXB, cboTimNXB,
                btnTimSach, btnDatLaiSach, lblDemSach
            });

            // Container chứa bảng kết quả & PictureBox preview bìa sách
            var pnlGridContainer = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15) };

            var pnlPicPreview = new Panel
            {
                Dock = DockStyle.Right,
                Width = 150,
                Padding = new Padding(10, 0, 0, 0)
            };

            var lblPicTitle = new Label { Text = "Ảnh bìa:", Dock = DockStyle.Top, Height = 25, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(71, 85, 105) };
            picPreviewSach = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(248, 250, 252)
            };
            pnlPicPreview.Controls.Add(picPreviewSach);
            pnlPicPreview.Controls.Add(lblPicTitle);

            dgvKetQuaSach = new DataGridView
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
                EnableHeadersVisualStyles = false,
                Font = new Font("Segoe UI", 9F)
            };
            dgvKetQuaSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvKetQuaSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvKetQuaSach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvKetQuaSach.ColumnHeadersHeight = 34;
            dgvKetQuaSach.RowTemplate.Height = 28;
            dgvKetQuaSach.CellClick += DgvKetQuaSach_CellClick;

            pnlGridContainer.Controls.Add(dgvKetQuaSach);
            pnlGridContainer.Controls.Add(pnlPicPreview);

            tab.Controls.Add(pnlGridContainer);
            tab.Controls.Add(pnlFilter);
            return tab;
        }

        private void DgvKetQuaSach_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvKetQuaSach.Rows.Count) return;
            string path = dgvKetQuaSach.Rows[e.RowIndex].Cells["Anh"].Value?.ToString() ?? string.Empty;

            if (picPreviewSach.Image != null)
            {
                picPreviewSach.Image.Dispose();
                picPreviewSach.Image = null;
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
                        picPreviewSach.Image = Image.FromStream(ms);
                        return;
                    }
                    catch { }
                }
            }
            picPreviewSach.Image = null;
        }

        private void ThucHienTimSach()
        {
            try
            {
                string? ten = string.IsNullOrWhiteSpace(txtTimTenSach?.Text) ? null : txtTimTenSach.Text.Trim();

                string? maLV = cboTimLinhVuc?.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maLV)) maLV = null;

                string? maTG = cboTimTacGia?.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maTG)) maTG = null;

                string? maNXB = cboTimNXB?.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maNXB)) maNXB = null;

                var dt = _sachBLL.TimKiemSach(ten, maLV, maTG, maNXB);
                dgvKetQuaSach.DataSource = dt;

                if (dgvKetQuaSach.Columns.Contains("MaSach")) dgvKetQuaSach.Columns["MaSach"].HeaderText = "Mã Sách";
                if (dgvKetQuaSach.Columns.Contains("TenSach")) dgvKetQuaSach.Columns["TenSach"].HeaderText = "Tên Sách";
                if (dgvKetQuaSach.Columns.Contains("TenLV")) dgvKetQuaSach.Columns["TenLV"].HeaderText = "Lĩnh Vực";
                if (dgvKetQuaSach.Columns.Contains("TenTG")) dgvKetQuaSach.Columns["TenTG"].HeaderText = "Tác Giả";
                if (dgvKetQuaSach.Columns.Contains("TenNXB")) dgvKetQuaSach.Columns["TenNXB"].HeaderText = "Nhà Xuất Bản";
                if (dgvKetQuaSach.Columns.Contains("SoLuong")) dgvKetQuaSach.Columns["SoLuong"].HeaderText = "Tồn Kho";
                if (dgvKetQuaSach.Columns.Contains("DonGiaThue"))
                {
                    dgvKetQuaSach.Columns["DonGiaThue"].HeaderText = "Giá Thuê (đ/ngày)";
                    dgvKetQuaSach.Columns["DonGiaThue"].DefaultCellStyle.Format = "N0";
                }
                if (dgvKetQuaSach.Columns.Contains("TenTT")) dgvKetQuaSach.Columns["TenTT"].HeaderText = "Tình Trạng";
                if (dgvKetQuaSach.Columns.Contains("Anh")) dgvKetQuaSach.Columns["Anh"].Visible = false;

                lblDemSach.Text = $"Tìm thấy: {dt.Rows.Count} cuốn sách";

                if (dt.Rows.Count > 0)
                {
                    DgvKetQuaSach_CellClick(null, new DataGridViewCellEventArgs(0, 0));
                }
                else
                {
                    if (picPreviewSach.Image != null)
                    {
                        picPreviewSach.Image.Dispose();
                        picPreviewSach.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Tim kiem sach error: " + ex.Message);
            }
        }
        #endregion

        #region 2. TAB TÌM KIẾM NHÂN VIÊN (YÊU CẦU 6)
        private TabPage BuildTabTimNhanVien()
        {
            var tab = new TabPage("Tra Cứu Nhân Viên (Yêu cầu 6)") { BackColor = Color.White };

            var pnlFilter = new Panel
            {
                Dock = DockStyle.Top,
                Height = 115,
                Padding = new Padding(20, 15, 20, 10),
                BackColor = Color.White
            };

            var lblHeader = new Label
            {
                Text = "BỘ LỌC ĐA TIÊU CHÍ NHÂN VIÊN (Tên nhân viên, Ca làm việc, Giới tính)",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(37, 99, 235),
                Dock = DockStyle.Top,
                Height = 25
            };

            var lblTen = new Label { Text = "Tên nhân viên:", Location = new Point(20, 48), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtTimTenNV = new TextBox { Location = new Point(125, 45), Width = 210, PlaceholderText = "Nhập tên nhân viên..." };
            txtTimTenNV.TextChanged += (s, e) => ThucHienTimNV();

            var lblCa = new Label { Text = "Ca làm việc:", Location = new Point(360, 48), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboTimCaLam = new ComboBox { Location = new Point(445, 45), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
            cboTimCaLam.SelectedIndexChanged += (s, e) => ThucHienTimNV();

            var lblGT = new Label { Text = "Giới tính:", Location = new Point(650, 48), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboTimGioiTinh = new ComboBox { Location = new Point(720, 45), Width = 110, DropDownStyle = ComboBoxStyle.DropDownList };
            cboTimGioiTinh.Items.AddRange(new object[] { "Tất cả", "Nam (M)", "Nữ (F)" });
            cboTimGioiTinh.SelectedIndex = 0;
            cboTimGioiTinh.SelectedIndexChanged += (s, e) => ThucHienTimNV();

            btnTimNV = new Button
            {
                Text = "Tìm kiếm",
                Location = new Point(850, 43),
                Size = new Size(95, 32),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnTimNV.FlatAppearance.BorderSize = 0;
            btnTimNV.Click += (s, e) => ThucHienTimNV();

            btnDatLaiNV = new Button
            {
                Text = "Đặt lại",
                Location = new Point(955, 43),
                Size = new Size(80, 32),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(226, 232, 240),
                ForeColor = Color.FromArgb(51, 65, 85),
                Font = new Font("Segoe UI", 8.5F),
                Cursor = Cursors.Hand
            };
            btnDatLaiNV.FlatAppearance.BorderSize = 0;
            btnDatLaiNV.Click += (s, e) =>
            {
                txtTimTenNV.Clear();
                if (cboTimCaLam.Items.Count > 0) cboTimCaLam.SelectedIndex = 0;
                cboTimGioiTinh.SelectedIndex = 0;
                ThucHienTimNV();
            };

            lblDemNV = new Label
            {
                Text = "Tìm thấy: 0 nhân viên",
                Location = new Point(20, 85),
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(16, 185, 129)
            };

            pnlFilter.Controls.AddRange(new Control[]
            {
                lblHeader, lblTen, txtTimTenNV, lblCa, cboTimCaLam,
                lblGT, cboTimGioiTinh, btnTimNV, btnDatLaiNV, lblDemNV
            });

            var pnlGridContainer = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15) };

            dgvKetQuaNV = new DataGridView
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
                EnableHeadersVisualStyles = false,
                Font = new Font("Segoe UI", 9F)
            };
            dgvKetQuaNV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvKetQuaNV.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvKetQuaNV.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvKetQuaNV.ColumnHeadersHeight = 34;
            dgvKetQuaNV.RowTemplate.Height = 28;

            pnlGridContainer.Controls.Add(dgvKetQuaNV);

            tab.Controls.Add(pnlGridContainer);
            tab.Controls.Add(pnlFilter);
            return tab;
        }

        private void ThucHienTimNV()
        {
            try
            {
                string? ten = string.IsNullOrWhiteSpace(txtTimTenNV?.Text) ? null : txtTimTenNV.Text.Trim();

                string? maCa = cboTimCaLam?.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maCa)) maCa = null;

                string? gioiTinh = null;
                if (cboTimGioiTinh?.SelectedIndex == 1) gioiTinh = "M";
                else if (cboTimGioiTinh?.SelectedIndex == 2) gioiTinh = "F";

                var dt = _nvBLL.TimKiemNhanVien(ten, maCa, gioiTinh);
                dgvKetQuaNV.DataSource = dt;

                if (dgvKetQuaNV.Columns.Contains("MaNV")) dgvKetQuaNV.Columns["MaNV"].HeaderText = "Mã NV";
                if (dgvKetQuaNV.Columns.Contains("TenNV")) dgvKetQuaNV.Columns["TenNV"].HeaderText = "Họ và Tên";
                if (dgvKetQuaNV.Columns.Contains("NamSinh")) dgvKetQuaNV.Columns["NamSinh"].HeaderText = "Năm Sinh";
                if (dgvKetQuaNV.Columns.Contains("GioiTinh")) dgvKetQuaNV.Columns["GioiTinh"].HeaderText = "Giới Tính";
                if (dgvKetQuaNV.Columns.Contains("DiaChi")) dgvKetQuaNV.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                if (dgvKetQuaNV.Columns.Contains("DienThoai")) dgvKetQuaNV.Columns["DienThoai"].HeaderText = "Điện Thoại";
                if (dgvKetQuaNV.Columns.Contains("LuongThang"))
                {
                    dgvKetQuaNV.Columns["LuongThang"].HeaderText = "Lương Tháng (VNĐ)";
                    dgvKetQuaNV.Columns["LuongThang"].DefaultCellStyle.Format = "N0";
                }

                lblDemNV.Text = $"Tìm thấy: {dt.Rows.Count} nhân viên";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Tim kiem nhan vien error: " + ex.Message);
            }
        }
        #endregion

        #region LOAD DỮ LIỆU BỘ LỌC
        private void LoadLookupData()
        {
            try
            {
                // 1. Lĩnh vực
                var dtLV = _dmBLL.GetLinhVuc().Copy();
                var rLV = dtLV.NewRow();
                rLV["MaLV"] = "";
                rLV["TenLV"] = "--- Tất cả lĩnh vực ---";
                dtLV.Rows.InsertAt(rLV, 0);
                cboTimLinhVuc.DataSource = dtLV;
                cboTimLinhVuc.DisplayMember = "TenLV";
                cboTimLinhVuc.ValueMember = "MaLV";

                // 2. Tác giả
                var dtTG = _dmBLL.GetTacGia().Copy();
                var rTG = dtTG.NewRow();
                rTG["MaTG"] = "";
                rTG["TenTG"] = "--- Tất cả tác giả ---";
                dtTG.Rows.InsertAt(rTG, 0);
                cboTimTacGia.DataSource = dtTG;
                cboTimTacGia.DisplayMember = "TenTG";
                cboTimTacGia.ValueMember = "MaTG";

                // 3. NXB
                var dtNXB = _dmBLL.GetNXB().Copy();
                var rNXB = dtNXB.NewRow();
                rNXB["MaNXB"] = "";
                rNXB["TenNXB"] = "--- Tất cả nhà xuất bản ---";
                dtNXB.Rows.InsertAt(rNXB, 0);
                cboTimNXB.DataSource = dtNXB;
                cboTimNXB.DisplayMember = "TenNXB";
                cboTimNXB.ValueMember = "MaNXB";

                // 4. Ca làm việc
                var dtCa = _dmBLL.GetCaLam().Copy();
                var rCa = dtCa.NewRow();
                rCa["MaCa"] = "";
                rCa["TenCa"] = "--- Tất cả ca trực ---";
                dtCa.Rows.InsertAt(rCa, 0);
                cboTimCaLam.DataSource = dtCa;
                cboTimCaLam.DisplayMember = "TenCa";
                cboTimCaLam.ValueMember = "MaCa";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load lookup error: " + ex.Message);
            }
        }
        #endregion
    }
}
