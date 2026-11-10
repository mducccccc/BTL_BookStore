using System.Data;
using BTL.DTO;

namespace BTL.Interfaces
{
    public interface IKhachHangService
    {
        DataTable GetAll();
        string GenerateNewMaKH();
        bool Insert(KhachHangDTO kh, out string error);
        bool Update(KhachHangDTO kh, out string error);
        bool Delete(string maKH, out string error);
    }
}
