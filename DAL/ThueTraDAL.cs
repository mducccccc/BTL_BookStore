using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BTL.DTO;

namespace BTL.DAL
{
    public class ThueTraDAL
    {
        #region THUÊ SÁCH (YÊU CẦU 1, 2)

        public string GenerateNewMaThue()
        {
            var pOut = new SqlParameter("@NewMaThue", SqlDbType.Char, 10)
            {
                Direction = ParameterDirection.Output
            };
            DatabaseHelper.ExecuteStoredProcedureNonQuery("SP_GenerateNewMaThue", new[] { pOut });
            return pOut.Value?.ToString()?.Trim() ?? string.Empty;
        }

        public DataTable GetAllPhieuThue()
        {
            string sql = @"
                SELECT t.MaThue, t.MaKH, kh.TenKH, t.MaNV, nv.TenNV, 
                       t.MaCa, ca.TenCa, t.NgayThue, t.TienDatCoc
                FROM tThueSach t
                JOIN tKhachHang kh ON kh.MaKH = t.MaKH
                JOIN tNhanVien nv ON nv.MaNV = t.MaNV
                JOIN tCaLam ca ON ca.MaCa = t.MaCa
                ORDER BY t.NgayThue DESC, t.MaThue DESC";
            return DatabaseHelper.ExecuteQuery(sql);
        }

        public DataTable GetChiTietThue(string maThue)
        {
            string sql = @"
                SELECT ct.MaThue, ct.MaSach, s.TenSach, ct.SoLuong, ct.DaTra, s.DonGiaThue
                FROM tChiTietThueSach ct
                JOIN tSachTruyen s ON s.MaSach = ct.MaSach
                WHERE ct.MaThue = @MaThue";
            return DatabaseHelper.ExecuteQuery(sql, new[] { new SqlParameter("@MaThue", maThue) });
        }

        // Lập phiếu thuê: ghi vào tThueSach và tChiTietThueSach trong cùng 1 Transaction
        // Trigger CSDL trg_ChiTietThue_Insert sẽ tự động trừ kho tSachTruyen (Yêu cầu 2)
        public bool LapPhieuThue(ThueSachDTO thue, List<ChiTietThueDTO> chiTietList)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var trans = conn.BeginTransaction();
            try
            {
                // 1. Thêm phiếu thuê
                string sqlThue = @"
                    INSERT INTO tThueSach (MaThue, MaKH, MaNV, MaCa, NgayThue, TienDatCoc)
                    VALUES (@MaThue, @MaKH, @MaNV, @MaCa, @NgayThue, @TienDatCoc)";

                using (var cmd = new SqlCommand(sqlThue, conn, trans))
                {
                    cmd.Parameters.AddWithValue("@MaThue", thue.MaThue);
                    cmd.Parameters.AddWithValue("@MaKH", thue.MaKH);
                    cmd.Parameters.AddWithValue("@MaNV", thue.MaNV);
                    cmd.Parameters.AddWithValue("@MaCa", thue.MaCa);
                    cmd.Parameters.AddWithValue("@NgayThue", thue.NgayThue);
                    cmd.Parameters.AddWithValue("@TienDatCoc", thue.TienDatCoc);
                    cmd.ExecuteNonQuery();
                }

                // 2. Thêm các dòng chi tiết thuê (Trigger DB sẽ tự động trừ SoLuong trong tSachTruyen)
                string sqlCT = @"
                    INSERT INTO tChiTietThueSach (MaThue, MaSach, SoLuong, DaTra)
                    VALUES (@MaThue, @MaSach, @SoLuong, 0)";

                foreach (var ct in chiTietList)
                {
                    using var cmdCT = new SqlCommand(sqlCT, conn, trans);
                    cmdCT.Parameters.AddWithValue("@MaThue", thue.MaThue);
                    cmdCT.Parameters.AddWithValue("@MaSach", ct.MaSach);
                    cmdCT.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                    cmdCT.ExecuteNonQuery();
                }

                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }

        #endregion

        #region TRẢ SÁCH (YÊU CẦU 2, 3, 4)

        public string GenerateNewMaTra()
        {
            var pOut = new SqlParameter("@NewMaTra", SqlDbType.Char, 10)
            {
                Direction = ParameterDirection.Output
            };
            DatabaseHelper.ExecuteStoredProcedureNonQuery("SP_GenerateNewMaTra", new[] { pOut });
            return pOut.Value?.ToString()?.Trim() ?? string.Empty;
        }

