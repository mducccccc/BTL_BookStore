using System.Drawing;
using System.Windows.Forms;

namespace BTL.GUI
{
    public class UC_Placeholder : UserControl
    {
        public UC_Placeholder(string moduleTitle, string description)
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(241, 245, 249);

            var pnl = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(25)
            };

            var lblTitle = new Label
            {
                Text = moduleTitle,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                AutoSize = true,
                Location = new Point(25, 25)
            };

            var lblDesc = new Label
            {
                Text = description,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                Location = new Point(25, 65)
            };

            pnl.Controls.Add(lblTitle);
            pnl.Controls.Add(lblDesc);
            this.Controls.Add(pnl);
        }
    }
}
