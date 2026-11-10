using System.Data;
using BTL.DTO;

namespace BTL.Interfaces
{
    public interface INhanVienService
    {
        DataTable GetAll();
        string GenerateNewMaNV();
        bool Insert(NhanVienDTO nv, out string error);
        bool Update(NhanVienDTO nv, out string error);
        bool Delete(string maNV, out string error);
        DataTable TimKiemNhanVien(string? tenNV, string? maCa, string? gioiTinh);
        NhanVienDTO? DangNhap(string maNV, string matKhau);
    }
}
