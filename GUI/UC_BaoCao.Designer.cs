namespace BTL.GUI
{
    partial class UC_BaoCao
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
            this.tabBaoCao = new System.Windows.Forms.TabControl();
            this.tabBaoCao1 = new System.Windows.Forms.TabPage();
            this.pnlGrid1 = new System.Windows.Forms.Panel();
            this.dgvSachChuaTra = new System.Windows.Forms.DataGridView();
            this.pnlTop1 = new System.Windows.Forms.Panel();
            this.lblTongTienCoc = new System.Windows.Forms.Label();
            this.lblTongTienTamTinh = new System.Windows.Forms.Label();
            this.lblTongChuaTra = new System.Windows.Forms.Label();
            this.btnXuatExcel1 = new System.Windows.Forms.Button();
            this.btnLamMoiChuaTra = new System.Windows.Forms.Button();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.tabBaoCao2 = new System.Windows.Forms.TabPage();
            this.splitDoanhThu = new System.Windows.Forms.Panel();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.splitterDoanhThu = new System.Windows.Forms.Splitter();
            this.pnlLeftGrid = new System.Windows.Forms.Panel();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.pnlTop2 = new System.Windows.Forms.Panel();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.btnXuatExcel2 = new System.Windows.Forms.Button();
            this.btnXemDoanhThu = new System.Windows.Forms.Button();
            this.numNamDoanhThu = new System.Windows.Forms.NumericUpDown();
            this.lblNam = new System.Windows.Forms.Label();
            this.cboKieuDoanhThu = new System.Windows.Forms.ComboBox();
            this.lblKieu = new System.Windows.Forms.Label();
            this.tabBaoCao3 = new System.Windows.Forms.TabPage();
            this.pnlGrid3 = new System.Windows.Forms.Panel();
            this.dgvTop5 = new System.Windows.Forms.DataGridView();
            this.pnlTop3 = new System.Windows.Forms.Panel();
            this.lblTop1Info = new System.Windows.Forms.Label();
            this.btnXuatExcel3 = new System.Windows.Forms.Button();
            this.btnXemTop5 = new System.Windows.Forms.Button();
            this.chkTatCaThoiGian = new System.Windows.Forms.CheckBox();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDen = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTu = new System.Windows.Forms.Label();
            this.lblHeader3 = new System.Windows.Forms.Label();
            this.tabBaoCao.SuspendLayout();
            this.tabBaoCao1.SuspendLayout();
            this.pnlGrid1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachChuaTra)).BeginInit();
            this.pnlTop1.SuspendLayout();
            this.tabBaoCao2.SuspendLayout();
            this.splitDoanhThu.SuspendLayout();
            this.pnlLeftGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.pnlTop2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamDoanhThu)).BeginInit();
            this.tabBaoCao3.SuspendLayout();
            this.pnlGrid3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop5)).BeginInit();
            this.pnlTop3.SuspendLayout();
            this.SuspendLayout();

            // 
            // tabBaoCao
            // 
            this.tabBaoCao.Controls.Add(this.tabBaoCao1);
            this.tabBaoCao.Controls.Add(this.tabBaoCao2);
            this.tabBaoCao.Controls.Add(this.tabBaoCao3);
            this.tabBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBaoCao.Location = new System.Drawing.Point(0, 0);
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.Padding = new System.Drawing.Point(16, 8);
            this.tabBaoCao.SelectedIndex = 0;
            this.tabBaoCao.Size = new System.Drawing.Size(1100, 700);
            this.tabBaoCao.TabIndex = 0;

            // 
            // tabBaoCao1
            // 
            this.tabBaoCao1.BackColor = System.Drawing.Color.White;
            this.tabBaoCao1.Controls.Add(this.pnlGrid1);
            this.tabBaoCao1.Controls.Add(this.pnlTop1);
            this.tabBaoCao1.Location = new System.Drawing.Point(4, 36);
            this.tabBaoCao1.Name = "tabBaoCao1";
            this.tabBaoCao1.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaoCao1.Size = new System.Drawing.Size(1092, 660);
            this.tabBaoCao1.TabIndex = 0;
            this.tabBaoCao1.Text = "Sách Đang Thuê Chưa Trả (Yêu cầu 7)";

            // 
            // pnlGrid1
            // 
            this.pnlGrid1.Controls.Add(this.dgvSachChuaTra);
            this.pnlGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid1.Location = new System.Drawing.Point(3, 113);
            this.pnlGrid1.Name = "pnlGrid1";
            this.pnlGrid1.Padding = new System.Windows.Forms.Padding(15);
            this.pnlGrid1.Size = new System.Drawing.Size(1086, 544);
            this.pnlGrid1.TabIndex = 1;

            // 
            // dgvSachChuaTra
            // 
            this.dgvSachChuaTra.AllowUserToAddRows = false;
            this.dgvSachChuaTra.AllowUserToDeleteRows = false;
            this.dgvSachChuaTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSachChuaTra.BackgroundColor = System.Drawing.Color.White;
            this.dgvSachChuaTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvSachChuaTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSachChuaTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSachChuaTra.Location = new System.Drawing.Point(15, 15);
            this.dgvSachChuaTra.Name = "dgvSachChuaTra";
            this.dgvSachChuaTra.ReadOnly = true;
            this.dgvSachChuaTra.RowHeadersVisible = false;
            this.dgvSachChuaTra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSachChuaTra.Size = new System.Drawing.Size(1056, 514);
            this.dgvSachChuaTra.TabIndex = 0;

            // 
            // pnlTop1
            // 
            this.pnlTop1.Controls.Add(this.lblTongTienCoc);
            this.pnlTop1.Controls.Add(this.lblTongTienTamTinh);
            this.pnlTop1.Controls.Add(this.lblTongChuaTra);
            this.pnlTop1.Controls.Add(this.btnXuatExcel1);
            this.pnlTop1.Controls.Add(this.btnLamMoiChuaTra);
            this.pnlTop1.Controls.Add(this.lblTitle1);
            this.pnlTop1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop1.Location = new System.Drawing.Point(3, 3);
            this.pnlTop1.Name = "pnlTop1";
            this.pnlTop1.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.pnlTop1.Size = new System.Drawing.Size(1086, 110);
            this.pnlTop1.TabIndex = 0;

            // 
            // lblTongTienCoc
            // 
            this.lblTongTienCoc.AutoSize = true;
            this.lblTongTienCoc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTongTienCoc.ForeColor = System.Drawing.Color.FromArgb(139, 92, 246);
            this.lblTongTienCoc.Location = new System.Drawing.Point(660, 52);
            this.lblTongTienCoc.Name = "lblTongTienCoc";
            this.lblTongTienCoc.Size = new System.Drawing.Size(83, 17);
            this.lblTongTienCoc.TabIndex = 5;
            this.lblTongTienCoc.Text = "Cọc giữ: 0 đ";

            // 
            // lblTongTienTamTinh
            // 
            this.lblTongTienTamTinh.AutoSize = true;
            this.lblTongTienTamTinh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTongTienTamTinh.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblTongTienTamTinh.Location = new System.Drawing.Point(470, 52);
            this.lblTongTienTamTinh.Name = "lblTongTienTamTinh";
            this.lblTongTienTamTinh.Size = new System.Drawing.Size(91, 17);
            this.lblTongTienTamTinh.TabIndex = 4;
            this.lblTongTienTamTinh.Text = "Tạm tính: 0 đ";

            // 
            // lblTongChuaTra
            // 
            this.lblTongChuaTra.AutoSize = true;
            this.lblTongChuaTra.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTongChuaTra.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblTongChuaTra.Location = new System.Drawing.Point(285, 52);
            this.lblTongChuaTra.Name = "lblTongChuaTra";
            this.lblTongChuaTra.Size = new System.Drawing.Size(121, 17);
            this.lblTongChuaTra.TabIndex = 3;
            this.lblTongChuaTra.Text = "Tổng sách: 0 cuốn";

            // 
            // btnXuatExcel1
            // 
            this.btnXuatExcel1.BackColor = System.Drawing.Color.White;
            this.btnXuatExcel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 231, 241);
            this.btnXuatExcel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel1.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.btnXuatExcel1.Location = new System.Drawing.Point(160, 45);
            this.btnXuatExcel1.Name = "btnXuatExcel1";
            this.btnXuatExcel1.Size = new System.Drawing.Size(110, 34);
            this.btnXuatExcel1.TabIndex = 2;
            this.btnXuatExcel1.Text = "Xuất Excel";
            this.btnXuatExcel1.UseVisualStyleBackColor = false;

            // 
            // btnLamMoiChuaTra
            // 
            this.btnLamMoiChuaTra.BackColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.btnLamMoiChuaTra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiChuaTra.FlatAppearance.BorderSize = 0;
            this.btnLamMoiChuaTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiChuaTra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoiChuaTra.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiChuaTra.Location = new System.Drawing.Point(20, 45);
            this.btnLamMoiChuaTra.Name = "btnLamMoiChuaTra";
            this.btnLamMoiChuaTra.Size = new System.Drawing.Size(130, 34);
            this.btnLamMoiChuaTra.TabIndex = 1;
            this.btnLamMoiChuaTra.Text = "Cập nhật dữ liệu";
            this.btnLamMoiChuaTra.UseVisualStyleBackColor = false;

            // 
            // lblTitle1
            // 
            this.lblTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle1.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.lblTitle1.Location = new System.Drawing.Point(20, 15);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(1046, 25);
            this.lblTitle1.TabIndex = 0;
            this.lblTitle1.Text = "BÁO CÁO DANH SÁCH SÁCH TRUYỆN ĐANG ĐƯỢC THUÊ CHƯA TRẢ";

            // 
            // tabBaoCao2
            // 
            this.tabBaoCao2.BackColor = System.Drawing.Color.White;
            this.tabBaoCao2.Controls.Add(this.splitDoanhThu);
            this.tabBaoCao2.Controls.Add(this.pnlTop2);
            this.tabBaoCao2.Location = new System.Drawing.Point(4, 36);
            this.tabBaoCao2.Name = "tabBaoCao2";
            this.tabBaoCao2.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaoCao2.Size = new System.Drawing.Size(1092, 660);
            this.tabBaoCao2.TabIndex = 1;
            this.tabBaoCao2.Text = "Doanh Thu Theo Tháng / Quý / Năm (Yêu cầu 8)";

            // 
            // splitDoanhThu
            // 
            this.splitDoanhThu.Controls.Add(this.pnlChart);
            this.splitDoanhThu.Controls.Add(this.splitterDoanhThu);
            this.splitDoanhThu.Controls.Add(this.pnlLeftGrid);
            this.splitDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDoanhThu.Location = new System.Drawing.Point(3, 88);
            this.splitDoanhThu.Name = "splitDoanhThu";
            this.splitDoanhThu.Padding = new System.Windows.Forms.Padding(15);
            this.splitDoanhThu.Size = new System.Drawing.Size(1086, 569);
            this.splitDoanhThu.TabIndex = 1;

            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(473, 15);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Padding = new System.Windows.Forms.Padding(20);
            this.pnlChart.Size = new System.Drawing.Size(598, 539);
            this.pnlChart.TabIndex = 2;

            // 
            // splitterDoanhThu
            // 
            this.splitterDoanhThu.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.splitterDoanhThu.Location = new System.Drawing.Point(465, 15);
            this.splitterDoanhThu.Name = "splitterDoanhThu";
            this.splitterDoanhThu.Size = new System.Drawing.Size(8, 539);
            this.splitterDoanhThu.TabIndex = 1;
            this.splitterDoanhThu.TabStop = false;

            // 
            // pnlLeftGrid
            // 
            this.pnlLeftGrid.Controls.Add(this.dgvDoanhThu);
            this.pnlLeftGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftGrid.Location = new System.Drawing.Point(15, 15);
            this.pnlLeftGrid.Name = "pnlLeftGrid";
            this.pnlLeftGrid.Size = new System.Drawing.Size(450, 539);
            this.pnlLeftGrid.TabIndex = 0;

            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AllowUserToAddRows = false;
            this.dgvDoanhThu.AllowUserToDeleteRows = false;
            this.dgvDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.RowHeadersVisible = false;
            this.dgvDoanhThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoanhThu.Size = new System.Drawing.Size(450, 539);
            this.dgvDoanhThu.TabIndex = 0;

            // 
            // pnlTop2
            // 
            this.pnlTop2.Controls.Add(this.lblTongDoanhThu);
            this.pnlTop2.Controls.Add(this.btnXuatExcel2);
            this.pnlTop2.Controls.Add(this.btnXemDoanhThu);
            this.pnlTop2.Controls.Add(this.numNamDoanhThu);
            this.pnlTop2.Controls.Add(this.lblNam);
            this.pnlTop2.Controls.Add(this.cboKieuDoanhThu);
            this.pnlTop2.Controls.Add(this.lblKieu);
            this.pnlTop2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop2.Location = new System.Drawing.Point(3, 3);
            this.pnlTop2.Name = "pnlTop2";
            this.pnlTop2.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.pnlTop2.Size = new System.Drawing.Size(1086, 85);
            this.pnlTop2.TabIndex = 0;

            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(660, 27);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(155, 20);
            this.lblTongDoanhThu.TabIndex = 6;
            this.lblTongDoanhThu.Text = "Tổng doanh thu: 0 đ";

            // 
            // btnXuatExcel2
            // 
            this.btnXuatExcel2.BackColor = System.Drawing.Color.White;
            this.btnXuatExcel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 231, 241);
            this.btnXuatExcel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel2.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.btnXuatExcel2.Location = new System.Drawing.Point(530, 21);
            this.btnXuatExcel2.Name = "btnXuatExcel2";
            this.btnXuatExcel2.Size = new System.Drawing.Size(110, 32);
            this.btnXuatExcel2.TabIndex = 5;
            this.btnXuatExcel2.Text = "Xuất Excel";
            this.btnXuatExcel2.UseVisualStyleBackColor = false;

            // 
            // btnXemDoanhThu
            // 
            this.btnXemDoanhThu.BackColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.btnXemDoanhThu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemDoanhThu.FlatAppearance.BorderSize = 0;
            this.btnXemDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnXemDoanhThu.Location = new System.Drawing.Point(410, 21);
            this.btnXemDoanhThu.Name = "btnXemDoanhThu";
            this.btnXemDoanhThu.Size = new System.Drawing.Size(110, 32);
            this.btnXemDoanhThu.TabIndex = 4;
            this.btnXemDoanhThu.Text = "Xem báo cáo";
            this.btnXemDoanhThu.UseVisualStyleBackColor = false;

            // 
            // numNamDoanhThu
            // 
            this.numNamDoanhThu.Location = new System.Drawing.Point(295, 23);
            this.numNamDoanhThu.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numNamDoanhThu.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.numNamDoanhThu.Name = "numNamDoanhThu";
            this.numNamDoanhThu.Size = new System.Drawing.Size(90, 24);
            this.numNamDoanhThu.TabIndex = 3;
            this.numNamDoanhThu.Value = new decimal(new int[] { 2026, 0, 0, 0 });

            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblNam.Location = new System.Drawing.Point(250, 26);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(39, 17);
            this.lblNam.TabIndex = 2;
            this.lblNam.Text = "Năm:";

            // 
            // cboKieuDoanhThu
            // 
            this.cboKieuDoanhThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKieuDoanhThu.FormattingEnabled = true;
            this.cboKieuDoanhThu.Items.AddRange(new object[] {
            "Theo Tháng",
            "Theo Quý",
            "Theo Năm"});
            this.cboKieuDoanhThu.Location = new System.Drawing.Point(90, 23);
            this.cboKieuDoanhThu.Name = "cboKieuDoanhThu";
            this.cboKieuDoanhThu.Size = new System.Drawing.Size(140, 25);
            this.cboKieuDoanhThu.TabIndex = 1;

            // 
            // lblKieu
            // 
            this.lblKieu.AutoSize = true;
            this.lblKieu.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblKieu.Location = new System.Drawing.Point(20, 26);
            this.lblKieu.Name = "lblKieu";
            this.lblKieu.Size = new System.Drawing.Size(66, 17);
            this.lblKieu.TabIndex = 0;
            this.lblKieu.Text = "Xem theo:";

            // 
            // tabBaoCao3
            // 
            this.tabBaoCao3.BackColor = System.Drawing.Color.White;
            this.tabBaoCao3.Controls.Add(this.pnlGrid3);
            this.tabBaoCao3.Controls.Add(this.pnlTop3);
            this.tabBaoCao3.Location = new System.Drawing.Point(4, 36);
            this.tabBaoCao3.Name = "tabBaoCao3";
            this.tabBaoCao3.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaoCao3.Size = new System.Drawing.Size(1092, 660);
            this.tabBaoCao3.TabIndex = 2;
            this.tabBaoCao3.Text = "Top 5 Sách Doanh Thu Cao Nhất (Yêu cầu 9)";

            // 
            // pnlGrid3
            // 
            this.pnlGrid3.Controls.Add(this.dgvTop5);
            this.pnlGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid3.Location = new System.Drawing.Point(3, 113);
            this.pnlGrid3.Name = "pnlGrid3";
            this.pnlGrid3.Padding = new System.Windows.Forms.Padding(15);
            this.pnlGrid3.Size = new System.Drawing.Size(1086, 544);
            this.pnlGrid3.TabIndex = 1;

            // 
            // dgvTop5
            // 
            this.dgvTop5.AllowUserToAddRows = false;
            this.dgvTop5.AllowUserToDeleteRows = false;
            this.dgvTop5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTop5.BackgroundColor = System.Drawing.Color.White;
            this.dgvTop5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvTop5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTop5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTop5.Location = new System.Drawing.Point(15, 15);
            this.dgvTop5.Name = "dgvTop5";
            this.dgvTop5.ReadOnly = true;
            this.dgvTop5.RowHeadersVisible = false;
            this.dgvTop5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTop5.Size = new System.Drawing.Size(1056, 514);
            this.dgvTop5.TabIndex = 0;

            // 
            // pnlTop3
            // 
            this.pnlTop3.Controls.Add(this.lblTop1Info);
            this.pnlTop3.Controls.Add(this.btnXuatExcel3);
            this.pnlTop3.Controls.Add(this.btnXemTop5);
            this.pnlTop3.Controls.Add(this.chkTatCaThoiGian);
            this.pnlTop3.Controls.Add(this.dtpDenNgay);
            this.pnlTop3.Controls.Add(this.lblDen);
            this.pnlTop3.Controls.Add(this.dtpTuNgay);
            this.pnlTop3.Controls.Add(this.lblTu);
            this.pnlTop3.Controls.Add(this.lblHeader3);
            this.pnlTop3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop3.Location = new System.Drawing.Point(3, 3);
            this.pnlTop3.Name = "pnlTop3";
            this.pnlTop3.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.pnlTop3.Size = new System.Drawing.Size(1086, 110);
            this.pnlTop3.TabIndex = 0;

            // 
            // lblTop1Info
            // 
            this.lblTop1Info.AutoSize = true;
            this.lblTop1Info.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTop1Info.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblTop1Info.Location = new System.Drawing.Point(20, 80);
            this.lblTop1Info.Name = "lblTop1Info";
            this.lblTop1Info.Size = new System.Drawing.Size(170, 17);
            this.lblTop1Info.TabIndex = 8;
            this.lblTop1Info.Text = "Quán quân doanh thu: ---";

            // 
            // btnXuatExcel3
            // 
            this.btnXuatExcel3.BackColor = System.Drawing.Color.White;
            this.btnXuatExcel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 231, 241);
            this.btnXuatExcel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel3.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.btnXuatExcel3.Location = new System.Drawing.Point(700, 40);
            this.btnXuatExcel3.Name = "btnXuatExcel3";
            this.btnXuatExcel3.Size = new System.Drawing.Size(110, 32);
            this.btnXuatExcel3.TabIndex = 7;
            this.btnXuatExcel3.Text = "Xuất Excel";
            this.btnXuatExcel3.UseVisualStyleBackColor = false;

            // 
            // btnXemTop5
            // 
            this.btnXemTop5.BackColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.btnXemTop5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemTop5.FlatAppearance.BorderSize = 0;
            this.btnXemTop5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemTop5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemTop5.ForeColor = System.Drawing.Color.White;
            this.btnXemTop5.Location = new System.Drawing.Point(590, 40);
            this.btnXemTop5.Name = "btnXemTop5";
            this.btnXemTop5.Size = new System.Drawing.Size(100, 32);
            this.btnXemTop5.TabIndex = 6;
            this.btnXemTop5.Text = "Xem Top 5";
            this.btnXemTop5.UseVisualStyleBackColor = false;

            // 
            // chkTatCaThoiGian
            // 
            this.chkTatCaThoiGian.AutoSize = true;
            this.chkTatCaThoiGian.Location = new System.Drawing.Point(450, 44);
            this.chkTatCaThoiGian.Name = "chkTatCaThoiGian";
            this.chkTatCaThoiGian.Size = new System.Drawing.Size(124, 21);
            this.chkTatCaThoiGian.TabIndex = 5;
            this.chkTatCaThoiGian.Text = "Tất cả thời gian";
            this.chkTatCaThoiGian.UseVisualStyleBackColor = true;

            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(300, 42);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(130, 24);
            this.dtpDenNgay.TabIndex = 4;

            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDen.Location = new System.Drawing.Point(230, 45);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(66, 17);
            this.lblDen.TabIndex = 3;
            this.lblDen.Text = "Đến ngày:";

            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(80, 42);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(130, 24);
            this.dtpTuNgay.TabIndex = 2;

            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTu.Location = new System.Drawing.Point(20, 45);
            this.lblTu.Name = "lblTu";
            this.lblTu.Size = new System.Drawing.Size(58, 17);
            this.lblTu.TabIndex = 1;
            this.lblTu.Text = "Từ ngày:";

            // 
            // lblHeader3
            // 
            this.lblHeader3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader3.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblHeader3.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.lblHeader3.Location = new System.Drawing.Point(20, 15);
            this.lblHeader3.Name = "lblHeader3";
            this.lblHeader3.Size = new System.Drawing.Size(1046, 25);
            this.lblHeader3.TabIndex = 0;
            this.lblHeader3.Text = "DANH SÁCH 5 SÁCH TRUYỆN ĐẠT DOANH THU NHIỀU NHẤT CỦA CỬA HÀNG";

            // 
            // UC_BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 249, 252);
            this.Controls.Add(this.tabBaoCao);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "UC_BaoCao";
            this.Size = new System.Drawing.Size(1100, 700);
            this.tabBaoCao.ResumeLayout(false);
            this.tabBaoCao1.ResumeLayout(false);
            this.pnlGrid1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachChuaTra)).EndInit();
            this.pnlTop1.ResumeLayout(false);
            this.pnlTop1.PerformLayout();
            this.tabBaoCao2.ResumeLayout(false);
            this.splitDoanhThu.ResumeLayout(false);
            this.pnlLeftGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.pnlTop2.ResumeLayout(false);
            this.pnlTop2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamDoanhThu)).EndInit();
            this.tabBaoCao3.ResumeLayout(false);
            this.pnlGrid3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop5)).EndInit();
            this.pnlTop3.ResumeLayout(false);
            this.pnlTop3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabBaoCao;
        private System.Windows.Forms.TabPage tabBaoCao1;
        private System.Windows.Forms.Panel pnlTop1;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Button btnLamMoiChuaTra;
        private System.Windows.Forms.Button btnXuatExcel1;
        private System.Windows.Forms.Label lblTongChuaTra;
        private System.Windows.Forms.Label lblTongTienTamTinh;
        private System.Windows.Forms.Label lblTongTienCoc;
        private System.Windows.Forms.Panel pnlGrid1;
        private System.Windows.Forms.DataGridView dgvSachChuaTra;
        private System.Windows.Forms.TabPage tabBaoCao2;
        private System.Windows.Forms.Panel pnlTop2;
        private System.Windows.Forms.Label lblKieu;
        private System.Windows.Forms.ComboBox cboKieuDoanhThu;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown numNamDoanhThu;
        private System.Windows.Forms.Button btnXemDoanhThu;
        private System.Windows.Forms.Button btnXuatExcel2;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Panel splitDoanhThu;
        private System.Windows.Forms.Panel pnlLeftGrid;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.Splitter splitterDoanhThu;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.TabPage tabBaoCao3;
        private System.Windows.Forms.Panel pnlTop3;
        private System.Windows.Forms.Label lblHeader3;
        private System.Windows.Forms.Label lblTu;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.CheckBox chkTatCaThoiGian;
        private System.Windows.Forms.Button btnXemTop5;
        private System.Windows.Forms.Button btnXuatExcel3;
        private System.Windows.Forms.Label lblTop1Info;
        private System.Windows.Forms.Panel pnlGrid3;
        private System.Windows.Forms.DataGridView dgvTop5;
    }
}

