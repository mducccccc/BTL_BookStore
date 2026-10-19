using System;
using System.Data;
using Microsoft.Data.SqlClient;
using BTL.DTO;

namespace BTL.DAL
{
    public class NhanVienDAL
    {
        public DataTable GetAll()
        {
            string sql = "SELECT MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang FROM tNhanVien ORDER BY MaNV";
            return DatabaseHelper.ExecuteQuery(sql);
        }

        public string GenerateNewMaNV()
        {
            var pOut = new SqlParameter("@NewMaNV", SqlDbType.Char, 7)
            {
                Direction = ParameterDirection.Output
            };
            DatabaseHelper.ExecuteStoredProcedureNonQuery("SP_GenerateNewMaNV", new[] { pOut });
            return pOut.Value?.ToString()?.Trim() ?? string.Empty;
        }

        public bool Insert(NhanVienDTO nv)
        {
            string sql = @"
                INSERT INTO tNhanVien (MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang)
                VALUES (@MaNV, @TenNV, @NamSinh, @GioiTinh, @DiaChi, @DienThoai, @LuongThang)";

            var parameters = new[]
            {
                new SqlParameter("@MaNV", nv.MaNV),
                new SqlParameter("@TenNV", nv.TenNV),
                new SqlParameter("@NamSinh", (object?)nv.NamSinh ?? DBNull.Value),
                new SqlParameter("@GioiTinh", nv.GioiTinh),
                new SqlParameter("@DiaChi", (object?)nv.DiaChi ?? DBNull.Value),
                new SqlParameter("@DienThoai", nv.DienThoai),
                new SqlParameter("@LuongThang", (object?)nv.LuongThang ?? DBNull.Value)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Update(NhanVienDTO nv)
        {
            string sql = @"
                UPDATE tNhanVien 
                SET TenNV = @TenNV, NamSinh = @NamSinh, GioiTinh = @GioiTinh, 
                    DiaChi = @DiaChi, DienThoai = @DienThoai, LuongThang = @LuongThang
                WHERE MaNV = @MaNV";

            var parameters = new[]
            {
                new SqlParameter("@MaNV", nv.MaNV),
                new SqlParameter("@TenNV", nv.TenNV),
                new SqlParameter("@NamSinh", (object?)nv.NamSinh ?? DBNull.Value),
                new SqlParameter("@GioiTinh", nv.GioiTinh),
                new SqlParameter("@DiaChi", (object?)nv.DiaChi ?? DBNull.Value),
                new SqlParameter("@DienThoai", nv.DienThoai),
                new SqlParameter("@LuongThang", (object?)nv.LuongThang ?? DBNull.Value)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Delete(string maNV)
        {
            string sql = "DELETE FROM tNhanVien WHERE MaNV = @MaNV";
            return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SqlParameter("@MaNV", maNV) }) > 0;
        }

        // Yêu cầu 6: Tìm kiếm nhân viên theo Tên, Ca làm, Giới tính
        public DataTable TimKiemNhanVien(string? tenNV, string? maCa, string? gioiTinh)
        {
            var parameters = new[]
            {
                new SqlParameter("@TenNV", string.IsNullOrWhiteSpace(tenNV) ? DBNull.Value : (object)tenNV.Trim()),
                new SqlParameter("@MaCa", string.IsNullOrWhiteSpace(maCa) ? DBNull.Value : (object)maCa.Trim()),
                new SqlParameter("@GioiTinh", string.IsNullOrWhiteSpace(gioiTinh) ? DBNull.Value : (object)gioiTinh.Trim())
            };
            return DatabaseHelper.ExecuteStoredProcedure("SP_TimNhanVien", parameters);
        }

        // Kiểm tra thông tin đăng nhập (MaNV và Mật khẩu = Số điện thoại)
        public NhanVienDTO? DangNhap(string maNV, string matKhau)
        {
            string sql = "SELECT TOP 1 MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang FROM tNhanVien WHERE MaNV = @MaNV AND DienThoai = @MatKhau";
            var dt = DatabaseHelper.ExecuteQuery(sql, new[]
            {
                new SqlParameter("@MaNV", maNV.Trim()),
                new SqlParameter("@MatKhau", matKhau.Trim())
            });

            if (dt.Rows.Count == 0) return null;
            var r = dt.Rows[0];
            return new NhanVienDTO
            {
                MaNV = r["MaNV"].ToString()?.Trim() ?? string.Empty,
                TenNV = r["TenNV"].ToString() ?? string.Empty,
                NamSinh = r["NamSinh"] != DBNull.Value ? Convert.ToInt32(r["NamSinh"]) : null,
                GioiTinh = r["GioiTinh"].ToString() ?? "M",
                DiaChi = r["DiaChi"]?.ToString() ?? string.Empty,
                DienThoai = r["DienThoai"].ToString() ?? string.Empty,
                LuongThang = r["LuongThang"] != DBNull.Value ? Convert.ToDecimal(r["LuongThang"]) : null
            };
        }
    }
}
