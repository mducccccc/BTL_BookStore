using System;
using System.Drawing;
using System.Windows.Forms;
using BTL.DTO;

namespace BTL.GUI
{
    public partial class FormMain : Form
    {
        private Button? _activeNavButton;
        private UserControl? _currentView;

        public FormMain()
        {
            InitializeComponent();
            SetupEvents();
            InitSessionData();
            // Mở mặc định trang Tổng quan (Dashboard)
            btnNavDashboard.PerformClick();
        }

        private void SetupEvents()
        {
            // Sự kiện điều hướng
            btnNavDashboard.Click += (s, e) => SwitchView(btnNavDashboard, new UC_Dashboard(), "TỔNG QUAN HỆ THỐNG");
            btnNavSach.Click += (s, e) => SwitchView(btnNavSach, new UC_Sach(), "QUẢN LÝ SÁCH TRUYỆN");
            btnNavThue.Click += (s, e) => SwitchView(btnNavThue, new UC_ThueSach(), "LẬP PHIẾU THUÊ SÁCH");
            btnNavTra.Click += (s, e) => SwitchView(btnNavTra, new UC_Placeholder("🔄 NHẬN TRẢ SÁCH & TÍNH TIỀN", "Yêu cầu 3: Lọc sách chưa trả | Yêu cầu 4: Tính tiền thuê + Phạt | Yêu cầu 2: Hoàn kho (Bước 7)"), "NHẬN TRẢ SÁCH");
            btnNavKhachHang.Click += (s, e) => SwitchView(btnNavKhachHang, new UC_KhachHang(), "QUẢN LÝ KHÁCH HÀNG");
            btnNavNhanVien.Click += (s, e) => SwitchView(btnNavNhanVien, new UC_NhanVien(), "QUẢN LÝ NHÂN VIÊN");
            btnNavDanhMuc.Click += (s, e) => SwitchView(btnNavDanhMuc, new UC_DanhMuc(), "DANH MỤC KHÁC");
            btnNavTimKiem.Click += (s, e) => SwitchView(btnNavTimKiem, new UC_Placeholder("🔍 TRA CỨU & TÌM KIẾM ĐA TIÊU CHÍ", "Yêu cầu 5: Tìm kiếm Sách | Yêu cầu 6: Tìm kiếm Nhân viên (Bước 8)"), "TRA CỨU & TÌM KIẾM");
            btnNavBaoCao.Click += (s, e) => SwitchView(btnNavBaoCao, new UC_Placeholder("📊 BÁO CÁO THỐNG KÊ & DOANH THU", "Yêu cầu 7: Sách chưa trả | Yêu cầu 8: Doanh thu T/Q/N | Yêu cầu 9: Top 5 sách (Bước 9)"), "BÁO CÁO & THỐNG KÊ");

            // Nút đăng xuất / thoát
            btnDangXuat.Click += BtnDangXuat_Click;

            // Timer đồng hồ
            timerClock.Interval = 1000;
            timerClock.Tick += (s, e) =>
            {
                lblClock.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy  HH:mm:ss");
            };
            timerClock.Start();
            lblClock.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy  HH:mm:ss");
        }

        private void InitSessionData()
        {
            if (SessionContext.CurrentNhanVien == null)
            {
                // Khởi tạo nhân viên mặc định phục vụ chạy thử nghiệm
                SessionContext.CurrentNhanVien = new NhanVienDTO
                {
                    MaNV = "NV25-01",
                    TenNV = "Nguyễn Văn Quản Lý",
                    DienThoai = "0988123456"
                };
            }

            lblCurrentUser.Text = $"👤 NV: {SessionContext.CurrentNhanVien.TenNV}";
            lblCaLam.Text = $"Ca trực: {SessionContext.CurrentCaLam}";
        }

        private void SwitchView(Button navButton, UserControl viewControl, string title)
        {
            // Đổi giao diện nút bấm
            if (_activeNavButton != null)
            {
                _activeNavButton.BackColor = Color.FromArgb(15, 23, 42);
                _activeNavButton.ForeColor = Color.FromArgb(203, 213, 225);
                _activeNavButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }

            _activeNavButton = navButton;
            _activeNavButton.BackColor = Color.FromArgb(30, 41, 59);
            _activeNavButton.ForeColor = Color.FromArgb(56, 189, 248); // Sky blue
            _activeNavButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Cập nhật tiêu đề module
            lblCurrentModule.Text = title;

            // Chuyển UserControl
            pnlContainer.SuspendLayout();
            if (_currentView != null)
            {
                pnlContainer.Controls.Remove(_currentView);
                _currentView.Dispose();
            }

            _currentView = viewControl;
            _currentView.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(_currentView);
            pnlContainer.ResumeLayout();
        }

        private void BtnDangXuat_Click(object? sender, EventArgs e)
        {
            var res = MessageBox.Show(
                "Bạn có muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
