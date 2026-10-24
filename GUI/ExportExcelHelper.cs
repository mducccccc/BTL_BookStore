using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using BTL.DTO;

namespace BTL.GUI
{
    public static class ExportExcelHelper
    {
        /// <summary>
        /// Xuất dữ liệu từ DataGridView ra tệp Excel (.xlsx) với phong cách trình bày chuẩn UTC
        /// </summary>
        public static bool Export(DataGridView dgv, string defaultFileName, string sheetTitle)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trong bảng để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = $"{defaultFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                Title = "Chọn nơi lưu tệp báo cáo Excel"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return false;

            try
            {
                using var workbook = new XLWorkbook();
                var ws = workbook.Worksheets.Add("BaoCao");
                ws.ShowGridLines = true;

                // 1. Dòng tiêu đề chính (Title Header)
                int colCount = 0;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible) colCount++;
                }
                if (colCount == 0) colCount = 1;

                // Tiêu đề đơn vị
                ws.Cell(1, 1).Value = "CỬA HÀNG CHO THUÊ SÁCH TRUYỆN BOOKSTORE";
                ws.Range(1, 1, 1, colCount).Merge();
                ws.Cell(1, 1).Style.Font.SetBold().Font.SetFontSize(10).Font.SetFontColor(XLColor.FromHtml("#607B99"));

                // Tiêu đề báo cáo
                ws.Cell(2, 1).Value = sheetTitle.ToUpper();
                ws.Range(2, 1, 2, colCount).Merge();
                ws.Cell(2, 1).Style.Font.SetBold().Font.SetFontSize(14).Font.SetFontColor(XLColor.FromHtml("#1C4279"));
                ws.Cell(2, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // Thời gian xuất
                ws.Cell(3, 1).Value = $"Thời gian xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm:ss}  |  Người lập: {SessionContext.CurrentNhanVien?.TenNV ?? "Nhân viên thu ngân"}";
                ws.Range(3, 1, 3, colCount).Merge();
                ws.Cell(3, 1).Style.Font.SetItalic().Font.SetFontSize(9).Font.SetFontColor(XLColor.FromHtml("#607B99"));
                ws.Cell(3, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                int startRow = 5;

                // 2. Tiêu đề các cột (Column Headers)
                int curCol = 1;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (!dgv.Columns[i].Visible) continue;

                    var cell = ws.Cell(startRow, curCol);
                    cell.Value = dgv.Columns[i].HeaderText;
                    cell.Style.Font.SetBold().Font.SetFontSize(10).Font.SetFontColor(XLColor.FromHtml("#1C4279"));
                    cell.Style.Fill.SetBackgroundColor(XLColor.FromHtml("#EAF5FC")); // Pale Soft
                    cell.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin).Border.SetOutsideBorderColor(XLColor.FromHtml("#DCE7F1"));
                    cell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    curCol++;
                }

                // 3. Dữ liệu dòng (Data Rows)
                int curRow = startRow + 1;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    curCol = 1;

                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (!dgv.Columns[i].Visible) continue;

                        var cell = ws.Cell(curRow, curCol);
                        var val = row.Cells[i].Value;

                        if (val != null && val != DBNull.Value)
                        {
                            if (decimal.TryParse(val.ToString(), out decimal numVal) && dgv.Columns[i].HeaderText.Contains("Giá", StringComparison.OrdinalIgnoreCase) || dgv.Columns[i].HeaderText.Contains("Tiền", StringComparison.OrdinalIgnoreCase) || dgv.Columns[i].HeaderText.Contains("Lương", StringComparison.OrdinalIgnoreCase) || dgv.Columns[i].HeaderText.Contains("Doanh Thu", StringComparison.OrdinalIgnoreCase))
                            {
                                cell.Value = numVal;
                                cell.Style.NumberFormat.Format = "#,##0";
                                cell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
                            }
                            else if (int.TryParse(val.ToString(), out int intVal) && (dgv.Columns[i].HeaderText.Contains("Số Lượng", StringComparison.OrdinalIgnoreCase) || dgv.Columns[i].HeaderText.Contains("Năm", StringComparison.OrdinalIgnoreCase) || dgv.Columns[i].HeaderText.Contains("Hạng", StringComparison.OrdinalIgnoreCase)))
                            {
                                cell.Value = intVal;
                                cell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            }
                            else if (DateTime.TryParse(val.ToString(), out DateTime dtVal))
                            {
                                cell.Value = dtVal;
                                cell.Style.NumberFormat.Format = "dd/MM/yyyy";
                                cell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            }
                            else
                            {
                                cell.Value = val.ToString();
                            }
                        }
                        else
                        {
                            cell.Value = string.Empty;
                        }

                        cell.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin).Border.SetOutsideBorderColor(XLColor.FromHtml("#DCE7F1"));
                        curCol++;
                    }
                    curRow++;
                }

                // 4. Tự động căn chỉnh độ rộng cột
                ws.Columns(1, colCount).AdjustToContents(5.0, 50.0);

                workbook.SaveAs(sfd.FileName);

                var res = MessageBox.Show(
                    $"Xuất báo cáo Excel thành công!\nĐường dẫn: {sfd.FileName}\n\nBạn có muốn mở tệp ngay không?",
                    "Xuất Excel thành công",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (res == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = sfd.FileName,
                        UseShellExecute = true
                    });
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
