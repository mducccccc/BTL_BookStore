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

            this.pnlSidebar.SuspendLayout();
            this.pnlNavButtons.SuspendLayout();
            this.pnlUserFooter.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.SuspendLayout();

            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlSidebar.Controls.Add(this.pnlNavButtons);
            this.pnlSidebar.Controls.Add(this.pnlUserFooter);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(235, 720);
            this.pnlSidebar.TabIndex = 0;

            // pnlLogo
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlLogo.Controls.Add(this.lblSubLogo);
            this.pnlLogo.Controls.Add(this.lblLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(235, 80);
            this.pnlLogo.TabIndex = 0;

            // lblLogo
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(18, 16);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(166, 25);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "📖 BOOKSTORE";

            // lblSubLogo
            this.lblSubLogo.AutoSize = true;
            this.lblSubLogo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubLogo.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblSubLogo.Location = new System.Drawing.Point(46, 43);
            this.lblSubLogo.Name = "lblSubLogo";
            this.lblSubLogo.Size = new System.Drawing.Size(135, 15);
            this.lblSubLogo.TabIndex = 1;
            this.lblSubLogo.Text = "Quản lý thuê sách truyện";

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
            this.pnlNavButtons.Location = new System.Drawing.Point(0, 80);
            this.pnlNavButtons.Name = "pnlNavButtons";
            this.pnlNavButtons.Size = new System.Drawing.Size(235, 570);
            this.pnlNavButtons.TabIndex = 1;

            // Nav buttons styling helper
            void StyleNavBtn(System.Windows.Forms.Button btn, string text, int top)
            {
                btn.Dock = System.Windows.Forms.DockStyle.Top;
                btn.Height = 48;
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
                btn.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
                btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
                btn.Text = text;
                btn.Cursor = System.Windows.Forms.Cursors.Hand;
            }

            StyleNavBtn(this.btnNavBaoCao, "📊  Báo Cáo & Thống Kê", 8);
            StyleNavBtn(this.btnNavTimKiem, "🔍  Tra Cứu / Lọc", 7);
            StyleNavBtn(this.btnNavDanhMuc, "📑  Danh Mục Khác", 6);
            StyleNavBtn(this.btnNavNhanVien, "👔  Quản Lý Nhân Viên", 5);
            StyleNavBtn(this.btnNavKhachHang, "👥  Quản Lý Khách Hàng", 4);
            StyleNavBtn(this.btnNavTra, "🔄  Nhận Trả Sách", 3);
            StyleNavBtn(this.btnNavThue, "📝  Lập Phiếu Thuê", 2);
            StyleNavBtn(this.btnNavSach, "📚  Quản Lý Sách", 1);
            StyleNavBtn(this.btnNavDashboard, "🏠  Tổng Quan", 0);

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
            this.pnlUserFooter.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlUserFooter.Controls.Add(this.btnDangXuat);
            this.pnlUserFooter.Controls.Add(this.lblCurrentUser);
            this.pnlUserFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUserFooter.Location = new System.Drawing.Point(0, 650);
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
            this.lblCurrentUser.Text = "👤 NV: Nguyễn Văn Quản Lý";

            // btnDangXuat
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnDangXuat.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnDangXuat.Location = new System.Drawing.Point(15, 34);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(120, 24);
            this.btnDangXuat.TabIndex = 1;
            this.btnDangXuat.Text = "Đổi ca / Thoát";
            this.btnDangXuat.UseVisualStyleBackColor = false;

            // pnlTopBar
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.Add(this.lblCaLam);
            this.pnlTopBar.Controls.Add(this.lblClock);
            this.pnlTopBar.Controls.Add(this.lblCurrentModule);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(235, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1009, 65);
            this.pnlTopBar.TabIndex = 1;

            // lblCurrentModule
            this.lblCurrentModule.AutoSize = true;
            this.lblCurrentModule.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCurrentModule.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblCurrentModule.Location = new System.Drawing.Point(20, 19);
            this.lblCurrentModule.Name = "lblCurrentModule";
            this.lblCurrentModule.Size = new System.Drawing.Size(206, 25);
            this.lblCurrentModule.TabIndex = 0;
            this.lblCurrentModule.Text = "TỔNG QUAN HỆ THỐNG";

            // lblClock
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblClock.Location = new System.Drawing.Point(750, 23);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(150, 17);
            this.lblClock.TabIndex = 1;
            this.lblClock.Text = "24/10/2026 --:--:--";

            // lblCaLam
            this.lblCaLam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCaLam.AutoSize = true;
            this.lblCaLam.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.lblCaLam.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCaLam.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblCaLam.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblCaLam.Location = new System.Drawing.Point(620, 20);
            this.lblCaLam.Name = "lblCaLam";
            this.lblCaLam.Size = new System.Drawing.Size(95, 21);
            this.lblCaLam.TabIndex = 2;
            this.lblCaLam.Text = "Ca 1 (Sáng)";

            // pnlContainer
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(235, 65);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1009, 655);
            this.pnlContainer.TabIndex = 2;

            // FormMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 720);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Cửa hàng Cho thuê Sách truyện - BTL Lập trình trực quan";

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
