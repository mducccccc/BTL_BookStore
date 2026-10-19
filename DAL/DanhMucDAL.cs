using System.Data;
using BTL.DTO;

namespace BTL.DAL
{
    public class DanhMucDAL
    {
        public DataTable GetAllLinhVuc() => DatabaseHelper.ExecuteQuery("SELECT MaLV, TenLV FROM tLinhVuc ORDER BY TenLV");
        public DataTable GetAllLoaiSach() => DatabaseHelper.ExecuteQuery("SELECT MaLoai, TenLoai FROM tLoaiSach ORDER BY TenLoai");
        public DataTable GetAllTinhTrang() => DatabaseHelper.ExecuteQuery("SELECT MaTT, TenTT FROM tTinhTrang ORDER BY TenTT");
        public DataTable GetAllNgonNgu() => DatabaseHelper.ExecuteQuery("SELECT MaNN, TenNN FROM tNgonNgu ORDER BY TenNN");
        public DataTable GetAllCaLam() => DatabaseHelper.ExecuteQuery("SELECT MaCa, TenCa FROM tCaLam ORDER BY MaCa");
        public DataTable GetAllViPham() => DatabaseHelper.ExecuteQuery("SELECT MaVP, TenVP, TienPhat FROM tViPham ORDER BY TenVP");
        public DataTable GetAllTacGia() => DatabaseHelper.ExecuteQuery("SELECT MaTG, TenTG, NgaySinh, GioiTinh, DiaChi FROM tTacGia ORDER BY TenTG");
        public DataTable GetAllNXB() => DatabaseHelper.ExecuteQuery("SELECT MaNXB, TenNXB, DiaChi, DienThoai FROM tNXB ORDER BY TenNXB");
    }
}
