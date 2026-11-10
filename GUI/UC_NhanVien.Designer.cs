namespace BTL.GUI
{
    partial class UC_NhanVien
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
            this.lblRoleNotice = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.btnAutoMa = new System.Windows.Forms.Button();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.lblNamSinh = new System.Windows.Forms.Label();
            this.numNamSinh = new System.Windows.Forms.NumericUpDown();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblLuong = new System.Windows.Forms.Label();
            this.numLuongThang = new System.Windows.Forms.NumericUpDown();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTim = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamSinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuongThang)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblRoleNotice);
            this.pnlTop.Controls.Add(this.lblTotal);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.pnlTop.Size = new System.Drawing.Size(950, 60);
            this.pnlTop.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ NHÂN VIÊN";

            // 
            // lblRoleNotice
            // 
            this.lblRoleNotice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoleNotice.AutoSize = true;
            this.lblRoleNotice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRoleNotice.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblRoleNotice.Location = new System.Drawing.Point(540, 22);
            this.lblRoleNotice.Name = "lblRoleNotice";
            this.lblRoleNotice.Size = new System.Drawing.Size(230, 15);
            this.lblRoleNotice.TabIndex = 2;
            this.lblRoleNotice.Text = "[Chế độ: Nhân viên - Chỉ được xem dữ liệu]";
            this.lblRoleNotice.Visible = false;

            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.lblTotal.Location = new System.Drawing.Point(790, 22);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 17);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Tổng: 0 nhân viên";

            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.Controls.Add(this.txtTimKiem);
            this.pnlInput.Controls.Add(this.lblTim);
            this.pnlInput.Controls.Add(this.btnLamMoi);
            this.pnlInput.Controls.Add(this.btnXoa);
            this.pnlInput.Controls.Add(this.btnSua);
            this.pnlInput.Controls.Add(this.btnThem);
            this.pnlInput.Controls.Add(this.cboChucVu);
            this.pnlInput.Controls.Add(this.lblChucVu);
            this.pnlInput.Controls.Add(this.txtDiaChi);
            this.pnlInput.Controls.Add(this.lblDiaChi);
            this.pnlInput.Controls.Add(this.numLuongThang);
            this.pnlInput.Controls.Add(this.lblLuong);
            this.pnlInput.Controls.Add(this.txtDienThoai);
            this.pnlInput.Controls.Add(this.lblPhone);
            this.pnlInput.Controls.Add(this.cboGioiTinh);
            this.pnlInput.Controls.Add(this.lblGioiTinh);
            this.pnlInput.Controls.Add(this.numNamSinh);
            this.pnlInput.Controls.Add(this.lblNamSinh);
            this.pnlInput.Controls.Add(this.txtTenNV);
            this.pnlInput.Controls.Add(this.lblTen);
            this.pnlInput.Controls.Add(this.btnAutoMa);
            this.pnlInput.Controls.Add(this.txtMaNV);
            this.pnlInput.Controls.Add(this.lblMa);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 60);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Padding = new System.Windows.Forms.Padding(20);
            this.pnlInput.Size = new System.Drawing.Size(950, 210);
            this.pnlInput.TabIndex = 1;

            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblMa.Location = new System.Drawing.Point(25, 20);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(89, 17);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã nhân viên:";

            // 
            // txtMaNV
            // 
            this.txtMaNV.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtMaNV.Location = new System.Drawing.Point(125, 16);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(90, 24);
            this.txtMaNV.TabIndex = 1;

            // 
            // btnAutoMa
            // 
            this.btnAutoMa.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnAutoMa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoMa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnAutoMa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoMa.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnAutoMa.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnAutoMa.Location = new System.Drawing.Point(220, 16);
            this.btnAutoMa.Name = "btnAutoMa";
            this.btnAutoMa.Size = new System.Drawing.Size(55, 24);
            this.btnAutoMa.TabIndex = 2;
            this.btnAutoMa.Text = "Tạo mã";
            this.btnAutoMa.UseVisualStyleBackColor = false;

            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTen.Location = new System.Drawing.Point(300, 20);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(66, 17);
            this.lblTen.TabIndex = 3;
            this.lblTen.Text = "Họ và tên:";

            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(375, 16);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(200, 24);
            this.txtTenNV.TabIndex = 4;

            // 
            // lblNamSinh
            // 
            this.lblNamSinh.AutoSize = true;
            this.lblNamSinh.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblNamSinh.Location = new System.Drawing.Point(600, 20);
            this.lblNamSinh.Name = "lblNamSinh";
            this.lblNamSinh.Size = new System.Drawing.Size(66, 17);
            this.lblNamSinh.TabIndex = 5;
            this.lblNamSinh.Text = "Năm sinh:";

            // 
            // numNamSinh
            // 
            this.numNamSinh.Location = new System.Drawing.Point(675, 16);
            this.numNamSinh.Maximum = new decimal(new int[] { 2050, 0, 0, 0 });
            this.numNamSinh.Minimum = new decimal(new int[] { 1950, 0, 0, 0 });
            this.numNamSinh.Name = "numNamSinh";
            this.numNamSinh.Size = new System.Drawing.Size(90, 24);
            this.numNamSinh.TabIndex = 6;
            this.numNamSinh.Value = new decimal(new int[] { 1998, 0, 0, 0 });

            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblGioiTinh.Location = new System.Drawing.Point(780, 20);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(59, 17);
            this.lblGioiTinh.TabIndex = 7;
            this.lblGioiTinh.Text = "Giới tính:";

            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam (M)",
            "Nữ (F)"});
            this.cboGioiTinh.Location = new System.Drawing.Point(845, 16);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(85, 25);
            this.cboGioiTinh.TabIndex = 8;

            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPhone.Location = new System.Drawing.Point(25, 60);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(95, 17);
            this.lblPhone.TabIndex = 9;
            this.lblPhone.Text = "SĐT (Mật khẩu):";

            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(125, 56);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(150, 24);
            this.txtDienThoai.TabIndex = 10;

            // 
            // lblLuong
            // 
            this.lblLuong.AutoSize = true;
            this.lblLuong.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblLuong.Location = new System.Drawing.Point(300, 60);
            this.lblLuong.Name = "lblLuong";
            this.lblLuong.Size = new System.Drawing.Size(84, 17);
            this.lblLuong.TabIndex = 11;
            this.lblLuong.Text = "Lương tháng:";

            // 
            // numLuongThang
            // 
            this.numLuongThang.Increment = new decimal(new int[] { 500000, 0, 0, 0 });
            this.numLuongThang.Location = new System.Drawing.Point(390, 56);
            this.numLuongThang.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numLuongThang.Name = "numLuongThang";
            this.numLuongThang.Size = new System.Drawing.Size(130, 24);
            this.numLuongThang.TabIndex = 12;
            this.numLuongThang.ThousandsSeparator = true;
            this.numLuongThang.Value = new decimal(new int[] { 7000000, 0, 0, 0 });

            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblChucVu.Location = new System.Drawing.Point(540, 60);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(57, 17);
            this.lblChucVu.TabIndex = 13;
            this.lblChucVu.Text = "Chức vụ:";

            // 
            // cboChucVu
            // 
            this.cboChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Items.AddRange(new object[] {
            "Admin (Quản trị)",
            "NhanVien (Nhân viên)"});
            this.cboChucVu.Location = new System.Drawing.Point(605, 56);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(160, 25);
            this.cboChucVu.TabIndex = 14;

            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDiaChi.Location = new System.Drawing.Point(25, 100);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(50, 17);
            this.lblDiaChi.TabIndex = 15;
            this.lblDiaChi.Text = "Địa chỉ:";

            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(125, 96);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(640, 24);
            this.txtDiaChi.TabIndex = 16;

            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(25, 148);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 32);
            this.btnThem.TabIndex = 17;
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
            this.btnSua.Location = new System.Drawing.Point(135, 148);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 32);
            this.btnSua.TabIndex = 18;
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
            this.btnXoa.Location = new System.Drawing.Point(245, 148);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 32);
            this.btnXoa.TabIndex = 19;
            this.btnXoa.Text = "Xóa";
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
            this.btnLamMoi.Location = new System.Drawing.Point(355, 148);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 32);
            this.btnLamMoi.TabIndex = 20;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;

            // 
            // lblTim
            // 
            this.lblTim.AutoSize = true;
            this.lblTim.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTim.Location = new System.Drawing.Point(485, 154);
            this.lblTim.Name = "lblTim";
            this.lblTim.Size = new System.Drawing.Size(68, 17);
            this.lblTim.TabIndex = 21;
            this.lblTim.Text = "Tìm kiếm:";

            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(560, 150);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Nhập tên, mã NV hoặc SĐT...";
            this.txtTimKiem.Size = new System.Drawing.Size(205, 24);
            this.txtTimKiem.TabIndex = 22;

            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvNhanVien);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 270);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(20, 15, 20, 20);
            this.pnlGrid.Size = new System.Drawing.Size(950, 430);
            this.pnlGrid.TabIndex = 2;

            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanVien.Location = new System.Drawing.Point(20, 15);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersVisible = false;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new System.Drawing.Size(910, 395);
            this.dgvNhanVien.TabIndex = 0;

            // 
            // UC_NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 249, 252);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "UC_NhanVien";
            this.Size = new System.Drawing.Size(950, 700);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamSinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuongThang)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblRoleNotice;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Button btnAutoMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label lblNamSinh;
        private System.Windows.Forms.NumericUpDown numNamSinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblLuong;
        private System.Windows.Forms.NumericUpDown numLuongThang;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTim;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvNhanVien;
    }
}
