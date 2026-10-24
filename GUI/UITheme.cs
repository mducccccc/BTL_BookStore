using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTL.GUI
{
    /// <summary>
    /// Hệ thống quy chuẩn giao diện (UI Design System Tokens) theo thu_vien_ban_sach_nhap_bo_sung.Rmd
    /// Trường Đại học Giao thông Vận tải (UTC)
    /// </summary>
    public static class UITheme
    {
        // --- 1. COLOR TOKENS ---
        public static readonly Color Navy = Color.FromArgb(28, 66, 121);        // #1C4279 - Top strip, Sidebar, Main Titles
        public static readonly Color Blue = Color.FromArgb(8, 127, 181);       // #087FB5 - Primary buttons, action triggers
        public static readonly Color BlueHover = Color.FromArgb(6, 106, 152);  // #066A98 - Button hover
        public static readonly Color Pale = Color.FromArgb(234, 245, 252);     // #EAF5FC - DGV Headers, Summary cards
        public static readonly Color Page = Color.FromArgb(244, 249, 252);     // #F4F9FC - Overall background
        public static readonly Color Border = Color.FromArgb(220, 231, 241);   // #DCE7F1 - Lines, borders, splitters
        public static readonly Color Text = Color.FromArgb(24, 59, 104);        // #183B68 - Primary text
        public static readonly Color Muted = Color.FromArgb(96, 123, 153);     // #607B99 - Subtitles, metadata, breadcrumbs
        public static readonly Color Yellow = Color.FromArgb(245, 213, 42);    // #F5D52A - Active navigation, TOP 1 gold badge
        public static readonly Color NavActiveBg = Color.FromArgb(40, 85, 142); // #28558E - Active sidebar item background
        public static readonly Color SelectionBg = Color.FromArgb(208, 230, 246); // Selection row soft blue

        // --- 2. CONTROL STYLING HELPERS ---
        public static void StyleDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Border;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersVisible = false;

            // Column Header Style: Pale background, Navy text, Bold Segoe UI
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Pale;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Navy;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Pale;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Navy;
            dgv.ColumnHeadersHeight = 36;

            // Row Default Style: White, text Navy
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.ForeColor = Text;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = SelectionBg;
            dgv.DefaultCellStyle.SelectionForeColor = Text;
            dgv.RowTemplate.Height = 32;

            // Alternating Row Style: Very subtle pale tint
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 252, 254);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = SelectionBg;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Text;
        }

        public static void StylePrimaryButton(Button btn)
        {
            if (btn == null) return;
            btn.BackColor = Blue;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        public static void StyleSecondaryButton(Button btn)
        {
            if (btn == null) return;
            btn.BackColor = Color.White;
            btn.ForeColor = Navy;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Border;
            btn.FlatAppearance.BorderSize = 1;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            btn.Cursor = Cursors.Hand;
        }

        public static void StyleDangerButton(Button btn)
        {
            if (btn == null) return;
            btn.BackColor = Color.FromArgb(220, 38, 38);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        public static void StyleSummaryBox(Panel pnl, Label? title = null, Label? subtitle = null)
        {
            if (pnl == null) return;
            pnl.BackColor = Pale;
            pnl.BorderStyle = BorderStyle.FixedSingle;
            if (title != null)
            {
                title.ForeColor = Navy;
                title.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            }
            if (subtitle != null)
            {
                subtitle.ForeColor = Muted;
                subtitle.Font = new Font("Segoe UI", 8.5F);
            }
        }
    }
}
