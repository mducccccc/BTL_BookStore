namespace BTL.DTO
{
    public static class SessionContext
    {
        public static NhanVienDTO? CurrentNhanVien { get; set; }
        public static string CurrentCaLam { get; set; } = "CA1";

        public static bool IsLoggedIn => CurrentNhanVien != null;
        public static bool IsAdmin => CurrentNhanVien != null && 
            (string.Equals(CurrentNhanVien.ChucVu, "Admin", System.StringComparison.OrdinalIgnoreCase) ||
             string.Equals(CurrentNhanVien.MaNV, "ADMIN", System.StringComparison.OrdinalIgnoreCase));

        public static void DangXuat()
        {
            CurrentNhanVien = null;
        }
    }
}
