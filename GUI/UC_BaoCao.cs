using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BTL.BLL;

namespace BTL.GUI
{
    public partial class UC_BaoCao : UserControl
    {
        private readonly BaoCaoBLL _baoCaoBLL = new();
        private DataTable _dtDoanhThu = new();

        public UC_BaoCao()
        {
            InitializeComponent();
            UITheme.StyleDataGridView(dgvSachChuaTra);
            UITheme.StyleDataGridView(dgvDoanhThu);
            UITheme.StyleDataGridView(dgvTop5);

            // Khởi tạo giá trị mặc định cho các bộ lọc
            if (cboKieuDoanhThu.Items.Count > 0 && cboKieuDoanhThu.SelectedIndex < 0)
            {
                cboKieuDoanhThu.SelectedIndex = 0; // Mặc định: Theo Tháng
            }

            int currentYear = DateTime.Now.Year;
            if (numNamDoanhThu.Minimum <= currentYear && numNamDoanhThu.Maximum >= currentYear)
            {
                numNamDoanhThu.Value = currentYear;
            }

            chkTatCaThoiGian.Checked = true;
            dtpTuNgay.Enabled = false;
            dtpDenNgay.Enabled = false;

            SetupEvents();

            // Nạp dữ liệu khi Control đã sẵn sàng
            this.Load += UC_BaoCao_Load;
        }

        private void UC_BaoCao_Load(object? sender, EventArgs e)
        {
            LoadBaoCao1();
            LoadBaoCao2();
            LoadBaoCao3();
        }

        private void SetupEvents()
        {
            // Chuyển Tab tự động nạp lại dữ liệu
            tabBaoCao.SelectedIndexChanged += (s, e) =>
            {
                if (tabBaoCao.SelectedIndex == 0) LoadBaoCao1();
                else if (tabBaoCao.SelectedIndex == 1) LoadBaoCao2();
                else if (tabBaoCao.SelectedIndex == 2) LoadBaoCao3();
            };

            // Tab 1
            btnLamMoiChuaTra.Click += (s, e) => LoadBaoCao1();
            btnXuatExcel1.Click += (s, e) => ExportExcelHelper.Export(dgvSachChuaTra, "BaoCao_SachChuaTra", "Báo Cáo Sách Truyện Đang Được Thuê Chưa Trả");

            // Tab 2
            btnXemDoanhThu.Click += (s, e) => LoadBaoCao2();
            btnXuatExcel2.Click += (s, e) =>
            {
                string kieuText = cboKieuDoanhThu.SelectedItem?.ToString() ?? "Theo Tháng";
                ExportExcelHelper.Export(dgvDoanhThu, "BaoCao_DoanhThu", $"Báo Cáo Doanh Thu {kieuText} Năm {numNamDoanhThu.Value}");
            };
            pnlChart.Paint += PnlChart_Paint;
            pnlChart.Resize += (s, e) => pnlChart.Invalidate();

            // Tab 3
            chkTatCaThoiGian.CheckedChanged += (s, e) =>
            {
                dtpTuNgay.Enabled = !chkTatCaThoiGian.Checked;
                dtpDenNgay.Enabled = !chkTatCaThoiGian.Checked;
                LoadBaoCao3();
            };
            btnXemTop5.Click += (s, e) => LoadBaoCao3();
            btnXuatExcel3.Click += (s, e) => ExportExcelHelper.Export(dgvTop5, "BaoCao_Top5SachDoanhThu", "Báo Cáo Top 5 Sách Truyện Đạt Doanh Thu Cao Nhất");
            dgvTop5.CellFormatting += DgvTop5_CellFormatting;
        }

        #region 1. TAB BÁO CÁO 1: SÁCH ĐANG THUÊ CHƯA TRẢ (YÊU CẦU 7)
        private void LoadBaoCao1()
        {
            try
            {
                var dt = _baoCaoBLL.GetSachDangThueChuaTra() ?? new DataTable();
                dgvSachChuaTra.DataSource = dt;

                foreach (DataGridViewColumn col in dgvSachChuaTra.Columns)
                {
                    if (col.Name == "MaThue") col.HeaderText = "Mã Thuê";
                    else if (col.Name == "TenKH") col.HeaderText = "Khách Hàng";
                    else if (col.Name == "MaSach") col.HeaderText = "Mã Sách";
                    else if (col.Name == "TenSach") col.HeaderText = "Tên Sách";
                    else if (col.Name == "SoLuong") col.HeaderText = "Số Lượng";
                    else if (col.Name == "NgayThue") col.HeaderText = "Ngày Thuê";
                    else if (col.Name == "SoNgayDaThue") col.HeaderText = "Số Ngày Thuê";
                    else if (col.Name == "TienThueTamTinh")
                    {
                        col.HeaderText = "Tiền Tạm Tính";
                        col.DefaultCellStyle.Format = "N0";
                    }
                    else if (col.Name == "TienDatCoc")
                    {
                        col.HeaderText = "Tiền Cọc";
                        col.DefaultCellStyle.Format = "N0";
                    }
                    else if (col.Name == "NhanVienLap") col.HeaderText = "NV Lập";
                }

                int tongCuon = 0;
                decimal tongTamTinh = 0;
                decimal tongCoc = 0;

                foreach (DataRow r in dt.Rows)
                {
                    if (r["SoLuong"] != DBNull.Value) tongCuon += Convert.ToInt32(r["SoLuong"]);
                    if (r["TienThueTamTinh"] != DBNull.Value) tongTamTinh += Convert.ToDecimal(r["TienThueTamTinh"]);
                    if (r["TienDatCoc"] != DBNull.Value) tongCoc += Convert.ToDecimal(r["TienDatCoc"]);
                }

                lblTongChuaTra.Text = $"Tổng: {dt.Rows.Count} lượt ({tongCuon} cuốn)";
                lblTongTienTamTinh.Text = $"Tạm tính: {tongTamTinh:N0} đ";
                lblTongTienCoc.Text = $"Tiền cọc giữ: {tongCoc:N0} đ";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load bao cao 1 error: " + ex.Message);
            }
        }
        #endregion

