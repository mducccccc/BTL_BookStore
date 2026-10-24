namespace BTL
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            ApplicationConfiguration.Initialize();

            // Hiển thị Form Đăng nhập (Bước 10)
            using var login = new GUI.FormLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new GUI.FormMain());
            }
        }
    }
}