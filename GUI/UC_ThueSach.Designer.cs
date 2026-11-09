namespace BTL.GUI
{
    partial class UC_ThueSach
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlLichSu = new System.Windows.Forms.Panel();
            this.dgvLichSuThue = new System.Windows.Forms.DataGridView();
            this.pnlTimHist = new System.Windows.Forms.Panel();
            this.txtTimLichSu = new System.Windows.Forms.TextBox();
            this.lblTimH = new System.Windows.Forms.Label();
            this.lblHistTitle = new System.Windows.Forms.Label();
            this.splitter = new System.Windows.Forms.Splitter();
            this.pnlLapPhieu = new System.Windows.Forms.Panel();
            this.grpGio = new System.Windows.Forms.GroupBox();
            this.dgvGioSach = new System.Windows.Forms.DataGridView();
            this.pnlLapActions = new System.Windows.Forms.Panel();
            this.btnHuyPhieu = new System.Windows.Forms.Button();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.lblTongSoCuon = new System.Windows.Forms.Label();
            this.grpChonSach = new System.Windows.Forms.GroupBox();
            this.btnXoaSach = new System.Windows.Forms.Button();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblTonKho = new System.Windows.Forms.Label();
            this.numSoLuongThue = new System.Windows.Forms.NumericUpDown();
            this.lblSL = new System.Windows.Forms.Label();
            this.cboSach = new System.Windows.Forms.ComboBox();
            this.lblChon = new System.Windows.Forms.Label();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.numTienCoc = new System.Windows.Forms.NumericUpDown();
            this.lblCoc = new System.Windows.Forms.Label();
            this.dtpNgayThue = new System.Windows.Forms.DateTimePicker();
            this.lblNgay = new System.Windows.Forms.Label();
            this.cboCaLam = new System.Windows.Forms.ComboBox();
            this.lblCa = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNV = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblKH = new System.Windows.Forms.Label();
            this.btnAutoMa = new System.Windows.Forms.Button();
            this.txtMaThue = new System.Windows.Forms.TextBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuThue)).BeginInit();
            this.pnlTimHist.SuspendLayout();
            this.pnlLapPhieu.SuspendLayout();
            this.grpGio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioSach)).BeginInit();
            this.pnlLapActions.SuspendLayout();
            this.grpChonSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongThue)).BeginInit();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTienCoc)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblSubtitle);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(20, 12, 20, 10);
            this.pnlTop.Size = new System.Drawing.Size(1100, 60);
            this.pnlTop.TabIndex = 0;

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.lblSubtitle.Location = new System.Drawing.Point(270, 20);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(434, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Yêu cầu 1: Chỉ chọn sách tồn kho > 0  |  Yêu cầu 2: Tự động trừ kho khi thuê";

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.lblTitle.Location = new System.Drawing.Point(18, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(209, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LẬP PHIẾU THUÊ SÁCH";

            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlBody.Controls.Add(this.pnlLichSu);
            this.pnlBody.Controls.Add(this.splitter);
            this.pnlBody.Controls.Add(this.pnlLapPhieu);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 60);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1100, 640);
            this.pnlBody.TabIndex = 1;

            // 
            // pnlLichSu
            // 
            this.pnlLichSu.BackColor = System.Drawing.Color.White;
            this.pnlLichSu.Controls.Add(this.dgvLichSuThue);
            this.pnlLichSu.Controls.Add(this.pnlTimHist);
            this.pnlLichSu.Controls.Add(this.lblHistTitle);
            this.pnlLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLichSu.Location = new System.Drawing.Point(635, 0);
            this.pnlLichSu.Name = "pnlLichSu";
            this.pnlLichSu.Padding = new System.Windows.Forms.Padding(15);
            this.pnlLichSu.Size = new System.Drawing.Size(465, 640);
            this.pnlLichSu.TabIndex = 2;

            // 
            // dgvLichSuThue
            // 
            this.dgvLichSuThue.AllowUserToAddRows = false;
            this.dgvLichSuThue.AllowUserToDeleteRows = false;
            this.dgvLichSuThue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSuThue.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSuThue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvLichSuThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuThue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSuThue.Location = new System.Drawing.Point(15, 85);
            this.dgvLichSuThue.Name = "dgvLichSuThue";
            this.dgvLichSuThue.ReadOnly = true;
            this.dgvLichSuThue.RowHeadersVisible = false;
            this.dgvLichSuThue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSuThue.Size = new System.Drawing.Size(435, 540);
            this.dgvLichSuThue.TabIndex = 2;

            // 
            // pnlTimHist
            // 
            this.pnlTimHist.Controls.Add(this.txtTimLichSu);
            this.pnlTimHist.Controls.Add(this.lblTimH);
            this.pnlTimHist.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimHist.Location = new System.Drawing.Point(15, 45);
            this.pnlTimHist.Name = "pnlTimHist";
            this.pnlTimHist.Size = new System.Drawing.Size(435, 40);
            this.pnlTimHist.TabIndex = 1;

            // 
            // txtTimLichSu
            // 
            this.txtTimLichSu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimLichSu.Location = new System.Drawing.Point(70, 7);
            this.txtTimLichSu.Name = "txtTimLichSu";
            this.txtTimLichSu.PlaceholderText = "Mã thuê, tên khách...";
            this.txtTimLichSu.Size = new System.Drawing.Size(230, 23);
            this.txtTimLichSu.TabIndex = 1;

            // 
            // lblTimH
            // 
            this.lblTimH.AutoSize = true;
            this.lblTimH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimH.Location = new System.Drawing.Point(5, 10);
            this.lblTimH.Name = "lblTimH";
            this.lblTimH.Size = new System.Drawing.Size(59, 15);
            this.lblTimH.TabIndex = 0;
            this.lblTimH.Text = "Tìm kiếm:";

            // 
            // lblHistTitle
            // 
            this.lblHistTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHistTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblHistTitle.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.lblHistTitle.Location = new System.Drawing.Point(15, 15);
            this.lblHistTitle.Name = "lblHistTitle";
            this.lblHistTitle.Size = new System.Drawing.Size(435, 30);
            this.lblHistTitle.TabIndex = 0;
            this.lblHistTitle.Text = "Lịch sử phiếu thuê đã lập";

            // 
            // splitter
            // 
            this.splitter.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.splitter.Location = new System.Drawing.Point(630, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(5, 640);
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;

            // 
            // pnlLapPhieu
            // 
            this.pnlLapPhieu.BackColor = System.Drawing.Color.White;
            this.pnlLapPhieu.Controls.Add(this.grpGio);
            this.pnlLapPhieu.Controls.Add(this.grpChonSach);
            this.pnlLapPhieu.Controls.Add(this.grpInfo);
            this.pnlLapPhieu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLapPhieu.Location = new System.Drawing.Point(0, 0);
            this.pnlLapPhieu.Name = "pnlLapPhieu";
            this.pnlLapPhieu.Padding = new System.Windows.Forms.Padding(15);
            this.pnlLapPhieu.Size = new System.Drawing.Size(630, 640);
            this.pnlLapPhieu.TabIndex = 0;

            // 
            // grpGio
            // 
            this.grpGio.Controls.Add(this.dgvGioSach);
            this.grpGio.Controls.Add(this.pnlLapActions);
            this.grpGio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpGio.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.grpGio.Location = new System.Drawing.Point(15, 275);
            this.grpGio.Name = "grpGio";
            this.grpGio.Padding = new System.Windows.Forms.Padding(10);
            this.grpGio.Size = new System.Drawing.Size(600, 350);
            this.grpGio.TabIndex = 2;
            this.grpGio.TabStop = false;
            this.grpGio.Text = "3. Sách trong phiếu thuê hiện tại";

            // 
            // dgvGioSach
            // 
            this.dgvGioSach.AllowUserToAddRows = false;
            this.dgvGioSach.AllowUserToDeleteRows = false;
            this.dgvGioSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioSach.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvGioSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGioSach.Location = new System.Drawing.Point(10, 27);
            this.dgvGioSach.Name = "dgvGioSach";
            this.dgvGioSach.ReadOnly = true;
            this.dgvGioSach.RowHeadersVisible = false;
            this.dgvGioSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioSach.Size = new System.Drawing.Size(580, 258);
            this.dgvGioSach.TabIndex = 0;

            // 
            // pnlLapActions
            // 
            this.pnlLapActions.Controls.Add(this.btnHuyPhieu);
            this.pnlLapActions.Controls.Add(this.btnLapPhieu);
            this.pnlLapActions.Controls.Add(this.lblTongSoCuon);
            this.pnlLapActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLapActions.Location = new System.Drawing.Point(10, 285);
            this.pnlLapActions.Name = "pnlLapActions";
            this.pnlLapActions.Padding = new System.Windows.Forms.Padding(5);
            this.pnlLapActions.Size = new System.Drawing.Size(580, 55);
            this.pnlLapActions.TabIndex = 1;

            // 
            // btnHuyPhieu
            // 
            this.btnHuyPhieu.BackColor = System.Drawing.Color.White;
            this.btnHuyPhieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyPhieu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 231, 241);
            this.btnHuyPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyPhieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHuyPhieu.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.btnHuyPhieu.Location = new System.Drawing.Point(450, 10);
            this.btnHuyPhieu.Name = "btnHuyPhieu";
            this.btnHuyPhieu.Size = new System.Drawing.Size(125, 36);
            this.btnHuyPhieu.TabIndex = 2;
            this.btnHuyPhieu.Text = "Hủy / Làm mới";
            this.btnHuyPhieu.UseVisualStyleBackColor = false;

            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.BackColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.btnLapPhieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLapPhieu.FlatAppearance.BorderSize = 0;
            this.btnLapPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLapPhieu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLapPhieu.ForeColor = System.Drawing.Color.White;
            this.btnLapPhieu.Location = new System.Drawing.Point(280, 10);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(160, 36);
            this.btnLapPhieu.TabIndex = 1;
            this.btnLapPhieu.Text = "LẬP PHIẾU THUÊ";
            this.btnLapPhieu.UseVisualStyleBackColor = false;

            // 
            // lblTongSoCuon
            // 
            this.lblTongSoCuon.AutoSize = true;
            this.lblTongSoCuon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongSoCuon.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTongSoCuon.Location = new System.Drawing.Point(10, 18);
            this.lblTongSoCuon.Name = "lblTongSoCuon";
            this.lblTongSoCuon.Size = new System.Drawing.Size(130, 19);
            this.lblTongSoCuon.TabIndex = 0;
            this.lblTongSoCuon.Text = "Tổng sách: 0 cuốn";

            // 
            // grpChonSach
            // 
            this.grpChonSach.Controls.Add(this.btnXoaSach);
            this.grpChonSach.Controls.Add(this.btnThemSach);
            this.grpChonSach.Controls.Add(this.lblDonGia);
            this.grpChonSach.Controls.Add(this.lblTonKho);
            this.grpChonSach.Controls.Add(this.numSoLuongThue);
            this.grpChonSach.Controls.Add(this.lblSL);
            this.grpChonSach.Controls.Add(this.cboSach);
            this.grpChonSach.Controls.Add(this.lblChon);
            this.grpChonSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChonSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpChonSach.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.grpChonSach.Location = new System.Drawing.Point(15, 165);
            this.grpChonSach.Name = "grpChonSach";
            this.grpChonSach.Size = new System.Drawing.Size(600, 110);
            this.grpChonSach.TabIndex = 1;
            this.grpChonSach.TabStop = false;
            this.grpChonSach.Text = "2. Chọn sách mượn (Yêu cầu 1: Chỉ sách tồn > 0)";

            // 
            // btnXoaSach
            // 
            this.btnXoaSach.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnXoaSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaSach.FlatAppearance.BorderSize = 0;
            this.btnXoaSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSach.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaSach.ForeColor = System.Drawing.Color.White;
            this.btnXoaSach.Location = new System.Drawing.Point(510, 56);
            this.btnXoaSach.Name = "btnXoaSach";
            this.btnXoaSach.Size = new System.Drawing.Size(80, 30);
            this.btnXoaSach.TabIndex = 7;
            this.btnXoaSach.Text = "Bỏ dòng";
            this.btnXoaSach.UseVisualStyleBackColor = false;

            // 
            // btnThemSach
            // 
            this.btnThemSach.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnThemSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemSach.FlatAppearance.BorderSize = 0;
            this.btnThemSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSach.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnThemSach.ForeColor = System.Drawing.Color.White;
            this.btnThemSach.Location = new System.Drawing.Point(410, 56);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(95, 30);
            this.btnThemSach.TabIndex = 6;
            this.btnThemSach.Text = "Thêm sách";
            this.btnThemSach.UseVisualStyleBackColor = false;

            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDonGia.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblDonGia.Location = new System.Drawing.Point(240, 60);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(107, 15);
            this.lblDonGia.TabIndex = 5;
            this.lblDonGia.Text = "Giá thuê: 0 đ/ngày";

            // 
            // lblTonKho
            // 
            this.lblTonKho.AutoSize = true;
            this.lblTonKho.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTonKho.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblTonKho.Location = new System.Drawing.Point(110, 60);
            this.lblTonKho.Name = "lblTonKho";
            this.lblTonKho.Size = new System.Drawing.Size(96, 15);
            this.lblTonKho.TabIndex = 4;
            this.lblTonKho.Text = "Tồn kho: 0 cuốn";

            // 
            // numSoLuongThue
            // 
            this.numSoLuongThue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numSoLuongThue.Location = new System.Drawing.Point(480, 23);
            this.numSoLuongThue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoLuongThue.Name = "numSoLuongThue";
            this.numSoLuongThue.Size = new System.Drawing.Size(65, 23);
            this.numSoLuongThue.TabIndex = 3;
            this.numSoLuongThue.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // 
            // lblSL
            // 
            this.lblSL.AutoSize = true;
            this.lblSL.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSL.Location = new System.Drawing.Point(410, 26);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(57, 15);
            this.lblSL.TabIndex = 2;
            this.lblSL.Text = "Số lượng:";

            // 
            // cboSach
            // 
            this.cboSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboSach.FormattingEnabled = true;
            this.cboSach.Location = new System.Drawing.Point(110, 23);
            this.cboSach.Name = "cboSach";
            this.cboSach.Size = new System.Drawing.Size(280, 23);
            this.cboSach.TabIndex = 1;

            // 
            // lblChon
            // 
            this.lblChon.AutoSize = true;
            this.lblChon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChon.Location = new System.Drawing.Point(15, 26);
            this.lblChon.Name = "lblChon";
            this.lblChon.Size = new System.Drawing.Size(89, 15);
            this.lblChon.TabIndex = 0;
            this.lblChon.Text = "Sách còn hàng:";

            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.numTienCoc);
            this.grpInfo.Controls.Add(this.lblCoc);
            this.grpInfo.Controls.Add(this.dtpNgayThue);
            this.grpInfo.Controls.Add(this.lblNgay);
            this.grpInfo.Controls.Add(this.cboCaLam);
            this.grpInfo.Controls.Add(this.lblCa);
            this.grpInfo.Controls.Add(this.cboNhanVien);
            this.grpInfo.Controls.Add(this.lblNV);
            this.grpInfo.Controls.Add(this.cboKhachHang);
            this.grpInfo.Controls.Add(this.lblKH);
            this.grpInfo.Controls.Add(this.btnAutoMa);
            this.grpInfo.Controls.Add(this.txtMaThue);
            this.grpInfo.Controls.Add(this.lblMa);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.grpInfo.Location = new System.Drawing.Point(15, 15);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(600, 150);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "1. Thông tin phiếu thuê";

            // 
            // numTienCoc
            // 
            this.numTienCoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numTienCoc.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numTienCoc.Location = new System.Drawing.Point(375, 102);
            this.numTienCoc.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numTienCoc.Name = "numTienCoc";
            this.numTienCoc.Size = new System.Drawing.Size(150, 23);
            this.numTienCoc.TabIndex = 12;
            this.numTienCoc.ThousandsSeparator = true;
            this.numTienCoc.Value = new decimal(new int[] { 50000, 0, 0, 0 });

            // 
            // lblCoc
            // 
            this.lblCoc.AutoSize = true;
            this.lblCoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCoc.Location = new System.Drawing.Point(290, 105);
            this.lblCoc.Name = "lblCoc";
            this.lblCoc.Size = new System.Drawing.Size(76, 15);
            this.lblCoc.TabIndex = 11;
            this.lblCoc.Text = "Tiền đặt cọc:";

            // 
            // dtpNgayThue
            // 
            this.dtpNgayThue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayThue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayThue.Location = new System.Drawing.Point(95, 102);
            this.dtpNgayThue.Name = "dtpNgayThue";
            this.dtpNgayThue.Size = new System.Drawing.Size(130, 23);
            this.dtpNgayThue.TabIndex = 10;

            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgay.Location = new System.Drawing.Point(15, 105);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(65, 15);
            this.lblNgay.TabIndex = 9;
            this.lblNgay.Text = "Ngày thuê:";

            // 
            // cboCaLam
            // 
            this.cboCaLam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaLam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboCaLam.FormattingEnabled = true;
            this.cboCaLam.Location = new System.Drawing.Point(375, 62);
            this.cboCaLam.Name = "cboCaLam";
            this.cboCaLam.Size = new System.Drawing.Size(215, 23);
            this.cboCaLam.TabIndex = 8;

            // 
            // lblCa
            // 
            this.lblCa.AutoSize = true;
            this.lblCa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCa.Location = new System.Drawing.Point(290, 65);
            this.lblCa.Name = "lblCa";
            this.lblCa.Size = new System.Drawing.Size(46, 15);
            this.lblCa.TabIndex = 7;
            this.lblCa.Text = "Ca làm:";

            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(95, 62);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(180, 23);
            this.cboNhanVien.TabIndex = 6;

            // 
            // lblNV
            // 
            this.lblNV.AutoSize = true;
            this.lblNV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNV.Location = new System.Drawing.Point(15, 65);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(63, 15);
            this.lblNV.TabIndex = 5;
            this.lblNV.Text = "Nhân viên:";

            // 
            // cboKhachHang
            // 
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(375, 23);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(215, 23);
            this.cboKhachHang.TabIndex = 4;

            // 
            // lblKH
            // 
            this.lblKH.AutoSize = true;
            this.lblKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKH.Location = new System.Drawing.Point(290, 26);
            this.lblKH.Name = "lblKH";
            this.lblKH.Size = new System.Drawing.Size(73, 15);
            this.lblKH.TabIndex = 3;
            this.lblKH.Text = "Khách hàng:";

            // 
            // btnAutoMa
            // 
            this.btnAutoMa.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnAutoMa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoMa.FlatAppearance.BorderSize = 0;
            this.btnAutoMa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoMa.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnAutoMa.Location = new System.Drawing.Point(210, 22);
            this.btnAutoMa.Name = "btnAutoMa";
            this.btnAutoMa.Size = new System.Drawing.Size(65, 25);
            this.btnAutoMa.TabIndex = 2;
            this.btnAutoMa.Text = "Tự sinh";
            this.btnAutoMa.UseVisualStyleBackColor = false;

            // 
            // txtMaThue
            // 
            this.txtMaThue.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtMaThue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaThue.Location = new System.Drawing.Point(95, 23);
            this.txtMaThue.Name = "txtMaThue";
            this.txtMaThue.ReadOnly = true;
            this.txtMaThue.Size = new System.Drawing.Size(110, 23);
            this.txtMaThue.TabIndex = 1;

            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMa.Location = new System.Drawing.Point(15, 26);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(60, 15);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã phiếu:";

            // 
            // UC_ThueSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 249, 252);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "UC_ThueSach";
            this.Size = new System.Drawing.Size(1100, 700);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuThue)).EndInit();
            this.pnlTimHist.ResumeLayout(false);
            this.pnlTimHist.PerformLayout();
            this.pnlLapPhieu.ResumeLayout(false);
            this.grpGio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioSach)).EndInit();
            this.pnlLapActions.ResumeLayout(false);
            this.pnlLapActions.PerformLayout();
            this.grpChonSach.ResumeLayout(false);
            this.grpChonSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongThue)).EndInit();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTienCoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlLichSu;
        private System.Windows.Forms.DataGridView dgvLichSuThue;
        private System.Windows.Forms.Panel pnlTimHist;
        private System.Windows.Forms.TextBox txtTimLichSu;
        private System.Windows.Forms.Label lblTimH;
        private System.Windows.Forms.Label lblHistTitle;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel pnlLapPhieu;
        private System.Windows.Forms.GroupBox grpGio;
        private System.Windows.Forms.DataGridView dgvGioSach;
        private System.Windows.Forms.Panel pnlLapActions;
        private System.Windows.Forms.Button btnHuyPhieu;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.Label lblTongSoCuon;
        private System.Windows.Forms.GroupBox grpChonSach;
        private System.Windows.Forms.Button btnXoaSach;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblTonKho;
        private System.Windows.Forms.NumericUpDown numSoLuongThue;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.ComboBox cboSach;
        private System.Windows.Forms.Label lblChon;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.NumericUpDown numTienCoc;
        private System.Windows.Forms.Label lblCoc;
        private System.Windows.Forms.DateTimePicker dtpNgayThue;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.ComboBox cboCaLam;
        private System.Windows.Forms.Label lblCa;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblNV;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label lblKH;
        private System.Windows.Forms.Button btnAutoMa;
        private System.Windows.Forms.TextBox txtMaThue;
        private System.Windows.Forms.Label lblMa;
    }
}

