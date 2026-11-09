using System;
using System.Windows.Forms;
using BTL.BLL;

namespace BTL.GUI
{
    public partial class UC_Dashboard : UserControl
    {
        private readonly SachBLL _sachBLL = new();
        private readonly BaoCaoBLL _baoCaoBLL = new();
        private readonly KhachHangBLL _khachHangBLL = new();
        private readonly ThueTraBLL _thueTraBLL = new();

        public UC_Dashboard()
        {
            InitializeComponent();
            UITheme.StyleDataGridView(dgvRecent);
            LoadDashboardData();
        }

        public void LoadDashboardData()
        {
            try
            {
                // Thống kê số lượng
                var dtSach = _sachBLL.GetAll();
                lblTotalSach.Text = dtSach.Rows.Count.ToString();

                var dtChuaTra = _baoCaoBLL.GetSachDangThueChuaTra();
                lblDangThue.Text = dtChuaTra.Rows.Count.ToString();

                var dtKH = _khachHangBLL.GetAll();
                lblTotalKH.Text = dtKH.Rows.Count.ToString();

                var dtTra = _thueTraBLL.GetAllPhieuTra();
                lblTotalTra.Text = dtTra.Rows.Count.ToString();

                // Nạp bảng sách đang thuê chưa trả
                dgvRecent.DataSource = dtChuaTra;
                if (dgvRecent.Columns.Contains("MaThue")) dgvRecent.Columns["MaThue"].HeaderText = "Mã Phiếu Thuê";
                if (dgvRecent.Columns.Contains("TenKH")) dgvRecent.Columns["TenKH"].HeaderText = "Tên Khách Hàng";
                if (dgvRecent.Columns.Contains("TenSach")) dgvRecent.Columns["TenSach"].HeaderText = "Tên Sách";
                if (dgvRecent.Columns.Contains("NgayThue"))
                {
                    dgvRecent.Columns["NgayThue"].HeaderText = "Ngày Thuê";
                    dgvRecent.Columns["NgayThue"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                if (dgvRecent.Columns.Contains("SoLuong")) dgvRecent.Columns["SoLuong"].HeaderText = "SL Thuê";
                if (dgvRecent.Columns.Contains("DonGiaThue"))
                {
                    dgvRecent.Columns["DonGiaThue"].HeaderText = "Đơn Giá/Ngày";
                    dgvRecent.Columns["DonGiaThue"].DefaultCellStyle.Format = "#,##0 VNĐ";
                }
                if (dgvRecent.Columns.Contains("SoNgayDaThue")) dgvRecent.Columns["SoNgayDaThue"].HeaderText = "Số Ngày Đã Thuê";
                if (dgvRecent.Columns.Contains("TienTamTinh"))
                {
                    dgvRecent.Columns["TienTamTinh"].HeaderText = "Tiền Tạm Tính";
                    dgvRecent.Columns["TienTamTinh"].DefaultCellStyle.Format = "#,##0 VNĐ";
                }
                if (dgvRecent.Columns.Contains("TienDatCoc"))
                {
                    dgvRecent.Columns["TienDatCoc"].HeaderText = "Tiền Đặt Cọc";
                    dgvRecent.Columns["TienDatCoc"].DefaultCellStyle.Format = "#,##0 VNĐ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Tổng quan: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