        #region 2. TAB BÁO CÁO 2: DOANH THU THÁNG / QUÝ / NĂM (YÊU CẦU 8)
        private void LoadBaoCao2()
        {
            try
            {
                string kieu = "THANG";
                if (cboKieuDoanhThu.SelectedIndex == 1) kieu = "QUY";
                else if (cboKieuDoanhThu.SelectedIndex == 2) kieu = "NAM";

                int nam = (int)numNamDoanhThu.Value;
                _dtDoanhThu = _baoCaoBLL.GetDoanhThu(kieu, nam) ?? new DataTable();
                dgvDoanhThu.DataSource = _dtDoanhThu;

                foreach (DataGridViewColumn col in dgvDoanhThu.Columns)
                {
                    if (col.Name == "Ky")
                    {
                        col.HeaderText = kieu == "THANG" ? "Tháng" : (kieu == "QUY" ? "Quý" : "Năm");
                    }
                    else if (col.Name == "SoPhieuTra")
                    {
                        col.HeaderText = "Số Lượt Trả";
                    }
                    else if (col.Name == "DoanhThu")
                    {
                        col.HeaderText = "Doanh Thu (VNĐ)";
                        col.DefaultCellStyle.Format = "N0";
                    }
                }

                decimal tong = 0;
                foreach (DataRow r in _dtDoanhThu.Rows)
                {
                    if (r["DoanhThu"] != DBNull.Value) tong += Convert.ToDecimal(r["DoanhThu"]);
                }

                string kieuDisplay = kieu == "THANG" ? "Tháng" : (kieu == "QUY" ? "Quý" : "Năm");
                lblTongDoanhThu.Text = $"Tổng doanh thu ({kieuDisplay}): {tong:N0} đ";
                pnlChart.Invalidate();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load bao cao 2 error: " + ex.Message);
            }
        }

