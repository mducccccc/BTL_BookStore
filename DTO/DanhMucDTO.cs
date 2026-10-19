namespace BTL.DTO
{
    public class LinhVucDTO
    {
        public string MaLV { get; set; } = string.Empty;
        public string TenLV { get; set; } = string.Empty;
    }

    public class LoaiSachDTO
    {
        public string MaLoai { get; set; } = string.Empty;
        public string TenLoai { get; set; } = string.Empty;
    }

    public class TinhTrangDTO
    {
        public string MaTT { get; set; } = string.Empty;
        public string TenTT { get; set; } = string.Empty;
    }

    public class NgonNguDTO
    {
        public string MaNN { get; set; } = string.Empty;
        public string TenNN { get; set; } = string.Empty;
    }

    public class CaLamDTO
    {
        public string MaCa { get; set; } = string.Empty;
        public string TenCa { get; set; } = string.Empty;
    }

    public class TacGiaDTO
    {
        public string MaTG { get; set; } = string.Empty;
        public string TenTG { get; set; } = string.Empty;
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; } = "M";
        public string DiaChi { get; set; } = string.Empty;
    }

    public class NXBDTO
    {
        public string MaNXB { get; set; } = string.Empty;
        public string TenNXB { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
        public string DienThoai { get; set; } = string.Empty;
    }

    public class ViPhamDTO
    {
        public string MaVP { get; set; } = string.Empty;
        public string TenVP { get; set; } = string.Empty;
        public decimal TienPhat { get; set; }
    }
}
