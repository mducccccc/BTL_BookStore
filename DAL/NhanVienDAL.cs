using System;
using System.Data;
using Microsoft.Data.SqlClient;
using BTL.DTO;

namespace BTL.DAL
{
    public class NhanVienDAL
    {
        private static bool? _hasChucVuColumn = null;

        private static bool CheckHasChucVuColumn()
        {
            if (_hasChucVuColumn.HasValue) return _hasChucVuColumn.Value;
            try
            {
                string checkSql = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'tNhanVien' AND COLUMN_NAME = 'ChucVu'";
                var result = DatabaseHelper.ExecuteScalar(checkSql);
                _hasChucVuColumn = Convert.ToInt32(result) > 0;
            }
            catch
            {
                _hasChucVuColumn = false;
            }
            return _hasChucVuColumn.Value;
        }

        public DataTable GetAll()
        {
            bool hasChucVu = CheckHasChucVuColumn();
            string sql = hasChucVu 
                ? "SELECT MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang, ISNULL(ChucVu, 'NhanVien') AS ChucVu FROM tNhanVien ORDER BY MaNV"
                : "SELECT MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang, 'NhanVien' AS ChucVu FROM tNhanVien ORDER BY MaNV";
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
            bool hasChucVu = CheckHasChucVuColumn();
            string sql;
            SqlParameter[] parameters;

            if (hasChucVu)
            {
                sql = @"
                    INSERT INTO tNhanVien (MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang, ChucVu)
                    VALUES (@MaNV, @TenNV, @NamSinh, @GioiTinh, @DiaChi, @DienThoai, @LuongThang, @ChucVu)";

                parameters = new[]
                {
                    new SqlParameter("@MaNV", nv.MaNV),
                    new SqlParameter("@TenNV", nv.TenNV),
                    new SqlParameter("@NamSinh", (object?)nv.NamSinh ?? DBNull.Value),
                    new SqlParameter("@GioiTinh", nv.GioiTinh),
                    new SqlParameter("@DiaChi", (object?)nv.DiaChi ?? DBNull.Value),
                    new SqlParameter("@DienThoai", nv.DienThoai),
                    new SqlParameter("@LuongThang", (object?)nv.LuongThang ?? DBNull.Value),
                    new SqlParameter("@ChucVu", string.IsNullOrWhiteSpace(nv.ChucVu) ? "NhanVien" : nv.ChucVu)
                };
            }
            else
            {
                sql = @"
                    INSERT INTO tNhanVien (MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang)
                    VALUES (@MaNV, @TenNV, @NamSinh, @GioiTinh, @DiaChi, @DienThoai, @LuongThang)";

                parameters = new[]
                {
                    new SqlParameter("@MaNV", nv.MaNV),
                    new SqlParameter("@TenNV", nv.TenNV),
                    new SqlParameter("@NamSinh", (object?)nv.NamSinh ?? DBNull.Value),
                    new SqlParameter("@GioiTinh", nv.GioiTinh),
                    new SqlParameter("@DiaChi", (object?)nv.DiaChi ?? DBNull.Value),
                    new SqlParameter("@DienThoai", nv.DienThoai),
                    new SqlParameter("@LuongThang", (object?)nv.LuongThang ?? DBNull.Value)
                };
            }

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Update(NhanVienDTO nv)
        {
            bool hasChucVu = CheckHasChucVuColumn();
            string sql;
            SqlParameter[] parameters;

            if (hasChucVu)
            {
                sql = @"
                    UPDATE tNhanVien 
                    SET TenNV = @TenNV, NamSinh = @NamSinh, GioiTinh = @GioiTinh, 
                        DiaChi = @DiaChi, DienThoai = @DienThoai, LuongThang = @LuongThang,
                        ChucVu = @ChucVu
                    WHERE MaNV = @MaNV";

                parameters = new[]
                {
                    new SqlParameter("@MaNV", nv.MaNV),
                    new SqlParameter("@TenNV", nv.TenNV),
                    new SqlParameter("@NamSinh", (object?)nv.NamSinh ?? DBNull.Value),
                    new SqlParameter("@GioiTinh", nv.GioiTinh),
                    new SqlParameter("@DiaChi", (object?)nv.DiaChi ?? DBNull.Value),
                    new SqlParameter("@DienThoai", nv.DienThoai),
                    new SqlParameter("@LuongThang", (object?)nv.LuongThang ?? DBNull.Value),
                    new SqlParameter("@ChucVu", string.IsNullOrWhiteSpace(nv.ChucVu) ? "NhanVien" : nv.ChucVu)
                };
            }
            else
            {
                sql = @"
                    UPDATE tNhanVien 
                    SET TenNV = @TenNV, NamSinh = @NamSinh, GioiTinh = @GioiTinh, 
                        DiaChi = @DiaChi, DienThoai = @DienThoai, LuongThang = @LuongThang
                    WHERE MaNV = @MaNV";

                parameters = new[]
                {
                    new SqlParameter("@MaNV", nv.MaNV),
                    new SqlParameter("@TenNV", nv.TenNV),
                    new SqlParameter("@NamSinh", (object?)nv.NamSinh ?? DBNull.Value),
                    new SqlParameter("@GioiTinh", nv.GioiTinh),
                    new SqlParameter("@DiaChi", (object?)nv.DiaChi ?? DBNull.Value),
                    new SqlParameter("@DienThoai", nv.DienThoai),
                    new SqlParameter("@LuongThang", (object?)nv.LuongThang ?? DBNull.Value)
                };
            }

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

        // Kiểm tra thông tin đăng nhập:
        // - Tài khoản admin duy nhất: Tên đăng nhập = "admin", Mật khẩu = "admin" (hoặc "admin123")
        // - Các nhân viên khác: Mã NV (VD: NV25-01, NV25-02,...) và Mật khẩu = Số điện thoại
        public NhanVienDTO? DangNhap(string maNV, string matKhau)
        {
            string trimmedMaNV = maNV.Trim();
            string trimmedMK = matKhau.Trim();

            // 1. Tài khoản admin chuyên dụng
            if (string.Equals(trimmedMaNV, "admin", StringComparison.OrdinalIgnoreCase))
            {
                if (trimmedMK == "admin" || trimmedMK == "admin123" || trimmedMK == "123456")
                {
                    return new NhanVienDTO
                    {
                        MaNV = "ADMIN",
                        TenNV = "Quản Trị Viên (Admin)",
                        GioiTinh = "M",
                        DienThoai = "admin",
                        ChucVu = "Admin"
                    };
                }
                return null; // Sai mật khẩu admin
            }

            // 2. Tài khoản nhân viên từ bảng tNhanVien (bao gồm cả NV25-01, NV25-02,...)
            bool hasChucVu = CheckHasChucVuColumn();
            string sql = hasChucVu
                ? "SELECT TOP 1 MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang, ChucVu FROM tNhanVien WHERE MaNV = @MaNV AND DienThoai = @MatKhau"
                : "SELECT TOP 1 MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang FROM tNhanVien WHERE MaNV = @MaNV AND DienThoai = @MatKhau";

            var dt = DatabaseHelper.ExecuteQuery(sql, new[]
            {
                new SqlParameter("@MaNV", trimmedMaNV),
                new SqlParameter("@MatKhau", trimmedMK)
            });

            if (dt.Rows.Count == 0) return null;
            var r = dt.Rows[0];
            string chucVu = "NhanVien";
            if (hasChucVu && dt.Columns.Contains("ChucVu") && r["ChucVu"] != DBNull.Value)
            {
                chucVu = r["ChucVu"].ToString() ?? "NhanVien";
            }

            return new NhanVienDTO
            {
                MaNV = r["MaNV"].ToString()?.Trim() ?? string.Empty,
                TenNV = r["TenNV"].ToString() ?? string.Empty,
                NamSinh = r["NamSinh"] != DBNull.Value ? Convert.ToInt32(r["NamSinh"]) : null,
                GioiTinh = r["GioiTinh"].ToString() ?? "M",
                DiaChi = r["DiaChi"]?.ToString() ?? string.Empty,
                DienThoai = r["DienThoai"].ToString() ?? string.Empty,
                LuongThang = r["LuongThang"] != DBNull.Value ? Convert.ToDecimal(r["LuongThang"]) : null,
                ChucVu = chucVu
            };
        }

        public NhanVienDTO? GetByMaNV(string maNV)
        {
            try
            {
                if (string.Equals(maNV.Trim(), "ADMIN", StringComparison.OrdinalIgnoreCase))
                {
                    return new NhanVienDTO
                    {
                        MaNV = "ADMIN",
                        TenNV = "Quản Trị Viên (Admin)",
                        GioiTinh = "M",
                        DienThoai = "admin",
                        ChucVu = "Admin"
                    };
                }

                bool hasChucVu = CheckHasChucVuColumn();
                string sql = hasChucVu
                    ? "SELECT TOP 1 MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang, ChucVu FROM tNhanVien WHERE MaNV = @MaNV"
                    : "SELECT TOP 1 MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang FROM tNhanVien WHERE MaNV = @MaNV";

                var dt = DatabaseHelper.ExecuteQuery(sql, new[] { new SqlParameter("@MaNV", maNV.Trim()) });
                if (dt.Rows.Count == 0) return null;
                var r = dt.Rows[0];
                string chucVu = "NhanVien";
                if (hasChucVu && dt.Columns.Contains("ChucVu") && r["ChucVu"] != DBNull.Value)
                {
                    chucVu = r["ChucVu"].ToString() ?? "NhanVien";
                }

                return new NhanVienDTO
                {
                    MaNV = r["MaNV"].ToString()?.Trim() ?? string.Empty,
                    TenNV = r["TenNV"].ToString() ?? string.Empty,
                    NamSinh = r["NamSinh"] != DBNull.Value ? Convert.ToInt32(r["NamSinh"]) : null,
                    GioiTinh = r["GioiTinh"].ToString() ?? "M",
                    DiaChi = r["DiaChi"]?.ToString() ?? string.Empty,
                    DienThoai = r["DienThoai"].ToString() ?? string.Empty,
                    LuongThang = r["LuongThang"] != DBNull.Value ? Convert.ToDecimal(r["LuongThang"]) : null,
                    ChucVu = chucVu
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
