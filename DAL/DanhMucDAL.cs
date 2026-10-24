using System;
using System.Data;
using Microsoft.Data.SqlClient;
using BTL.DTO;

namespace BTL.DAL
{
    public class DanhMucDAL
    {
        #region GET ALL
        public DataTable GetAllLinhVuc() => DatabaseHelper.ExecuteQuery("SELECT MaLV, TenLV FROM tLinhVuc ORDER BY MaLV");
        public DataTable GetAllLoaiSach() => DatabaseHelper.ExecuteQuery("SELECT MaLoai, TenLoai FROM tLoaiSach ORDER BY MaLoai");
        public DataTable GetAllTinhTrang() => DatabaseHelper.ExecuteQuery("SELECT MaTT, TenTT FROM tTinhTrang ORDER BY MaTT");
        public DataTable GetAllNgonNgu() => DatabaseHelper.ExecuteQuery("SELECT MaNN, TenNN FROM tNgonNgu ORDER BY MaNN");
        public DataTable GetAllCaLam() => DatabaseHelper.ExecuteQuery("SELECT MaCa, TenCa FROM tCaLam ORDER BY MaCa");
        public DataTable GetAllViPham() => DatabaseHelper.ExecuteQuery("SELECT MaVP, TenVP, TienPhat FROM tViPham ORDER BY MaVP");
        public DataTable GetAllTacGia() => DatabaseHelper.ExecuteQuery("SELECT MaTG, TenTG, NgaySinh, GioiTinh, DiaChi FROM tTacGia ORDER BY MaTG");
        public DataTable GetAllNXB() => DatabaseHelper.ExecuteQuery("SELECT MaNXB, TenNXB, DiaChi, DienThoai FROM tNXB ORDER BY MaNXB");
        #endregion

        #region VI PHẠM (YÊU CẦU 4 LIÊN QUAN)
        public bool InsertViPham(ViPhamDTO vp)
        {
            string sql = "INSERT INTO tViPham (MaVP, TenVP, TienPhat) VALUES (@MaVP, @TenVP, @TienPhat)";
            return DatabaseHelper.ExecuteNonQuery(sql, new[]
            {
                new SqlParameter("@MaVP", vp.MaVP),
                new SqlParameter("@TenVP", vp.TenVP),
                new SqlParameter("@TienPhat", vp.TienPhat)
            }) > 0;
        }

        public bool UpdateViPham(ViPhamDTO vp)
        {
            string sql = "UPDATE tViPham SET TenVP = @TenVP, TienPhat = @TienPhat WHERE MaVP = @MaVP";
            return DatabaseHelper.ExecuteNonQuery(sql, new[]
            {
                new SqlParameter("@MaVP", vp.MaVP),
                new SqlParameter("@TenVP", vp.TenVP),
                new SqlParameter("@TienPhat", vp.TienPhat)
            }) > 0;
        }

        public bool DeleteViPham(string maVP)
        {
            string sql = "DELETE FROM tViPham WHERE MaVP = @MaVP";
            return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SqlParameter("@MaVP", maVP) }) > 0;
        }
        #endregion

        #region TÁC GIẢ
        public bool InsertTacGia(TacGiaDTO tg)
        {
            string sql = "INSERT INTO tTacGia (MaTG, TenTG, NgaySinh, GioiTinh, DiaChi) VALUES (@MaTG, @TenTG, @NgaySinh, @GioiTinh, @DiaChi)";
            return DatabaseHelper.ExecuteNonQuery(sql, new[]
            {
                new SqlParameter("@MaTG", tg.MaTG),
                new SqlParameter("@TenTG", tg.TenTG),
                new SqlParameter("@NgaySinh", (object?)tg.NgaySinh ?? DBNull.Value),
                new SqlParameter("@GioiTinh", tg.GioiTinh),
                new SqlParameter("@DiaChi", (object?)tg.DiaChi ?? DBNull.Value)
            }) > 0;
        }

        public bool UpdateTacGia(TacGiaDTO tg)
        {
            string sql = "UPDATE tTacGia SET TenTG = @TenTG, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi WHERE MaTG = @MaTG";
            return DatabaseHelper.ExecuteNonQuery(sql, new[]
            {
                new SqlParameter("@MaTG", tg.MaTG),
                new SqlParameter("@TenTG", tg.TenTG),
                new SqlParameter("@NgaySinh", (object?)tg.NgaySinh ?? DBNull.Value),
                new SqlParameter("@GioiTinh", tg.GioiTinh),
                new SqlParameter("@DiaChi", (object?)tg.DiaChi ?? DBNull.Value)
            }) > 0;
        }

        public bool DeleteTacGia(string maTG)
        {
            string sql = "DELETE FROM tTacGia WHERE MaTG = @MaTG";
            return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SqlParameter("@MaTG", maTG) }) > 0;
        }
        #endregion

        #region NHÀ XUẤT BẢN
        public bool InsertNXB(NXBDTO nxb)
        {
            string sql = "INSERT INTO tNXB (MaNXB, TenNXB, DiaChi, DienThoai) VALUES (@MaNXB, @TenNXB, @DiaChi, @DienThoai)";
            return DatabaseHelper.ExecuteNonQuery(sql, new[]
            {
                new SqlParameter("@MaNXB", nxb.MaNXB),
                new SqlParameter("@TenNXB", nxb.TenNXB),
                new SqlParameter("@DiaChi", (object?)nxb.DiaChi ?? DBNull.Value),
                new SqlParameter("@DienThoai", (object?)nxb.DienThoai ?? DBNull.Value)
            }) > 0;
        }

        public bool UpdateNXB(NXBDTO nxb)
        {
            string sql = "UPDATE tNXB SET TenNXB = @TenNXB, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaNXB = @MaNXB";
            return DatabaseHelper.ExecuteNonQuery(sql, new[]
            {
                new SqlParameter("@MaNXB", nxb.MaNXB),
                new SqlParameter("@TenNXB", nxb.TenNXB),
                new SqlParameter("@DiaChi", (object?)nxb.DiaChi ?? DBNull.Value),
                new SqlParameter("@DienThoai", (object?)nxb.DienThoai ?? DBNull.Value)
            }) > 0;
        }

        public bool DeleteNXB(string maNXB)
        {
            string sql = "DELETE FROM tNXB WHERE MaNXB = @MaNXB";
            return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SqlParameter("@MaNXB", maNXB) }) > 0;
        }
        #endregion

        #region CA LÀM
        public bool InsertCaLam(CaLamDTO ca)
        {
            string sql = "INSERT INTO tCaLam (MaCa, TenCa) VALUES (@MaCa, @TenCa)";
            return DatabaseHelper.ExecuteNonQuery(sql, new[]
            {
                new SqlParameter("@MaCa", ca.MaCa),
                new SqlParameter("@TenCa", ca.TenCa)
            }) > 0;
        }

        public bool UpdateCaLam(CaLamDTO ca)
        {
            string sql = "UPDATE tCaLam SET TenCa = @TenCa WHERE MaCa = @MaCa";
            return DatabaseHelper.ExecuteNonQuery(sql, new[]
            {
                new SqlParameter("@MaCa", ca.MaCa),
                new SqlParameter("@TenCa", ca.TenCa)
            }) > 0;
        }

        public bool DeleteCaLam(string maCa)
        {
            string sql = "DELETE FROM tCaLam WHERE MaCa = @MaCa";
            return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SqlParameter("@MaCa", maCa) }) > 0;
        }
        #endregion
    }
}
