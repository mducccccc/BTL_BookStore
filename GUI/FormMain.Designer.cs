namespace BTL.GUI
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.pnlTopStrip = new System.Windows.Forms.Panel();
            this.lblTopStripLeft = new System.Windows.Forms.Label();
            this.lblTopStripRight = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlNavButtons = new System.Windows.Forms.Panel();
            this.btnNavBaoCao = new System.Windows.Forms.Button();
            this.btnNavTimKiem = new System.Windows.Forms.Button();
            this.btnNavDanhMuc = new System.Windows.Forms.Button();
            this.btnNavNhanVien = new System.Windows.Forms.Button();
            this.btnNavKhachHang = new System.Windows.Forms.Button();
            this.btnNavTra = new System.Windows.Forms.Button();
            this.btnNavThue = new System.Windows.Forms.Button();
            this.btnNavSach = new System.Windows.Forms.Button();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.pnlUserFooter = new System.Windows.Forms.Panel();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblSubLogo = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblCaLam = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblCurrentModule = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);

            this.pnlTopStrip.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlNavButtons.SuspendLayout();
            this.pnlUserFooter.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.SuspendLayout();

            // pnlTopStrip
            this.pnlTopStrip.BackColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.pnlTopStrip.Controls.Add(this.lblTopStripRight);
            this.pnlTopStrip.Controls.Add(this.lblTopStripLeft);
            this.pnlTopStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopStrip.Location = new System.Drawing.Point(0, 0);
            this.pnlTopStrip.Name = "pnlTopStrip";
            this.pnlTopStrip.Size = new System.Drawing.Size(1244, 28);
            this.pnlTopStrip.TabIndex = 3;

            // lblTopStripLeft
            this.lblTopStripLeft.AutoSize = true;
            this.lblTopStripLeft.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTopStripLeft.ForeColor = System.Drawing.Color.White;
            this.lblTopStripLeft.Location = new System.Drawing.Point(16, 6);
            this.lblTopStripLeft.Name = "lblTopStripLeft";
            this.lblTopStripLeft.Size = new System.Drawing.Size(460, 15);
            this.lblTopStripLeft.TabIndex = 0;
            this.lblTopStripLeft.Text = "HỆ THỐNG QUẢN LÝ CỬA HÀNG CHO THUÊ SÁCH TRUYỆN - BOOKSTORE PRO";

            // lblTopStripRight
            this.lblTopStripRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopStripRight.AutoSize = true;
            this.lblTopStripRight.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTopStripRight.ForeColor = System.Drawing.Color.FromArgb(220, 231, 241);
            this.lblTopStripRight.Location = new System.Drawing.Point(960, 6);
            this.lblTopStripRight.Name = "lblTopStripRight";
            this.lblTopStripRight.Size = new System.Drawing.Size(270, 15);
            this.lblTopStripRight.TabIndex = 1;
            this.lblTopStripRight.Text = "Hotline: 1900 8888  |  Giờ mở cửa: 08:00 - 22:00";

            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.pnlSidebar.Controls.Add(this.pnlNavButtons);
            this.pnlSidebar.Controls.Add(this.pnlUserFooter);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 28);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(235, 692);
            this.pnlSidebar.TabIndex = 0;

            // pnlLogo
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.pnlLogo.Controls.Add(this.lblSubLogo);
            this.pnlLogo.Controls.Add(this.lblLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(235, 78);
            this.pnlLogo.TabIndex = 0;

            // lblLogo
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(245, 213, 42);
            this.lblLogo.Location = new System.Drawing.Point(16, 15);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(126, 25);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "BOOKSTORE";

            // lblSubLogo
            this.lblSubLogo.AutoSize = true;
            this.lblSubLogo.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.lblSubLogo.ForeColor = System.Drawing.Color.FromArgb(220, 231, 241);
            this.lblSubLogo.Location = new System.Drawing.Point(17, 44);
            this.lblSubLogo.Name = "lblSubLogo";
            this.lblSubLogo.Size = new System.Drawing.Size(170, 13);
            this.lblSubLogo.TabIndex = 1;
            this.lblSubLogo.Text = "HỆ THỐNG THUÊ SÁCH TRUYỆN";

            // pnlNavButtons
            this.pnlNavButtons.AutoScroll = true;
            this.pnlNavButtons.Controls.Add(this.btnNavBaoCao);
            this.pnlNavButtons.Controls.Add(this.btnNavTimKiem);
            this.pnlNavButtons.Controls.Add(this.btnNavDanhMuc);
            this.pnlNavButtons.Controls.Add(this.btnNavNhanVien);
            this.pnlNavButtons.Controls.Add(this.btnNavKhachHang);
            this.pnlNavButtons.Controls.Add(this.btnNavTra);
            this.pnlNavButtons.Controls.Add(this.btnNavThue);
            this.pnlNavButtons.Controls.Add(this.btnNavSach);
            this.pnlNavButtons.Controls.Add(this.btnNavDashboard);
            this.pnlNavButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavButtons.Location = new System.Drawing.Point(0, 78);
            this.pnlNavButtons.Name = "pnlNavButtons";
            this.pnlNavButtons.Size = new System.Drawing.Size(235, 544);
            this.pnlNavButtons.TabIndex = 1;

            // Nav buttons styling helper
            void StyleNavBtn(System.Windows.Forms.Button btn, string text, int top)
            {
                btn.Dock = System.Windows.Forms.DockStyle.Top;
                btn.Height = 46;
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = System.Drawing.Color.FromArgb(28, 66, 121);
                btn.ForeColor = System.Drawing.Color.FromArgb(245, 248, 252);
                btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
                btn.Text = text;
                btn.Cursor = System.Windows.Forms.Cursors.Hand;
            }

            StyleNavBtn(this.btnNavBaoCao, "Báo Cáo & Thống Kê", 8);
            StyleNavBtn(this.btnNavTimKiem, "Tra Cứu & Tìm Kiếm", 7);
            StyleNavBtn(this.btnNavDanhMuc, "Danh Mục Phụ Trợ", 6);
            StyleNavBtn(this.btnNavNhanVien, "Quản Lý Nhân Viên", 5);
            StyleNavBtn(this.btnNavKhachHang, "Quản Lý Khách Hàng", 4);
            StyleNavBtn(this.btnNavTra, "Nhận Trả Sách", 3);
            StyleNavBtn(this.btnNavThue, "Lập Phiếu Thuê", 2);
            StyleNavBtn(this.btnNavSach, "Quản Lý Kho Sách", 1);
            StyleNavBtn(this.btnNavDashboard, "Tổng Quan Hệ Thống", 0);

            // Re-order by controls dock top (inverse order in code)
            this.pnlNavButtons.Controls.SetChildIndex(this.btnNavDashboard, 0);
            this.pnlNavButtons.Controls.SetChildIndex(this.btnNavSach, 1);
            this.pnlNavButtons.Controls.SetChildIndex(this.btnNavThue, 2);
            this.pnlNavButtons.Controls.SetChildIndex(this.btnNavTra, 3);
            this.pnlNavButtons.Controls.SetChildIndex(this.btnNavKhachHang, 4);
            this.pnlNavButtons.Controls.SetChildIndex(this.btnNavNhanVien, 5);
            this.pnlNavButtons.Controls.SetChildIndex(this.btnNavDanhMuc, 6);
            this.pnlNavButtons.Controls.SetChildIndex(this.btnNavTimKiem, 7);
            this.pnlNavButtons.Controls.SetChildIndex(this.btnNavBaoCao, 8);

            // pnlUserFooter
            this.pnlUserFooter.BackColor = System.Drawing.Color.FromArgb(22, 53, 98);
            this.pnlUserFooter.Controls.Add(this.btnDangXuat);
            this.pnlUserFooter.Controls.Add(this.lblCurrentUser);
            this.pnlUserFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUserFooter.Location = new System.Drawing.Point(0, 622);
            this.pnlUserFooter.Name = "pnlUserFooter";
            this.pnlUserFooter.Size = new System.Drawing.Size(235, 70);
            this.pnlUserFooter.TabIndex = 2;

            // lblCurrentUser
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCurrentUser.ForeColor = System.Drawing.Color.White;
            this.lblCurrentUser.Location = new System.Drawing.Point(12, 12);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(122, 15);
            this.lblCurrentUser.TabIndex = 0;
            this.lblCurrentUser.Text = "NV: Nguyễn Văn Quản Lý";

            // btnDangXuat
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(15, 34);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(120, 26);
            this.btnDangXuat.TabIndex = 1;
            this.btnDangXuat.Text = "Đổi ca / Thoát";
            this.btnDangXuat.UseVisualStyleBackColor = false;

            // pnlTopBar
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.Add(this.lblCaLam);
            this.pnlTopBar.Controls.Add(this.lblClock);
            this.pnlTopBar.Controls.Add(this.lblCurrentModule);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(235, 28);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1009, 60);
            this.pnlTopBar.TabIndex = 1;

            // lblCurrentModule
            this.lblCurrentModule.AutoSize = true;
            this.lblCurrentModule.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblCurrentModule.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.lblCurrentModule.Location = new System.Drawing.Point(20, 18);
            this.lblCurrentModule.Name = "lblCurrentModule";
            this.lblCurrentModule.Size = new System.Drawing.Size(206, 23);
            this.lblCurrentModule.TabIndex = 0;
            this.lblCurrentModule.Text = "TỔNG QUAN HỆ THỐNG";

            // lblClock
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(96, 123, 153);
            this.lblClock.Location = new System.Drawing.Point(750, 21);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(150, 17);
            this.lblClock.TabIndex = 1;
            this.lblClock.Text = "24/10/2026 --:--:--";

            // lblCaLam
            this.lblCaLam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCaLam.AutoSize = true;
            this.lblCaLam.BackColor = System.Drawing.Color.FromArgb(234, 245, 252);
            this.lblCaLam.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCaLam.ForeColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.lblCaLam.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.lblCaLam.Location = new System.Drawing.Point(620, 17);
            this.lblCaLam.Name = "lblCaLam";
            this.lblCaLam.Size = new System.Drawing.Size(95, 23);
            this.lblCaLam.TabIndex = 2;
            this.lblCaLam.Text = "Ca 1 (Sáng)";

            // pnlContainer
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(244, 249, 252);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(235, 88);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1009, 632);
            this.pnlContainer.TabIndex = 2;

            // FormMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 720);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlTopStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Cửa hàng Cho thuê Sách truyện - BookStore Pro";

            this.pnlTopStrip.ResumeLayout(false);
            this.pnlTopStrip.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlNavButtons.ResumeLayout(false);
            this.pnlUserFooter.ResumeLayout(false);
            this.pnlUserFooter.PerformLayout();
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTopStrip;
        private System.Windows.Forms.Label lblTopStripLeft;
        private System.Windows.Forms.Label lblTopStripRight;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblSubLogo;
        private System.Windows.Forms.Panel pnlNavButtons;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavSach;
        private System.Windows.Forms.Button btnNavThue;
        private System.Windows.Forms.Button btnNavTra;
        private System.Windows.Forms.Button btnNavKhachHang;
        private System.Windows.Forms.Button btnNavNhanVien;
        private System.Windows.Forms.Button btnNavDanhMuc;
        private System.Windows.Forms.Button btnNavTimKiem;
        private System.Windows.Forms.Button btnNavBaoCao;
        private System.Windows.Forms.Panel pnlUserFooter;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblCurrentModule;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblCaLam;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Timer timerClock;
    }
}
