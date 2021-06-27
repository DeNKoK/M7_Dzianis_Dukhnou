using System.Configuration;

namespace M7_Dzianis_Dukhnou.WebDriver
{
    public static class Configuration
    {

        public static string GetEnviromentVar(string var, string defaultValue)
        {
            return ConfigurationManager.AppSettings[var] ?? defaultValue;
        }

        public static string ElementTimeout => GetEnviromentVar("ElementTimeout", "30");

        public static string Browser => GetEnviromentVar("Browser", "Firefox");

        public static string StartUrl => GetEnviromentVar("StartUrl", "https://mail.yandex.by");

        public static string UserID => GetEnviromentVar("User", "DzianisM6");

        public static string Password => GetEnviromentVar("Password", "HometaskM6");

    }
}