using System;
using System.Drawing;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;

namespace BTL.GUI
{
    public class FormLogin : Form
    {
        private TextBox txtMaNV = null!;
        private TextBox txtMatKhau = null!;
        private ComboBox cboCaLam = null!;
        private Button btnDangNhap = null!;
        private Button btnThoat = null!;
        private Label lblError = null!;
        private readonly NhanVienBLL _nhanVienBLL = new();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Đăng nhập - Quản lý Cửa hàng Cho thuê Sách truyện UTC";
            this.Size = new Size(450, 550);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = UITheme.Page;
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            // 1. Top Strip & Header Panel
            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 135,
                BackColor = UITheme.Navy
            };

            var lblLogo = new Label
            {
                Text = "◉",
                Font = new Font("Segoe UI", 26F, FontStyle.Bold),
                ForeColor = UITheme.Yellow,
                Location = new Point(190, 8),
                Size = new Size(60, 45),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblSchool = new Label
            {
                Text = "TRƯỜNG ĐẠI HỌC GIAO THÔNG VẬN TẢI\nKHOA CÔNG NGHỆ THÔNG TIN",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(220, 231, 241),
                Location = new Point(20, 52),
                Size = new Size(400, 32),
                TextAlign = ContentAlignment.TopCenter
            };

            var lblApp = new Label
            {
                Text = "HỆ THỐNG CHO THUÊ SÁCH TRUYỆN",
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 92),
                Size = new Size(400, 25),
                TextAlign = ContentAlignment.TopCenter
            };

            pnlTop.Controls.AddRange(new Control[] { lblLogo, lblSchool, lblApp });

            // 2. Form Body
            var pnlBody = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(35, 20, 35, 20),
                BackColor = Color.White
            };

            var lblTitle = new Label
            {
                Text = "ĐĂNG NHẬP PHIÊN LÀM VIỆC",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = UITheme.Navy,
                Location = new Point(35, 15),
                Size = new Size(365, 25),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Mã nhân viên
            var lblMa = new Label { Text = "Mã nhân viên (Tài khoản):", Location = new Point(35, 52), AutoSize = true, ForeColor = UITheme.Text };
            txtMaNV = new TextBox
            {
                Location = new Point(35, 75),
                Size = new Size(365, 30),
                Text = "NV25-01",
                PlaceholderText = "Nhập mã nhân viên (VD: NV25-01)"
            };

            // Mật khẩu
            var lblMK = new Label { Text = "Mật khẩu (Số điện thoại):", Location = new Point(35, 115), AutoSize = true, ForeColor = UITheme.Text };
            txtMatKhau = new TextBox
            {
                Location = new Point(35, 138),
                Size = new Size(365, 30),
                Text = "0988123456",
                PasswordChar = '●',
                PlaceholderText = "Nhập mật khẩu (Mặc định: Số điện thoại)"
            };

            // Ca làm việc
            var lblCa = new Label { Text = "Ca làm việc của phiên:", Location = new Point(35, 178), AutoSize = true, ForeColor = UITheme.Text };
            cboCaLam = new ComboBox
            {
                Location = new Point(35, 201),
                Size = new Size(365, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboCaLam.Items.AddRange(new object[]
            {
                "Ca 1 (Sáng: 07:00 - 11:30)",
                "Ca 2 (Chiều: 13:00 - 17:30)",
                "Ca 3 (Tối: 17:30 - 21:00)"
            });
            cboCaLam.SelectedIndex = 0;

            // Nút đăng nhập
            btnDangNhap = new Button
            {
                Text = "ĐĂNG NHẬP",
                Location = new Point(35, 248),
                Size = new Size(365, 42),
                FlatStyle = FlatStyle.Flat,
                BackColor = UITheme.Blue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.Click += BtnDangNhap_Click;

            // Nút thoát
            btnThoat = new Button
            {
                Text = "Thoát chương trình",
                Location = new Point(35, 298),
                Size = new Size(365, 34),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = UITheme.Navy,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Cursor = Cursors.Hand
            };
            btnThoat.FlatAppearance.BorderColor = UITheme.Border;
            btnThoat.FlatAppearance.BorderSize = 1;
            btnThoat.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            // Thông báo lỗi
            lblError = new Label
            {
                Text = "",
                Location = new Point(35, 338),
                Size = new Size(365, 30),
                ForeColor = Color.FromArgb(220, 38, 38),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Gợi ý tài khoản demo
            var lblHint = new Label
            {
                Text = "💡 Gợi ý tài khoản demo: NV25-01 / 0988123456\n(Mật khẩu mặc định là số điện thoại đã lưu trong tNhanVien)",
                Location = new Point(35, 365),
                Size = new Size(365, 32),
                ForeColor = UITheme.Muted,
                Font = new Font("Segoe UI", 7.8F),
                TextAlign = ContentAlignment.MiddleCenter
            };

            pnlBody.Controls.AddRange(new Control[]
            {
                lblTitle, lblMa, txtMaNV, lblMK, txtMatKhau,
                lblCa, cboCaLam, btnDangNhap, btnThoat, lblError, lblHint
            });

            this.Controls.Add(pnlBody);
            this.Controls.Add(pnlTop);

            this.AcceptButton = btnDangNhap;
        }

        private void BtnDangNhap_Click(object? sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            string maNV = txtMaNV.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(maNV))
            {
                lblError.Text = "Vui lòng nhập Mã nhân viên!";
                txtMaNV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                lblError.Text = "Vui lòng nhập Mật khẩu!";
                txtMatKhau.Focus();
                return;
            }

            try
            {
                var nv = _nhanVienBLL.DangNhap(maNV, matKhau);
                if (nv != null)
                {
                    SessionContext.CurrentNhanVien = nv;
                    SessionContext.CurrentCaLam = cboCaLam.Text.Split('(')[0].Trim();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lblError.Text = "Mã nhân viên hoặc Mật khẩu không chính xác!";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Lỗi kết nối CSDL: " + ex.Message;
            }
        }
    }
}
