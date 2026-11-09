namespace BTL.GUI
{
    partial class UC_Dashboard
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
            this.pnlCards = new System.Windows.Forms.Panel();
            this.card1 = new System.Windows.Forms.Panel();
            this.stripe1 = new System.Windows.Forms.Panel();
            this.lblTitleCard1 = new System.Windows.Forms.Label();
            this.lblTotalSach = new System.Windows.Forms.Label();
            this.card2 = new System.Windows.Forms.Panel();
            this.stripe2 = new System.Windows.Forms.Panel();
            this.lblTitleCard2 = new System.Windows.Forms.Label();
            this.lblDangThue = new System.Windows.Forms.Label();
            this.card3 = new System.Windows.Forms.Panel();
            this.stripe3 = new System.Windows.Forms.Panel();
            this.lblTitleCard3 = new System.Windows.Forms.Label();
            this.lblTotalKH = new System.Windows.Forms.Label();
            this.card4 = new System.Windows.Forms.Panel();
            this.stripe4 = new System.Windows.Forms.Panel();
            this.lblTitleCard4 = new System.Windows.Forms.Label();
            this.lblTotalTra = new System.Windows.Forms.Label();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.dgvRecent = new System.Windows.Forms.DataGridView();
            this.lblRecentTitle = new System.Windows.Forms.Label();
            this.pnlCards.SuspendLayout();
            this.card1.SuspendLayout();
            this.card2.SuspendLayout();
            this.card3.SuspendLayout();
            this.card4.SuspendLayout();
            this.pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlCards
            // 
            this.pnlCards.BackColor = System.Drawing.Color.FromArgb(244, 249, 252);
            this.pnlCards.Controls.Add(this.card4);
            this.pnlCards.Controls.Add(this.card3);
            this.pnlCards.Controls.Add(this.card2);
            this.pnlCards.Controls.Add(this.card1);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 0);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Padding = new System.Windows.Forms.Padding(15, 15, 15, 10);
            this.pnlCards.Size = new System.Drawing.Size(1100, 130);
            this.pnlCards.TabIndex = 0;

            // 
            // card1
            // 
            this.card1.BackColor = System.Drawing.Color.White;
            this.card1.Controls.Add(this.lblTotalSach);
            this.card1.Controls.Add(this.lblTitleCard1);
            this.card1.Controls.Add(this.stripe1);
            this.card1.Location = new System.Drawing.Point(15, 15);
            this.card1.Name = "card1";
            this.card1.Size = new System.Drawing.Size(240, 100);
            this.card1.TabIndex = 0;

            // 
            // stripe1
            // 
            this.stripe1.BackColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.stripe1.Dock = System.Windows.Forms.DockStyle.Left;
            this.stripe1.Location = new System.Drawing.Point(0, 0);
            this.stripe1.Name = "stripe1";
            this.stripe1.Size = new System.Drawing.Size(6, 100);
            this.stripe1.TabIndex = 0;

            // 
            // lblTitleCard1
            // 
            this.lblTitleCard1.AutoSize = true;
            this.lblTitleCard1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTitleCard1.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitleCard1.Location = new System.Drawing.Point(20, 16);
            this.lblTitleCard1.Name = "lblTitleCard1";
            this.lblTitleCard1.Size = new System.Drawing.Size(95, 17);
            this.lblTitleCard1.TabIndex = 1;
            this.lblTitleCard1.Text = "Tổng đầu sách";

            // 
            // lblTotalSach
            // 
            this.lblTotalSach.AutoSize = true;
            this.lblTotalSach.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalSach.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTotalSach.Location = new System.Drawing.Point(20, 42);
            this.lblTotalSach.Name = "lblTotalSach";
            this.lblTotalSach.Size = new System.Drawing.Size(33, 37);
            this.lblTotalSach.TabIndex = 2;
            this.lblTotalSach.Text = "0";

            // 
            // card2
            // 
            this.card2.BackColor = System.Drawing.Color.White;
            this.card2.Controls.Add(this.lblDangThue);
            this.card2.Controls.Add(this.lblTitleCard2);
            this.card2.Controls.Add(this.stripe2);
            this.card2.Location = new System.Drawing.Point(270, 15);
            this.card2.Name = "card2";
            this.card2.Size = new System.Drawing.Size(240, 100);
            this.card2.TabIndex = 1;

            // 
            // stripe2
            // 
            this.stripe2.BackColor = System.Drawing.Color.FromArgb(8, 127, 181);
            this.stripe2.Dock = System.Windows.Forms.DockStyle.Left;
            this.stripe2.Location = new System.Drawing.Point(0, 0);
            this.stripe2.Name = "stripe2";
            this.stripe2.Size = new System.Drawing.Size(6, 100);
            this.stripe2.TabIndex = 0;

            // 
            // lblTitleCard2
            // 
            this.lblTitleCard2.AutoSize = true;
            this.lblTitleCard2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTitleCard2.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitleCard2.Location = new System.Drawing.Point(20, 16);
            this.lblTitleCard2.Name = "lblTitleCard2";
            this.lblTitleCard2.Size = new System.Drawing.Size(98, 17);
            this.lblTitleCard2.TabIndex = 1;
            this.lblTitleCard2.Text = "Sách đang thuê";

            // 
            // lblDangThue
            // 
            this.lblDangThue.AutoSize = true;
            this.lblDangThue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblDangThue.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDangThue.Location = new System.Drawing.Point(20, 42);
            this.lblDangThue.Name = "lblDangThue";
            this.lblDangThue.Size = new System.Drawing.Size(33, 37);
            this.lblDangThue.TabIndex = 2;
            this.lblDangThue.Text = "0";

            // 
            // card3
            // 
            this.card3.BackColor = System.Drawing.Color.White;
            this.card3.Controls.Add(this.lblTotalKH);
            this.card3.Controls.Add(this.lblTitleCard3);
            this.card3.Controls.Add(this.stripe3);
            this.card3.Location = new System.Drawing.Point(525, 15);
            this.card3.Name = "card3";
            this.card3.Size = new System.Drawing.Size(240, 100);
            this.card3.TabIndex = 2;

            // 
            // stripe3
            // 
            this.stripe3.BackColor = System.Drawing.Color.FromArgb(202, 138, 4);
            this.stripe3.Dock = System.Windows.Forms.DockStyle.Left;
            this.stripe3.Location = new System.Drawing.Point(0, 0);
            this.stripe3.Name = "stripe3";
            this.stripe3.Size = new System.Drawing.Size(6, 100);
            this.stripe3.TabIndex = 0;

            // 
            // lblTitleCard3
            // 
            this.lblTitleCard3.AutoSize = true;
            this.lblTitleCard3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTitleCard3.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitleCard3.Location = new System.Drawing.Point(20, 16);
            this.lblTitleCard3.Name = "lblTitleCard3";
            this.lblTitleCard3.Size = new System.Drawing.Size(76, 17);
            this.lblTitleCard3.TabIndex = 1;
            this.lblTitleCard3.Text = "Khách hàng";

            // 
            // lblTotalKH
            // 
            this.lblTotalKH.AutoSize = true;
            this.lblTotalKH.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalKH.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTotalKH.Location = new System.Drawing.Point(20, 42);
            this.lblTotalKH.Name = "lblTotalKH";
            this.lblTotalKH.Size = new System.Drawing.Size(33, 37);
            this.lblTotalKH.TabIndex = 2;
            this.lblTotalKH.Text = "0";

            // 
            // card4
            // 
            this.card4.BackColor = System.Drawing.Color.White;
            this.card4.Controls.Add(this.lblTotalTra);
            this.card4.Controls.Add(this.lblTitleCard4);
            this.card4.Controls.Add(this.stripe4);
            this.card4.Location = new System.Drawing.Point(780, 15);
            this.card4.Name = "card4";
            this.card4.Size = new System.Drawing.Size(240, 100);
            this.card4.TabIndex = 3;

            // 
            // stripe4
            // 
            this.stripe4.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.stripe4.Dock = System.Windows.Forms.DockStyle.Left;
            this.stripe4.Location = new System.Drawing.Point(0, 0);
            this.stripe4.Name = "stripe4";
            this.stripe4.Size = new System.Drawing.Size(6, 100);
            this.stripe4.TabIndex = 0;

            // 
            // lblTitleCard4
            // 
            this.lblTitleCard4.AutoSize = true;
            this.lblTitleCard4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTitleCard4.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitleCard4.Location = new System.Drawing.Point(20, 16);
            this.lblTitleCard4.Name = "lblTitleCard4";
            this.lblTitleCard4.Size = new System.Drawing.Size(107, 17);
            this.lblTitleCard4.TabIndex = 1;
            this.lblTitleCard4.Text = "Phiếu trả đã lập";

            // 
            // lblTotalTra
            // 
            this.lblTotalTra.AutoSize = true;
            this.lblTotalTra.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalTra.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTotalTra.Location = new System.Drawing.Point(20, 42);
            this.lblTotalTra.Name = "lblTotalTra";
            this.lblTotalTra.Size = new System.Drawing.Size(33, 37);
            this.lblTotalTra.TabIndex = 2;
            this.lblTotalTra.Text = "0";

            // 
            // pnlTable
            // 
            this.pnlTable.BackColor = System.Drawing.Color.FromArgb(244, 249, 252);
            this.pnlTable.Controls.Add(this.dgvRecent);
            this.pnlTable.Controls.Add(this.lblRecentTitle);
            this.pnlTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTable.Location = new System.Drawing.Point(0, 130);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Padding = new System.Windows.Forms.Padding(15, 5, 15, 15);
            this.pnlTable.Size = new System.Drawing.Size(1100, 520);
            this.pnlTable.TabIndex = 1;

            // 
            // lblRecentTitle
            // 
            this.lblRecentTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRecentTitle.ForeColor = System.Drawing.Color.FromArgb(28, 66, 121);
            this.lblRecentTitle.Location = new System.Drawing.Point(15, 5);
            this.lblRecentTitle.Name = "lblRecentTitle";
            this.lblRecentTitle.Size = new System.Drawing.Size(1070, 35);
            this.lblRecentTitle.TabIndex = 0;
            this.lblRecentTitle.Text = "Danh sách sách đang được thuê chưa trả (Cập nhật thời gian thực)";
            this.lblRecentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // dgvRecent
            // 
            this.dgvRecent.AllowUserToAddRows = false;
            this.dgvRecent.AllowUserToDeleteRows = false;
            this.dgvRecent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecent.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvRecent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecent.Location = new System.Drawing.Point(15, 40);
            this.dgvRecent.Name = "dgvRecent";
            this.dgvRecent.ReadOnly = true;
            this.dgvRecent.RowHeadersVisible = false;
            this.dgvRecent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecent.Size = new System.Drawing.Size(1070, 465);
            this.dgvRecent.TabIndex = 1;

            // 
            // UC_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 249, 252);
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.pnlCards);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(1100, 650);
            this.pnlCards.ResumeLayout(false);
            this.card1.ResumeLayout(false);
            this.card1.PerformLayout();
            this.card2.ResumeLayout(false);
            this.card2.PerformLayout();
            this.card3.ResumeLayout(false);
            this.card3.PerformLayout();
            this.card4.ResumeLayout(false);
            this.card4.PerformLayout();
            this.pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Panel card1;
        private System.Windows.Forms.Panel stripe1;
        private System.Windows.Forms.Label lblTitleCard1;
        private System.Windows.Forms.Label lblTotalSach;
        private System.Windows.Forms.Panel card2;
        private System.Windows.Forms.Panel stripe2;
        private System.Windows.Forms.Label lblTitleCard2;
        private System.Windows.Forms.Label lblDangThue;
        private System.Windows.Forms.Panel card3;
        private System.Windows.Forms.Panel stripe3;
        private System.Windows.Forms.Label lblTitleCard3;
        private System.Windows.Forms.Label lblTotalKH;
        private System.Windows.Forms.Panel card4;
        private System.Windows.Forms.Panel stripe4;
        private System.Windows.Forms.Label lblTitleCard4;
        private System.Windows.Forms.Label lblTotalTra;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.Label lblRecentTitle;
        private System.Windows.Forms.DataGridView dgvRecent;
    }
}

