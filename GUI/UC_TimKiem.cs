using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BTL.BLL;

namespace BTL.GUI
{
    public partial class UC_TimKiem : UserControl
    {
        private readonly SachBLL _sachBLL = new();
        private readonly NhanVienBLL _nvBLL = new();
        private readonly DanhMucBLL _dmBLL = new();

        public UC_TimKiem()
        {
            InitializeComponent();
            UITheme.StyleDataGridView(dgvKetQuaSach);
            UITheme.StyleDataGridView(dgvKetQuaNV);

            SetupEvents();
            LoadLookupData();
            ThucHienTimSach();
            ThucHienTimNV();
        }

        private void SetupEvents()
        {
            // Tab 1: Sách
            txtTimTenSach.TextChanged += (s, e) => ThucHienTimSach();
            cboTimLinhVuc.SelectedIndexChanged += (s, e) => ThucHienTimSach();
            cboTimTacGia.SelectedIndexChanged += (s, e) => ThucHienTimSach();
            cboTimNXB.SelectedIndexChanged += (s, e) => ThucHienTimSach();
            btnTimSach.Click += (s, e) => ThucHienTimSach();
            btnDatLaiSach.Click += (s, e) =>
            {
                txtTimTenSach.Clear();
                if (cboTimLinhVuc.Items.Count > 0) cboTimLinhVuc.SelectedIndex = 0;
                if (cboTimTacGia.Items.Count > 0) cboTimTacGia.SelectedIndex = 0;
                if (cboTimNXB.Items.Count > 0) cboTimNXB.SelectedIndex = 0;
                ThucHienTimSach();
            };
            dgvKetQuaSach.CellClick += DgvKetQuaSach_CellClick;

            // Tab 2: Nhân viên
            txtTimTenNV.TextChanged += (s, e) => ThucHienTimNV();
            cboTimCaLam.SelectedIndexChanged += (s, e) => ThucHienTimNV();
            cboTimGioiTinh.SelectedIndexChanged += (s, e) => ThucHienTimNV();
            btnTimNV.Click += (s, e) => ThucHienTimNV();
            btnDatLaiNV.Click += (s, e) =>
            {
                txtTimTenNV.Clear();
                if (cboTimCaLam.Items.Count > 0) cboTimCaLam.SelectedIndex = 0;
                cboTimGioiTinh.SelectedIndex = 0;
                ThucHienTimNV();
            };
        }

        private void DgvKetQuaSach_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvKetQuaSach.Rows.Count) return;
            string path = dgvKetQuaSach.Rows[e.RowIndex].Cells["Anh"].Value?.ToString() ?? string.Empty;

            if (picPreviewSach.Image != null)
            {
                picPreviewSach.Image.Dispose();
                picPreviewSach.Image = null;
            }

