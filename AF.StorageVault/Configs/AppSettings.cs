using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.StorageVault.Configs
{
    public class AppSettings
    {
        public const string AppSettingsEnvPath = "AF.StorageVault.Env";
        private static string GetAppSettingsEnvPath { get => Environment.GetEnvironmentVariable(AppSettingsEnvPath) ?? "Configs\\AppSettings.json"; }
        private IConfigurationSection? configurationSection { get => configuration?.GetSection("AppSettings"); }
        private IConfiguration? configuration;

        public AppSettings()
        {
            var builder = new ConfigurationBuilder().AddJsonFile(GetAppSettingsEnvPath, optional: false, reloadOnChange: true);
            configuration = builder.Build();
        }

        public string RsaContainerName { get => configurationSection?[nameof(RsaContainerName)] ?? string.Empty; }
		public string PasswordFilePath { get => configurationSection?[nameof(PasswordFilePath)] ?? string.Empty; }
		public string StorageFilePath { get => configurationSection?[nameof(StorageFilePath)] ?? string.Empty; }

    }
}
