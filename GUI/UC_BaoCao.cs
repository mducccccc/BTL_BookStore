using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BTL.BLL;

namespace BTL.GUI
{
    public class UC_BaoCao : UserControl
    {
        private readonly BaoCaoBLL _baoCaoBLL = new();

        private TabControl tabBaoCao = null!;

        #region Controls Báo Cáo 1 (Yêu cầu 7)
        private DataGridView dgvSachChuaTra = null!;
        private Label lblTongChuaTra = null!;
        private Label lblTongTienTamTinh = null!;
        private Label lblTongTienCoc = null!;
        private Button btnLamMoiChuaTra = null!;
        #endregion

        #region Controls Báo Cáo 2 (Yêu cầu 8)
        private ComboBox cboKieuDoanhThu = null!;
        private NumericUpDown numNamDoanhThu = null!;
        private Button btnXemDoanhThu = null!;
        private DataGridView dgvDoanhThu = null!;
        private Label lblTongDoanhThu = null!;
        private Panel pnlChart = null!;
        private DataTable _dtDoanhThu = new();
        #endregion

        #region Controls Báo Cáo 3 (Yêu cầu 9)
        private DateTimePicker dtpTuNgay = null!;
        private DateTimePicker dtpDenNgay = null!;
        private CheckBox chkTatCaThoiGian = null!;
        private Button btnXemTop5 = null!;
        private DataGridView dgvTop5 = null!;
        private Label lblTop1Info = null!;
        #endregion

        public UC_BaoCao()
        {
            InitializeComponent();
            LoadBaoCao1();
            LoadBaoCao2();
            LoadBaoCao3();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = UITheme.Page;
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            tabBaoCao = new TabControl
            {
                Dock = DockStyle.Fill,
                Padding = new Point(16, 8)
            };

            var tab1 = BuildTabBaoCao1();
            var tab2 = BuildTabBaoCao2();
            var tab3 = BuildTabBaoCao3();

            tabBaoCao.TabPages.AddRange(new TabPage[] { tab1, tab2, tab3 });
            this.Controls.Add(tabBaoCao);
        }

        #region 1. TAB BÁO CÁO 1: SÁCH ĐANG THUÊ CHƯA TRẢ (YÊU CẦU 7)
        private TabPage BuildTabBaoCao1()
        {
            var tab = new TabPage("Sách Đang Thuê Chưa Trả (Yêu cầu 7)") { BackColor = Color.White };

            // Panel thanh công cụ & thẻ thống kê
            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                Padding = new Padding(20, 15, 20, 10),
                BackColor = Color.White
            };

            var lblTitle = new Label
            {
                Text = "BÁO CÁO DANH SÁCH SÁCH TRUYỆN ĐANG ĐƯỢC THUÊ CHƯA TRẢ",
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = UITheme.Navy,
                Dock = DockStyle.Top,
                Height = 25
            };

            btnLamMoiChuaTra = new Button
            {
                Text = "Cập nhật dữ liệu",
                Location = new Point(20, 45),
                Size = new Size(130, 34),
                FlatStyle = FlatStyle.Flat,
                BackColor = UITheme.Blue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnLamMoiChuaTra.FlatAppearance.BorderSize = 0;
            btnLamMoiChuaTra.Click += (s, e) => LoadBaoCao1();

            lblTongChuaTra = new Label
            {
                Text = "Tổng sách đang thuê: 0 cuốn",
                Location = new Point(170, 52),
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(217, 119, 6)
            };

            lblTongTienTamTinh = new Label
            {
                Text = "Tiền thuê tạm tính: 0 đ",
                Location = new Point(410, 52),
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(16, 185, 129)
            };

            lblTongTienCoc = new Label
            {
                Text = "Tiền cọc đang giữ: 0 đ",
                Location = new Point(650, 52),
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(139, 92, 246)
            };

            pnlTop.Controls.AddRange(new Control[] { lblTitle, btnLamMoiChuaTra, lblTongChuaTra, lblTongTienTamTinh, lblTongTienCoc });

            var pnlGrid = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15) };

            dgvSachChuaTra = new DataGridView
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
            UITheme.StyleDataGridView(dgvSachChuaTra);

            pnlGrid.Controls.Add(dgvSachChuaTra);

