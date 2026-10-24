using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;

namespace BTL.GUI
{
    public class UC_ThueSach : UserControl
    {
        private readonly ThueTraBLL _thueBLL = new();
        private readonly SachBLL _sachBLL = new();
        private readonly KhachHangBLL _khBLL = new();
        private readonly NhanVienBLL _nvBLL = new();
        private readonly DanhMucBLL _dmBLL = new();

        #region Controls Thông Tin Phiếu Thuê
        private TextBox txtMaThue = null!;
        private ComboBox cboKhachHang = null!;
        private ComboBox cboNhanVien = null!;
        private ComboBox cboCaLam = null!;
        private DateTimePicker dtpNgayThue = null!;
        private NumericUpDown numTienCoc = null!;
        #endregion

        #region Controls Chọn Sách (Yêu cầu 1)
        private ComboBox cboSach = null!;
        private NumericUpDown numSoLuongThue = null!;
        private Label lblTonKho = null!;
        private Label lblDonGia = null!;
        private Button btnThemSach = null!;
        private Button btnXoaSach = null!;
        #endregion

        #region Grids & Buttons
        private DataGridView dgvGioSach = null!;
        private DataGridView dgvLichSuThue = null!;
        private Label lblTongSoCuon = null!;
        private Button btnLapPhieu = null!;
        private Button btnHuyPhieu = null!;
        private TextBox txtTimLichSu = null!;
        #endregion

        // Danh sách giỏ sách tạm thời
        private readonly List<ChiTietThueDTO> _gioSach = new();
        private DataTable _dtSachConHang = new();

        public UC_ThueSach()
        {
            InitializeComponent();
            LoadLookupData();
            LoadSachConHang();
            LoadLichSuThue();
            ResetPhieuMoi();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(241, 245, 249);
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
                Text = "LẬP PHIẾU THUÊ SÁCH",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                AutoSize = true,
                Location = new Point(18, 16)
            };

            var lblSubtitle = new Label
            {
                Text = "Yêu cầu 1: Chỉ chọn sách tồn kho > 0  |  Yêu cầu 2: Tự động trừ kho khi thuê",
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                ForeColor = Color.FromArgb(37, 99, 235),
                AutoSize = true,
                Location = new Point(270, 20)
            };

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblSubtitle);

