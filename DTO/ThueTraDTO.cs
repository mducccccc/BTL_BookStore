namespace BTL.DTO
{
    public class ThueSachDTO
    {
        public string MaThue { get; set; } = string.Empty;
        public string MaKH { get; set; } = string.Empty;
        public string MaNV { get; set; } = string.Empty;
        public string MaCa { get; set; } = string.Empty;
        public DateTime NgayThue { get; set; } = DateTime.Today;
        public decimal TienDatCoc { get; set; }

        // Trường tham chiếu hiển thị
        public string? TenKH { get; set; }
        public string? TenNV { get; set; }
        public string? TenCa { get; set; }
    }

    public class ChiTietThueDTO
    {
        public string MaThue { get; set; } = string.Empty;
        public string MaSach { get; set; } = string.Empty;
        public int SoLuong { get; set; } = 1;
        public bool DaTra { get; set; } = false;

        // Thuộc tính mở rộng hiển thị
        public string? TenSach { get; set; }
        public decimal DonGiaThue { get; set; }
    }

    public class TraSachDTO
    {
        public string MaTra { get; set; } = string.Empty;
        public string MaThue { get; set; } = string.Empty;
        public string MaNV { get; set; } = string.Empty;
        public DateTime NgayTra { get; set; } = DateTime.Today;
        public decimal TongTien { get; set; }

        public string? TenNV { get; set; }
        public string? TenKH { get; set; }
    }

    public class ChiTietTraDTO
    {
        public string MaTra { get; set; } = string.Empty;
        public string MaSach { get; set; } = string.Empty;
        public string? MaVP { get; set; }
        public decimal ThanhTien { get; set; }

        // Thuộc tính mở rộng
        public string? TenSach { get; set; }
        public string? TenVP { get; set; }
        public int SoLuong { get; set; }
        public int SoNgayThue { get; set; }
    }
}
