using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;

namespace BTL.GUI
{
    public class UC_TraSach : UserControl
    {
        private readonly ThueTraBLL _thueTraBLL = new();
        private readonly NhanVienBLL _nvBLL = new();
        private readonly DanhMucBLL _dmBLL = new();

        #region Controls Thông Tin Phiếu Trả
        private TextBox txtMaTra = null!;
        private ComboBox cboMaThue = null!;
        private ComboBox cboNhanVien = null!;
        private DateTimePicker dtpNgayTra = null!;
        private Label lblKhachHangInfo = null!;
        private Label lblNgayThueInfo = null!;
        private Label lblTienCocInfo = null!;
        #endregion

        #region Controls Chọn Sách Trả (Yêu cầu 3 & 4)
        private ComboBox cboSachChuaTra = null!;
        private ComboBox cboViPham = null!;
        private Label lblSLThue = null!;
        private Label lblDonGia = null!;
        private Label lblSoNgayThue = null!;
        private Label lblTienPhat = null!;
        private Label lblThanhTienTamTinh = null!;
        private Button btnThemSachTra = null!;
        private Button btnXoaSachTra = null!;
        #endregion

        #region Grids & Buttons
        private DataGridView dgvGioTra = null!;
        private DataGridView dgvLichSuTra = null!;
        private DataGridView dgvChiTietTra = null!;
        private Label lblTongThanhTien = null!;
        private Label lblThanhToanCuoi = null!;
        private Button btnXacNhanTra = null!;
        private Button btnLamMoi = null!;
        private TextBox txtTimLichSu = null!;
        #endregion

        // Dữ liệu tạm thời
        private readonly List<ChiTietTraDTO> _gioTra = new();
        private DataTable _dtSachChuaTra = new();
        private DateTime _ngayThueCuaPhieu = DateTime.Today;
        private decimal _tienCocCuaPhieu = 0;

        public UC_TraSach()
        {
            InitializeComponent();
            LoadLookupData();
            LoadLichSuTra();
            ResetForm();
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
                Text = "NHẬN TRẢ SÁCH & TÍNH TIỀN",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = UITheme.Navy,
                AutoSize = true,
                Location = new Point(18, 16)
            };

            var lblSubtitle = new Label
            {
                Text = "Yêu cầu 3: Lọc sách chưa trả  |  Yêu cầu 4: Tính tiền thuê + Phạt  |  Yêu cầu 2: Hoàn kho tự động",
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                ForeColor = UITheme.Blue,
                AutoSize = true,
                Location = new Point(290, 20)
            };

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblSubtitle);

