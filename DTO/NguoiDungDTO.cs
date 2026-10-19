namespace BTL.DTO
{
    public class KhachHangDTO
    {
        public string MaKH { get; set; } = string.Empty;
        public string TenKH { get; set; } = string.Empty;
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; } = "M";
        public string DiaChi { get; set; } = string.Empty;
    }

    public class NhanVienDTO
    {
        public string MaNV { get; set; } = string.Empty;
        public string TenNV { get; set; } = string.Empty;
        public int? NamSinh { get; set; }
        public string GioiTinh { get; set; } = "M";
        public string DiaChi { get; set; } = string.Empty;
        public string DienThoai { get; set; } = string.Empty;
        public decimal? LuongThang { get; set; }
    }
}
