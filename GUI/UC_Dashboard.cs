using System;
using System.Drawing;
using System.Windows.Forms;
using BTL.BLL;

namespace BTL.GUI
{
    public class UC_Dashboard : UserControl
    {
        private Panel pnlCards = null!;
        private Panel card1 = null!, card2 = null!, card3 = null!, card4 = null!;
        private Label lblTotalSach = null!, lblDangThue = null!, lblTotalKH = null!, lblTotalTra = null!;
        private DataGridView dgvRecent = null!;
        private Label lblRecentTitle = null!;
        private Panel pnlTable = null!;

        private readonly SachBLL _sachBLL = new();
        private readonly BaoCaoBLL _baoCaoBLL = new();
        private readonly KhachHangBLL _khachHangBLL = new();
        private readonly ThueTraBLL _thueTraBLL = new();

        public UC_Dashboard()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = UITheme.Page;
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            // Container Panel for Cards
            pnlCards = new Panel
            {
                Dock = DockStyle.Top,
                Height = 130,
                Padding = new Padding(15, 15, 15, 10),
                BackColor = UITheme.Page
            };

            int cardWidth = 240;
            int cardGap = 15;

            // Card 1: Tổng đầu sách (Navy)
            card1 = CreateMetricCard("Tổng đầu sách", "0", "📚", UITheme.Navy, 15 + 0 * (cardWidth + cardGap), out lblTotalSach);
            // Card 2: Sách đang cho thuê (Blue)
            card2 = CreateMetricCard("Sách đang thuê", "0", "⏳", UITheme.Blue, 15 + 1 * (cardWidth + cardGap), out lblDangThue);
            // Card 3: Khách hàng (Gold)
            card3 = CreateMetricCard("Khách hàng", "0", "👥", Color.FromArgb(202, 138, 4), 15 + 2 * (cardWidth + cardGap), out lblTotalKH);
            // Card 4: Lượt trả sách (Green)
            card4 = CreateMetricCard("Phiếu trả đã lập", "0", "🔄", Color.FromArgb(16, 185, 129), 15 + 3 * (cardWidth + cardGap), out lblTotalTra);

            pnlCards.Controls.AddRange(new Control[] { card1, card2, card3, card4 });

            // Panel Table
            pnlTable = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(15, 5, 15, 15),
                BackColor = UITheme.Page
            };

            lblRecentTitle = new Label
            {
                Text = "📌 Danh sách sách đang được thuê chưa trả (Cập nhật thời gian thực)",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = UITheme.Navy,
                Dock = DockStyle.Top,
                Height = 35
            };

            dgvRecent = new DataGridView
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
            UITheme.StyleDataGridView(dgvRecent);

            pnlTable.Controls.Add(dgvRecent);
            pnlTable.Controls.Add(lblRecentTitle);

            this.Controls.Add(pnlTable);
            this.Controls.Add(pnlCards);
        }

        private Panel CreateMetricCard(string title, string value, string icon, Color accentColor, int left, out Label lblVal)
        {
            var pnl = new Panel
            {
                Width = 240,
                Height = 100,
                Left = left,
                Top = 15,
                BackColor = Color.White
            };

            // Viền trái màu nhấn
            var stripe = new Panel
            {
                Dock = DockStyle.Left,
                Width = 6,
                BackColor = accentColor
            };

            var lblTitle = new Label
            {
                Text = title,
                ForeColor = Color.FromArgb(100, 116, 139),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                Left = 18,
                Top = 14,
                AutoSize = true
            };

            lblVal = new Label
            {
                Text = value,
                ForeColor = Color.FromArgb(15, 23, 42),
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Left = 18,
                Top = 38,
                AutoSize = true
            };

            var lblIcon = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 22F),
                Left = 175,
                Top = 22,
                AutoSize = true
            };

            pnl.Controls.AddRange(new Control[] { stripe, lblTitle, lblVal, lblIcon });
            return pnl;
        }

        public void LoadDashboardData()
        {
            try
            {
                // Thống kê số lượng
                var dtSach = _sachBLL.GetAll();
                lblTotalSach.Text = dtSach.Rows.Count.ToString();

                var dtChuaTra = _baoCaoBLL.GetSachDangThueChuaTra();
                lblDangThue.Text = dtChuaTra.Rows.Count.ToString();

                var dtKH = _khachHangBLL.GetAll();
                lblTotalKH.Text = dtKH.Rows.Count.ToString();

                var dtTra = _thueTraBLL.GetAllPhieuTra();
                lblTotalTra.Text = dtTra.Rows.Count.ToString();

                // Nạp bảng sách đang thuê chưa trả
                dgvRecent.DataSource = dtChuaTra;
                if (dgvRecent.Columns.Contains("MaThue")) dgvRecent.Columns["MaThue"].HeaderText = "Mã Thuê";
                if (dgvRecent.Columns.Contains("TenKH")) dgvRecent.Columns["TenKH"].HeaderText = "Khách Hàng";
                if (dgvRecent.Columns.Contains("MaSach")) dgvRecent.Columns["MaSach"].HeaderText = "Mã Sách";
                if (dgvRecent.Columns.Contains("TenSach")) dgvRecent.Columns["TenSach"].HeaderText = "Tên Sách";
                if (dgvRecent.Columns.Contains("SoLuong")) dgvRecent.Columns["SoLuong"].HeaderText = "Số Lượng";
                if (dgvRecent.Columns.Contains("NgayThue")) dgvRecent.Columns["NgayThue"].HeaderText = "Ngày Thuê";
                if (dgvRecent.Columns.Contains("SoNgayDaThue")) dgvRecent.Columns["SoNgayDaThue"].HeaderText = "Số Ngày Thuê";
                if (dgvRecent.Columns.Contains("TienThueTamTinh"))
                {
                    dgvRecent.Columns["TienThueTamTinh"].HeaderText = "Tiền Tạm Tính";
                    dgvRecent.Columns["TienThueTamTinh"].DefaultCellStyle.Format = "N0";
                }
                if (dgvRecent.Columns.Contains("TienDatCoc"))
                {
                    dgvRecent.Columns["TienDatCoc"].HeaderText = "Tiền Cọc";
                    dgvRecent.Columns["TienDatCoc"].DefaultCellStyle.Format = "N0";
                }
                if (dgvRecent.Columns.Contains("NhanVienLap")) dgvRecent.Columns["NhanVienLap"].HeaderText = "NV Lập";
            }
            catch (Exception ex)
            {
                // Nếu chưa mở kết nối CSDL thì bỏ qua hoặc log nhẹ
                System.Diagnostics.Debug.WriteLine("Dashboard Load Error: " + ex.Message);
            }
        }
    }
}
