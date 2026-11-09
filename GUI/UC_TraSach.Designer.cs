namespace BTL.GUI
{
    partial class UC_TraSach
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
            this.pnlHistSplit = new System.Windows.Forms.Panel();
            this.dgvChiTietTra = new System.Windows.Forms.DataGridView();
            this.lblCTTitle = new System.Windows.Forms.Label();
            this.dgvLichSuTra = new System.Windows.Forms.DataGridView();
            this.pnlTimHist = new System.Windows.Forms.Panel();
            this.txtTimLichSu = new System.Windows.Forms.TextBox();
            this.lblTimH = new System.Windows.Forms.Label();
            this.lblHistTitle = new System.Windows.Forms.Label();
            this.splitter = new System.Windows.Forms.Splitter();
            this.pnlLapPhieu = new System.Windows.Forms.Panel();
            this.grpGio = new System.Windows.Forms.GroupBox();
            this.dgvGioTra = new System.Windows.Forms.DataGridView();
            this.pnlLapActions = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXacNhanTra = new System.Windows.Forms.Button();
            this.lblThanhToanCuoi = new System.Windows.Forms.Label();
            this.lblTongThanhTien = new System.Windows.Forms.Label();
            this.grpChonSach = new System.Windows.Forms.GroupBox();
            this.btnXoaSachTra = new System.Windows.Forms.Button();
            this.btnThemSachTra = new System.Windows.Forms.Button();
            this.lblThanhTienTamTinh = new System.Windows.Forms.Label();
            this.lblSoNgayThue = new System.Windows.Forms.Label();
            this.lblTienPhat = new System.Windows.Forms.Label();
            this.cboViPham = new System.Windows.Forms.ComboBox();
            this.lblVP = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblSLThue = new System.Windows.Forms.Label();
            this.cboSachChuaTra = new System.Windows.Forms.ComboBox();
            this.lblSach = new System.Windows.Forms.Label();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblTienCocInfo = new System.Windows.Forms.Label();
            this.lblNgayThueInfo = new System.Windows.Forms.Label();
            this.lblKhachHangInfo = new System.Windows.Forms.Label();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.lblNgay = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNV = new System.Windows.Forms.Label();
            this.cboMaThue = new System.Windows.Forms.ComboBox();
            this.lblPhieuThue = new System.Windows.Forms.Label();
            this.btnAutoMa = new System.Windows.Forms.Button();
            this.txtMaTra = new System.Windows.Forms.TextBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlLichSu.SuspendLayout();
            this.pnlHistSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietTra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuTra)).BeginInit();
            this.pnlTimHist.SuspendLayout();
            this.pnlLapPhieu.SuspendLayout();
            this.grpGio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioTra)).BeginInit();
            this.pnlLapActions.SuspendLayout();
            this.grpChonSach.SuspendLayout();
            this.grpInfo.SuspendLayout();
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
            this.pnlTop.Size = new System.Drawing.Size(1150, 60);
            this.pnlTop.TabIndex = 0;

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.lblSubtitle.Location = new System.Drawing.Point(290, 20);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(564, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Yêu cầu 3: Lọc sách chưa trả  |  Yêu cầu 4: Tính tiền thuê + Phạt  |  Yêu cầu 2: Hoàn kho tự động";

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.lblTitle.Location = new System.Drawing.Point(18, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "NHẬN TRẢ SÁCH & TÍNH TIỀN";

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
            this.pnlBody.Size = new System.Drawing.Size(1150, 660);
            this.pnlBody.TabIndex = 1;

            // 
            // pnlLichSu
            // 
            this.pnlLichSu.BackColor = System.Drawing.Color.White;
            this.pnlLichSu.Controls.Add(this.pnlHistSplit);
            this.pnlLichSu.Controls.Add(this.pnlTimHist);
            this.pnlLichSu.Controls.Add(this.lblHistTitle);
            this.pnlLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLichSu.Location = new System.Drawing.Point(645, 0);
            this.pnlLichSu.Name = "pnlLichSu";
            this.pnlLichSu.Padding = new System.Windows.Forms.Padding(15);
            this.pnlLichSu.Size = new System.Drawing.Size(505, 660);
            this.pnlLichSu.TabIndex = 2;

            // 
            // pnlHistSplit
            // 
            this.pnlHistSplit.Controls.Add(this.dgvChiTietTra);
            this.pnlHistSplit.Controls.Add(this.lblCTTitle);
            this.pnlHistSplit.Controls.Add(this.dgvLichSuTra);
            this.pnlHistSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHistSplit.Location = new System.Drawing.Point(15, 85);
            this.pnlHistSplit.Name = "pnlHistSplit";
            this.pnlHistSplit.Size = new System.Drawing.Size(475, 560);
            this.pnlHistSplit.TabIndex = 2;

            // 
            // dgvChiTietTra
            // 
            this.dgvChiTietTra.AllowUserToAddRows = false;
            this.dgvChiTietTra.AllowUserToDeleteRows = false;
            this.dgvChiTietTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietTra.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvChiTietTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietTra.Location = new System.Drawing.Point(0, 280);
            this.dgvChiTietTra.Name = "dgvChiTietTra";
            this.dgvChiTietTra.ReadOnly = true;
            this.dgvChiTietTra.RowHeadersVisible = false;
            this.dgvChiTietTra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietTra.Size = new System.Drawing.Size(475, 280);
            this.dgvChiTietTra.TabIndex = 2;

            // 
            // lblCTTitle
            // 
            this.lblCTTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCTTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCTTitle.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.lblCTTitle.Location = new System.Drawing.Point(0, 250);
            this.lblCTTitle.Name = "lblCTTitle";
            this.lblCTTitle.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblCTTitle.Size = new System.Drawing.Size(475, 30);
            this.lblCTTitle.TabIndex = 1;
            this.lblCTTitle.Text = "Chi tiết sách trả của phiếu được chọn:";

            // 
            // dgvLichSuTra
            // 
            this.dgvLichSuTra.AllowUserToAddRows = false;
            this.dgvLichSuTra.AllowUserToDeleteRows = false;
            this.dgvLichSuTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSuTra.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSuTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvLichSuTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuTra.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvLichSuTra.Location = new System.Drawing.Point(0, 0);
            this.dgvLichSuTra.Name = "dgvLichSuTra";
            this.dgvLichSuTra.ReadOnly = true;
            this.dgvLichSuTra.RowHeadersVisible = false;
            this.dgvLichSuTra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSuTra.Size = new System.Drawing.Size(475, 250);
            this.dgvLichSuTra.TabIndex = 0;

            // 
            // pnlTimHist
            // 
            this.pnlTimHist.Controls.Add(this.txtTimLichSu);
            this.pnlTimHist.Controls.Add(this.lblTimH);
            this.pnlTimHist.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimHist.Location = new System.Drawing.Point(15, 45);
            this.pnlTimHist.Name = "pnlTimHist";
            this.pnlTimHist.Size = new System.Drawing.Size(475, 40);
            this.pnlTimHist.TabIndex = 1;

            // 
            // txtTimLichSu
            // 
            this.txtTimLichSu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimLichSu.Location = new System.Drawing.Point(70, 7);
            this.txtTimLichSu.Name = "txtTimLichSu";
            this.txtTimLichSu.PlaceholderText = "Mã trả, mã thuê, khách...";
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
            this.lblHistTitle.Size = new System.Drawing.Size(475, 30);
            this.lblHistTitle.TabIndex = 0;
            this.lblHistTitle.Text = "Lịch sử các phiếu trả sách";

            // 
            // splitter
            // 
            this.splitter.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.splitter.Location = new System.Drawing.Point(640, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(5, 660);
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
            this.pnlLapPhieu.Size = new System.Drawing.Size(640, 660);
            this.pnlLapPhieu.TabIndex = 0;

            // 
            // grpGio
            // 
            this.grpGio.Controls.Add(this.dgvGioTra);
            this.grpGio.Controls.Add(this.pnlLapActions);
            this.grpGio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpGio.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.grpGio.Location = new System.Drawing.Point(15, 320);
            this.grpGio.Name = "grpGio";
            this.grpGio.Padding = new System.Windows.Forms.Padding(10);
            this.grpGio.Size = new System.Drawing.Size(610, 325);
            this.grpGio.TabIndex = 2;
            this.grpGio.TabStop = false;
            this.grpGio.Text = "3. Danh sách sách trả trong lần này";

            // 
            // dgvGioTra
            // 
            this.dgvGioTra.AllowUserToAddRows = false;
            this.dgvGioTra.AllowUserToDeleteRows = false;
            this.dgvGioTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioTra.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvGioTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGioTra.Location = new System.Drawing.Point(10, 27);
            this.dgvGioTra.Name = "dgvGioTra";
            this.dgvGioTra.ReadOnly = true;
            this.dgvGioTra.RowHeadersVisible = false;
            this.dgvGioTra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioTra.Size = new System.Drawing.Size(590, 198);
            this.dgvGioTra.TabIndex = 0;

            // 
            // pnlLapActions
            // 
            this.pnlLapActions.Controls.Add(this.btnLamMoi);
            this.pnlLapActions.Controls.Add(this.btnXacNhanTra);
            this.pnlLapActions.Controls.Add(this.lblThanhToanCuoi);
            this.pnlLapActions.Controls.Add(this.lblTongThanhTien);
            this.pnlLapActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLapActions.Location = new System.Drawing.Point(10, 225);
            this.pnlLapActions.Name = "pnlLapActions";
            this.pnlLapActions.Padding = new System.Windows.Forms.Padding(5);
            this.pnlLapActions.Size = new System.Drawing.Size(590, 90);
            this.pnlLapActions.TabIndex = 1;

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.White;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 231, 241);
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.btnLamMoi.Location = new System.Drawing.Point(475, 15);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(105, 40);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;

            // 
            // btnXacNhanTra
            // 
            this.btnXacNhanTra.BackColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.btnXacNhanTra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhanTra.FlatAppearance.BorderSize = 0;
            this.btnXacNhanTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanTra.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXacNhanTra.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanTra.Location = new System.Drawing.Point(300, 15);
            this.btnXacNhanTra.Name = "btnXacNhanTra";
            this.btnXacNhanTra.Size = new System.Drawing.Size(165, 40);
            this.btnXacNhanTra.TabIndex = 2;
            this.btnXacNhanTra.Text = "XÁC NHẬN TRẢ SÁCH";
            this.btnXacNhanTra.UseVisualStyleBackColor = false;

            // 
            // lblThanhToanCuoi
            // 
            this.lblThanhToanCuoi.AutoSize = true;
            this.lblThanhToanCuoi.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblThanhToanCuoi.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.lblThanhToanCuoi.Location = new System.Drawing.Point(10, 40);
            this.lblThanhToanCuoi.Name = "lblThanhToanCuoi";
            this.lblThanhToanCuoi.Size = new System.Drawing.Size(195, 19);
            this.lblThanhToanCuoi.TabIndex = 1;
            this.lblThanhToanCuoi.Text = "Cần thu thêm: 0 đ (Trừ cọc)";

            // 
            // lblTongThanhTien
            // 
            this.lblTongThanhTien.AutoSize = true;
            this.lblTongThanhTien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTongThanhTien.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTongThanhTien.Location = new System.Drawing.Point(10, 10);
            this.lblTongThanhTien.Name = "lblTongThanhTien";
            this.lblTongThanhTien.Size = new System.Drawing.Size(170, 17);
            this.lblTongThanhTien.TabIndex = 0;
            this.lblTongThanhTien.Text = "Tổng tiền thuê & phạt: 0 đ";

            // 
            // grpChonSach
            // 
            this.grpChonSach.Controls.Add(this.btnXoaSachTra);
            this.grpChonSach.Controls.Add(this.btnThemSachTra);
            this.grpChonSach.Controls.Add(this.lblThanhTienTamTinh);
            this.grpChonSach.Controls.Add(this.lblSoNgayThue);
            this.grpChonSach.Controls.Add(this.lblTienPhat);
            this.grpChonSach.Controls.Add(this.cboViPham);
            this.grpChonSach.Controls.Add(this.lblVP);
            this.grpChonSach.Controls.Add(this.lblDonGia);
            this.grpChonSach.Controls.Add(this.lblSLThue);
            this.grpChonSach.Controls.Add(this.cboSachChuaTra);
            this.grpChonSach.Controls.Add(this.lblSach);
            this.grpChonSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChonSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpChonSach.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.grpChonSach.Location = new System.Drawing.Point(15, 170);
            this.grpChonSach.Name = "grpChonSach";
            this.grpChonSach.Size = new System.Drawing.Size(610, 150);
            this.grpChonSach.TabIndex = 1;
            this.grpChonSach.TabStop = false;
            this.grpChonSach.Text = "2. Chọn sách trả & Tính tiền (YC 3: Chỉ sách chưa trả | YC 4: Tính tiền + Phạt)";

            // 
            // btnXoaSachTra
            // 
            this.btnXoaSachTra.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnXoaSachTra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaSachTra.FlatAppearance.BorderSize = 0;
            this.btnXoaSachTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSachTra.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaSachTra.ForeColor = System.Drawing.Color.White;
            this.btnXoaSachTra.Location = new System.Drawing.Point(515, 96);
            this.btnXoaSachTra.Name = "btnXoaSachTra";
            this.btnXoaSachTra.Size = new System.Drawing.Size(85, 32);
            this.btnXoaSachTra.TabIndex = 10;
            this.btnXoaSachTra.Text = "Bỏ dòng";
            this.btnXoaSachTra.UseVisualStyleBackColor = false;

            // 
            // btnThemSachTra
            // 
            this.btnThemSachTra.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnThemSachTra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemSachTra.FlatAppearance.BorderSize = 0;
            this.btnThemSachTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSachTra.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnThemSachTra.ForeColor = System.Drawing.Color.White;
            this.btnThemSachTra.Location = new System.Drawing.Point(390, 96);
            this.btnThemSachTra.Name = "btnThemSachTra";
            this.btnThemSachTra.Size = new System.Drawing.Size(115, 32);
            this.btnThemSachTra.TabIndex = 9;
            this.btnThemSachTra.Text = "Thêm vào phiếu";
            this.btnThemSachTra.UseVisualStyleBackColor = false;

            // 
            // lblThanhTienTamTinh
            // 
            this.lblThanhTienTamTinh.AutoSize = true;
            this.lblThanhTienTamTinh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThanhTienTamTinh.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblThanhTienTamTinh.Location = new System.Drawing.Point(200, 100);
            this.lblThanhTienTamTinh.Name = "lblThanhTienTamTinh";
            this.lblThanhTienTamTinh.Size = new System.Drawing.Size(107, 19);
            this.lblThanhTienTamTinh.TabIndex = 8;
            this.lblThanhTienTamTinh.Text = "Thành tiền: 0 đ";

            // 
            // lblSoNgayThue
            // 
            this.lblSoNgayThue.AutoSize = true;
            this.lblSoNgayThue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoNgayThue.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblSoNgayThue.Location = new System.Drawing.Point(15, 100);
            this.lblSoNgayThue.Name = "lblSoNgayThue";
            this.lblSoNgayThue.Size = new System.Drawing.Size(126, 15);
            this.lblSoNgayThue.TabIndex = 7;
            this.lblSoNgayThue.Text = "Số ngày thuê: 1 ngày";

            // 
            // lblTienPhat
            // 
            this.lblTienPhat.AutoSize = true;
            this.lblTienPhat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTienPhat.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblTienPhat.Location = new System.Drawing.Point(405, 62);
            this.lblTienPhat.Name = "lblTienPhat";
            this.lblTienPhat.Size = new System.Drawing.Size(84, 15);
            this.lblTienPhat.TabIndex = 6;
            this.lblTienPhat.Text = "Tiền phạt: 0 đ";

            // 
            // cboViPham
            // 
            this.cboViPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViPham.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboViPham.FormattingEnabled = true;
            this.cboViPham.Location = new System.Drawing.Point(110, 59);
            this.cboViPham.Name = "cboViPham";
            this.cboViPham.Size = new System.Drawing.Size(280, 23);
            this.cboViPham.TabIndex = 5;

            // 
            // lblVP
            // 
            this.lblVP.AutoSize = true;
            this.lblVP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVP.Location = new System.Drawing.Point(15, 62);
            this.lblVP.Name = "lblVP";
            this.lblVP.Size = new System.Drawing.Size(73, 15);
            this.lblVP.TabIndex = 4;
            this.lblVP.Text = "Lỗi vi phạm:";

            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDonGia.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDonGia.Location = new System.Drawing.Point(495, 26);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(103, 15);
            this.lblDonGia.TabIndex = 3;
            this.lblDonGia.Text = "Giá thuê: 0 đ/ngày";

            // 
            // lblSLThue
            // 
            this.lblSLThue.AutoSize = true;
            this.lblSLThue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSLThue.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblSLThue.Location = new System.Drawing.Point(405, 26);
            this.lblSLThue.Name = "lblSLThue";
            this.lblSLThue.Size = new System.Drawing.Size(68, 15);
            this.lblSLThue.TabIndex = 2;
            this.lblSLThue.Text = "Số lượng: 0";

            // 
            // cboSachChuaTra
            // 
            this.cboSachChuaTra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSachChuaTra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboSachChuaTra.FormattingEnabled = true;
            this.cboSachChuaTra.Location = new System.Drawing.Point(110, 23);
            this.cboSachChuaTra.Name = "cboSachChuaTra";
            this.cboSachChuaTra.Size = new System.Drawing.Size(280, 23);
            this.cboSachChuaTra.TabIndex = 1;

            // 
            // lblSach
            // 
            this.lblSach.AutoSize = true;
            this.lblSach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSach.Location = new System.Drawing.Point(15, 26);
            this.lblSach.Name = "lblSach";
            this.lblSach.Size = new System.Drawing.Size(84, 15);
            this.lblSach.TabIndex = 0;
            this.lblSach.Text = "Sách chưa trả:";

            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblTienCocInfo);
            this.grpInfo.Controls.Add(this.lblNgayThueInfo);
            this.grpInfo.Controls.Add(this.lblKhachHangInfo);
            this.grpInfo.Controls.Add(this.dtpNgayTra);
            this.grpInfo.Controls.Add(this.lblNgay);
            this.grpInfo.Controls.Add(this.cboNhanVien);
            this.grpInfo.Controls.Add(this.lblNV);
            this.grpInfo.Controls.Add(this.cboMaThue);
            this.grpInfo.Controls.Add(this.lblPhieuThue);
            this.grpInfo.Controls.Add(this.btnAutoMa);
            this.grpInfo.Controls.Add(this.txtMaTra);
            this.grpInfo.Controls.Add(this.lblMa);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.grpInfo.Location = new System.Drawing.Point(15, 15);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(610, 155);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "1. Thông tin phiếu trả";

            // 
            // lblTienCocInfo
            // 
            this.lblTienCocInfo.AutoSize = true;
            this.lblTienCocInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTienCocInfo.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblTienCocInfo.Location = new System.Drawing.Point(410, 105);
            this.lblTienCocInfo.Name = "lblTienCocInfo";
            this.lblTienCocInfo.Size = new System.Drawing.Size(78, 15);
            this.lblTienCocInfo.TabIndex = 11;
            this.lblTienCocInfo.Text = "Tiền cọc: 0 đ";

            // 
            // lblNgayThueInfo
            // 
            this.lblNgayThueInfo.AutoSize = true;
            this.lblNgayThueInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayThueInfo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblNgayThueInfo.Location = new System.Drawing.Point(230, 105);
            this.lblNgayThueInfo.Name = "lblNgayThueInfo";
            this.lblNgayThueInfo.Size = new System.Drawing.Size(84, 15);
            this.lblNgayThueInfo.TabIndex = 10;
            this.lblNgayThueInfo.Text = "Ngày thuê: ---";

            // 
            // lblKhachHangInfo
            // 
            this.lblKhachHangInfo.AutoSize = true;
            this.lblKhachHangInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKhachHangInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblKhachHangInfo.Location = new System.Drawing.Point(15, 105);
            this.lblKhachHangInfo.Name = "lblKhachHangInfo";
            this.lblKhachHangInfo.Size = new System.Drawing.Size(102, 15);
            this.lblKhachHangInfo.TabIndex = 9;
            this.lblKhachHangInfo.Text = "Khách hàng: ---";

            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTra.Location = new System.Drawing.Point(380, 62);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(130, 23);
            this.dtpNgayTra.TabIndex = 8;

            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgay.Location = new System.Drawing.Point(300, 65);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(55, 15);
            this.lblNgay.TabIndex = 7;
            this.lblNgay.Text = "Ngày trả:";

            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(115, 62);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(170, 23);
            this.cboNhanVien.TabIndex = 6;

            // 
            // lblNV
            // 
            this.lblNV.AutoSize = true;
            this.lblNV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNV.Location = new System.Drawing.Point(15, 65);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(95, 15);
            this.lblNV.TabIndex = 5;
            this.lblNV.Text = "Nhân viên nhận:";

            // 
            // cboMaThue
            // 
            this.cboMaThue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaThue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboMaThue.FormattingEnabled = true;
            this.cboMaThue.Location = new System.Drawing.Point(380, 23);
            this.cboMaThue.Name = "cboMaThue";
            this.cboMaThue.Size = new System.Drawing.Size(215, 23);
            this.cboMaThue.TabIndex = 4;

            // 
            // lblPhieuThue
            // 
            this.lblPhieuThue.AutoSize = true;
            this.lblPhieuThue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhieuThue.Location = new System.Drawing.Point(300, 26);
            this.lblPhieuThue.Name = "lblPhieuThue";
            this.lblPhieuThue.Size = new System.Drawing.Size(68, 15);
            this.lblPhieuThue.TabIndex = 3;
            this.lblPhieuThue.Text = "Phiếu thuê:";

            // 
            // btnAutoMa
            // 
            this.btnAutoMa.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnAutoMa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoMa.FlatAppearance.BorderSize = 0;
            this.btnAutoMa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoMa.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnAutoMa.Location = new System.Drawing.Point(220, 22);
            this.btnAutoMa.Name = "btnAutoMa";
            this.btnAutoMa.Size = new System.Drawing.Size(65, 25);
            this.btnAutoMa.TabIndex = 2;
            this.btnAutoMa.Text = "Tự sinh";
            this.btnAutoMa.UseVisualStyleBackColor = false;

            // 
            // txtMaTra
            // 
            this.txtMaTra.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtMaTra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaTra.Location = new System.Drawing.Point(105, 23);
            this.txtMaTra.Name = "txtMaTra";
            this.txtMaTra.ReadOnly = true;
            this.txtMaTra.Size = new System.Drawing.Size(110, 23);
            this.txtMaTra.TabIndex = 1;

            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMa.Location = new System.Drawing.Point(15, 26);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(78, 15);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã phiếu trả:";

            // 
            // UC_TraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 249, 252);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "UC_TraSach";
            this.Size = new System.Drawing.Size(1150, 720);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlLichSu.ResumeLayout(false);
            this.pnlHistSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietTra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuTra)).EndInit();
            this.pnlTimHist.ResumeLayout(false);
            this.pnlTimHist.PerformLayout();
            this.pnlLapPhieu.ResumeLayout(false);
            this.grpGio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioTra)).EndInit();
            this.pnlLapActions.ResumeLayout(false);
            this.pnlLapActions.PerformLayout();
            this.grpChonSach.ResumeLayout(false);
            this.grpChonSach.PerformLayout();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlLichSu;
        private System.Windows.Forms.Panel pnlHistSplit;
        private System.Windows.Forms.DataGridView dgvChiTietTra;
        private System.Windows.Forms.Label lblCTTitle;
        private System.Windows.Forms.DataGridView dgvLichSuTra;
        private System.Windows.Forms.Panel pnlTimHist;
        private System.Windows.Forms.TextBox txtTimLichSu;
        private System.Windows.Forms.Label lblTimH;
        private System.Windows.Forms.Label lblHistTitle;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel pnlLapPhieu;
        private System.Windows.Forms.GroupBox grpGio;
        private System.Windows.Forms.DataGridView dgvGioTra;
        private System.Windows.Forms.Panel pnlLapActions;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXacNhanTra;
        private System.Windows.Forms.Label lblThanhToanCuoi;
        private System.Windows.Forms.Label lblTongThanhTien;
        private System.Windows.Forms.GroupBox grpChonSach;
        private System.Windows.Forms.Button btnXoaSachTra;
        private System.Windows.Forms.Button btnThemSachTra;
        private System.Windows.Forms.Label lblThanhTienTamTinh;
        private System.Windows.Forms.Label lblSoNgayThue;
        private System.Windows.Forms.Label lblTienPhat;
        private System.Windows.Forms.ComboBox cboViPham;
        private System.Windows.Forms.Label lblVP;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblSLThue;
        private System.Windows.Forms.ComboBox cboSachChuaTra;
        private System.Windows.Forms.Label lblSach;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblTienCocInfo;
        private System.Windows.Forms.Label lblNgayThueInfo;
        private System.Windows.Forms.Label lblKhachHangInfo;
        private System.Windows.Forms.DateTimePicker dtpNgayTra;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblNV;
        private System.Windows.Forms.ComboBox cboMaThue;
        private System.Windows.Forms.Label lblPhieuThue;
        private System.Windows.Forms.Button btnAutoMa;
        private System.Windows.Forms.TextBox txtMaTra;
        private System.Windows.Forms.Label lblMa;
    }
}

