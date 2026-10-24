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
            btnNavTra.Click += (s, e) => SwitchView(btnNavTra, new UC_TraSach(), "NHẬN TRẢ SÁCH");
            btnNavKhachHang.Click += (s, e) => SwitchView(btnNavKhachHang, new UC_KhachHang(), "QUẢN LÝ KHÁCH HÀNG");
            btnNavNhanVien.Click += (s, e) => SwitchView(btnNavNhanVien, new UC_NhanVien(), "QUẢN LÝ NHÂN VIÊN");
            btnNavDanhMuc.Click += (s, e) => SwitchView(btnNavDanhMuc, new UC_DanhMuc(), "DANH MỤC KHÁC");
            btnNavTimKiem.Click += (s, e) => SwitchView(btnNavTimKiem, new UC_TimKiem(), "TRA CỨU & TÌM KIẾM");
            btnNavBaoCao.Click += (s, e) => SwitchView(btnNavBaoCao, new UC_BaoCao(), "BÁO CÁO & THỐNG KÊ");

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
                _activeNavButton.BackColor = UITheme.Navy;
                _activeNavButton.ForeColor = Color.FromArgb(245, 248, 252);
                _activeNavButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            }

            _activeNavButton = navButton;
            _activeNavButton.BackColor = UITheme.NavActiveBg;
            _activeNavButton.ForeColor = UITheme.Yellow;
            _activeNavButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            // Cập nhật tiêu đề module (Breadcrumb phong cách UTC Rmd)
            lblCurrentModule.Text = $"UTC  /  QUẢN TRỊ  /  {title}";

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
                "Bạn có muốn đăng xuất tài khoản hiện tại không?\n\n- Chọn Yes: Đăng xuất để đổi ca trực / tài khoản\n- Chọn No: Thoát hoàn toàn chương trình\n- Chọn Cancel: Tiếp tục làm việc",
                "Xác nhận phiên làm việc",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                this.Hide();
                using var login = new FormLogin();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    InitSessionData();
                    this.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
            else if (res == DialogResult.No)
            {
                Application.Exit();
            }
        }
    }
}
