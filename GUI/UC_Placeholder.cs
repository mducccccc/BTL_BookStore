using System.Windows.Forms;

namespace BTL.GUI
{
    public partial class UC_Placeholder : UserControl
    {
        public UC_Placeholder()
        {
            InitializeComponent();
        }

        public UC_Placeholder(string moduleTitle, string description) : this()
        {
            lblTitle.Text = moduleTitle;
            lblDesc.Text = description;
        }
    }
}
