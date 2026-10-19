namespace BTL.DTO
{
    public static class SessionContext
    {
        public static NhanVienDTO? CurrentNhanVien { get; set; }
        public static string CurrentCaLam { get; set; } = "CA1";

        public static bool IsLoggedIn => CurrentNhanVien != null;

        public static void DangXuat()
        {
            CurrentNhanVien = null;
        }
    }
}
