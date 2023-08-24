using AF.StorageVault.Configs;

namespace AF.StorageVault
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PasswordHandler handler = new PasswordHandler(new RsaContainer(), new AppSettings());
            StorageItemController controller = new StorageItemController(handler);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new StorageVaultForm(handler, controller));
        }
    }
}