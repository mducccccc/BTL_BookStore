using System;
using System.Data;
using Microsoft.Data.SqlClient;
using BTL.DTO;

namespace BTL.DAL
{
    public class KhachHangDAL
    {
        public DataTable GetAll()
        {
            string sql = "SELECT MaKH, TenKH, NgaySinh, GioiTinh, DiaChi FROM tKhachHang ORDER BY MaKH";
            return DatabaseHelper.ExecuteQuery(sql);
        }

        public string GenerateNewMaKH()
        {
            var pOut = new SqlParameter("@NewMaKH", SqlDbType.Char, 8)
            {
                Direction = ParameterDirection.Output
            };
            DatabaseHelper.ExecuteStoredProcedureNonQuery("SP_GenerateNewMaKH", new[] { pOut });
            return pOut.Value?.ToString()?.Trim() ?? string.Empty;
        }

        public bool Insert(KhachHangDTO kh)
        {
            string sql = @"
                INSERT INTO tKhachHang (MaKH, TenKH, NgaySinh, GioiTinh, DiaChi)
                VALUES (@MaKH, @TenKH, @NgaySinh, @GioiTinh, @DiaChi)";

            var parameters = new[]
            {
                new SqlParameter("@MaKH", kh.MaKH),
                new SqlParameter("@TenKH", kh.TenKH),
                new SqlParameter("@NgaySinh", (object?)kh.NgaySinh ?? DBNull.Value),
                new SqlParameter("@GioiTinh", kh.GioiTinh),
                new SqlParameter("@DiaChi", (object?)kh.DiaChi ?? DBNull.Value)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Update(KhachHangDTO kh)
        {
            string sql = @"
                UPDATE tKhachHang 
                SET TenKH = @TenKH, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi
                WHERE MaKH = @MaKH";

            var parameters = new[]
            {
                new SqlParameter("@MaKH", kh.MaKH),
                new SqlParameter("@TenKH", kh.TenKH),
                new SqlParameter("@NgaySinh", (object?)kh.NgaySinh ?? DBNull.Value),
                new SqlParameter("@GioiTinh", kh.GioiTinh),
                new SqlParameter("@DiaChi", (object?)kh.DiaChi ?? DBNull.Value)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Delete(string maKH)
        {
            string sql = "DELETE FROM tKhachHang WHERE MaKH = @MaKH";
            return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SqlParameter("@MaKH", maKH) }) > 0;
        }
    }
}
