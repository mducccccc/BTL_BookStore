using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BTL.DAL
{
    public class BaoCaoDAL
    {
        // Yêu cầu 7: Báo cáo danh sách sách truyện đang được thuê chưa trả
        public DataTable GetSachDangThueChuaTra()
        {
            string sql = @"
                SELECT MaThue, TenKH, MaSach, TenSach, SoLuong, 
                       NgayThue, SoNgayDaThue, TienThueTamTinh, TienDatCoc, NhanVienLap
                FROM vw_SachDangThueChuaTra
                ORDER BY NgayThue ASC";
            return DatabaseHelper.ExecuteQuery(sql);
        }

        // Yêu cầu 8: Báo cáo tổng tiền cho thuê thu được theo Tháng, Quý, Năm
        public DataTable GetDoanhThu(string kieu, int? nam)
        {
            var parameters = new[]
            {
                new SqlParameter("@Kieu", kieu), // 'THANG', 'QUY', 'NAM'
                new SqlParameter("@Nam", (object?)nam ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteStoredProcedure("SP_DoanhThu", parameters);
        }

        // Yêu cầu 9: Báo cáo danh sách 5 sách truyện đạt doanh thu nhiều nhất
        public DataTable GetTop5Sach(DateTime? tuNgay, DateTime? denNgay)
        {
            var parameters = new[]
            {
                new SqlParameter("@TuNgay", (object?)tuNgay ?? DBNull.Value),
                new SqlParameter("@DenNgay", (object?)denNgay ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteStoredProcedure("SP_Top5SachDoanhThu", parameters);
        }
    }
}