        // Yêu cầu 3: Lấy danh sách sách CHƯA TRẢ theo mã phiếu thuê
        public DataTable GetSachChuaTra(string maThue)
        {
            var p = new SqlParameter("@MaThue", maThue);
            return DatabaseHelper.ExecuteStoredProcedure("SP_GetSachChuaTraTheoPhieu", new[] { p });
        }

        public DataTable GetAllPhieuTra()
        {
            string sql = @"
                SELECT tr.MaTra, tr.MaThue, tr.MaNV, nv.TenNV, tr.NgayTra, tr.TongTien, kh.TenKH
                FROM tTraSach tr
                JOIN tThueSach t ON t.MaThue = tr.MaThue
                JOIN tKhachHang kh ON kh.MaKH = t.MaKH
                JOIN tNhanVien nv ON nv.MaNV = tr.MaNV
                ORDER BY tr.NgayTra DESC, tr.MaTra DESC";
            return DatabaseHelper.ExecuteQuery(sql);
        }

        public DataTable GetChiTietTra(string maTra)
        {
            string sql = @"
                SELECT ct.MaTra, ct.MaSach, s.TenSach, ct.MaVP, vp.TenVP, vp.TienPhat, ct.ThanhTien
                FROM tChiTietTraSach ct
                JOIN tSachTruyen s ON s.MaSach = ct.MaSach
                LEFT JOIN tViPham vp ON vp.MaVP = ct.MaVP
                WHERE ct.MaTra = @MaTra";
            return DatabaseHelper.ExecuteQuery(sql, new[] { new SqlParameter("@MaTra", maTra) });
        }

        // Lập phiếu trả sách:
        // YC4: Sử dụng SP_ThemChiTietTra để tự tính Thành tiền = Đơn giá * Số ngày + Phạt
        // YC2: Trigger trg_ChiTietTra_Insert trong DB tự cộng lại SoLuong và đánh dấu DaTra = 1
        public bool LapPhieuTra(TraSachDTO tra, List<ChiTietTraDTO> chiTietList)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var trans = conn.BeginTransaction();
            try
            {
                // 1. Tạo phiếu trả với tổng tiền ban đầu = 0
                string sqlTra = @"
                    INSERT INTO tTraSach (MaTra, MaThue, MaNV, NgayTra, TongTien)
                    VALUES (@MaTra, @MaThue, @MaNV, @NgayTra, 0)";

                using (var cmd = new SqlCommand(sqlTra, conn, trans))
                {
                    cmd.Parameters.AddWithValue("@MaTra", tra.MaTra);
                    cmd.Parameters.AddWithValue("@MaThue", tra.MaThue);
                    cmd.Parameters.AddWithValue("@MaNV", tra.MaNV);
                    cmd.Parameters.AddWithValue("@NgayTra", tra.NgayTra);
                    cmd.ExecuteNonQuery();
                }

                // 2. Thêm từng chi tiết trả (Trigger trg_ChiTietTra_Insert sẽ tự cộng lại kho và đánh dấu DaTra = 1)
                string sqlCT = @"
                    INSERT INTO tChiTietTraSach (MaTra, MaSach, MaVP, ThanhTien)
                    VALUES (@MaTra, @MaSach, @MaVP, @ThanhTien)";

                foreach (var ct in chiTietList)
                {
                    using var cmdCT = new SqlCommand(sqlCT, conn, trans);
                    cmdCT.Parameters.AddWithValue("@MaTra", tra.MaTra);
                    cmdCT.Parameters.AddWithValue("@MaSach", ct.MaSach);
                    cmdCT.Parameters.AddWithValue("@MaVP", string.IsNullOrWhiteSpace(ct.MaVP) ? DBNull.Value : (object)ct.MaVP);
                    cmdCT.Parameters.AddWithValue("@ThanhTien", ct.ThanhTien);
                    cmdCT.ExecuteNonQuery();
                }

                // 3. Cập nhật tổng tiền vào phiếu trả
                string sqlUp = @"
                    UPDATE tTraSach 
                    SET TongTien = (SELECT ISNULL(SUM(ThanhTien), 0) FROM tChiTietTraSach WHERE MaTra = @MaTra)
                    WHERE MaTra = @MaTra";
                using (var cmdUp = new SqlCommand(sqlUp, conn, trans))
                {
                    cmdUp.Parameters.AddWithValue("@MaTra", tra.MaTra);
                    cmdUp.ExecuteNonQuery();
                }

                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }

        #endregion
    }
}