            if (!string.IsNullOrWhiteSpace(path))
            {
                string fullPath = Path.IsPathRooted(path) ? path : Path.Combine(Application.StartupPath, path);
                if (File.Exists(fullPath))
                {
                    try
                    {
                        byte[] bytes = File.ReadAllBytes(fullPath);
                        using var ms = new MemoryStream(bytes);
                        picPreviewSach.Image = Image.FromStream(ms);
                        return;
                    }
                    catch { }
                }
            }
            picPreviewSach.Image = null;
        }

        private void ThucHienTimSach()
        {
            try
            {
                string? ten = string.IsNullOrWhiteSpace(txtTimTenSach?.Text) ? null : txtTimTenSach.Text.Trim();

                string? maLV = cboTimLinhVuc?.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maLV)) maLV = null;

                string? maTG = cboTimTacGia?.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maTG)) maTG = null;

                string? maNXB = cboTimNXB?.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maNXB)) maNXB = null;

                var dt = _sachBLL.TimKiemSach(ten, maLV, maTG, maNXB);
                dgvKetQuaSach.DataSource = dt;

                if (dgvKetQuaSach.Columns.Contains("MaSach")) dgvKetQuaSach.Columns["MaSach"].HeaderText = "Mã Sách";
                if (dgvKetQuaSach.Columns.Contains("TenSach")) dgvKetQuaSach.Columns["TenSach"].HeaderText = "Tên Sách";
                if (dgvKetQuaSach.Columns.Contains("TenLV")) dgvKetQuaSach.Columns["TenLV"].HeaderText = "Lĩnh Vực";
                if (dgvKetQuaSach.Columns.Contains("TenTG")) dgvKetQuaSach.Columns["TenTG"].HeaderText = "Tác Giả";
                if (dgvKetQuaSach.Columns.Contains("TenNXB")) dgvKetQuaSach.Columns["TenNXB"].HeaderText = "Nhà Xuất Bản";
                if (dgvKetQuaSach.Columns.Contains("SoLuong")) dgvKetQuaSach.Columns["SoLuong"].HeaderText = "Tồn Kho";
                if (dgvKetQuaSach.Columns.Contains("DonGiaThue"))
                {
                    dgvKetQuaSach.Columns["DonGiaThue"].HeaderText = "Giá Thuê (đ/ngày)";
                    dgvKetQuaSach.Columns["DonGiaThue"].DefaultCellStyle.Format = "N0";
                }
                if (dgvKetQuaSach.Columns.Contains("TenTT")) dgvKetQuaSach.Columns["TenTT"].HeaderText = "Tình Trạng";
                if (dgvKetQuaSach.Columns.Contains("Anh")) dgvKetQuaSach.Columns["Anh"].Visible = false;

                lblDemSach.Text = $"Tìm thấy: {dt.Rows.Count} cuốn sách";

                if (dt.Rows.Count > 0)
                {
                    DgvKetQuaSach_CellClick(null, new DataGridViewCellEventArgs(0, 0));
                }
                else
                {
                    if (picPreviewSach.Image != null)
                    {
                        picPreviewSach.Image.Dispose();
                        picPreviewSach.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Tim kiem sach error: " + ex.Message);
            }
        }

        private void ThucHienTimNV()
        {
            try
            {
                string? ten = string.IsNullOrWhiteSpace(txtTimTenNV?.Text) ? null : txtTimTenNV.Text.Trim();

                string? maCa = cboTimCaLam?.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maCa)) maCa = null;

                string? gioiTinh = null;
                if (cboTimGioiTinh?.SelectedIndex == 1) gioiTinh = "M";
                else if (cboTimGioiTinh?.SelectedIndex == 2) gioiTinh = "F";

                var dt = _nvBLL.TimKiemNhanVien(ten, maCa, gioiTinh);
                dgvKetQuaNV.DataSource = dt;

                if (dgvKetQuaNV.Columns.Contains("MaNV")) dgvKetQuaNV.Columns["MaNV"].HeaderText = "Mã NV";
                if (dgvKetQuaNV.Columns.Contains("TenNV")) dgvKetQuaNV.Columns["TenNV"].HeaderText = "Họ và Tên";
                if (dgvKetQuaNV.Columns.Contains("NamSinh")) dgvKetQuaNV.Columns["NamSinh"].HeaderText = "Năm Sinh";
                if (dgvKetQuaNV.Columns.Contains("GioiTinh")) dgvKetQuaNV.Columns["GioiTinh"].HeaderText = "Giới Tính";
                if (dgvKetQuaNV.Columns.Contains("DiaChi")) dgvKetQuaNV.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                if (dgvKetQuaNV.Columns.Contains("DienThoai")) dgvKetQuaNV.Columns["DienThoai"].HeaderText = "Điện Thoại";
                if (dgvKetQuaNV.Columns.Contains("LuongThang"))
                {
                    dgvKetQuaNV.Columns["LuongThang"].HeaderText = "Lương Tháng (VNĐ)";
                    dgvKetQuaNV.Columns["LuongThang"].DefaultCellStyle.Format = "N0";
                }

                lblDemNV.Text = $"Tìm thấy: {dt.Rows.Count} nhân viên";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Tim kiem nhan vien error: " + ex.Message);
            }
        }

        private void LoadLookupData()
        {
            try
            {
                var dtLV = _dmBLL.GetLinhVuc().Copy();
                var rLV = dtLV.NewRow();
                rLV["MaLV"] = "";
                rLV["TenLV"] = "--- Tất cả lĩnh vực ---";
                dtLV.Rows.InsertAt(rLV, 0);
                cboTimLinhVuc.DataSource = dtLV;
                cboTimLinhVuc.DisplayMember = "TenLV";
                cboTimLinhVuc.ValueMember = "MaLV";

                var dtTG = _dmBLL.GetTacGia().Copy();
                var rTG = dtTG.NewRow();
                rTG["MaTG"] = "";
                rTG["TenTG"] = "--- Tất cả tác giả ---";
                dtTG.Rows.InsertAt(rTG, 0);
                cboTimTacGia.DataSource = dtTG;
                cboTimTacGia.DisplayMember = "TenTG";
                cboTimTacGia.ValueMember = "MaTG";

                var dtNXB = _dmBLL.GetNXB().Copy();
                var rNXB = dtNXB.NewRow();
                rNXB["MaNXB"] = "";
                rNXB["TenNXB"] = "--- Tất cả nhà xuất bản ---";
                dtNXB.Rows.InsertAt(rNXB, 0);
                cboTimNXB.DataSource = dtNXB;
                cboTimNXB.DisplayMember = "TenNXB";
                cboTimNXB.ValueMember = "MaNXB";

                var dtCa = _dmBLL.GetCaLam().Copy();
                var rCa = dtCa.NewRow();
                rCa["MaCa"] = "";
                rCa["TenCa"] = "--- Tất cả ca trực ---";
                dtCa.Rows.InsertAt(rCa, 0);
                cboTimCaLam.DataSource = dtCa;
                cboTimCaLam.DisplayMember = "TenCa";
                cboTimCaLam.ValueMember = "MaCa";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load lookup error: " + ex.Message);
            }
        }
    }
}