            // 2. Main Body Container
            var pnlBody = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(241, 245, 249)
            };

            // ===== CỘT TRÁI: LẬP PHIẾU TRẢ MỚI =====
            var pnlLapPhieu = new Panel
            {
                Dock = DockStyle.Left,
                Width = 640,
                BackColor = Color.White,
                Padding = new Padding(15)
            };

            // Group 1: Thông tin phiếu trả
            var grpInfo = new GroupBox
            {
                Text = "1. Thông tin phiếu trả",
                Dock = DockStyle.Top,
                Height = 155,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59)
            };

            var lblMa = new Label { Text = "Mã phiếu trả:", Location = new Point(15, 26), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            txtMaTra = new TextBox { Location = new Point(105, 23), Width = 110, ReadOnly = true, BackColor = Color.FromArgb(241, 245, 249), Font = new Font("Segoe UI", 9F) };

            var btnAutoMa = new Button
            {
                Text = "Tự sinh",
                Location = new Point(220, 22),
                Width = 65,
                Height = 25,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(226, 232, 240),
                Font = new Font("Segoe UI", 8.5F),
                Cursor = Cursors.Hand
            };
            btnAutoMa.Click += (s, e) => txtMaTra.Text = _thueTraBLL.GenerateNewMaTra();

            var lblPhieuThue = new Label { Text = "Phiếu thuê:", Location = new Point(300, 26), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            cboMaThue = new ComboBox { Location = new Point(380, 23), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F) };
            cboMaThue.SelectedIndexChanged += CboMaThue_SelectedIndexChanged;

            var lblNV = new Label { Text = "Nhân viên nhận:", Location = new Point(15, 65), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            cboNhanVien = new ComboBox { Location = new Point(115, 62), Width = 170, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F) };

            var lblNgay = new Label { Text = "Ngày trả:", Location = new Point(300, 65), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            dtpNgayTra = new DateTimePicker { Location = new Point(380, 62), Width = 130, Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 9F) };
            dtpNgayTra.ValueChanged += (s, e) => TinhToanThanhTienPreview();

            lblKhachHangInfo = new Label { Text = "Khách hàng: ---", Location = new Point(15, 105), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(30, 41, 59) };
            lblNgayThueInfo = new Label { Text = "Ngày thuê: ---", Location = new Point(230, 105), AutoSize = true, Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(71, 85, 105) };
            lblTienCocInfo = new Label { Text = "Tiền cọc: 0 đ", Location = new Point(410, 105), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(16, 185, 129) };

            grpInfo.Controls.AddRange(new Control[]
            {
                lblMa, txtMaTra, btnAutoMa, lblPhieuThue, cboMaThue,
                lblNV, cboNhanVien, lblNgay, dtpNgayTra,
                lblKhachHangInfo, lblNgayThueInfo, lblTienCocInfo
            });

            // Group 2: Chọn sách trả (Yêu cầu 3 & 4)
            var grpChonSach = new GroupBox
            {
                Text = "2. Chọn sách trả & Tính tiền (YC 3: Chỉ sách chưa trả | YC 4: Tính tiền + Phạt)",
                Dock = DockStyle.Top,
                Height = 150,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59)
            };

            var lblSach = new Label { Text = "Sách chưa trả:", Location = new Point(15, 26), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            cboSachChuaTra = new ComboBox { Location = new Point(110, 23), Width = 280, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F) };
            cboSachChuaTra.SelectedIndexChanged += CboSachChuaTra_SelectedIndexChanged;

            lblSLThue = new Label { Text = "Số lượng: 0", Location = new Point(405, 26), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(30, 41, 59) };
            lblDonGia = new Label { Text = "Giá thuê: 0 đ/ngày", Location = new Point(495, 26), AutoSize = true, Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(71, 85, 105) };

            var lblVP = new Label { Text = "Lỗi vi phạm:", Location = new Point(15, 62), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            cboViPham = new ComboBox { Location = new Point(110, 59), Width = 280, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F) };
            cboViPham.SelectedIndexChanged += (s, e) => TinhToanThanhTienPreview();

            lblTienPhat = new Label { Text = "Tiền phạt: 0 đ", Location = new Point(405, 62), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(239, 68, 68) };

            lblSoNgayThue = new Label { Text = "Số ngày thuê: 1 ngày", Location = new Point(15, 100), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(37, 99, 235) };
            lblThanhTienTamTinh = new Label { Text = "Thành tiền: 0 đ", Location = new Point(200, 100), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(16, 185, 129) };

            btnThemSachTra = new Button
            {
                Text = "Thêm vào phiếu",
                Location = new Point(390, 96),
                Size = new Size(115, 32),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(16, 185, 129),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnThemSachTra.FlatAppearance.BorderSize = 0;
            btnThemSachTra.Click += BtnThemSachTra_Click;

            btnXoaSachTra = new Button
            {
                Text = "Bỏ dòng",
                Location = new Point(515, 96),
                Size = new Size(85, 32),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXoaSachTra.FlatAppearance.BorderSize = 0;
            btnXoaSachTra.Click += BtnXoaSachTra_Click;

            grpChonSach.Controls.AddRange(new Control[]
            {
                lblSach, cboSachChuaTra, lblSLThue, lblDonGia,
                lblVP, cboViPham, lblTienPhat,
                lblSoNgayThue, lblThanhTienTamTinh,
                btnThemSachTra, btnXoaSachTra
            });

            // Group 3: Giỏ sách trả
            var grpGio = new GroupBox
            {
                Text = "3. Danh sách sách trả trong lần này",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Padding = new Padding(10)
            };

            dgvGioTra = new DataGridView
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
            UITheme.StyleDataGridView(dgvGioTra);

            InitGioTraGrid();

            // Panel thanh toán & xác nhận
            var pnlLapActions = new Panel { Dock = DockStyle.Bottom, Height = 90, Padding = new Padding(5) };

            lblTongThanhTien = new Label
            {
                Text = "Tổng tiền thuê & phạt: 0 đ",
                Location = new Point(10, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59)
            };

            lblThanhToanCuoi = new Label
            {
                Text = "Cần thu thêm: 0 đ (Trừ cọc)",
                Location = new Point(10, 35),
                AutoSize = true,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = UITheme.Navy
            };

            btnXacNhanTra = new Button
            {
                Text = "XÁC NHẬN TRẢ SÁCH",
                Location = new Point(310, 15),
                Size = new Size(170, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = UITheme.Blue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXacNhanTra.FlatAppearance.BorderSize = 0;
            btnXacNhanTra.Click += BtnXacNhanTra_Click;

            btnLamMoi = new Button
            {
                Text = "Làm mới",
                Location = new Point(490, 15),
                Size = new Size(115, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = UITheme.Navy,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Cursor = Cursors.Hand
            };
            btnLamMoi.FlatAppearance.BorderColor = UITheme.Border;
            btnLamMoi.FlatAppearance.BorderSize = 1;
            btnLamMoi.Click += (s, e) => ResetForm();

            pnlLapActions.Controls.AddRange(new Control[] { lblTongThanhTien, lblThanhToanCuoi, btnXacNhanTra, btnLamMoi });

            grpGio.Controls.Add(dgvGioTra);
            grpGio.Controls.Add(pnlLapActions);

            pnlLapPhieu.Controls.Add(grpGio);
            pnlLapPhieu.Controls.Add(grpChonSach);
            pnlLapPhieu.Controls.Add(grpInfo);

            // Splitter giữa 2 cột co giãn
            var splitter = new Splitter
            {
                Dock = DockStyle.Left,
                Width = 5,
                BackColor = Color.FromArgb(226, 232, 240)
            };

            // ===== CỘT PHẢI: LỊCH SỬ CÁC PHIẾU TRẢ ĐÃ LẬP =====
            var pnlLichSu = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(15) };

            var lblHistTitle = new Label
            {
                Text = "Lịch sử các phiếu trả sách",
                Dock = DockStyle.Top,
                Height = 30,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = UITheme.Navy
            };

            var pnlTimHist = new Panel { Dock = DockStyle.Top, Height = 40 };
            var lblTimH = new Label { Text = "Tìm kiếm:", Location = new Point(5, 10), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            txtTimLichSu = new TextBox { Location = new Point(70, 7), Width = 230, PlaceholderText = "Mã trả, mã thuê, khách...", Font = new Font("Segoe UI", 9F) };
            txtTimLichSu.TextChanged += (s, e) => FilterLichSu();
            pnlTimHist.Controls.AddRange(new Control[] { lblTimH, txtTimLichSu });

            // Split con ở cột phải: nửa trên là danh sách phiếu trả, nửa dưới là chi tiết sách của phiếu trả đang chọn
            var pnlHistSplit = new Panel { Dock = DockStyle.Fill };

            dgvLichSuTra = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 250,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            UITheme.StyleDataGridView(dgvLichSuTra);
            dgvLichSuTra.CellClick += DgvLichSuTra_CellClick;

            var lblCTTitle = new Label
            {
                Text = "Chi tiết sách trả của phiếu được chọn:",
                Dock = DockStyle.Top,
                Height = 30,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = UITheme.Navy,
                Padding = new Padding(0, 8, 0, 0)
            };

            dgvChiTietTra = new DataGridView
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
            UITheme.StyleDataGridView(dgvChiTietTra);
            dgvChiTietTra.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvChiTietTra.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvChiTietTra.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dgvChiTietTra.ColumnHeadersHeight = 28;
            dgvChiTietTra.RowTemplate.Height = 26;

            pnlHistSplit.Controls.Add(dgvChiTietTra);
            pnlHistSplit.Controls.Add(lblCTTitle);
            pnlHistSplit.Controls.Add(dgvLichSuTra);

            pnlLichSu.Controls.Add(pnlHistSplit);
            pnlLichSu.Controls.Add(pnlTimHist);
            pnlLichSu.Controls.Add(lblHistTitle);

            pnlBody.Controls.Add(pnlLichSu);
            pnlBody.Controls.Add(splitter);
            pnlBody.Controls.Add(pnlLapPhieu);

            this.Controls.Add(pnlBody);
            this.Controls.Add(pnlTop);
        }

        private void InitGioTraGrid()
        {
            dgvGioTra.Columns.Clear();
            dgvGioTra.Columns.Add("MaSach", "Mã Sách");
            dgvGioTra.Columns.Add("TenSach", "Tên Sách");
            dgvGioTra.Columns.Add("SoLuong", "SL");
            dgvGioTra.Columns.Add("SoNgayThue", "Số Ngày");
            dgvGioTra.Columns.Add("DonGiaThue", "Giá Thuê (đ/ngày)");
            dgvGioTra.Columns.Add("TenVP", "Lỗi Vi Phạm");
            dgvGioTra.Columns.Add("TienPhat", "Tiền Phạt (đ)");
            dgvGioTra.Columns.Add("ThanhTien", "Thành Tiền (đ)");

            dgvGioTra.Columns["DonGiaThue"].DefaultCellStyle.Format = "N0";
            dgvGioTra.Columns["TienPhat"].DefaultCellStyle.Format = "N0";
            dgvGioTra.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            dgvGioTra.Columns["MaSach"].Width = 80;
            dgvGioTra.Columns["SoLuong"].Width = 40;
            dgvGioTra.Columns["SoNgayThue"].Width = 65;
        }

        private void LoadLookupData()
        {
            try
            {
                // Danh sách phiếu thuê có thể trả
                var dtThue = _thueTraBLL.GetAllPhieuThue();
                cboMaThue.DataSource = dtThue;
                cboMaThue.DisplayMember = "MaThue";
                cboMaThue.ValueMember = "MaThue";

                // Nhân viên
                cboNhanVien.DataSource = _nvBLL.GetAll();
                cboNhanVien.DisplayMember = "TenNV";
                cboNhanVien.ValueMember = "MaNV";
                if (SessionContext.CurrentNhanVien != null)
                {
                    cboNhanVien.SelectedValue = SessionContext.CurrentNhanVien.MaNV;
                }

                // Danh mục vi phạm (Thêm lựa chọn Không vi phạm)
                var dtVP = _dmBLL.GetViPham().Copy();
                var rNone = dtVP.NewRow();
                rNone["MaVP"] = "";
                rNone["TenVP"] = "Không vi phạm (Bình thường)";
                rNone["TienPhat"] = 0;
                dtVP.Rows.InsertAt(rNone, 0);

                cboViPham.DataSource = dtVP;
                cboViPham.DisplayMember = "TenVP";
                cboViPham.ValueMember = "MaVP";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load lookup error: " + ex.Message);
            }
        }

        // Khi chọn mã phiếu thuê: Nạp thông tin phiếu và Lọc sách CHƯA TRẢ (Yêu cầu 3)
        private void CboMaThue_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboMaThue.SelectedItem is DataRowView drv)
            {
                string maThue = drv["MaThue"].ToString()?.Trim() ?? string.Empty;
                string tenKH = drv["TenKH"].ToString() ?? string.Empty;
                _ngayThueCuaPhieu = Convert.ToDateTime(drv["NgayThue"]);
                _tienCocCuaPhieu = Convert.ToDecimal(drv["TienDatCoc"]);

                lblKhachHangInfo.Text = $"Khách hàng: {tenKH}";
                lblNgayThueInfo.Text = $"Ngày thuê: {_ngayThueCuaPhieu:dd/MM/yyyy}";
                lblTienCocInfo.Text = $"Tiền cọc: {_tienCocCuaPhieu:N0} đ";

                // Yêu cầu 3: Lấy danh sách sách CHƯA TRẢ theo mã phiếu
                LoadSachChuaTra(maThue);
            }
        }

        // Yêu cầu 3: Lấy sách chưa trả qua SP_GetSachChuaTraTheoPhieu
        private void LoadSachChuaTra(string maThue)
        {
            try
            {
                _dtSachChuaTra = _thueTraBLL.GetSachChuaTra(maThue);
                cboSachChuaTra.DataSource = _dtSachChuaTra;
                cboSachChuaTra.DisplayMember = "TenSach";
                cboSachChuaTra.ValueMember = "MaSach";

                if (_dtSachChuaTra.Rows.Count == 0)
                {
                    lblSLThue.Text = "Số lượng: 0";
                    lblDonGia.Text = "Giá thuê: 0 đ/ngày";
                    lblSoNgayThue.Text = "Số ngày: 0";
                    lblThanhTienTamTinh.Text = "Thành tiền: 0 đ (Đã trả hết sách)";
                }
                else
                {
                    CboSachChuaTra_SelectedIndexChanged(null, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load sach chua tra error: " + ex.Message);
            }
        }

        private void CboSachChuaTra_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboSachChuaTra.SelectedItem is DataRowView drv)
            {
                int sl = Convert.ToInt32(drv["SoLuong"]);
                decimal donGia = Convert.ToDecimal(drv["DonGiaThue"]);

                lblSLThue.Text = $"Số lượng: {sl} cuốn";
                lblDonGia.Text = $"Giá thuê: {donGia:N0} đ/ngày";

                TinhToanThanhTienPreview();
            }
        }

        // Yêu cầu 4: Tính Thành tiền = Đơn giá thuê * Số ngày thuê * Số lượng + Tiền phạt (nếu có)
        private void TinhToanThanhTienPreview()
        {
            if (cboSachChuaTra.SelectedItem is not DataRowView drv) return;

            int sl = Convert.ToInt32(drv["SoLuong"]);
            decimal donGia = Convert.ToDecimal(drv["DonGiaThue"]);

            // Tính số ngày thuê
            int soNgay = (dtpNgayTra.Value.Date - _ngayThueCuaPhieu.Date).Days;
            if (soNgay < 1) soNgay = 1; // Mượn trong ngày tính 1 ngày

            lblSoNgayThue.Text = $"Số ngày thuê: {soNgay} ngày";

            // Tiền phạt
            decimal tienPhat = 0;
            if (cboViPham.SelectedItem is DataRowView rVP && rVP["TienPhat"] != DBNull.Value)
            {
                tienPhat = Convert.ToDecimal(rVP["TienPhat"]);
            }
            lblTienPhat.Text = $"Tiền phạt: {tienPhat:N0} đ";

            // Thành tiền YC 4
            decimal thanhTien = (donGia * soNgay * sl) + tienPhat;
            lblThanhTienTamTinh.Text = $"Thành tiền: {thanhTien:N0} đ";
        }

        private void BtnThemSachTra_Click(object? sender, EventArgs e)
        {
            if (cboSachChuaTra.SelectedItem is not DataRowView drv)
            {
                MessageBox.Show("Phiếu thuê này không còn cuốn sách nào chưa trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maSach = drv["MaSach"].ToString()?.Trim() ?? string.Empty;
            string tenSach = drv["TenSach"].ToString() ?? string.Empty;
            int sl = Convert.ToInt32(drv["SoLuong"]);
            decimal donGia = Convert.ToDecimal(drv["DonGiaThue"]);

            // Kiểm tra xem đã thêm vào giỏ trả chưa
            if (_gioTra.Exists(x => x.MaSach == maSach))
            {
                MessageBox.Show("Cuốn sách này đã được thêm vào danh sách trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soNgay = (dtpNgayTra.Value.Date - _ngayThueCuaPhieu.Date).Days;
            if (soNgay < 1) soNgay = 1;

            string maVP = string.Empty;
            string tenVP = "Không";
            decimal tienPhat = 0;

            if (cboViPham.SelectedItem is DataRowView rVP)
            {
                maVP = rVP["MaVP"].ToString()?.Trim() ?? string.Empty;
                tenVP = rVP["TenVP"].ToString() ?? "Không";
                if (rVP["TienPhat"] != DBNull.Value) tienPhat = Convert.ToDecimal(rVP["TienPhat"]);
            }

            decimal thanhTien = (donGia * soNgay * sl) + tienPhat;

            _gioTra.Add(new ChiTietTraDTO
            {
                MaSach = maSach,
                TenSach = tenSach,
                SoLuong = sl,
                SoNgayThue = soNgay,
                MaVP = string.IsNullOrEmpty(maVP) ? null : maVP,
                TenVP = tenVP,
                ThanhTien = thanhTien
            });

            CapNhatGioTraGrid();
        }

        private void BtnXoaSachTra_Click(object? sender, EventArgs e)
        {
            if (dgvGioTra.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn cuốn sách cần bỏ khỏi danh sách trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSach = dgvGioTra.SelectedRows[0].Cells["MaSach"].Value?.ToString() ?? string.Empty;
            _gioTra.RemoveAll(x => x.MaSach == maSach);
            CapNhatGioTraGrid();
        }

        private void CapNhatGioTraGrid()
        {
            dgvGioTra.Rows.Clear();
            decimal tongTien = 0;

            foreach (var item in _gioTra)
            {
                // Tìm đơn giá thuê
                decimal donGia = 0;
                foreach (DataRow r in _dtSachChuaTra.Rows)
                {
                    if (r["MaSach"].ToString()?.Trim() == item.MaSach)
                    {
                        donGia = Convert.ToDecimal(r["DonGiaThue"]);
                        break;
                    }
                }

                decimal tienPhat = item.MaVP != null ? (item.ThanhTien - (donGia * item.SoNgayThue * item.SoLuong)) : 0;
                if (tienPhat < 0) tienPhat = 0;

                dgvGioTra.Rows.Add(item.MaSach, item.TenSach, item.SoLuong, item.SoNgayThue, donGia, item.TenVP, tienPhat, item.ThanhTien);
                tongTien += item.ThanhTien;
            }

            lblTongThanhTien.Text = $"Tổng tiền thuê & phạt: {tongTien:N0} đ";

            decimal chenhLech = tongTien - _tienCocCuaPhieu;
            if (chenhLech >= 0)
            {
                lblThanhToanCuoi.Text = $"Khách cần nộp thêm: {chenhLech:N0} đ (Sau khi trừ cọc)";
                lblThanhToanCuoi.ForeColor = Color.FromArgb(239, 68, 68);
            }
            else
            {
                lblThanhToanCuoi.Text = $"Hoàn trả cọc cho khách: {Math.Abs(chenhLech):N0} đ";
                lblThanhToanCuoi.ForeColor = Color.FromArgb(16, 185, 129);
            }
        }

        // Yêu cầu 2: Lưu phiếu trả, Trigger hoàn kho và đánh dấu DaTra = 1
        private void BtnXacNhanTra_Click(object? sender, EventArgs e)
        {
            if (cboMaThue.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu thuê cần trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên nhận trả sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_gioTra.Count == 0)
            {
                MessageBox.Show("Danh sách trả sách đang trống! Vui lòng chọn ít nhất 1 cuốn sách để trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var phieu = new TraSachDTO
            {
                MaTra = txtMaTra.Text.Trim(),
                MaThue = cboMaThue.SelectedValue.ToString() ?? string.Empty,
                MaNV = cboNhanVien.SelectedValue.ToString() ?? string.Empty,
                NgayTra = dtpNgayTra.Value
            };

            // Thực thi lập phiếu trả qua BLL
            if (_thueTraBLL.LapPhieuTra(phieu, _gioTra, out string error))
            {
                MessageBox.Show($"Xác nhận trả sách phiếu [{phieu.MaTra}] thành công!\nSố lượng sách đã được tự động hoàn lại vào kho.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadLichSuTra();
                string curMaThue = phieu.MaThue;
                ResetForm();
                // Nạp lại danh sách sách chưa trả của phiếu này
                cboMaThue.SelectedValue = curMaThue;
            }
            else
            {
                MessageBox.Show("Xác nhận trả sách thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLichSuTra()
        {
            try
            {
                var dt = _thueTraBLL.GetAllPhieuTra();
                dgvLichSuTra.DataSource = dt;

                if (dgvLichSuTra.Columns.Contains("MaTra")) dgvLichSuTra.Columns["MaTra"].HeaderText = "Mã Trả";
                if (dgvLichSuTra.Columns.Contains("MaThue")) dgvLichSuTra.Columns["MaThue"].HeaderText = "Mã Thuê";
                if (dgvLichSuTra.Columns.Contains("TenKH")) dgvLichSuTra.Columns["TenKH"].HeaderText = "Khách Hàng";
                if (dgvLichSuTra.Columns.Contains("TenNV")) dgvLichSuTra.Columns["TenNV"].HeaderText = "NV Nhận";
                if (dgvLichSuTra.Columns.Contains("NgayTra")) dgvLichSuTra.Columns["NgayTra"].HeaderText = "Ngày Trả";
                if (dgvLichSuTra.Columns.Contains("TongTien"))
                {
                    dgvLichSuTra.Columns["TongTien"].HeaderText = "Tổng Tiền (đ)";
                    dgvLichSuTra.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                }

                if (dgvLichSuTra.Columns.Contains("MaNV")) dgvLichSuTra.Columns["MaNV"].Visible = false;

                if (dt.Rows.Count > 0)
                {
                    DgvLichSuTra_CellClick(null, new DataGridViewCellEventArgs(0, 0));
                }
            }
            catch { }
        }

        private void DgvLichSuTra_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvLichSuTra.Rows.Count) return;
            string maTra = dgvLichSuTra.Rows[e.RowIndex].Cells["MaTra"].Value?.ToString()?.Trim() ?? string.Empty;

            try
            {
                var dtCT = _thueTraBLL.GetChiTietTra(maTra);
                dgvChiTietTra.DataSource = dtCT;

                if (dgvChiTietTra.Columns.Contains("MaTra")) dgvChiTietTra.Columns["MaTra"].Visible = false;
                if (dgvChiTietTra.Columns.Contains("MaVP")) dgvChiTietTra.Columns["MaVP"].Visible = false;

                if (dgvChiTietTra.Columns.Contains("MaSach")) dgvChiTietTra.Columns["MaSach"].HeaderText = "Mã Sách";
                if (dgvChiTietTra.Columns.Contains("TenSach")) dgvChiTietTra.Columns["TenSach"].HeaderText = "Tên Sách";
                if (dgvChiTietTra.Columns.Contains("TenVP")) dgvChiTietTra.Columns["TenVP"].HeaderText = "Lỗi Vi Phạm";
                if (dgvChiTietTra.Columns.Contains("TienPhat"))
                {
                    dgvChiTietTra.Columns["TienPhat"].HeaderText = "Phạt (đ)";
                    dgvChiTietTra.Columns["TienPhat"].DefaultCellStyle.Format = "N0";
                }
                if (dgvChiTietTra.Columns.Contains("ThanhTien"))
                {
                    dgvChiTietTra.Columns["ThanhTien"].HeaderText = "Thành Tiền (đ)";
                    dgvChiTietTra.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }
            }
            catch { }
        }

        private void FilterLichSu()
        {
            try
            {
                var dt = dgvLichSuTra.DataSource as DataTable;
                if (dt != null)
                {
                    string f = txtTimLichSu.Text.Trim().Replace("'", "''");
                    if (string.IsNullOrEmpty(f))
                    {
                        dt.DefaultView.RowFilter = string.Empty;
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = $"MaTra LIKE '%{f}%' OR MaThue LIKE '%{f}%' OR TenKH LIKE '%{f}%' OR TenNV LIKE '%{f}%'";
                    }
                }
            }
            catch { }
        }

        private void ResetForm()
        {
            txtMaTra.Text = _thueTraBLL.GenerateNewMaTra();
            dtpNgayTra.Value = DateTime.Today;
            _gioTra.Clear();
            CapNhatGioTraGrid();
            if (cboMaThue.Items.Count > 0)
            {
                cboMaThue.SelectedIndex = 0;
                CboMaThue_SelectedIndexChanged(null, EventArgs.Empty);
            }
        }
    }
}
