using System;
using System.Data;

namespace BTL.Interfaces
{
    public interface IBaoCaoService
    {
        DataTable GetSachDangThueChuaTra();
        DataTable GetDoanhThu(string kieu, int? nam);
        DataTable GetTop5Sach(DateTime? tuNgay, DateTime? denNgay);
    }
}