        private void PnlChart_Paint(object? sender, PaintEventArgs e)
        {
            try
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                var rect = pnlChart.ClientRectangle;
                if (rect.Width < 100 || rect.Height < 100) return;

                using var fontTitle = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                using var brushTitle = new SolidBrush(Color.FromArgb(30, 41, 59));
                g.DrawString("BIỂU ĐỒ DOANH THU", fontTitle, brushTitle, 20, 15);

                if (_dtDoanhThu == null || _dtDoanhThu.Rows.Count == 0)
                {
                    using var fontMsg = new Font("Segoe UI", 9.5F, FontStyle.Italic);
                    using var brushMsg = new SolidBrush(Color.FromArgb(148, 163, 184));
                    g.DrawString("Chưa có dữ liệu doanh thu trong kỳ này để hiển thị biểu đồ.", fontMsg, brushMsg, 20, 50);
                    return;
                }

                decimal maxVal = 0;
                foreach (DataRow r in _dtDoanhThu.Rows)
                {
                    if (r["DoanhThu"] != DBNull.Value)
                    {
                        decimal v = Convert.ToDecimal(r["DoanhThu"]);
                        if (v > maxVal) maxVal = v;
                    }
                }
                if (maxVal <= 0) maxVal = 1;

                int bottomY = rect.Height - 50;
                int topY = 60;
                int chartHeight = bottomY - topY;
                if (chartHeight <= 40) return;

                using var penAxis = new Pen(Color.FromArgb(203, 213, 225), 2);
                g.DrawLine(penAxis, 30, bottomY, Math.Max(30, rect.Width - 30), bottomY);

                int count = _dtDoanhThu.Rows.Count;
                int availableWidth = Math.Max(100, rect.Width - 80);
                int colWidth = Math.Max(16, Math.Min(48, availableWidth / Math.Max(1, count * 2)));
                int gap = Math.Max(10, colWidth);
                int startX = 40;

                using var fontLabel = new Font("Segoe UI", 8F);
                using var brushLabel = new SolidBrush(Color.FromArgb(71, 85, 105));
                using var brushVal = new SolidBrush(Color.FromArgb(37, 99, 235));

                for (int i = 0; i < count; i++)
                {
                    var r = _dtDoanhThu.Rows[i];
                    string ky = r["Ky"]?.ToString() ?? "";
                    decimal val = r["DoanhThu"] != DBNull.Value ? Convert.ToDecimal(r["DoanhThu"]) : 0;

                    int barHeight = (int)((val / maxVal) * (chartHeight - 30));
                    int barX = startX + i * (colWidth + gap);
                    int barY = bottomY - barHeight;

                    if (barHeight > 0 && colWidth > 0 && barY >= 0)
                    {
                        var barRect = new Rectangle(barX, barY, colWidth, barHeight);
                        try
                        {
                            using var brushBar = new LinearGradientBrush(barRect, UITheme.Blue, UITheme.Navy, LinearGradientMode.Vertical);
                            g.FillRectangle(brushBar, barRect);
                        }
                        catch
                        {
                            using var solidBar = new SolidBrush(UITheme.Blue);
                            g.FillRectangle(solidBar, barRect);
                        }
                    }

                    string prefix = cboKieuDoanhThu.SelectedIndex == 0 ? "T." : (cboKieuDoanhThu.SelectedIndex == 1 ? "Q." : "");
                    string kyText = prefix + ky;
                    g.DrawString(kyText, fontLabel, brushLabel, barX, bottomY + 8);

                    if (val > 0)
                    {
                        string valText = val >= 1000000 ? $"{val / 1000000:0.#}Tr" : $"{val / 1000:0}k";
                        g.DrawString(valText, fontLabel, brushVal, barX - 4, Math.Max(topY, barY - 18));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("PnlChart_Paint error: " + ex.Message);
            }
        }
        #endregion

        #region 3. TAB BÁO CÁO 3: TOP 5 SÁCH DOANH THU CAO NHẤT (YÊU CẦU 9)
        private void LoadBaoCao3()
        {
            try
            {
                DateTime? tu = chkTatCaThoiGian.Checked ? null : dtpTuNgay.Value.Date;
                DateTime? den = chkTatCaThoiGian.Checked ? null : dtpDenNgay.Value.Date;

                var dt = _baoCaoBLL.GetTop5Sach(tu, den) ?? new DataTable();
                dgvTop5.DataSource = dt;

                foreach (DataGridViewColumn col in dgvTop5.Columns)
                {
                    if (col.Name == "Hang")
                    {
                        col.HeaderText = "Thứ Hạng";
                        col.MinimumWidth = 80;
                    }
                    else if (col.Name == "MaSach")
                    {
                        col.HeaderText = "Mã Sách";
                        col.MinimumWidth = 90;
                    }
                    else if (col.Name == "TenSach")
                    {
                        col.HeaderText = "Tên Sách Truyện";
                    }
                    else if (col.Name == "TenTG")
                    {
                        col.HeaderText = "Tác Giả";
                    }
                    else if (col.Name == "SoLanThue")
                    {
                        col.HeaderText = "Số Lần Thuê";
                        col.MinimumWidth = 100;
                    }
                    else if (col.Name == "DoanhThu")
                    {
                        col.HeaderText = "Doanh Thu (VNĐ)";
                        col.DefaultCellStyle.Format = "N0";
                        col.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    string top1Ten = dt.Rows[0]["TenSach"]?.ToString() ?? "";
                    decimal top1DT = dt.Rows[0]["DoanhThu"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["DoanhThu"]) : 0;
                    lblTop1Info.Text = $"TOP 1: [{top1Ten}] - Doanh thu: {top1DT:N0} đ";
                }
                else
                {
                    lblTop1Info.Text = "Không có giao dịch trả sách nào trong khoảng thời gian đã chọn.";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load bao cao 3 error: " + ex.Message);
            }
        }

        private void DgvTop5_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.CellStyle == null || e.Value == null) return;

                if (e.ColumnIndex < dgvTop5.Columns.Count && dgvTop5.Columns[e.ColumnIndex].Name == "Hang")
                {
                    string valStr = e.Value.ToString()?.Replace("TOP ", "").Trim() ?? "";
                    if (int.TryParse(valStr, out int hang))
                    {
                        e.Value = $"TOP {hang}";
                        e.FormattingApplied = true;

                        if (hang == 1)
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);
                            e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        }
                        else if (hang == 2)
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(71, 85, 105);
                            e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        }
                        else if (hang == 3)
                        {
                            e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);
                            e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        }
                    }
                }
            }
            catch
            {
                // Bỏ qua lỗi format
            }
        }
        #endregion
    }
}