            // 2. Main Body Container
            var pnlBody = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(241, 245, 249)
            };

            // ===== PANEL 1: LẬP PHIẾU THUÊ MỚI (BÊN TRÁI) =====
            var pnlLapPhieu = new Panel
            {
                Dock = DockStyle.Left,
                Width = 630,
                BackColor = Color.White,
                Padding = new Padding(15)
            };

            // Group 1: Thông tin chung
            var grpInfo = new GroupBox
            {
                Text = "1. Thông tin phiếu thuê",
                Dock = DockStyle.Top,
                Height = 150,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59)
            };

            var lblMa = new Label { Text = "Mã phiếu:", Location = new Point(15, 26), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            txtMaThue = new TextBox { Location = new Point(95, 23), Width = 110, ReadOnly = true, BackColor = Color.FromArgb(241, 245, 249), Font = new Font("Segoe UI", 9F) };

            var btnAutoMa = new Button
            {
                Text = "Tự sinh",
                Location = new Point(210, 22),
                Width = 65,
                Height = 25,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(226, 232, 240),
                Font = new Font("Segoe UI", 8.5F),
                Cursor = Cursors.Hand
            };
            btnAutoMa.Click += (s, e) => txtMaThue.Text = _thueBLL.GenerateNewMaThue();

            var lblKH = new Label { Text = "Khách hàng:", Location = new Point(290, 26), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            cboKhachHang = new ComboBox { Location = new Point(375, 23), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F) };

            var lblNV = new Label { Text = "Nhân viên:", Location = new Point(15, 65), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            cboNhanVien = new ComboBox { Location = new Point(95, 62), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F) };

            var lblCa = new Label { Text = "Ca làm:", Location = new Point(290, 65), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            cboCaLam = new ComboBox { Location = new Point(375, 62), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F) };

            var lblNgay = new Label { Text = "Ngày thuê:", Location = new Point(15, 105), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            dtpNgayThue = new DateTimePicker { Location = new Point(95, 102), Width = 130, Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 9F) };

            var lblCoc = new Label { Text = "Tiền đặt cọc:", Location = new Point(290, 105), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            numTienCoc = new NumericUpDown { Location = new Point(375, 102), Width = 150, Maximum = 10000000, Increment = 10000, ThousandsSeparator = true, Value = 50000, Font = new Font("Segoe UI", 9F) };

            grpInfo.Controls.AddRange(new Control[]
            {
                lblMa, txtMaThue, btnAutoMa, lblKH, cboKhachHang,
                lblNV, cboNhanVien, lblCa, cboCaLam,
                lblNgay, dtpNgayThue, lblCoc, numTienCoc
            });

            // Group 2: Chọn sách thuê (Yêu cầu 1: chỉ lấy SoLuong > 0)
            var grpChonSach = new GroupBox
            {
                Text = "2. Chọn sách mượn (Yêu cầu 1: Chỉ sách tồn > 0)",
                Dock = DockStyle.Top,
                Height = 110,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59)
            };

            var lblChon = new Label { Text = "Sách còn hàng:", Location = new Point(15, 26), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            cboSach = new ComboBox { Location = new Point(110, 23), Width = 280, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F) };
            cboSach.SelectedIndexChanged += CboSach_SelectedIndexChanged;

            var lblSL = new Label { Text = "Số lượng:", Location = new Point(410, 26), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            numSoLuongThue = new NumericUpDown { Location = new Point(480, 23), Width = 65, Minimum = 1, Maximum = 100, Value = 1, Font = new Font("Segoe UI", 9F) };

            lblTonKho = new Label { Text = "Tồn kho: 0 cuốn", Location = new Point(110, 60), AutoSize = true, ForeColor = Color.FromArgb(16, 185, 129), Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            lblDonGia = new Label { Text = "Giá thuê: 0 đ/ngày", Location = new Point(250, 60), AutoSize = true, ForeColor = Color.FromArgb(37, 99, 235), Font = new Font("Segoe UI", 9F, FontStyle.Bold) };

            btnThemSach = new Button
            {
                Text = "Thêm sách",
                Location = new Point(410, 56),
                Size = new Size(95, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(16, 185, 129),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnThemSach.FlatAppearance.BorderSize = 0;
            btnThemSach.Click += BtnThemSach_Click;

            btnXoaSach = new Button
            {
                Text = "Bỏ dòng",
                Location = new Point(515, 56),
                Size = new Size(85, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXoaSach.FlatAppearance.BorderSize = 0;
            btnXoaSach.Click += BtnXoaSach_Click;

            grpChonSach.Controls.AddRange(new Control[]
            {
                lblChon, cboSach, lblSL, numSoLuongThue, lblTonKho, lblDonGia, btnThemSach, btnXoaSach
            });

            // Group 3: Giỏ sách trong phiếu thuê
            var grpGio = new GroupBox
            {
                Text = "3. Sách trong phiếu thuê hiện tại",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Padding = new Padding(10)
            };

            dgvGioSach = new DataGridView
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
            dgvGioSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvGioSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvGioSach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvGioSach.ColumnHeadersHeight = 32;
            dgvGioSach.RowTemplate.Height = 28;

            InitGioSachGrid();

            // Bottom Actions Panel of Left
            var pnlLapActions = new Panel { Dock = DockStyle.Bottom, Height = 55, Padding = new Padding(5) };

            lblTongSoCuon = new Label
            {
                Text = "Tổng sách: 0 cuốn",
                Location = new Point(10, 18),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59)
            };

            btnLapPhieu = new Button
            {
                Text = "LẬP PHIẾU THUÊ",
                Location = new Point(310, 10),
                Size = new Size(160, 36),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnLapPhieu.FlatAppearance.BorderSize = 0;
            btnLapPhieu.Click += BtnLapPhieu_Click;

            btnHuyPhieu = new Button
            {
                Text = "Hủy / Làm mới",
                Location = new Point(480, 10),
                Size = new Size(125, 36),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(100, 116, 139),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnHuyPhieu.FlatAppearance.BorderSize = 0;
            btnHuyPhieu.Click += (s, e) => ResetPhieuMoi();

            pnlLapActions.Controls.AddRange(new Control[] { lblTongSoCuon, btnLapPhieu, btnHuyPhieu });

            grpGio.Controls.Add(dgvGioSach);
            grpGio.Controls.Add(pnlLapActions);

            pnlLapPhieu.Controls.Add(grpGio);
            pnlLapPhieu.Controls.Add(grpChonSach);
            pnlLapPhieu.Controls.Add(grpInfo);

            // Splitter giữa 2 cột cho phép co giãn kích thước
            var splitter = new Splitter
            {
                Dock = DockStyle.Left,
                Width = 5,
                BackColor = Color.FromArgb(226, 232, 240)
            };

            // ===== PANEL 2: LỊCH SỬ CÁC PHIẾU THUÊ ĐÃ LẬP (BÊN PHẢI) =====
            var pnlLichSu = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(15) };

            var lblHistTitle = new Label
            {
                Text = "Lịch sử phiếu thuê đã lập",
                Dock = DockStyle.Top,
                Height = 30,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59)
            };

            var pnlTimHist = new Panel { Dock = DockStyle.Top, Height = 40 };
            var lblTimH = new Label { Text = "Tìm kiếm:", Location = new Point(5, 10), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            txtTimLichSu = new TextBox { Location = new Point(70, 7), Width = 230, PlaceholderText = "Mã thuê, tên khách...", Font = new Font("Segoe UI", 9F) };
            txtTimLichSu.TextChanged += (s, e) => FilterLichSu();
            pnlTimHist.Controls.AddRange(new Control[] { lblTimH, txtTimLichSu });

            dgvLichSuThue = new DataGridView
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
            dgvLichSuThue.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvLichSuThue.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvLichSuThue.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvLichSuThue.ColumnHeadersHeight = 32;
            dgvLichSuThue.RowTemplate.Height = 28;

            pnlLichSu.Controls.Add(dgvLichSuThue);
            pnlLichSu.Controls.Add(pnlTimHist);
            pnlLichSu.Controls.Add(lblHistTitle);

            // Nạp các cột vào pnlBody (Dock Fill xếp trước, sau đó là Splitter, rồi Dock Left)
            pnlBody.Controls.Add(pnlLichSu);
            pnlBody.Controls.Add(splitter);
            pnlBody.Controls.Add(pnlLapPhieu);

            this.Controls.Add(pnlBody);
            this.Controls.Add(pnlTop);
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
                // Khách hàng
                cboKhachHang.DataSource = _khBLL.GetAll();
                cboKhachHang.DisplayMember = "TenKH";
                cboKhachHang.ValueMember = "MaKH";

                // Nhân viên
                cboNhanVien.DataSource = _nvBLL.GetAll();
                cboNhanVien.DisplayMember = "TenNV";
                cboNhanVien.ValueMember = "MaNV";
                if (SessionContext.CurrentNhanVien != null)
                {
                    cboNhanVien.SelectedValue = SessionContext.CurrentNhanVien.MaNV;
                }

                // Ca làm việc
                cboCaLam.DataSource = _dmBLL.GetCaLam();
                cboCaLam.DisplayMember = "TenCa";
                cboCaLam.ValueMember = "MaCa";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load lookup error: " + ex.Message);
            }
        }

        // Yêu cầu 1: Chỉ tải các sách có SoLuong > 0
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

                // Ẩn mã nội bộ
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

            // Kiểm tra xem đã có trong giỏ chưa
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

        // Yêu cầu 2: Lưu phiếu thuê và trừ tồn kho sách trong CSDL
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

            // Thực thi lập phiếu qua BLL (Trigger trg_ChiTietThue_Insert sẽ tự động trừ số lượng sách)
            if (_thueBLL.LapPhieuThue(phieu, _gioSach, out string error))
            {
                MessageBox.Show($"Lập phiếu thuê sách [{phieu.MaThue}] thành công!\nTồn kho sách đã được tự động cập nhật.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Nạp lại dữ liệu
                LoadSachConHang(); // Tồn kho đã giảm
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
