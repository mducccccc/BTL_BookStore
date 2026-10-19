using System;
using System.Data;
using BTL.DAL;
using BTL.DTO;

namespace BTL.BLL
{
    public class NhanVienBLL
    {
        private readonly NhanVienDAL _dal = new();

        public DataTable GetAll() => _dal.GetAll();
        public string GenerateNewMaNV() => _dal.GenerateNewMaNV();

        public bool Insert(NhanVienDTO nv, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(nv.TenNV))
            {
                error = "Tên nhân viên không được để trống!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(nv.DienThoai))
            {
                error = "Số điện thoại không được để trống (dùng làm mật khẩu mặc định)!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(nv.MaNV))
            {
                nv.MaNV = _dal.GenerateNewMaNV();
            }

            try
            {
                return _dal.Insert(nv);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool Update(NhanVienDTO nv, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(nv.MaNV))
            {
                error = "Mã nhân viên không hợp lệ!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(nv.TenNV))
            {
                error = "Tên nhân viên không được để trống!";
                return false;
            }

            try
            {
                return _dal.Update(nv);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool Delete(string maNV, out string error)
        {
            error = string.Empty;
            try
            {
                return _dal.Delete(maNV);
            }
            catch (Exception ex)
            {
                error = "Không thể xóa nhân viên này vì đã có dữ liệu lập phiếu mượn/trả liên quan. (" + ex.Message + ")";
                return false;
            }
        }

        // Yêu cầu 6: Tìm kiếm nhân viên
        public DataTable TimKiemNhanVien(string? tenNV, string? maCa, string? gioiTinh)
        {
            return _dal.TimKiemNhanVien(tenNV, maCa, gioiTinh);
        }

        // Đăng nhập
        public NhanVienDTO? DangNhap(string maNV, string matKhau)
        {
            return _dal.DangNhap(maNV, matKhau);
        }
    }
}
