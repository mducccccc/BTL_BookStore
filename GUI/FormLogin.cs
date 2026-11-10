using System;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;

namespace BTL.GUI
{
    public partial class FormLogin : Form
    {
        private readonly NhanVienBLL _nhanVienBLL = new();

        public FormLogin()
        {
            InitializeComponent();
            lblHint.Text = "Gợi ý đăng nhập:\n• Quản trị viên: Tên đăng nhập = admin | Mật khẩu = admin\n• Nhân viên: Mã NV (VD: NV25-01, NV25-02) | MK = Số điện thoại";
            cboCaLam.SelectedIndex = 0;
            btnDangNhap.Click += BtnDangNhap_Click;
            btnThoat.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private void BtnDangNhap_Click(object? sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            string maNV = txtMaNV.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(maNV))
            {
                lblError.Text = "Vui lòng nhập Tên đăng nhập / Mã NV!";
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
                    lblError.Text = "Tài khoản hoặc Mật khẩu không chính xác!";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Lỗi kết nối CSDL: " + ex.Message;
            }
        }
    }
}
