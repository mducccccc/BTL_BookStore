namespace BTL.DTO
{
    public class SachDTO
    {
        public string MaSach { get; set; } = string.Empty;
        public string TenSach { get; set; } = string.Empty;
        public string MaLoai { get; set; } = string.Empty;
        public string MaLV { get; set; } = string.Empty;
        public string MaTG { get; set; } = string.Empty;
        public string MaNXB { get; set; } = string.Empty;
        public string MaNN { get; set; } = string.Empty;
        public int? SoTrang { get; set; }
        public decimal GiaSach { get; set; }
        public decimal DonGiaThue { get; set; }
        public string MaTT { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public string? Anh { get; set; }
        public string? GhiChu { get; set; }

        // Các thuộc tính liên kết hiển thị
        public string? TenLoai { get; set; }
        public string? TenLV { get; set; }
        public string? TenTG { get; set; }
        public string? TenNXB { get; set; }
        public string? TenNN { get; set; }
        public string? TenTT { get; set; }
    }
}
