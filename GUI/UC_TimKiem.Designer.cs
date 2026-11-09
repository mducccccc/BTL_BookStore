namespace BTL.GUI
{
    partial class UC_TimKiem
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
            this.tabSearch = new System.Windows.Forms.TabControl();
            this.tabSach = new System.Windows.Forms.TabPage();
            this.pnlGridContainerSach = new System.Windows.Forms.Panel();
            this.dgvKetQuaSach = new System.Windows.Forms.DataGridView();
            this.pnlPicPreview = new System.Windows.Forms.Panel();
            this.picPreviewSach = new System.Windows.Forms.PictureBox();
            this.lblPicTitle = new System.Windows.Forms.Label();
            this.pnlFilterSach = new System.Windows.Forms.Panel();
            this.lblDemSach = new System.Windows.Forms.Label();
            this.btnDatLaiSach = new System.Windows.Forms.Button();
            this.btnTimSach = new System.Windows.Forms.Button();
            this.cboTimNXB = new System.Windows.Forms.ComboBox();
            this.lblNXBSach = new System.Windows.Forms.Label();
            this.cboTimTacGia = new System.Windows.Forms.ComboBox();
            this.lblTGSach = new System.Windows.Forms.Label();
            this.cboTimLinhVuc = new System.Windows.Forms.ComboBox();
            this.lblLVSach = new System.Windows.Forms.Label();
            this.txtTimTenSach = new System.Windows.Forms.TextBox();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.lblHeaderSach = new System.Windows.Forms.Label();
            this.tabNhanVien = new System.Windows.Forms.TabPage();
            this.pnlGridContainerNV = new System.Windows.Forms.Panel();
            this.dgvKetQuaNV = new System.Windows.Forms.DataGridView();
            this.pnlFilterNV = new System.Windows.Forms.Panel();
            this.lblDemNV = new System.Windows.Forms.Label();
            this.btnDatLaiNV = new System.Windows.Forms.Button();
            this.btnTimNV = new System.Windows.Forms.Button();
            this.cboTimGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblGTNV = new System.Windows.Forms.Label();
            this.cboTimCaLam = new System.Windows.Forms.ComboBox();
            this.lblCaNV = new System.Windows.Forms.Label();
            this.txtTimTenNV = new System.Windows.Forms.TextBox();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.lblHeaderNV = new System.Windows.Forms.Label();
            this.tabSearch.SuspendLayout();
            this.tabSach.SuspendLayout();
            this.pnlGridContainerSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQuaSach)).BeginInit();
            this.pnlPicPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreviewSach)).BeginInit();
            this.pnlFilterSach.SuspendLayout();
            this.tabNhanVien.SuspendLayout();
            this.pnlGridContainerNV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQuaNV)).BeginInit();
            this.pnlFilterNV.SuspendLayout();
            this.SuspendLayout();

            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.tabSach);
            this.tabSearch.Controls.Add(this.tabNhanVien);
            this.tabSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSearch.Location = new System.Drawing.Point(0, 0);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Drawing.Point(16, 8);
            this.tabSearch.SelectedIndex = 0;
            this.tabSearch.Size = new System.Drawing.Size(1100, 700);
            this.tabSearch.TabIndex = 0;

            // 
            // tabSach
            // 
            this.tabSach.BackColor = System.Drawing.Color.White;
            this.tabSach.Controls.Add(this.pnlGridContainerSach);
            this.tabSach.Controls.Add(this.pnlFilterSach);
            this.tabSach.Location = new System.Drawing.Point(4, 36);
            this.tabSach.Name = "tabSach";
            this.tabSach.Padding = new System.Windows.Forms.Padding(3);
            this.tabSach.Size = new System.Drawing.Size(1092, 660);
            this.tabSach.TabIndex = 0;
            this.tabSach.Text = "Tra Cứu Sách Truyện (Yêu cầu 5)";

            // 
            // pnlGridContainerSach
            // 
            this.pnlGridContainerSach.Controls.Add(this.dgvKetQuaSach);
            this.pnlGridContainerSach.Controls.Add(this.pnlPicPreview);
            this.pnlGridContainerSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridContainerSach.Location = new System.Drawing.Point(3, 138);
            this.pnlGridContainerSach.Name = "pnlGridContainerSach";
            this.pnlGridContainerSach.Padding = new System.Windows.Forms.Padding(15);
            this.pnlGridContainerSach.Size = new System.Drawing.Size(1086, 519);
            this.pnlGridContainerSach.TabIndex = 1;

            // 
            // dgvKetQuaSach
            // 
            this.dgvKetQuaSach.AllowUserToAddRows = false;
            this.dgvKetQuaSach.AllowUserToDeleteRows = false;
            this.dgvKetQuaSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQuaSach.BackgroundColor = System.Drawing.Color.White;
            this.dgvKetQuaSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvKetQuaSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQuaSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQuaSach.Location = new System.Drawing.Point(15, 15);
            this.dgvKetQuaSach.Name = "dgvKetQuaSach";
            this.dgvKetQuaSach.ReadOnly = true;
            this.dgvKetQuaSach.RowHeadersVisible = false;
            this.dgvKetQuaSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQuaSach.Size = new System.Drawing.Size(906, 489);
            this.dgvKetQuaSach.TabIndex = 0;

            // 
            // pnlPicPreview
            // 
            this.pnlPicPreview.Controls.Add(this.picPreviewSach);
            this.pnlPicPreview.Controls.Add(this.lblPicTitle);
            this.pnlPicPreview.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPicPreview.Location = new System.Drawing.Point(921, 15);
            this.pnlPicPreview.Name = "pnlPicPreview";
            this.pnlPicPreview.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnlPicPreview.Size = new System.Drawing.Size(150, 489);
            this.pnlPicPreview.TabIndex = 1;

            // 
            // picPreviewSach
            // 
            this.picPreviewSach.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.picPreviewSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreviewSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPreviewSach.Location = new System.Drawing.Point(10, 25);
            this.picPreviewSach.Name = "picPreviewSach";
            this.picPreviewSach.Size = new System.Drawing.Size(140, 464);
            this.picPreviewSach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreviewSach.TabIndex = 1;
            this.picPreviewSach.TabStop = false;

            // 
            // lblPicTitle
            // 
            this.lblPicTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPicTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPicTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPicTitle.Location = new System.Drawing.Point(10, 0);
            this.lblPicTitle.Name = "lblPicTitle";
            this.lblPicTitle.Size = new System.Drawing.Size(140, 25);
            this.lblPicTitle.TabIndex = 0;
            this.lblPicTitle.Text = "Ảnh bìa:";

            // 
            // pnlFilterSach
            // 
            this.pnlFilterSach.Controls.Add(this.lblDemSach);
            this.pnlFilterSach.Controls.Add(this.btnDatLaiSach);
            this.pnlFilterSach.Controls.Add(this.btnTimSach);
            this.pnlFilterSach.Controls.Add(this.cboTimNXB);
            this.pnlFilterSach.Controls.Add(this.lblNXBSach);
            this.pnlFilterSach.Controls.Add(this.cboTimTacGia);
            this.pnlFilterSach.Controls.Add(this.lblTGSach);
            this.pnlFilterSach.Controls.Add(this.cboTimLinhVuc);
            this.pnlFilterSach.Controls.Add(this.lblLVSach);
            this.pnlFilterSach.Controls.Add(this.txtTimTenSach);
            this.pnlFilterSach.Controls.Add(this.lblTenSach);
            this.pnlFilterSach.Controls.Add(this.lblHeaderSach);
            this.pnlFilterSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterSach.Location = new System.Drawing.Point(3, 3);
            this.pnlFilterSach.Name = "pnlFilterSach";
            this.pnlFilterSach.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.pnlFilterSach.Size = new System.Drawing.Size(1086, 135);
            this.pnlFilterSach.TabIndex = 0;

            // 
            // lblDemSach
            // 
            this.lblDemSach.AutoSize = true;
            this.lblDemSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDemSach.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblDemSach.Location = new System.Drawing.Point(780, 52);
            this.lblDemSach.Name = "lblDemSach";
            this.lblDemSach.Size = new System.Drawing.Size(155, 19);
            this.lblDemSach.TabIndex = 11;
            this.lblDemSach.Text = "Tìm thấy: 0 cuốn sách";

            // 
            // btnDatLaiSach
            // 
            this.btnDatLaiSach.BackColor = System.Drawing.Color.White;
            this.btnDatLaiSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatLaiSach.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 231, 241);
            this.btnDatLaiSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatLaiSach.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnDatLaiSach.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.btnDatLaiSach.Location = new System.Drawing.Point(650, 82);
            this.btnDatLaiSach.Name = "btnDatLaiSach";
            this.btnDatLaiSach.Size = new System.Drawing.Size(100, 28);
            this.btnDatLaiSach.TabIndex = 10;
            this.btnDatLaiSach.Text = "Đặt lại";
            this.btnDatLaiSach.UseVisualStyleBackColor = false;

            // 
            // btnTimSach
            // 
            this.btnTimSach.BackColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.btnTimSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimSach.FlatAppearance.BorderSize = 0;
            this.btnTimSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimSach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimSach.ForeColor = System.Drawing.Color.White;
            this.btnTimSach.Location = new System.Drawing.Point(650, 45);
            this.btnTimSach.Name = "btnTimSach";
            this.btnTimSach.Size = new System.Drawing.Size(100, 32);
            this.btnTimSach.TabIndex = 9;
            this.btnTimSach.Text = "Tìm kiếm";
            this.btnTimSach.UseVisualStyleBackColor = false;

            // 
            // cboTimNXB
            // 
            this.cboTimNXB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimNXB.FormattingEnabled = true;
            this.cboTimNXB.Location = new System.Drawing.Point(420, 77);
            this.cboTimNXB.Name = "cboTimNXB";
            this.cboTimNXB.Size = new System.Drawing.Size(200, 25);
            this.cboTimNXB.TabIndex = 8;

            // 
            // lblNXBSach
            // 
            this.lblNXBSach.AutoSize = true;
            this.lblNXBSach.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblNXBSach.Location = new System.Drawing.Point(350, 80);
            this.lblNXBSach.Name = "lblNXBSach";
            this.lblNXBSach.Size = new System.Drawing.Size(58, 17);
            this.lblNXBSach.TabIndex = 7;
            this.lblNXBSach.Text = "Nhà XB:";

            // 
            // cboTimTacGia
            // 
            this.cboTimTacGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimTacGia.FormattingEnabled = true;
            this.cboTimTacGia.Location = new System.Drawing.Point(90, 77);
            this.cboTimTacGia.Name = "cboTimTacGia";
            this.cboTimTacGia.Size = new System.Drawing.Size(230, 25);
            this.cboTimTacGia.TabIndex = 6;

            // 
            // lblTGSach
            // 
            this.lblTGSach.AutoSize = true;
            this.lblTGSach.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTGSach.Location = new System.Drawing.Point(20, 80);
            this.lblTGSach.Name = "lblTGSach";
            this.lblTGSach.Size = new System.Drawing.Size(53, 17);
            this.lblTGSach.TabIndex = 5;
            this.lblTGSach.Text = "Tác giả:";

            // 
            // cboTimLinhVuc
            // 
            this.cboTimLinhVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimLinhVuc.FormattingEnabled = true;
            this.cboTimLinhVuc.Location = new System.Drawing.Point(420, 39);
            this.cboTimLinhVuc.Name = "cboTimLinhVuc";
            this.cboTimLinhVuc.Size = new System.Drawing.Size(200, 25);
            this.cboTimLinhVuc.TabIndex = 4;

            // 
            // lblLVSach
            // 
            this.lblLVSach.AutoSize = true;
            this.lblLVSach.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblLVSach.Location = new System.Drawing.Point(350, 42);
            this.lblLVSach.Name = "lblLVSach";
            this.lblLVSach.Size = new System.Drawing.Size(60, 17);
            this.lblLVSach.TabIndex = 3;
            this.lblLVSach.Text = "Lĩnh vực:";

            // 
            // txtTimTenSach
            // 
            this.txtTimTenSach.Location = new System.Drawing.Point(90, 39);
            this.txtTimTenSach.Name = "txtTimTenSach";
            this.txtTimTenSach.PlaceholderText = "Nhập tên sách cần tìm...";
            this.txtTimTenSach.Size = new System.Drawing.Size(230, 24);
            this.txtTimTenSach.TabIndex = 2;

            // 
            // lblTenSach
            // 
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTenSach.Location = new System.Drawing.Point(20, 42);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(64, 17);
            this.lblTenSach.TabIndex = 1;
            this.lblTenSach.Text = "Tên sách:";

            // 
            // lblHeaderSach
            // 
            this.lblHeaderSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderSach.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.lblHeaderSach.Location = new System.Drawing.Point(20, 15);
            this.lblHeaderSach.Name = "lblHeaderSach";
            this.lblHeaderSach.Size = new System.Drawing.Size(1046, 25);
            this.lblHeaderSach.TabIndex = 0;
            this.lblHeaderSach.Text = "BỘ LỌC ĐA TIÊU CHÍ SÁCH TRUYỆN (Tên sách, Lĩnh vực, Tác giả, Nhà xuất bản)";

            // 
            // tabNhanVien
            // 
            this.tabNhanVien.BackColor = System.Drawing.Color.White;
            this.tabNhanVien.Controls.Add(this.pnlGridContainerNV);
            this.tabNhanVien.Controls.Add(this.pnlFilterNV);
            this.tabNhanVien.Location = new System.Drawing.Point(4, 36);
            this.tabNhanVien.Name = "tabNhanVien";
            this.tabNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabNhanVien.Size = new System.Drawing.Size(1092, 660);
            this.tabNhanVien.TabIndex = 1;
            this.tabNhanVien.Text = "Tra Cứu Nhân Viên (Yêu cầu 6)";

            // 
            // pnlGridContainerNV
            // 
            this.pnlGridContainerNV.Controls.Add(this.dgvKetQuaNV);
            this.pnlGridContainerNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridContainerNV.Location = new System.Drawing.Point(3, 118);
            this.pnlGridContainerNV.Name = "pnlGridContainerNV";
            this.pnlGridContainerNV.Padding = new System.Windows.Forms.Padding(15);
            this.pnlGridContainerNV.Size = new System.Drawing.Size(1086, 539);
            this.pnlGridContainerNV.TabIndex = 1;

            // 
            // dgvKetQuaNV
            // 
            this.dgvKetQuaNV.AllowUserToAddRows = false;
            this.dgvKetQuaNV.AllowUserToDeleteRows = false;
            this.dgvKetQuaNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQuaNV.BackgroundColor = System.Drawing.Color.White;
            this.dgvKetQuaNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvKetQuaNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQuaNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQuaNV.Location = new System.Drawing.Point(15, 15);
            this.dgvKetQuaNV.Name = "dgvKetQuaNV";
            this.dgvKetQuaNV.ReadOnly = true;
            this.dgvKetQuaNV.RowHeadersVisible = false;
            this.dgvKetQuaNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQuaNV.Size = new System.Drawing.Size(1056, 509);
            this.dgvKetQuaNV.TabIndex = 0;

            // 
            // pnlFilterNV
            // 
            this.pnlFilterNV.Controls.Add(this.lblDemNV);
            this.pnlFilterNV.Controls.Add(this.btnDatLaiNV);
            this.pnlFilterNV.Controls.Add(this.btnTimNV);
            this.pnlFilterNV.Controls.Add(this.cboTimGioiTinh);
            this.pnlFilterNV.Controls.Add(this.lblGTNV);
            this.pnlFilterNV.Controls.Add(this.cboTimCaLam);
            this.pnlFilterNV.Controls.Add(this.lblCaNV);
            this.pnlFilterNV.Controls.Add(this.txtTimTenNV);
            this.pnlFilterNV.Controls.Add(this.lblTenNV);
            this.pnlFilterNV.Controls.Add(this.lblHeaderNV);
            this.pnlFilterNV.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterNV.Location = new System.Drawing.Point(3, 3);
            this.pnlFilterNV.Name = "pnlFilterNV";
            this.pnlFilterNV.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.pnlFilterNV.Size = new System.Drawing.Size(1086, 115);
            this.pnlFilterNV.TabIndex = 0;

            // 
            // lblDemNV
            // 
            this.lblDemNV.AutoSize = true;
            this.lblDemNV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDemNV.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblDemNV.Location = new System.Drawing.Point(20, 85);
            this.lblDemNV.Name = "lblDemNV";
            this.lblDemNV.Size = new System.Drawing.Size(142, 17);
            this.lblDemNV.TabIndex = 9;
            this.lblDemNV.Text = "Tìm thấy: 0 nhân viên";

            // 
            // btnDatLaiNV
            // 
            this.btnDatLaiNV.BackColor = System.Drawing.Color.White;
            this.btnDatLaiNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatLaiNV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 231, 241);
            this.btnDatLaiNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatLaiNV.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnDatLaiNV.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.btnDatLaiNV.Location = new System.Drawing.Point(955, 43);
            this.btnDatLaiNV.Name = "btnDatLaiNV";
            this.btnDatLaiNV.Size = new System.Drawing.Size(80, 32);
            this.btnDatLaiNV.TabIndex = 8;
            this.btnDatLaiNV.Text = "Đặt lại";
            this.btnDatLaiNV.UseVisualStyleBackColor = false;

            // 
            // btnTimNV
            // 
            this.btnTimNV.BackColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.btnTimNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimNV.FlatAppearance.BorderSize = 0;
            this.btnTimNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimNV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimNV.ForeColor = System.Drawing.Color.White;
            this.btnTimNV.Location = new System.Drawing.Point(850, 43);
            this.btnTimNV.Name = "btnTimNV";
            this.btnTimNV.Size = new System.Drawing.Size(95, 32);
            this.btnTimNV.TabIndex = 7;
            this.btnTimNV.Text = "Tìm kiếm";
            this.btnTimNV.UseVisualStyleBackColor = false;

            // 
            // cboTimGioiTinh
            // 
            this.cboTimGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimGioiTinh.FormattingEnabled = true;
            this.cboTimGioiTinh.Items.AddRange(new object[] {
            "Tất cả",
            "Nam (M)",
            "Nữ (F)"});
            this.cboTimGioiTinh.Location = new System.Drawing.Point(720, 45);
            this.cboTimGioiTinh.Name = "cboTimGioiTinh";
            this.cboTimGioiTinh.Size = new System.Drawing.Size(110, 25);
            this.cboTimGioiTinh.TabIndex = 6;

            // 
            // lblGTNV
            // 
            this.lblGTNV.AutoSize = true;
            this.lblGTNV.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblGTNV.Location = new System.Drawing.Point(650, 48);
            this.lblGTNV.Name = "lblGTNV";
            this.lblGTNV.Size = new System.Drawing.Size(59, 17);
            this.lblGTNV.TabIndex = 5;
            this.lblGTNV.Text = "Giới tính:";

            // 
            // cboTimCaLam
            // 
            this.cboTimCaLam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimCaLam.FormattingEnabled = true;
            this.cboTimCaLam.Location = new System.Drawing.Point(445, 45);
            this.cboTimCaLam.Name = "cboTimCaLam";
            this.cboTimCaLam.Size = new System.Drawing.Size(180, 25);
            this.cboTimCaLam.TabIndex = 4;

            // 
            // lblCaNV
            // 
            this.lblCaNV.AutoSize = true;
            this.lblCaNV.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCaNV.Location = new System.Drawing.Point(360, 48);
            this.lblCaNV.Name = "lblCaNV";
            this.lblCaNV.Size = new System.Drawing.Size(79, 17);
            this.lblCaNV.TabIndex = 3;
            this.lblCaNV.Text = "Ca làm việc:";

            // 
            // txtTimTenNV
            // 
            this.txtTimTenNV.Location = new System.Drawing.Point(125, 45);
            this.txtTimTenNV.Name = "txtTimTenNV";
            this.txtTimTenNV.PlaceholderText = "Nhập tên nhân viên...";
            this.txtTimTenNV.Size = new System.Drawing.Size(210, 24);
            this.txtTimTenNV.TabIndex = 2;

            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTenNV.Location = new System.Drawing.Point(20, 48);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(92, 17);
            this.lblTenNV.TabIndex = 1;
            this.lblTenNV.Text = "Tên nhân viên:";

            // 
            // lblHeaderNV
            // 
            this.lblHeaderNV.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderNV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderNV.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.lblHeaderNV.Location = new System.Drawing.Point(20, 15);
            this.lblHeaderNV.Name = "lblHeaderNV";
            this.lblHeaderNV.Size = new System.Drawing.Size(1046, 25);
            this.lblHeaderNV.TabIndex = 0;
            this.lblHeaderNV.Text = "BỘ LỌC ĐA TIÊU CHÍ NHÂN VIÊN (Tên nhân viên, Ca làm việc, Giới tính)";

            // 
            // UC_TimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 249, 252);
            this.Controls.Add(this.tabSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "UC_TimKiem";
            this.Size = new System.Drawing.Size(1100, 700);
            this.tabSearch.ResumeLayout(false);
            this.tabSach.ResumeLayout(false);
            this.pnlGridContainerSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQuaSach)).EndInit();
            this.pnlPicPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreviewSach)).EndInit();
            this.pnlFilterSach.ResumeLayout(false);
            this.pnlFilterSach.PerformLayout();
            this.tabNhanVien.ResumeLayout(false);
            this.pnlGridContainerNV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQuaNV)).EndInit();
            this.pnlFilterNV.ResumeLayout(false);
            this.pnlFilterNV.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSearch;
        private System.Windows.Forms.TabPage tabSach;
        private System.Windows.Forms.Panel pnlFilterSach;
        private System.Windows.Forms.Label lblHeaderSach;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.TextBox txtTimTenSach;
        private System.Windows.Forms.Label lblLVSach;
        private System.Windows.Forms.ComboBox cboTimLinhVuc;
        private System.Windows.Forms.Label lblTGSach;
        private System.Windows.Forms.ComboBox cboTimTacGia;
        private System.Windows.Forms.Label lblNXBSach;
        private System.Windows.Forms.ComboBox cboTimNXB;
        private System.Windows.Forms.Button btnTimSach;
        private System.Windows.Forms.Button btnDatLaiSach;
        private System.Windows.Forms.Label lblDemSach;
        private System.Windows.Forms.Panel pnlGridContainerSach;
        private System.Windows.Forms.DataGridView dgvKetQuaSach;
        private System.Windows.Forms.Panel pnlPicPreview;
        private System.Windows.Forms.Label lblPicTitle;
        private System.Windows.Forms.PictureBox picPreviewSach;
        private System.Windows.Forms.TabPage tabNhanVien;
        private System.Windows.Forms.Panel pnlFilterNV;
        private System.Windows.Forms.Label lblHeaderNV;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.TextBox txtTimTenNV;
        private System.Windows.Forms.Label lblCaNV;
        private System.Windows.Forms.ComboBox cboTimCaLam;
        private System.Windows.Forms.Label lblGTNV;
        private System.Windows.Forms.ComboBox cboTimGioiTinh;
        private System.Windows.Forms.Button btnTimNV;
        private System.Windows.Forms.Button btnDatLaiNV;
        private System.Windows.Forms.Label lblDemNV;
        private System.Windows.Forms.Panel pnlGridContainerNV;
        private System.Windows.Forms.DataGridView dgvKetQuaNV;
    }
}