            tab.Controls.Add(pnlGrid);
            tab.Controls.Add(pnlTop);
            return tab;
        }

        private void LoadBaoCao1()
        {
            try
            {
                var dt = _baoCaoBLL.GetSachDangThueChuaTra();
                dgvSachChuaTra.DataSource = dt;

                if (dgvSachChuaTra.Columns.Contains("MaThue")) dgvSachChuaTra.Columns["MaThue"].HeaderText = "Mã Thuê";
                if (dgvSachChuaTra.Columns.Contains("TenKH")) dgvSachChuaTra.Columns["TenKH"].HeaderText = "Khách Hàng";
                if (dgvSachChuaTra.Columns.Contains("MaSach")) dgvSachChuaTra.Columns["MaSach"].HeaderText = "Mã Sách";
                if (dgvSachChuaTra.Columns.Contains("TenSach")) dgvSachChuaTra.Columns["TenSach"].HeaderText = "Tên Sách";
                if (dgvSachChuaTra.Columns.Contains("SoLuong")) dgvSachChuaTra.Columns["SoLuong"].HeaderText = "Số Lượng";
                if (dgvSachChuaTra.Columns.Contains("NgayThue")) dgvSachChuaTra.Columns["NgayThue"].HeaderText = "Ngày Thuê";
                if (dgvSachChuaTra.Columns.Contains("SoNgayDaThue")) dgvSachChuaTra.Columns["SoNgayDaThue"].HeaderText = "Số Ngày Thuê";
                if (dgvSachChuaTra.Columns.Contains("TienThueTamTinh"))
                {
                    dgvSachChuaTra.Columns["TienThueTamTinh"].HeaderText = "Tiền Tạm Tính";
                    dgvSachChuaTra.Columns["TienThueTamTinh"].DefaultCellStyle.Format = "N0";
                }
                if (dgvSachChuaTra.Columns.Contains("TienDatCoc"))
                {
                    dgvSachChuaTra.Columns["TienDatCoc"].HeaderText = "Tiền Cọc";
                    dgvSachChuaTra.Columns["TienDatCoc"].DefaultCellStyle.Format = "N0";
                }
                if (dgvSachChuaTra.Columns.Contains("NhanVienLap")) dgvSachChuaTra.Columns["NhanVienLap"].HeaderText = "NV Lập";

                // Tính tổng cộng
                int tongCuon = 0;
                decimal tongTamTinh = 0;
                decimal tongCoc = 0;

                foreach (DataRow r in dt.Rows)
                {
                    if (r["SoLuong"] != DBNull.Value) tongCuon += Convert.ToInt32(r["SoLuong"]);
                    if (r["TienThueTamTinh"] != DBNull.Value) tongTamTinh += Convert.ToDecimal(r["TienThueTamTinh"]);
                    if (r["TienDatCoc"] != DBNull.Value) tongCoc += Convert.ToDecimal(r["TienDatCoc"]);
                }

                lblTongChuaTra.Text = $"Tổng: {dt.Rows.Count} lượt ({tongCuon} cuốn)";
                lblTongTienTamTinh.Text = $"Tạm tính: {tongTamTinh:N0} đ";
                lblTongTienCoc.Text = $"Tiền cọc giữ: {tongCoc:N0} đ";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load bao cao 1 error: " + ex.Message);
            }
        }
        #endregion

        #region 2. TAB BÁO CÁO 2: DOANH THU THÁNG / QUÝ / NĂM (YÊU CẦU 8)
        private TabPage BuildTabBaoCao2()
        {
            var tab = new TabPage("Doanh Thu Theo Tháng / Quý / Năm (Yêu cầu 8)") { BackColor = Color.White };

            // Panel bộ lọc
            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 85,
                Padding = new Padding(20, 15, 20, 10),
                BackColor = Color.White
            };

            var lblKieu = new Label { Text = "Xem theo:", Location = new Point(20, 26), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboKieuDoanhThu = new ComboBox { Location = new Point(90, 23), Width = 140, DropDownStyle = ComboBoxStyle.DropDownList };
            cboKieuDoanhThu.Items.AddRange(new object[] { "Theo Tháng", "Theo Quý", "Theo Năm" });
            cboKieuDoanhThu.SelectedIndex = 0;

            var lblNam = new Label { Text = "Năm:", Location = new Point(250, 26), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            numNamDoanhThu = new NumericUpDown { Location = new Point(295, 23), Width = 90, Minimum = 2000, Maximum = 2100, Value = DateTime.Today.Year };

            btnXemDoanhThu = new Button
            {
                Text = "Xem báo cáo",
                Location = new Point(410, 21),
                Size = new Size(110, 32),
                FlatStyle = FlatStyle.Flat,
                BackColor = UITheme.Blue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXemDoanhThu.FlatAppearance.BorderSize = 0;
            btnXemDoanhThu.Click += (s, e) => LoadBaoCao2();

            lblTongDoanhThu = new Label
            {
                Text = "Tổng doanh thu: 0 đ",
                Location = new Point(540, 27),
                AutoSize = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(16, 185, 129)
            };

            pnlTop.Controls.AddRange(new Control[] { lblKieu, cboKieuDoanhThu, lblNam, numNamDoanhThu, btnXemDoanhThu, lblTongDoanhThu });

            // Body: Bên trái là Bảng số liệu, bên phải là Biểu đồ trực quan
            var splitDoanhThu = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15) };

            var pnlLeftGrid = new Panel { Dock = DockStyle.Left, Width = 450 };

            dgvDoanhThu = new DataGridView
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
            UITheme.StyleDataGridView(dgvDoanhThu);

            pnlLeftGrid.Controls.Add(dgvDoanhThu);

            // Panel Biểu đồ cột tự vẽ (GDI+ Custom Paint)
            pnlChart = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(248, 250, 252),
                Padding = new Padding(20)
            };
            pnlChart.Paint += PnlChart_Paint;

            splitDoanhThu.Controls.Add(pnlChart);
            splitDoanhThu.Controls.Add(new Splitter { Dock = DockStyle.Left, Width = 8, BackColor = Color.FromArgb(241, 245, 249) });
            splitDoanhThu.Controls.Add(pnlLeftGrid);

            tab.Controls.Add(splitDoanhThu);
            tab.Controls.Add(pnlTop);
            return tab;
        }

        private void LoadBaoCao2()
        {
            try
            {
                string kieu = "THANG";
                if (cboKieuDoanhThu.SelectedIndex == 1) kieu = "QUY";
                else if (cboKieuDoanhThu.SelectedIndex == 2) kieu = "NAM";

                int nam = (int)numNamDoanhThu.Value;
                _dtDoanhThu = _baoCaoBLL.GetDoanhThu(kieu, nam);
                dgvDoanhThu.DataSource = _dtDoanhThu;

                if (dgvDoanhThu.Columns.Contains("Ky"))
                {
                    dgvDoanhThu.Columns["Ky"].HeaderText = kieu == "THANG" ? "Tháng" : (kieu == "QUY" ? "Quý" : "Năm");
                }
                if (dgvDoanhThu.Columns.Contains("SoPhieuTra")) dgvDoanhThu.Columns["SoPhieuTra"].HeaderText = "Số Lượt Trả";
                if (dgvDoanhThu.Columns.Contains("DoanhThu"))
                {
                    dgvDoanhThu.Columns["DoanhThu"].HeaderText = "Doanh Thu (VNĐ)";
                    dgvDoanhThu.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
                }

                decimal tong = 0;
                foreach (DataRow r in _dtDoanhThu.Rows)
                {
                    if (r["DoanhThu"] != DBNull.Value) tong += Convert.ToDecimal(r["DoanhThu"]);
                }

                lblTongDoanhThu.Text = $"Tổng doanh thu ({kieu}): {tong:N0} đ";

                // Vẽ lại biểu đồ cột
                pnlChart.Invalidate();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load bao cao 2 error: " + ex.Message);
            }
        }

        // Vẽ biểu đồ cột doanh thu trực quan bằng GDI+
        private void PnlChart_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = pnlChart.ClientRectangle;
            if (rect.Width < 100 || rect.Height < 100) return;

            // Tiêu đề biểu đồ
            using var fontTitle = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            using var brushTitle = new SolidBrush(Color.FromArgb(30, 41, 59));
            g.DrawString("BIỂU ĐỒ DOANH THU", fontTitle, brushTitle, 20, 15);

            if (_dtDoanhThu == null || _dtDoanhThu.Rows.Count == 0)
            {
                using var fontMsg = new Font("Segoe UI", 9.5F, FontStyle.Italic);
                using var brushMsg = new SolidBrush(Color.FromArgb(148, 163, 184));
                g.DrawString("Chưa có dữ liệu doanh thu trong kỳ này để hiển thị biểu đồ.", fontMsg, brushMsg, 20, 50);
                return;
            }

            // Tìm giá trị max
            decimal maxVal = 0;
            foreach (DataRow r in _dtDoanhThu.Rows)
            {
                if (r["DoanhThu"] != DBNull.Value)
                {
                    decimal v = Convert.ToDecimal(r["DoanhThu"]);
                    if (v > maxVal) maxVal = v;
                }
            }
            if (maxVal <= 0) maxVal = 1;

            int bottomY = rect.Height - 50;
            int topY = 60;
            int chartHeight = bottomY - topY;

            // Trục ngang
            using var penAxis = new Pen(Color.FromArgb(203, 213, 225), 2);
            g.DrawLine(penAxis, 30, bottomY, rect.Width - 30, bottomY);

            int count = _dtDoanhThu.Rows.Count;
            int colWidth = Math.Min(50, (rect.Width - 80) / Math.Max(1, count * 2));
            int gap = colWidth;
            int startX = 40;

            using var fontLabel = new Font("Segoe UI", 8F);
            using var brushLabel = new SolidBrush(Color.FromArgb(71, 85, 105));
            using var brushVal = new SolidBrush(Color.FromArgb(37, 99, 235));

            for (int i = 0; i < count; i++)
            {
                var r = _dtDoanhThu.Rows[i];
                string ky = r["Ky"].ToString() ?? "";
                decimal val = r["DoanhThu"] != DBNull.Value ? Convert.ToDecimal(r["DoanhThu"]) : 0;

                int barHeight = (int)((val / maxVal) * (chartHeight - 30));
                int barX = startX + i * (colWidth + gap);
                int barY = bottomY - barHeight;

                // Vẽ cột với màu gradient UTC (Blue -> Navy)
                var barRect = new Rectangle(barX, barY, colWidth, barHeight);
                if (barHeight > 0)
                {
                    using var brushBar = new LinearGradientBrush(barRect, UITheme.Blue, UITheme.Navy, LinearGradientMode.Vertical);
                    g.FillRectangle(brushBar, barRect);
                }

                // Nhãn kỳ (Tháng / Quý)
                string kyText = (cboKieuDoanhThu.SelectedIndex == 0 ? "T." : (cboKieuDoanhThu.SelectedIndex == 1 ? "Q." : "")) + ky;
                g.DrawString(kyText, fontLabel, brushLabel, barX + 5, bottomY + 8);

                // Số tiền rút gọn phía trên cột
                if (val > 0)
                {
                    string valText = val >= 1000000 ? $"{val / 1000000:0.#}Tr" : $"{val / 1000:0}k";
                    g.DrawString(valText, fontLabel, brushVal, barX, Math.Max(topY, barY - 18));
                }
            }
        }
        #endregion

        #region 3. TAB BÁO CÁO 3: TOP 5 SÁCH DOANH THU CAO NHẤT (YÊU CẦU 9)
        private TabPage BuildTabBaoCao3()
        {
            var tab = new TabPage("Top 5 Sách Doanh Thu Cao Nhất (Yêu cầu 9)") { BackColor = Color.White };

            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                Padding = new Padding(20, 15, 20, 10),
                BackColor = Color.White
            };

            var lblHeader = new Label
            {
                Text = "DANH SÁCH 5 SÁCH TRUYỆN ĐẠT DOANH THU NHIỀU NHẤT CỦA CỬA HÀNG",
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = UITheme.Navy,
                Dock = DockStyle.Top,
                Height = 25
            };

            var lblTu = new Label { Text = "Từ ngày:", Location = new Point(20, 45), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            dtpTuNgay = new DateTimePicker { Location = new Point(80, 42), Width = 130, Format = DateTimePickerFormat.Short, Value = new DateTime(DateTime.Today.Year, 1, 1) };

            var lblDen = new Label { Text = "Đến ngày:", Location = new Point(230, 45), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            dtpDenNgay = new DateTimePicker { Location = new Point(300, 42), Width = 130, Format = DateTimePickerFormat.Short, Value = DateTime.Today };

            chkTatCaThoiGian = new CheckBox { Text = "Tất cả thời gian", Location = new Point(450, 44), AutoSize = true };
            chkTatCaThoiGian.CheckedChanged += (s, e) =>
            {
                dtpTuNgay.Enabled = !chkTatCaThoiGian.Checked;
                dtpDenNgay.Enabled = !chkTatCaThoiGian.Checked;
                LoadBaoCao3();
            };

            btnXemTop5 = new Button
            {
                Text = "Xem Top 5",
                Location = new Point(590, 40),
                Size = new Size(110, 32),
                FlatStyle = FlatStyle.Flat,
                BackColor = UITheme.Blue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXemTop5.FlatAppearance.BorderSize = 0;
            btnXemTop5.Click += (s, e) => LoadBaoCao3();

            lblTop1Info = new Label
            {
                Text = "Quán quân doanh thu: ---",
                Location = new Point(20, 80),
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(217, 119, 6)
            };

            pnlTop.Controls.AddRange(new Control[] { lblHeader, lblTu, dtpTuNgay, lblDen, dtpDenNgay, chkTatCaThoiGian, btnXemTop5, lblTop1Info });

            var pnlGrid = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15) };

            dgvTop5 = new DataGridView
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
            UITheme.StyleDataGridView(dgvTop5);

            dgvTop5.CellFormatting += DgvTop5_CellFormatting;

            pnlGrid.Controls.Add(dgvTop5);

            tab.Controls.Add(pnlGrid);
            tab.Controls.Add(pnlTop);
            return tab;
        }

        private void LoadBaoCao3()
        {
            try
            {
                DateTime? tu = chkTatCaThoiGian.Checked ? null : dtpTuNgay.Value.Date;
                DateTime? den = chkTatCaThoiGian.Checked ? null : dtpDenNgay.Value.Date;

                var dt = _baoCaoBLL.GetTop5Sach(tu, den);
                dgvTop5.DataSource = dt;

                if (dgvTop5.Columns.Contains("Hang"))
                {
                    dgvTop5.Columns["Hang"].HeaderText = "Thứ Hạng";
                    dgvTop5.Columns["Hang"].Width = 90;
                }
                if (dgvTop5.Columns.Contains("MaSach"))
                {
                    dgvTop5.Columns["MaSach"].HeaderText = "Mã Sách";
                    dgvTop5.Columns["MaSach"].Width = 100;
                }
                if (dgvTop5.Columns.Contains("TenSach")) dgvTop5.Columns["TenSach"].HeaderText = "Tên Sách Truyện";
                if (dgvTop5.Columns.Contains("TenTG")) dgvTop5.Columns["TenTG"].HeaderText = "Tác Giả";
                if (dgvTop5.Columns.Contains("SoLanThue"))
                {
                    dgvTop5.Columns["SoLanThue"].HeaderText = "Số Lần Thuê";
                    dgvTop5.Columns["SoLanThue"].Width = 110;
                }
                if (dgvTop5.Columns.Contains("DoanhThu"))
                {
                    dgvTop5.Columns["DoanhThu"].HeaderText = "Doanh Thu (VNĐ)";
                    dgvTop5.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
                    dgvTop5.Columns["DoanhThu"].DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }

                if (dt.Rows.Count > 0)
                {
                    string top1Ten = dt.Rows[0]["TenSach"]?.ToString() ?? "";
                    decimal top1DT = dt.Rows[0]["DoanhThu"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["DoanhThu"]) : 0;
                    lblTop1Info.Text = $"TOP 1: [{top1Ten}] - Doanh thu: {top1DT:N0} đ";
                }
                else
                {
                    lblTop1Info.Text = "Không có giao dịch trả sách nào trong khoảng thời gian đã chọn.";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load bao cao 3 error: " + ex.Message);
            }
        }

        // Đánh dấu nổi bật TOP 1 (Gold), TOP 2 (Silver), TOP 3 (Bronze)
        private void DgvTop5_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTop5.Columns[e.ColumnIndex].Name == "Hang" && e.Value != null)
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = "🥇 TOP 1";
                    e.CellStyle!.ForeColor = Color.FromArgb(180, 83, 9);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
                else if (e.Value.ToString() == "2")
                {
                    e.Value = "🥈 TOP 2";
                    e.CellStyle!.ForeColor = Color.FromArgb(71, 85, 105);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
                else if (e.Value.ToString() == "3")
                {
                    e.Value = "🥉 TOP 3";
                    e.CellStyle!.ForeColor = Color.FromArgb(180, 83, 9);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
                else
                {
                    e.Value = $"  TOP {e.Value}";
                }
            }
        }
        #endregion
    }
}
