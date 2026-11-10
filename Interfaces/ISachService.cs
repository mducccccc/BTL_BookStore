using System.Data;
using BTL.DTO;

namespace BTL.Interfaces
{
    public interface ISachService
    {
        DataTable GetAll();
        string GenerateNewMaSach();
        bool Insert(SachDTO sach, out string error);
        bool Update(SachDTO sach, out string error);
        bool Delete(string maSach, out string error);
        DataTable GetSachConHang();
        DataTable TimKiemSach(string? tenSach, string? maLV, string? maTG, string? maNXB);
    }
}
