using System;
using System.Data;
using Microsoft.Data.SqlClient;
using BTL.DTO;

namespace BTL.DAL
{
    public class SachDAL
    {
        public DataTable GetAll()
        {
            string sql = @"
                SELECT s.MaSach, s.TenSach, s.MaLoai, l.TenLoai, s.MaLV, lv.TenLV, 
                       s.MaTG, tg.TenTG, s.MaNXB, nxb.TenNXB, s.MaNN, nn.TenNN,
                       s.SoTrang, s.GiaSach, s.DonGiaThue, s.MaTT, tt.TenTT, 
                       s.SoLuong, s.Anh, s.GhiChu
                FROM tSachTruyen s
                LEFT JOIN tLoaiSach l ON l.MaLoai = s.MaLoai
                LEFT JOIN tLinhVuc lv ON lv.MaLV = s.MaLV
                LEFT JOIN tTacGia tg ON tg.MaTG = s.MaTG
                LEFT JOIN tNXB nxb ON nxb.MaNXB = s.MaNXB
                LEFT JOIN tNgonNgu nn ON nn.MaNN = s.MaNN
                LEFT JOIN tTinhTrang tt ON tt.MaTT = s.MaTT
                ORDER BY s.MaSach DESC";
            return DatabaseHelper.ExecuteQuery(sql);
        }

        public string GenerateNewMaSach()
        {
            var pOut = new SqlParameter("@NewMaSach", SqlDbType.Char, 8)
            {
                Direction = ParameterDirection.Output
            };
            DatabaseHelper.ExecuteStoredProcedureNonQuery("SP_GenerateNewMaSach", new[] { pOut });
            return pOut.Value?.ToString()?.Trim() ?? string.Empty;
        }

        public bool Insert(SachDTO s)
        {
            string sql = @"
                INSERT INTO tSachTruyen (MaSach, TenSach, MaLoai, MaLV, MaTG, MaNXB, MaNN, SoTrang, GiaSach, DonGiaThue, MaTT, SoLuong, Anh, GhiChu)
                VALUES (@MaSach, @TenSach, @MaLoai, @MaLV, @MaTG, @MaNXB, @MaNN, @SoTrang, @GiaSach, @DonGiaThue, @MaTT, @SoLuong, @Anh, @GhiChu)";
            
            var parameters = new[]
            {
                new SqlParameter("@MaSach", s.MaSach),
                new SqlParameter("@TenSach", s.TenSach),
                new SqlParameter("@MaLoai", s.MaLoai),
                new SqlParameter("@MaLV", s.MaLV),
                new SqlParameter("@MaTG", s.MaTG),
                new SqlParameter("@MaNXB", s.MaNXB),
                new SqlParameter("@MaNN", s.MaNN),
                new SqlParameter("@SoTrang", (object?)s.SoTrang ?? DBNull.Value),
                new SqlParameter("@GiaSach", s.GiaSach),
                new SqlParameter("@DonGiaThue", s.DonGiaThue),
                new SqlParameter("@MaTT", s.MaTT),
                new SqlParameter("@SoLuong", s.SoLuong),
                new SqlParameter("@Anh", (object?)s.Anh ?? DBNull.Value),
                new SqlParameter("@GhiChu", (object?)s.GhiChu ?? DBNull.Value)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Update(SachDTO s)
        {
            string sql = @"
                UPDATE tSachTruyen 
                SET TenSach = @TenSach, MaLoai = @MaLoai, MaLV = @MaLV, MaTG = @MaTG, 
                    MaNXB = @MaNXB, MaNN = @MaNN, SoTrang = @SoTrang, GiaSach = @GiaSach, 
                    DonGiaThue = @DonGiaThue, MaTT = @MaTT, SoLuong = @SoLuong, 
                    Anh = @Anh, GhiChu = @GhiChu
                WHERE MaSach = @MaSach";

            var parameters = new[]
            {
                new SqlParameter("@MaSach", s.MaSach),
                new SqlParameter("@TenSach", s.TenSach),
                new SqlParameter("@MaLoai", s.MaLoai),
                new SqlParameter("@MaLV", s.MaLV),
                new SqlParameter("@MaTG", s.MaTG),
                new SqlParameter("@MaNXB", s.MaNXB),
                new SqlParameter("@MaNN", s.MaNN),
                new SqlParameter("@SoTrang", (object?)s.SoTrang ?? DBNull.Value),
                new SqlParameter("@GiaSach", s.GiaSach),
                new SqlParameter("@DonGiaThue", s.DonGiaThue),
                new SqlParameter("@MaTT", s.MaTT),
                new SqlParameter("@SoLuong", s.SoLuong),
                new SqlParameter("@Anh", (object?)s.Anh ?? DBNull.Value),
                new SqlParameter("@GhiChu", (object?)s.GhiChu ?? DBNull.Value)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Delete(string maSach)
        {
            string sql = "DELETE FROM tSachTruyen WHERE MaSach = @MaSach";
            return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SqlParameter("@MaSach", maSach) }) > 0;
        }

        // Yêu cầu 1: Lấy danh sách sách có số lượng > 0
        public DataTable GetSachConHang()
        {
            return DatabaseHelper.ExecuteStoredProcedure("SP_GetSachConHang");
        }

        // Yêu cầu 5: Tìm kiếm sách truyện kết hợp đa tiêu chí
        public DataTable TimKiemSach(string? tenSach, string? maLV, string? maTG, string? maNXB)
        {
            var parameters = new[]
            {
                new SqlParameter("@TenSach", string.IsNullOrWhiteSpace(tenSach) ? DBNull.Value : (object)tenSach.Trim()),
                new SqlParameter("@MaLV", string.IsNullOrWhiteSpace(maLV) ? DBNull.Value : (object)maLV.Trim()),
                new SqlParameter("@MaTG", string.IsNullOrWhiteSpace(maTG) ? DBNull.Value : (object)maTG.Trim()),
                new SqlParameter("@MaNXB", string.IsNullOrWhiteSpace(maNXB) ? DBNull.Value : (object)maNXB.Trim())
            };
            return DatabaseHelper.ExecuteStoredProcedure("SP_TimSach", parameters);
        }
    }
}
