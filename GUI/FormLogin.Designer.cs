namespace BTL.GUI
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblSchool = new System.Windows.Forms.Label();
            this.lblApp = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblMK = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblCa = new System.Windows.Forms.Label();
            this.cboCaLam = new System.Windows.Forms.ComboBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.pnlTop.Controls.Add(this.lblApp);
            this.pnlTop.Controls.Add(this.lblSchool);
            this.pnlTop.Controls.Add(this.lblLogo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(434, 125);
            this.pnlTop.TabIndex = 0;

            // 
            // lblLogo
            // 
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(245, 213, 42);
            this.lblLogo.Location = new System.Drawing.Point(17, 18);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(400, 32);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "BOOKSTORE PRO";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblSchool
            // 
            this.lblSchool.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSchool.ForeColor = System.Drawing.Color.FromArgb(220, 231, 241);
            this.lblSchool.Location = new System.Drawing.Point(17, 55);
            this.lblSchool.Name = "lblSchool";
            this.lblSchool.Size = new System.Drawing.Size(400, 20);
            this.lblSchool.TabIndex = 1;
            this.lblSchool.Text = "CỬA HÀNG CHO THUÊ SÁCH TRUYỆN";
            this.lblSchool.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // 
            // lblApp
            // 
            this.lblApp.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblApp.ForeColor = System.Drawing.Color.White;
            this.lblApp.Location = new System.Drawing.Point(17, 80);
            this.lblApp.Name = "lblApp";
            this.lblApp.Size = new System.Drawing.Size(400, 25);
            this.lblApp.TabIndex = 2;
            this.lblApp.Text = "HỆ THỐNG QUẢN LÝ DỊCH VỤ";
            this.lblApp.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.lblHint);
            this.pnlBody.Controls.Add(this.lblError);
            this.pnlBody.Controls.Add(this.btnThoat);
            this.pnlBody.Controls.Add(this.btnDangNhap);
            this.pnlBody.Controls.Add(this.cboCaLam);
            this.pnlBody.Controls.Add(this.lblCa);
            this.pnlBody.Controls.Add(this.txtMatKhau);
            this.pnlBody.Controls.Add(this.lblMK);
            this.pnlBody.Controls.Add(this.txtMaNV);
            this.pnlBody.Controls.Add(this.lblMa);
            this.pnlBody.Controls.Add(this.lblTitle);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 125);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(35, 20, 35, 20);
            this.pnlBody.Size = new System.Drawing.Size(434, 415);
            this.pnlBody.TabIndex = 1;

            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.lblTitle.Location = new System.Drawing.Point(35, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(365, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG NHẬP PHIÊN LÀM VIỆC";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.ForeColor = System.Drawing.Color.FromArgb(24, 59, 104);
            this.lblMa.Location = new System.Drawing.Point(35, 48);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(155, 17);
            this.lblMa.TabIndex = 1;
            this.lblMa.Text = "Mã nhân viên (Tài khoản):";

            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(35, 70);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.PlaceholderText = "Nhập mã nhân viên (VD: NV25-01)";
            this.txtMaNV.Size = new System.Drawing.Size(365, 24);
            this.txtMaNV.TabIndex = 2;
            this.txtMaNV.Text = "NV25-01";

            // 
            // lblMK
            // 
            this.lblMK.AutoSize = true;
            this.lblMK.ForeColor = System.Drawing.Color.FromArgb(24, 59, 104);
            this.lblMK.Location = new System.Drawing.Point(35, 106);
            this.lblMK.Name = "lblMK";
            this.lblMK.Size = new System.Drawing.Size(149, 17);
            this.lblMK.TabIndex = 3;
            this.lblMK.Text = "Mật khẩu (Số điện thoại):";

            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(35, 128);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '●';
            this.txtMatKhau.PlaceholderText = "Nhập mật khẩu (Mặc định: Số điện thoại)";
            this.txtMatKhau.Size = new System.Drawing.Size(365, 24);
            this.txtMatKhau.TabIndex = 4;
            this.txtMatKhau.Text = "0988123456";

            // 
            // lblCa
            // 
            this.lblCa.AutoSize = true;
            this.lblCa.ForeColor = System.Drawing.Color.FromArgb(24, 59, 104);
            this.lblCa.Location = new System.Drawing.Point(35, 166);
            this.lblCa.Name = "lblCa";
            this.lblCa.Size = new System.Drawing.Size(135, 17);
            this.lblCa.TabIndex = 5;
            this.lblCa.Text = "Ca làm việc của phiên:";

            // 
            // cboCaLam
            // 
            this.cboCaLam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaLam.FormattingEnabled = true;
            this.cboCaLam.Items.AddRange(new object[] {
            "Ca 1 (Sáng: 07:00 - 11:30)",
            "Ca 2 (Chiều: 13:00 - 17:30)",
            "Ca 3 (Tối: 17:30 - 21:00)"});
            this.cboCaLam.Location = new System.Drawing.Point(35, 188);
            this.cboCaLam.Name = "cboCaLam";
            this.cboCaLam.Size = new System.Drawing.Size(365, 25);
            this.cboCaLam.TabIndex = 6;

            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(35, 232);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(365, 42);
            this.btnDangNhap.TabIndex = 7;
            this.btnDangNhap.Text = "ĐĂNG NHẬP";
            this.btnDangNhap.UseVisualStyleBackColor = false;

            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.White;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 231, 241);
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.btnThoat.Location = new System.Drawing.Point(35, 282);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(365, 34);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát chương trình";
            this.btnThoat.UseVisualStyleBackColor = false;

            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblError.Location = new System.Drawing.Point(35, 322);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(365, 25);
            this.lblError.TabIndex = 9;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblHint
            // 
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(96, 123, 153);
            this.lblHint.Location = new System.Drawing.Point(35, 347);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(365, 35);
            this.lblHint.TabIndex = 10;
            this.lblHint.Text = "Gợi ý tài khoản: NV25-01 / 0988123456\r\n(Mật khẩu mặc định là số điện thoại đã lưu trong tNhanVien)";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 249, 252);
            this.ClientSize = new System.Drawing.Size(434, 540);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Cửa hàng Cho thuê Sách truyện BookStore";
            this.pnlTop.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblSchool;
        private System.Windows.Forms.Label lblApp;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblMK;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblCa;
        private System.Windows.Forms.ComboBox cboCaLam;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblHint;
    }
}

