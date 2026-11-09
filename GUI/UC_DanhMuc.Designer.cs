namespace BTL.GUI
{
    partial class UC_DanhMuc
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.tabDanhMuc = new System.Windows.Forms.TabControl();
            this.tabViPham = new System.Windows.Forms.TabPage();
            this.dgvViPham = new System.Windows.Forms.DataGridView();
            this.pnlTopVP = new System.Windows.Forms.Panel();
            this.btnMoiVP = new System.Windows.Forms.Button();
            this.btnXoaVP = new System.Windows.Forms.Button();
            this.btnSuaVP = new System.Windows.Forms.Button();
            this.btnThemVP = new System.Windows.Forms.Button();
            this.numTienPhat = new System.Windows.Forms.NumericUpDown();
            this.lblTien = new System.Windows.Forms.Label();
            this.txtTenVP = new System.Windows.Forms.TextBox();
            this.lblTenVP = new System.Windows.Forms.Label();
            this.txtMaVP = new System.Windows.Forms.TextBox();
            this.lblMaVP = new System.Windows.Forms.Label();
            this.tabTacGia = new System.Windows.Forms.TabPage();
            this.dgvTacGia = new System.Windows.Forms.DataGridView();
            this.pnlTopTG = new System.Windows.Forms.Panel();
            this.btnMoiTG = new System.Windows.Forms.Button();
            this.btnXoaTG = new System.Windows.Forms.Button();
            this.btnSuaTG = new System.Windows.Forms.Button();
            this.btnThemTG = new System.Windows.Forms.Button();
            this.txtDiaChiTG = new System.Windows.Forms.TextBox();
            this.lblDC_TG = new System.Windows.Forms.Label();
            this.dtpNgaySinhTG = new System.Windows.Forms.DateTimePicker();
            this.lblNS = new System.Windows.Forms.Label();
            this.cboGioiTinhTG = new System.Windows.Forms.ComboBox();
            this.lblGT = new System.Windows.Forms.Label();
            this.txtTenTG = new System.Windows.Forms.TextBox();
            this.lblTenTG = new System.Windows.Forms.Label();
            this.txtMaTG = new System.Windows.Forms.TextBox();
            this.lblMaTG = new System.Windows.Forms.Label();
            this.tabNXB = new System.Windows.Forms.TabPage();
            this.dgvNXB = new System.Windows.Forms.DataGridView();
            this.pnlTopNXB = new System.Windows.Forms.Panel();
            this.btnXoaNXB = new System.Windows.Forms.Button();
            this.btnSuaNXB = new System.Windows.Forms.Button();
            this.btnThemNXB = new System.Windows.Forms.Button();
            this.txtDiaChiNXB = new System.Windows.Forms.TextBox();
            this.lblDC_NXB = new System.Windows.Forms.Label();
            this.txtPhoneNXB = new System.Windows.Forms.TextBox();
            this.lblPhoneNXB = new System.Windows.Forms.Label();
            this.txtTenNXB = new System.Windows.Forms.TextBox();
            this.lblTenNXB = new System.Windows.Forms.Label();
            this.txtMaNXB = new System.Windows.Forms.TextBox();
            this.lblMaNXB = new System.Windows.Forms.Label();
            this.tabCaLam = new System.Windows.Forms.TabPage();
            this.dgvCaLam = new System.Windows.Forms.DataGridView();
            this.pnlTopCa = new System.Windows.Forms.Panel();
            this.btnXoaCa = new System.Windows.Forms.Button();
            this.btnSuaCa = new System.Windows.Forms.Button();
            this.btnThemCa = new System.Windows.Forms.Button();
            this.txtTenCa = new System.Windows.Forms.TextBox();
            this.lblTenCa = new System.Windows.Forms.Label();
            this.txtMaCa = new System.Windows.Forms.TextBox();
            this.lblMaCa = new System.Windows.Forms.Label();
            this.tabDanhMuc.SuspendLayout();
            this.tabViPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViPham)).BeginInit();
            this.pnlTopVP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTienPhat)).BeginInit();
            this.tabTacGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTacGia)).BeginInit();
            this.pnlTopTG.SuspendLayout();
            this.tabNXB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNXB)).BeginInit();
            this.pnlTopNXB.SuspendLayout();
            this.tabCaLam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaLam)).BeginInit();
            this.pnlTopCa.SuspendLayout();
            this.SuspendLayout();

            // 
            // tabDanhMuc
            // 
            this.tabDanhMuc.Controls.Add(this.tabViPham);
            this.tabDanhMuc.Controls.Add(this.tabTacGia);
            this.tabDanhMuc.Controls.Add(this.tabNXB);
            this.tabDanhMuc.Controls.Add(this.tabCaLam);
            this.tabDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.tabDanhMuc.Name = "tabDanhMuc";
            this.tabDanhMuc.Padding = new System.Drawing.Point(16, 8);
            this.tabDanhMuc.SelectedIndex = 0;
            this.tabDanhMuc.Size = new System.Drawing.Size(1000, 700);
            this.tabDanhMuc.TabIndex = 0;

            // 
            // tabViPham
            // 
            this.tabViPham.BackColor = System.Drawing.Color.White;
            this.tabViPham.Controls.Add(this.dgvViPham);
            this.tabViPham.Controls.Add(this.pnlTopVP);
            this.tabViPham.Location = new System.Drawing.Point(4, 36);
            this.tabViPham.Name = "tabViPham";
            this.tabViPham.Padding = new System.Windows.Forms.Padding(3);
            this.tabViPham.Size = new System.Drawing.Size(992, 660);
            this.tabViPham.TabIndex = 0;
            this.tabViPham.Text = "Vi Phạm & Tiền Phạt";

            // 
            // dgvViPham
            // 
            this.dgvViPham.AllowUserToAddRows = false;
            this.dgvViPham.AllowUserToDeleteRows = false;
            this.dgvViPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvViPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvViPham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvViPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvViPham.Location = new System.Drawing.Point(3, 133);
            this.dgvViPham.Name = "dgvViPham";
            this.dgvViPham.ReadOnly = true;
            this.dgvViPham.RowHeadersVisible = false;
            this.dgvViPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvViPham.Size = new System.Drawing.Size(986, 524);
            this.dgvViPham.TabIndex = 1;

            // 
            // pnlTopVP
            // 
            this.pnlTopVP.Controls.Add(this.btnMoiVP);
            this.pnlTopVP.Controls.Add(this.btnXoaVP);
            this.pnlTopVP.Controls.Add(this.btnSuaVP);
            this.pnlTopVP.Controls.Add(this.btnThemVP);
            this.pnlTopVP.Controls.Add(this.numTienPhat);
            this.pnlTopVP.Controls.Add(this.lblTien);
            this.pnlTopVP.Controls.Add(this.txtTenVP);
            this.pnlTopVP.Controls.Add(this.lblTenVP);
            this.pnlTopVP.Controls.Add(this.txtMaVP);
            this.pnlTopVP.Controls.Add(this.lblMaVP);
            this.pnlTopVP.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopVP.Location = new System.Drawing.Point(3, 3);
            this.pnlTopVP.Name = "pnlTopVP";
            this.pnlTopVP.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTopVP.Size = new System.Drawing.Size(986, 130);
            this.pnlTopVP.TabIndex = 0;

            // 
            // btnMoiVP
            // 
            this.btnMoiVP.BackColor = System.Drawing.Color.FromArgb(96, 123, 153);
            this.btnMoiVP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoiVP.FlatAppearance.BorderSize = 0;
            this.btnMoiVP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoiVP.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnMoiVP.ForeColor = System.Drawing.Color.White;
            this.btnMoiVP.Location = new System.Drawing.Point(570, 54);
            this.btnMoiVP.Name = "btnMoiVP";
            this.btnMoiVP.Size = new System.Drawing.Size(80, 30);
            this.btnMoiVP.TabIndex = 9;
            this.btnMoiVP.Text = "Làm mới";
            this.btnMoiVP.UseVisualStyleBackColor = false;

            // 
            // btnXoaVP
            // 
            this.btnXoaVP.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnXoaVP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaVP.FlatAppearance.BorderSize = 0;
            this.btnXoaVP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaVP.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaVP.ForeColor = System.Drawing.Color.White;
            this.btnXoaVP.Location = new System.Drawing.Point(480, 54);
            this.btnXoaVP.Name = "btnXoaVP";
            this.btnXoaVP.Size = new System.Drawing.Size(80, 30);
            this.btnXoaVP.TabIndex = 8;
            this.btnXoaVP.Text = "Xóa";
            this.btnXoaVP.UseVisualStyleBackColor = false;

            // 
            // btnSuaVP
            // 
            this.btnSuaVP.BackColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.btnSuaVP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaVP.FlatAppearance.BorderSize = 0;
            this.btnSuaVP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaVP.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSuaVP.ForeColor = System.Drawing.Color.White;
            this.btnSuaVP.Location = new System.Drawing.Point(390, 54);
            this.btnSuaVP.Name = "btnSuaVP";
            this.btnSuaVP.Size = new System.Drawing.Size(80, 30);
            this.btnSuaVP.TabIndex = 7;
            this.btnSuaVP.Text = "Sửa";
            this.btnSuaVP.UseVisualStyleBackColor = false;

            // 
            // btnThemVP
            // 
            this.btnThemVP.BackColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.btnThemVP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemVP.FlatAppearance.BorderSize = 0;
            this.btnThemVP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemVP.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnThemVP.ForeColor = System.Drawing.Color.White;
            this.btnThemVP.Location = new System.Drawing.Point(300, 54);
            this.btnThemVP.Name = "btnThemVP";
            this.btnThemVP.Size = new System.Drawing.Size(80, 30);
            this.btnThemVP.TabIndex = 6;
            this.btnThemVP.Text = "Thêm";
            this.btnThemVP.UseVisualStyleBackColor = false;

            // 
            // numTienPhat
            // 
            this.numTienPhat.Increment = new decimal(new int[] { 5000, 0, 0, 0 });
            this.numTienPhat.Location = new System.Drawing.Point(120, 56);
            this.numTienPhat.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numTienPhat.Name = "numTienPhat";
            this.numTienPhat.Size = new System.Drawing.Size(150, 24);
            this.numTienPhat.TabIndex = 5;
            this.numTienPhat.ThousandsSeparator = true;

            // 
            // lblTien
            // 
            this.lblTien.AutoSize = true;
            this.lblTien.Location = new System.Drawing.Point(20, 60);
            this.lblTien.Name = "lblTien";
            this.lblTien.Size = new System.Drawing.Size(66, 17);
            this.lblTien.TabIndex = 4;
            this.lblTien.Text = "Tiền phạt:";

            // 
            // txtTenVP
            // 
            this.txtTenVP.Location = new System.Drawing.Point(370, 16);
            this.txtTenVP.Name = "txtTenVP";
            this.txtTenVP.Size = new System.Drawing.Size(300, 24);
            this.txtTenVP.TabIndex = 3;

            // 
            // lblTenVP
            // 
            this.lblTenVP.AutoSize = true;
            this.lblTenVP.Location = new System.Drawing.Point(270, 20);
            this.lblTenVP.Name = "lblTenVP";
            this.lblTenVP.Size = new System.Drawing.Size(80, 17);
            this.lblTenVP.TabIndex = 2;
            this.lblTenVP.Text = "Tên vi phạm:";

            // 
            // txtMaVP
            // 
            this.txtMaVP.Location = new System.Drawing.Point(120, 16);
            this.txtMaVP.Name = "txtMaVP";
            this.txtMaVP.Size = new System.Drawing.Size(120, 24);
            this.txtMaVP.TabIndex = 1;

            // 
            // lblMaVP
            // 
            this.lblMaVP.AutoSize = true;
            this.lblMaVP.Location = new System.Drawing.Point(20, 20);
            this.lblMaVP.Name = "lblMaVP";
            this.lblMaVP.Size = new System.Drawing.Size(77, 17);
            this.lblMaVP.TabIndex = 0;
            this.lblMaVP.Text = "Mã vi phạm:";

            // 
            // tabTacGia
            // 
            this.tabTacGia.BackColor = System.Drawing.Color.White;
            this.tabTacGia.Controls.Add(this.dgvTacGia);
            this.tabTacGia.Controls.Add(this.pnlTopTG);
            this.tabTacGia.Location = new System.Drawing.Point(4, 36);
            this.tabTacGia.Name = "tabTacGia";
            this.tabTacGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabTacGia.Size = new System.Drawing.Size(992, 660);
            this.tabTacGia.TabIndex = 1;
            this.tabTacGia.Text = "Tác Giả";

            // 
            // dgvTacGia
            // 
            this.dgvTacGia.AllowUserToAddRows = false;
            this.dgvTacGia.AllowUserToDeleteRows = false;
            this.dgvTacGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTacGia.BackgroundColor = System.Drawing.Color.White;
            this.dgvTacGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvTacGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTacGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTacGia.Location = new System.Drawing.Point(3, 143);
            this.dgvTacGia.Name = "dgvTacGia";
            this.dgvTacGia.ReadOnly = true;
            this.dgvTacGia.RowHeadersVisible = false;
            this.dgvTacGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTacGia.Size = new System.Drawing.Size(986, 514);
            this.dgvTacGia.TabIndex = 1;

            // 
            // pnlTopTG
            // 
            this.pnlTopTG.Controls.Add(this.btnMoiTG);
            this.pnlTopTG.Controls.Add(this.btnXoaTG);
            this.pnlTopTG.Controls.Add(this.btnSuaTG);
            this.pnlTopTG.Controls.Add(this.btnThemTG);
            this.pnlTopTG.Controls.Add(this.txtDiaChiTG);
            this.pnlTopTG.Controls.Add(this.lblDC_TG);
            this.pnlTopTG.Controls.Add(this.dtpNgaySinhTG);
            this.pnlTopTG.Controls.Add(this.lblNS);
            this.pnlTopTG.Controls.Add(this.cboGioiTinhTG);
            this.pnlTopTG.Controls.Add(this.lblGT);
            this.pnlTopTG.Controls.Add(this.txtTenTG);
            this.pnlTopTG.Controls.Add(this.lblTenTG);
            this.pnlTopTG.Controls.Add(this.txtMaTG);
            this.pnlTopTG.Controls.Add(this.lblMaTG);
            this.pnlTopTG.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopTG.Location = new System.Drawing.Point(3, 3);
            this.pnlTopTG.Name = "pnlTopTG";
            this.pnlTopTG.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTopTG.Size = new System.Drawing.Size(986, 140);
            this.pnlTopTG.TabIndex = 0;

            // 
            // btnMoiTG
            // 
            this.btnMoiTG.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnMoiTG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoiTG.FlatAppearance.BorderSize = 0;
            this.btnMoiTG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoiTG.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnMoiTG.ForeColor = System.Drawing.Color.White;
            this.btnMoiTG.Location = new System.Drawing.Point(290, 98);
            this.btnMoiTG.Name = "btnMoiTG";
            this.btnMoiTG.Size = new System.Drawing.Size(80, 30);
            this.btnMoiTG.TabIndex = 13;
            this.btnMoiTG.Text = "Làm mới";
            this.btnMoiTG.UseVisualStyleBackColor = false;

            // 
            // btnXoaTG
            // 
            this.btnXoaTG.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnXoaTG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaTG.FlatAppearance.BorderSize = 0;
            this.btnXoaTG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTG.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaTG.ForeColor = System.Drawing.Color.White;
            this.btnXoaTG.Location = new System.Drawing.Point(200, 98);
            this.btnXoaTG.Name = "btnXoaTG";
            this.btnXoaTG.Size = new System.Drawing.Size(80, 30);
            this.btnXoaTG.TabIndex = 12;
            this.btnXoaTG.Text = "Xóa";
            this.btnXoaTG.UseVisualStyleBackColor = false;

            // 
            // btnSuaTG
            // 
            this.btnSuaTG.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSuaTG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaTG.FlatAppearance.BorderSize = 0;
            this.btnSuaTG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaTG.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSuaTG.ForeColor = System.Drawing.Color.White;
            this.btnSuaTG.Location = new System.Drawing.Point(110, 98);
            this.btnSuaTG.Name = "btnSuaTG";
            this.btnSuaTG.Size = new System.Drawing.Size(80, 30);
            this.btnSuaTG.TabIndex = 11;
            this.btnSuaTG.Text = "Sửa";
            this.btnSuaTG.UseVisualStyleBackColor = false;

            // 
            // btnThemTG
            // 
            this.btnThemTG.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnThemTG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemTG.FlatAppearance.BorderSize = 0;
            this.btnThemTG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemTG.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnThemTG.ForeColor = System.Drawing.Color.White;
            this.btnThemTG.Location = new System.Drawing.Point(20, 98);
            this.btnThemTG.Name = "btnThemTG";
            this.btnThemTG.Size = new System.Drawing.Size(80, 30);
            this.btnThemTG.TabIndex = 10;
            this.btnThemTG.Text = "Thêm";
            this.btnThemTG.UseVisualStyleBackColor = false;

            // 
            // txtDiaChiTG
            // 
            this.txtDiaChiTG.Location = new System.Drawing.Point(290, 56);
            this.txtDiaChiTG.Name = "txtDiaChiTG";
            this.txtDiaChiTG.Size = new System.Drawing.Size(380, 24);
            this.txtDiaChiTG.TabIndex = 9;

            // 
            // lblDC_TG
            // 
            this.lblDC_TG.AutoSize = true;
            this.lblDC_TG.Location = new System.Drawing.Point(220, 60);
            this.lblDC_TG.Name = "lblDC_TG";
            this.lblDC_TG.Size = new System.Drawing.Size(50, 17);
            this.lblDC_TG.TabIndex = 8;
            this.lblDC_TG.Text = "Địa chỉ:";

            // 
            // dtpNgaySinhTG
            // 
            this.dtpNgaySinhTG.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinhTG.Location = new System.Drawing.Point(80, 56);
            this.dtpNgaySinhTG.Name = "dtpNgaySinhTG";
            this.dtpNgaySinhTG.Size = new System.Drawing.Size(130, 24);
            this.dtpNgaySinhTG.TabIndex = 7;

            // 
            // lblNS
            // 
            this.lblNS.AutoSize = true;
            this.lblNS.Location = new System.Drawing.Point(20, 60);
            this.lblNS.Name = "lblNS";
            this.lblNS.Size = new System.Drawing.Size(69, 17);
            this.lblNS.TabIndex = 6;
            this.lblNS.Text = "Ngày sinh:";

            // 
            // cboGioiTinhTG
            // 
            this.cboGioiTinhTG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinhTG.FormattingEnabled = true;
            this.cboGioiTinhTG.Items.AddRange(new object[] {
            "Nam (M)",
            "Nữ (F)"});
            this.cboGioiTinhTG.Location = new System.Drawing.Point(580, 16);
            this.cboGioiTinhTG.Name = "cboGioiTinhTG";
            this.cboGioiTinhTG.Size = new System.Drawing.Size(90, 25);
            this.cboGioiTinhTG.TabIndex = 5;

            // 
            // lblGT
            // 
            this.lblGT.AutoSize = true;
            this.lblGT.Location = new System.Drawing.Point(510, 20);
            this.lblGT.Name = "lblGT";
            this.lblGT.Size = new System.Drawing.Size(59, 17);
            this.lblGT.TabIndex = 4;
            this.lblGT.Text = "Giới tính:";

            // 
            // txtTenTG
            // 
            this.txtTenTG.Location = new System.Drawing.Point(290, 16);
            this.txtTenTG.Name = "txtTenTG";
            this.txtTenTG.Size = new System.Drawing.Size(200, 24);
            this.txtTenTG.TabIndex = 3;

            // 
            // lblTenTG
            // 
            this.lblTenTG.AutoSize = true;
            this.lblTenTG.Location = new System.Drawing.Point(220, 20);
            this.lblTenTG.Name = "lblTenTG";
            this.lblTenTG.Size = new System.Drawing.Size(53, 17);
            this.lblTenTG.TabIndex = 2;
            this.lblTenTG.Text = "Tên TG:";

            // 
            // txtMaTG
            // 
            this.txtMaTG.Location = new System.Drawing.Point(80, 16);
            this.txtMaTG.Name = "txtMaTG";
            this.txtMaTG.Size = new System.Drawing.Size(110, 24);
            this.txtMaTG.TabIndex = 1;

            // 
            // lblMaTG
            // 
            this.lblMaTG.AutoSize = true;
            this.lblMaTG.Location = new System.Drawing.Point(20, 20);
            this.lblMaTG.Name = "lblMaTG";
            this.lblMaTG.Size = new System.Drawing.Size(50, 17);
            this.lblMaTG.TabIndex = 0;
            this.lblMaTG.Text = "Mã TG:";

            // 
            // tabNXB
            // 
            this.tabNXB.BackColor = System.Drawing.Color.White;
            this.tabNXB.Controls.Add(this.dgvNXB);
            this.tabNXB.Controls.Add(this.pnlTopNXB);
            this.tabNXB.Location = new System.Drawing.Point(4, 36);
            this.tabNXB.Name = "tabNXB";
            this.tabNXB.Padding = new System.Windows.Forms.Padding(3);
            this.tabNXB.Size = new System.Drawing.Size(992, 660);
            this.tabNXB.TabIndex = 2;
            this.tabNXB.Text = "Nhà Xuất Bản";

            // 
            // dgvNXB
            // 
            this.dgvNXB.AllowUserToAddRows = false;
            this.dgvNXB.AllowUserToDeleteRows = false;
            this.dgvNXB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNXB.BackgroundColor = System.Drawing.Color.White;
            this.dgvNXB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvNXB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNXB.Location = new System.Drawing.Point(3, 133);
            this.dgvNXB.Name = "dgvNXB";
            this.dgvNXB.ReadOnly = true;
            this.dgvNXB.RowHeadersVisible = false;
            this.dgvNXB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNXB.Size = new System.Drawing.Size(986, 524);
            this.dgvNXB.TabIndex = 1;

            // 
            // pnlTopNXB
            // 
            this.pnlTopNXB.Controls.Add(this.btnXoaNXB);
            this.pnlTopNXB.Controls.Add(this.btnSuaNXB);
            this.pnlTopNXB.Controls.Add(this.btnThemNXB);
            this.pnlTopNXB.Controls.Add(this.txtDiaChiNXB);
            this.pnlTopNXB.Controls.Add(this.lblDC_NXB);
            this.pnlTopNXB.Controls.Add(this.txtPhoneNXB);
            this.pnlTopNXB.Controls.Add(this.lblPhoneNXB);
            this.pnlTopNXB.Controls.Add(this.txtTenNXB);
            this.pnlTopNXB.Controls.Add(this.lblTenNXB);
            this.pnlTopNXB.Controls.Add(this.txtMaNXB);
            this.pnlTopNXB.Controls.Add(this.lblMaNXB);
            this.pnlTopNXB.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopNXB.Location = new System.Drawing.Point(3, 3);
            this.pnlTopNXB.Name = "pnlTopNXB";
            this.pnlTopNXB.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTopNXB.Size = new System.Drawing.Size(986, 130);
            this.pnlTopNXB.TabIndex = 0;

            // 
            // btnXoaNXB
            // 
            this.btnXoaNXB.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnXoaNXB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaNXB.FlatAppearance.BorderSize = 0;
            this.btnXoaNXB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaNXB.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaNXB.ForeColor = System.Drawing.Color.White;
            this.btnXoaNXB.Location = new System.Drawing.Point(730, 54);
            this.btnXoaNXB.Name = "btnXoaNXB";
            this.btnXoaNXB.Size = new System.Drawing.Size(80, 30);
            this.btnXoaNXB.TabIndex = 10;
            this.btnXoaNXB.Text = "Xóa";
            this.btnXoaNXB.UseVisualStyleBackColor = false;

            // 
            // btnSuaNXB
            // 
            this.btnSuaNXB.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSuaNXB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaNXB.FlatAppearance.BorderSize = 0;
            this.btnSuaNXB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaNXB.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSuaNXB.ForeColor = System.Drawing.Color.White;
            this.btnSuaNXB.Location = new System.Drawing.Point(645, 54);
            this.btnSuaNXB.Name = "btnSuaNXB";
            this.btnSuaNXB.Size = new System.Drawing.Size(80, 30);
            this.btnSuaNXB.TabIndex = 9;
            this.btnSuaNXB.Text = "Sửa";
            this.btnSuaNXB.UseVisualStyleBackColor = false;

            // 
            // btnThemNXB
            // 
            this.btnThemNXB.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnThemNXB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNXB.FlatAppearance.BorderSize = 0;
            this.btnThemNXB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNXB.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnThemNXB.ForeColor = System.Drawing.Color.White;
            this.btnThemNXB.Location = new System.Drawing.Point(560, 54);
            this.btnThemNXB.Name = "btnThemNXB";
            this.btnThemNXB.Size = new System.Drawing.Size(80, 30);
            this.btnThemNXB.TabIndex = 8;
            this.btnThemNXB.Text = "Thêm";
            this.btnThemNXB.UseVisualStyleBackColor = false;

            // 
            // txtDiaChiNXB
            // 
            this.txtDiaChiNXB.Location = new System.Drawing.Point(90, 56);
            this.txtDiaChiNXB.Name = "txtDiaChiNXB";
            this.txtDiaChiNXB.Size = new System.Drawing.Size(450, 24);
            this.txtDiaChiNXB.TabIndex = 7;

            // 
            // lblDC_NXB
            // 
            this.lblDC_NXB.AutoSize = true;
            this.lblDC_NXB.Location = new System.Drawing.Point(20, 60);
            this.lblDC_NXB.Name = "lblDC_NXB";
            this.lblDC_NXB.Size = new System.Drawing.Size(50, 17);
            this.lblDC_NXB.TabIndex = 6;
            this.lblDC_NXB.Text = "Địa chỉ:";

            // 
            // txtPhoneNXB
            // 
            this.txtPhoneNXB.Location = new System.Drawing.Point(640, 16);
            this.txtPhoneNXB.Name = "txtPhoneNXB";
            this.txtPhoneNXB.Size = new System.Drawing.Size(140, 24);
            this.txtPhoneNXB.TabIndex = 5;

            // 
            // lblPhoneNXB
            // 
            this.lblPhoneNXB.AutoSize = true;
            this.lblPhoneNXB.Location = new System.Drawing.Point(560, 20);
            this.lblPhoneNXB.Name = "lblPhoneNXB";
            this.lblPhoneNXB.Size = new System.Drawing.Size(70, 17);
            this.lblPhoneNXB.TabIndex = 4;
            this.lblPhoneNXB.Text = "Điện thoại:";

            // 
            // txtTenNXB
            // 
            this.txtTenNXB.Location = new System.Drawing.Point(310, 16);
            this.txtTenNXB.Name = "txtTenNXB";
            this.txtTenNXB.Size = new System.Drawing.Size(230, 24);
            this.txtTenNXB.TabIndex = 3;

            // 
            // lblTenNXB
            // 
            this.lblTenNXB.AutoSize = true;
            this.lblTenNXB.Location = new System.Drawing.Point(230, 20);
            this.lblTenNXB.Name = "lblTenNXB";
            this.lblTenNXB.Size = new System.Drawing.Size(61, 17);
            this.lblTenNXB.TabIndex = 2;
            this.lblTenNXB.Text = "Tên NXB:";

            // 
            // txtMaNXB
            // 
            this.txtMaNXB.Location = new System.Drawing.Point(90, 16);
            this.txtMaNXB.Name = "txtMaNXB";
            this.txtMaNXB.Size = new System.Drawing.Size(110, 24);
            this.txtMaNXB.TabIndex = 1;

            // 
            // lblMaNXB
            // 
            this.lblMaNXB.AutoSize = true;
            this.lblMaNXB.Location = new System.Drawing.Point(20, 20);
            this.lblMaNXB.Name = "lblMaNXB";
            this.lblMaNXB.Size = new System.Drawing.Size(58, 17);
            this.lblMaNXB.TabIndex = 0;
            this.lblMaNXB.Text = "Mã NXB:";

            // 
            // tabCaLam
            // 
            this.tabCaLam.BackColor = System.Drawing.Color.White;
            this.tabCaLam.Controls.Add(this.dgvCaLam);
            this.tabCaLam.Controls.Add(this.pnlTopCa);
            this.tabCaLam.Location = new System.Drawing.Point(4, 36);
            this.tabCaLam.Name = "tabCaLam";
            this.tabCaLam.Padding = new System.Windows.Forms.Padding(3);
            this.tabCaLam.Size = new System.Drawing.Size(992, 660);
            this.tabCaLam.TabIndex = 3;
            this.tabCaLam.Text = "Ca Làm Việc";

            // 
            // dgvCaLam
            // 
            this.dgvCaLam.AllowUserToAddRows = false;
            this.dgvCaLam.AllowUserToDeleteRows = false;
            this.dgvCaLam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaLam.BackgroundColor = System.Drawing.Color.White;
            this.dgvCaLam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvCaLam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaLam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCaLam.Location = new System.Drawing.Point(3, 103);
            this.dgvCaLam.Name = "dgvCaLam";
            this.dgvCaLam.ReadOnly = true;
            this.dgvCaLam.RowHeadersVisible = false;
            this.dgvCaLam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaLam.Size = new System.Drawing.Size(986, 554);
            this.dgvCaLam.TabIndex = 1;

            // 
            // pnlTopCa
            // 
            this.pnlTopCa.Controls.Add(this.btnXoaCa);
            this.pnlTopCa.Controls.Add(this.btnSuaCa);
            this.pnlTopCa.Controls.Add(this.btnThemCa);
            this.pnlTopCa.Controls.Add(this.txtTenCa);
            this.pnlTopCa.Controls.Add(this.lblTenCa);
            this.pnlTopCa.Controls.Add(this.txtMaCa);
            this.pnlTopCa.Controls.Add(this.lblMaCa);
            this.pnlTopCa.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopCa.Location = new System.Drawing.Point(3, 3);
            this.pnlTopCa.Name = "pnlTopCa";
            this.pnlTopCa.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTopCa.Size = new System.Drawing.Size(986, 100);
            this.pnlTopCa.TabIndex = 0;

            // 
            // btnXoaCa
            // 
            this.btnXoaCa.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnXoaCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaCa.FlatAppearance.BorderSize = 0;
            this.btnXoaCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCa.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaCa.ForeColor = System.Drawing.Color.White;
            this.btnXoaCa.Location = new System.Drawing.Point(730, 14);
            this.btnXoaCa.Name = "btnXoaCa";
            this.btnXoaCa.Size = new System.Drawing.Size(80, 30);
            this.btnXoaCa.TabIndex = 6;
            this.btnXoaCa.Text = "Xóa";
            this.btnXoaCa.UseVisualStyleBackColor = false;

            // 
            // btnSuaCa
            // 
            this.btnSuaCa.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSuaCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaCa.FlatAppearance.BorderSize = 0;
            this.btnSuaCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaCa.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSuaCa.ForeColor = System.Drawing.Color.White;
            this.btnSuaCa.Location = new System.Drawing.Point(645, 14);
            this.btnSuaCa.Name = "btnSuaCa";
            this.btnSuaCa.Size = new System.Drawing.Size(80, 30);
            this.btnSuaCa.TabIndex = 5;
            this.btnSuaCa.Text = "Sửa";
            this.btnSuaCa.UseVisualStyleBackColor = false;

            // 
            // btnThemCa
            // 
            this.btnThemCa.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnThemCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemCa.FlatAppearance.BorderSize = 0;
            this.btnThemCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCa.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnThemCa.ForeColor = System.Drawing.Color.White;
            this.btnThemCa.Location = new System.Drawing.Point(560, 14);
            this.btnThemCa.Name = "btnThemCa";
            this.btnThemCa.Size = new System.Drawing.Size(80, 30);
            this.btnThemCa.TabIndex = 4;
            this.btnThemCa.Text = "Thêm";
            this.btnThemCa.UseVisualStyleBackColor = false;

            // 
            // txtTenCa
            // 
            this.txtTenCa.Location = new System.Drawing.Point(290, 16);
            this.txtTenCa.Name = "txtTenCa";
            this.txtTenCa.Size = new System.Drawing.Size(250, 24);
            this.txtTenCa.TabIndex = 3;

            // 
            // lblTenCa
            // 
            this.lblTenCa.AutoSize = true;
            this.lblTenCa.Location = new System.Drawing.Point(220, 20);
            this.lblTenCa.Name = "lblTenCa";
            this.lblTenCa.Size = new System.Drawing.Size(51, 17);
            this.lblTenCa.TabIndex = 2;
            this.lblTenCa.Text = "Tên ca:";

            // 
            // txtMaCa
            // 
            this.txtMaCa.Location = new System.Drawing.Point(90, 16);
            this.txtMaCa.Name = "txtMaCa";
            this.txtMaCa.Size = new System.Drawing.Size(100, 24);
            this.txtMaCa.TabIndex = 1;

            // 
            // lblMaCa
            // 
            this.lblMaCa.AutoSize = true;
            this.lblMaCa.Location = new System.Drawing.Point(20, 20);
            this.lblMaCa.Name = "lblMaCa";
            this.lblMaCa.Size = new System.Drawing.Size(48, 17);
            this.lblMaCa.TabIndex = 0;
            this.lblMaCa.Text = "Mã ca:";

            // 
            // UC_DanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 249, 252);
            this.Controls.Add(this.tabDanhMuc);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "UC_DanhMuc";
            this.Size = new System.Drawing.Size(1000, 700);
            this.tabDanhMuc.ResumeLayout(false);
            this.tabViPham.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViPham)).EndInit();
            this.pnlTopVP.ResumeLayout(false);
            this.pnlTopVP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTienPhat)).EndInit();
            this.tabTacGia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTacGia)).EndInit();
            this.pnlTopTG.ResumeLayout(false);
            this.pnlTopTG.PerformLayout();
            this.tabNXB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNXB)).EndInit();
            this.pnlTopNXB.ResumeLayout(false);
            this.pnlTopNXB.PerformLayout();
            this.tabCaLam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaLam)).EndInit();
            this.pnlTopCa.ResumeLayout(false);
            this.pnlTopCa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDanhMuc;
        private System.Windows.Forms.TabPage tabViPham;
        private System.Windows.Forms.Panel pnlTopVP;
        private System.Windows.Forms.Label lblMaVP;
        private System.Windows.Forms.TextBox txtMaVP;
        private System.Windows.Forms.Label lblTenVP;
        private System.Windows.Forms.TextBox txtTenVP;
        private System.Windows.Forms.Label lblTien;
        private System.Windows.Forms.NumericUpDown numTienPhat;
        private System.Windows.Forms.Button btnThemVP;
        private System.Windows.Forms.Button btnSuaVP;
        private System.Windows.Forms.Button btnXoaVP;
        private System.Windows.Forms.Button btnMoiVP;
        private System.Windows.Forms.DataGridView dgvViPham;
        private System.Windows.Forms.TabPage tabTacGia;
        private System.Windows.Forms.Panel pnlTopTG;
        private System.Windows.Forms.Label lblMaTG;
        private System.Windows.Forms.TextBox txtMaTG;
        private System.Windows.Forms.Label lblTenTG;
        private System.Windows.Forms.TextBox txtTenTG;
        private System.Windows.Forms.Label lblGT;
        private System.Windows.Forms.ComboBox cboGioiTinhTG;
        private System.Windows.Forms.Label lblNS;
        private System.Windows.Forms.DateTimePicker dtpNgaySinhTG;
        private System.Windows.Forms.Label lblDC_TG;
        private System.Windows.Forms.TextBox txtDiaChiTG;
        private System.Windows.Forms.Button btnThemTG;
        private System.Windows.Forms.Button btnSuaTG;
        private System.Windows.Forms.Button btnXoaTG;
        private System.Windows.Forms.Button btnMoiTG;
        private System.Windows.Forms.DataGridView dgvTacGia;
        private System.Windows.Forms.TabPage tabNXB;
        private System.Windows.Forms.Panel pnlTopNXB;
        private System.Windows.Forms.Label lblMaNXB;
        private System.Windows.Forms.TextBox txtMaNXB;
        private System.Windows.Forms.Label lblTenNXB;
        private System.Windows.Forms.TextBox txtTenNXB;
        private System.Windows.Forms.Label lblPhoneNXB;
        private System.Windows.Forms.TextBox txtPhoneNXB;
        private System.Windows.Forms.Label lblDC_NXB;
        private System.Windows.Forms.TextBox txtDiaChiNXB;
        private System.Windows.Forms.Button btnThemNXB;
        private System.Windows.Forms.Button btnSuaNXB;
        private System.Windows.Forms.Button btnXoaNXB;
        private System.Windows.Forms.DataGridView dgvNXB;
        private System.Windows.Forms.TabPage tabCaLam;
        private System.Windows.Forms.Panel pnlTopCa;
        private System.Windows.Forms.Label lblMaCa;
        private System.Windows.Forms.TextBox txtMaCa;
        private System.Windows.Forms.Label lblTenCa;
        private System.Windows.Forms.TextBox txtTenCa;
        private System.Windows.Forms.Button btnThemCa;
        private System.Windows.Forms.Button btnSuaCa;
        private System.Windows.Forms.Button btnXoaCa;
        private System.Windows.Forms.DataGridView dgvCaLam;
    }
}

