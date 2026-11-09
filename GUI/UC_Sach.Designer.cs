namespace BTL.GUI
{
    partial class UC_Sach
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.btnAutoMa = new System.Windows.Forms.Button();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoaiSach = new System.Windows.Forms.ComboBox();
            this.lblLV = new System.Windows.Forms.Label();
            this.cboLinhVuc = new System.Windows.Forms.ComboBox();
            this.lblTG = new System.Windows.Forms.Label();
            this.cboTacGia = new System.Windows.Forms.ComboBox();
            this.lblNXB = new System.Windows.Forms.Label();
            this.cboNXB = new System.Windows.Forms.ComboBox();
            this.lblNN = new System.Windows.Forms.Label();
            this.cboNgonNgu = new System.Windows.Forms.ComboBox();
            this.lblTT = new System.Windows.Forms.Label();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.lblSoTrang = new System.Windows.Forms.Label();
            this.numSoTrang = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblGiaSach = new System.Windows.Forms.Label();
            this.numGiaSach = new System.Windows.Forms.NumericUpDown();
            this.lblDonGiaThue = new System.Windows.Forms.Label();
            this.numDonGiaThue = new System.Windows.Forms.NumericUpDown();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtAnh = new System.Windows.Forms.TextBox();
            this.pnlPicBorder = new System.Windows.Forms.Panel();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.btnXoaAnh = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.lblTim = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTrang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGiaThue)).BeginInit();
            this.pnlPicBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTotal);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(20, 12, 20, 10);
            this.pnlTop.Size = new System.Drawing.Size(1020, 60);
            this.pnlTop.TabIndex = 0;

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
            this.lblTitle.Text = "QUẢN LÝ SÁCH TRUYỆN";

            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTotal.Location = new System.Drawing.Point(820, 20);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(104, 17);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Tổng: 0 đầu sách";

            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.Controls.Add(this.txtTimKiem);
            this.pnlInput.Controls.Add(this.lblTim);
            this.pnlInput.Controls.Add(this.btnXuatExcel);
            this.pnlInput.Controls.Add(this.btnLamMoi);
            this.pnlInput.Controls.Add(this.btnXoa);
            this.pnlInput.Controls.Add(this.btnSua);
            this.pnlInput.Controls.Add(this.btnThem);
            this.pnlInput.Controls.Add(this.btnXoaAnh);
            this.pnlInput.Controls.Add(this.btnChonAnh);
            this.pnlInput.Controls.Add(this.pnlPicBorder);
            this.pnlInput.Controls.Add(this.txtAnh);
            this.pnlInput.Controls.Add(this.txtGhiChu);
            this.pnlInput.Controls.Add(this.lblGhiChu);
            this.pnlInput.Controls.Add(this.numDonGiaThue);
            this.pnlInput.Controls.Add(this.lblDonGiaThue);
            this.pnlInput.Controls.Add(this.numGiaSach);
            this.pnlInput.Controls.Add(this.lblGiaSach);
            this.pnlInput.Controls.Add(this.numSoLuong);
            this.pnlInput.Controls.Add(this.lblSoLuong);
            this.pnlInput.Controls.Add(this.numSoTrang);
            this.pnlInput.Controls.Add(this.lblSoTrang);
            this.pnlInput.Controls.Add(this.cboTinhTrang);
            this.pnlInput.Controls.Add(this.lblTT);
            this.pnlInput.Controls.Add(this.cboNgonNgu);
            this.pnlInput.Controls.Add(this.lblNN);
            this.pnlInput.Controls.Add(this.cboNXB);
            this.pnlInput.Controls.Add(this.lblNXB);
            this.pnlInput.Controls.Add(this.cboTacGia);
            this.pnlInput.Controls.Add(this.lblTG);
            this.pnlInput.Controls.Add(this.cboLinhVuc);
            this.pnlInput.Controls.Add(this.lblLV);
            this.pnlInput.Controls.Add(this.cboLoaiSach);
            this.pnlInput.Controls.Add(this.lblLoai);
            this.pnlInput.Controls.Add(this.txtTenSach);
            this.pnlInput.Controls.Add(this.lblTen);
            this.pnlInput.Controls.Add(this.btnAutoMa);
            this.pnlInput.Controls.Add(this.txtMaSach);
            this.pnlInput.Controls.Add(this.lblMa);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 60);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.pnlInput.Size = new System.Drawing.Size(1020, 275);
            this.pnlInput.TabIndex = 1;

            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblMa.Location = new System.Drawing.Point(20, 15);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(61, 17);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã sách:";

            // 
            // txtMaSach
            // 
            this.txtMaSach.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtMaSach.Location = new System.Drawing.Point(100, 12);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.ReadOnly = true;
            this.txtMaSach.Size = new System.Drawing.Size(110, 24);
            this.txtMaSach.TabIndex = 1;

            // 
            // btnAutoMa
            // 
            this.btnAutoMa.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnAutoMa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoMa.FlatAppearance.BorderSize = 0;
            this.btnAutoMa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoMa.Location = new System.Drawing.Point(215, 11);
            this.btnAutoMa.Name = "btnAutoMa";
            this.btnAutoMa.Size = new System.Drawing.Size(70, 27);
            this.btnAutoMa.TabIndex = 2;
            this.btnAutoMa.Text = "Tự sinh";
            this.btnAutoMa.UseVisualStyleBackColor = false;

            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTen.Location = new System.Drawing.Point(20, 50);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(64, 17);
            this.lblTen.TabIndex = 3;
            this.lblTen.Text = "Tên sách:";

            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(100, 47);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(185, 24);
            this.txtTenSach.TabIndex = 4;

            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblLoai.Location = new System.Drawing.Point(20, 85);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(68, 17);
            this.lblLoai.TabIndex = 5;
            this.lblLoai.Text = "Loại sách:";

            // 
            // cboLoaiSach
            // 
            this.cboLoaiSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiSach.FormattingEnabled = true;
            this.cboLoaiSach.Location = new System.Drawing.Point(100, 82);
            this.cboLoaiSach.Name = "cboLoaiSach";
            this.cboLoaiSach.Size = new System.Drawing.Size(185, 25);
            this.cboLoaiSach.TabIndex = 6;

            // 
            // lblLV
            // 
            this.lblLV.AutoSize = true;
            this.lblLV.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblLV.Location = new System.Drawing.Point(20, 120);
            this.lblLV.Name = "lblLV";
            this.lblLV.Size = new System.Drawing.Size(60, 17);
            this.lblLV.TabIndex = 7;
            this.lblLV.Text = "Lĩnh vực:";

            // 
            // cboLinhVuc
            // 
            this.cboLinhVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLinhVuc.FormattingEnabled = true;
            this.cboLinhVuc.Location = new System.Drawing.Point(100, 117);
            this.cboLinhVuc.Name = "cboLinhVuc";
            this.cboLinhVuc.Size = new System.Drawing.Size(185, 25);
            this.cboLinhVuc.TabIndex = 8;

            // 
            // lblTG
            // 
            this.lblTG.AutoSize = true;
            this.lblTG.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTG.Location = new System.Drawing.Point(20, 155);
            this.lblTG.Name = "lblTG";
            this.lblTG.Size = new System.Drawing.Size(53, 17);
            this.lblTG.TabIndex = 9;
            this.lblTG.Text = "Tác giả:";

            // 
            // cboTacGia
            // 
            this.cboTacGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTacGia.FormattingEnabled = true;
            this.cboTacGia.Location = new System.Drawing.Point(100, 152);
            this.cboTacGia.Name = "cboTacGia";
            this.cboTacGia.Size = new System.Drawing.Size(185, 25);
            this.cboTacGia.TabIndex = 10;

            // 
            // lblNXB
            // 
            this.lblNXB.AutoSize = true;
            this.lblNXB.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblNXB.Location = new System.Drawing.Point(310, 15);
            this.lblNXB.Name = "lblNXB";
            this.lblNXB.Size = new System.Drawing.Size(58, 17);
            this.lblNXB.TabIndex = 11;
            this.lblNXB.Text = "Nhà XB:";

            // 
            // cboNXB
            // 
            this.cboNXB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNXB.FormattingEnabled = true;
            this.cboNXB.Location = new System.Drawing.Point(395, 12);
            this.cboNXB.Name = "cboNXB";
            this.cboNXB.Size = new System.Drawing.Size(175, 25);
            this.cboNXB.TabIndex = 12;

            // 
            // lblNN
            // 
            this.lblNN.AutoSize = true;
            this.lblNN.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblNN.Location = new System.Drawing.Point(310, 50);
            this.lblNN.Name = "lblNN";
            this.lblNN.Size = new System.Drawing.Size(71, 17);
            this.lblNN.TabIndex = 13;
            this.lblNN.Text = "Ngôn ngữ:";

            // 
            // cboNgonNgu
            // 
            this.cboNgonNgu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNgonNgu.FormattingEnabled = true;
            this.cboNgonNgu.Location = new System.Drawing.Point(395, 47);
            this.cboNgonNgu.Name = "cboNgonNgu";
            this.cboNgonNgu.Size = new System.Drawing.Size(175, 25);
            this.cboNgonNgu.TabIndex = 14;

            // 
            // lblTT
            // 
            this.lblTT.AutoSize = true;
            this.lblTT.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTT.Location = new System.Drawing.Point(310, 85);
            this.lblTT.Name = "lblTT";
            this.lblTT.Size = new System.Drawing.Size(73, 17);
            this.lblTT.TabIndex = 15;
            this.lblTT.Text = "Tình trạng:";

            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhTrang.FormattingEnabled = true;
            this.cboTinhTrang.Location = new System.Drawing.Point(395, 82);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(175, 25);
            this.cboTinhTrang.TabIndex = 16;

            // 
            // lblSoTrang
            // 
            this.lblSoTrang.AutoSize = true;
            this.lblSoTrang.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblSoTrang.Location = new System.Drawing.Point(310, 120);
            this.lblSoTrang.Name = "lblSoTrang";
            this.lblSoTrang.Size = new System.Drawing.Size(63, 17);
            this.lblSoTrang.TabIndex = 17;
            this.lblSoTrang.Text = "Số trang:";

            // 
            // numSoTrang
            // 
            this.numSoTrang.Location = new System.Drawing.Point(395, 117);
            this.numSoTrang.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numSoTrang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoTrang.Name = "numSoTrang";
            this.numSoTrang.Size = new System.Drawing.Size(175, 24);
            this.numSoTrang.TabIndex = 18;
            this.numSoTrang.Value = new decimal(new int[] { 150, 0, 0, 0 });

            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblSoLuong.Location = new System.Drawing.Point(310, 155);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(68, 17);
            this.lblSoLuong.TabIndex = 19;
            this.lblSoLuong.Text = "Số lượng:";

            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(395, 152);
            this.numSoLuong.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(175, 24);
            this.numSoLuong.TabIndex = 20;
            this.numSoLuong.Value = new decimal(new int[] { 5, 0, 0, 0 });

            // 
            // lblGiaSach
            // 
            this.lblGiaSach.AutoSize = true;
            this.lblGiaSach.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblGiaSach.Location = new System.Drawing.Point(595, 15);
            this.lblGiaSach.Name = "lblGiaSach";
            this.lblGiaSach.Size = new System.Drawing.Size(73, 17);
            this.lblGiaSach.TabIndex = 21;
            this.lblGiaSach.Text = "Giá bìa (đ):";

            // 
            // numGiaSach
            // 
            this.numGiaSach.Increment = new decimal(new int[] { 5000, 0, 0, 0 });
            this.numGiaSach.Location = new System.Drawing.Point(690, 12);
            this.numGiaSach.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numGiaSach.Name = "numGiaSach";
            this.numGiaSach.Size = new System.Drawing.Size(140, 24);
            this.numGiaSach.TabIndex = 22;
            this.numGiaSach.ThousandsSeparator = true;
            this.numGiaSach.Value = new decimal(new int[] { 50000, 0, 0, 0 });

            // 
            // lblDonGiaThue
            // 
            this.lblDonGiaThue.AutoSize = true;
            this.lblDonGiaThue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDonGiaThue.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDonGiaThue.Location = new System.Drawing.Point(595, 50);
            this.lblDonGiaThue.Name = "lblDonGiaThue";
            this.lblDonGiaThue.Size = new System.Drawing.Size(95, 17);
            this.lblDonGiaThue.TabIndex = 23;
            this.lblDonGiaThue.Text = "Giá thuê/Day:";

            // 
            // numDonGiaThue
            // 
            this.numDonGiaThue.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numDonGiaThue.Location = new System.Drawing.Point(690, 47);
            this.numDonGiaThue.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numDonGiaThue.Name = "numDonGiaThue";
            this.numDonGiaThue.Size = new System.Drawing.Size(140, 24);
            this.numDonGiaThue.TabIndex = 24;
            this.numDonGiaThue.ThousandsSeparator = true;
            this.numDonGiaThue.Value = new decimal(new int[] { 3000, 0, 0, 0 });

            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblGhiChu.Location = new System.Drawing.Point(595, 85);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(54, 17);
            this.lblGhiChu.TabIndex = 25;
            this.lblGhiChu.Text = "Ghi chú:";

            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(690, 82);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(140, 60);
            this.txtGhiChu.TabIndex = 26;

            // 
            // txtAnh
            // 
            this.txtAnh.Location = new System.Drawing.Point(690, 152);
            this.txtAnh.Name = "txtAnh";
            this.txtAnh.PlaceholderText = "Đường dẫn ảnh";
            this.txtAnh.ReadOnly = true;
            this.txtAnh.Size = new System.Drawing.Size(140, 24);
            this.txtAnh.TabIndex = 27;

            // 
            // pnlPicBorder
            // 
            this.pnlPicBorder.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlPicBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPicBorder.Controls.Add(this.picAnh);
            this.pnlPicBorder.Location = new System.Drawing.Point(855, 10);
            this.pnlPicBorder.Name = "pnlPicBorder";
            this.pnlPicBorder.Size = new System.Drawing.Size(130, 170);
            this.pnlPicBorder.TabIndex = 28;

            // 
            // picAnh
            // 
            this.picAnh.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.picAnh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picAnh.Location = new System.Drawing.Point(0, 0);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(128, 168);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnh.TabIndex = 0;
            this.picAnh.TabStop = false;

            // 
            // btnChonAnh
            // 
            this.btnChonAnh.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnChonAnh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChonAnh.FlatAppearance.BorderSize = 0;
            this.btnChonAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonAnh.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnChonAnh.Location = new System.Drawing.Point(855, 185);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(65, 26);
            this.btnChonAnh.TabIndex = 29;
            this.btnChonAnh.Text = "Chọn ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = false;

            // 
            // btnXoaAnh
            // 
            this.btnXoaAnh.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnXoaAnh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaAnh.FlatAppearance.BorderSize = 0;
            this.btnXoaAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaAnh.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnXoaAnh.Location = new System.Drawing.Point(922, 185);
            this.btnXoaAnh.Name = "btnXoaAnh";
            this.btnXoaAnh.Size = new System.Drawing.Size(63, 26);
            this.btnXoaAnh.TabIndex = 30;
            this.btnXoaAnh.Text = "Bỏ ảnh";
            this.btnXoaAnh.UseVisualStyleBackColor = false;

            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(20, 225);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 32);
            this.btnThem.TabIndex = 31;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = false;

            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(140, 225);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 32);
            this.btnSua.TabIndex = 32;
            this.btnSua.Text = "Cập nhật";
            this.btnSua.UseVisualStyleBackColor = false;

            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(260, 225);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 32);
            this.btnXoa.TabIndex = 33;
            this.btnXoa.Text = "Xóa sách";
            this.btnXoa.UseVisualStyleBackColor = false;

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(96, 123, 153);
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(380, 225);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 32);
            this.btnLamMoi.TabIndex = 34;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;

            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.White;
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 231, 241);
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.btnXuatExcel.Location = new System.Drawing.Point(500, 225);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(105, 32);
            this.btnXuatExcel.TabIndex = 35;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;

            // 
            // lblTim
            // 
            this.lblTim.AutoSize = true;
            this.lblTim.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTim.Location = new System.Drawing.Point(620, 230);
            this.lblTim.Name = "lblTim";
            this.lblTim.Size = new System.Drawing.Size(75, 17);
            this.lblTim.TabIndex = 36;
            this.lblTim.Text = "Tìm nhanh:";

            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(700, 226);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Nhập tên sách, tác giả...";
            this.txtTimKiem.Size = new System.Drawing.Size(180, 24);
            this.txtTimKiem.TabIndex = 37;

            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvSach);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 335);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.pnlGrid.Size = new System.Drawing.Size(1020, 365);
            this.pnlGrid.TabIndex = 2;

            // 
            // dgvSach
            // 
            this.dgvSach.AllowUserToAddRows = false;
            this.dgvSach.AllowUserToDeleteRows = false;
            this.dgvSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSach.BackgroundColor = System.Drawing.Color.White;
            this.dgvSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSach.Location = new System.Drawing.Point(20, 10);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.ReadOnly = true;
            this.dgvSach.RowHeadersVisible = false;
            this.dgvSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSach.Size = new System.Drawing.Size(980, 335);
            this.dgvSach.TabIndex = 0;

            // 
            // UC_Sach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 249, 252);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "UC_Sach";
            this.Size = new System.Drawing.Size(1020, 700);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTrang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGiaThue)).EndInit();
            this.pnlPicBorder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Button btnAutoMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoaiSach;
        private System.Windows.Forms.Label lblLV;
        private System.Windows.Forms.ComboBox cboLinhVuc;
        private System.Windows.Forms.Label lblTG;
        private System.Windows.Forms.ComboBox cboTacGia;
        private System.Windows.Forms.Label lblNXB;
        private System.Windows.Forms.ComboBox cboNXB;
        private System.Windows.Forms.Label lblNN;
        private System.Windows.Forms.ComboBox cboNgonNgu;
        private System.Windows.Forms.Label lblTT;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.Label lblSoTrang;
        private System.Windows.Forms.NumericUpDown numSoTrang;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label lblGiaSach;
        private System.Windows.Forms.NumericUpDown numGiaSach;
        private System.Windows.Forms.Label lblDonGiaThue;
        private System.Windows.Forms.NumericUpDown numDonGiaThue;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtAnh;
        private System.Windows.Forms.Panel pnlPicBorder;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Button btnXoaAnh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Label lblTim;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvSach;
    }
}

