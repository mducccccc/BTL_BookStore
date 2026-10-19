using System;
using System.Data;
using BTL.DAL;

namespace BTL.BLL
{
    public class BaoCaoBLL
    {
        private readonly BaoCaoDAL _dal = new();

        // Yêu cầu 7: Báo cáo danh sách sách truyện đang được thuê chưa trả
        public DataTable GetSachDangThueChuaTra()
        {
            return _dal.GetSachDangThueChuaTra();
        }

        // Yêu cầu 8: Thống kê doanh thu theo Tháng, Quý, Năm
        public DataTable GetDoanhThu(string kieu, int? nam)
        {
            kieu = kieu.ToUpper();
            if (kieu != "THANG" && kieu != "QUY" && kieu != "NAM")
            {
                kieu = "THANG";
            }
            if (!nam.HasValue || nam.Value <= 0)
            {
                nam = DateTime.Now.Year;
            }
            return _dal.GetDoanhThu(kieu, nam);
        }

        // Yêu cầu 9: Báo cáo top 5 sách có doanh thu cao nhất
        public DataTable GetTop5Sach(DateTime? tuNgay, DateTime? denNgay)
        {
            return _dal.GetTop5Sach(tuNgay, denNgay);
        }
    }
}
