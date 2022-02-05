// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;


namespace OneTrackerMobile.Misc.Settings
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string settingsKey = "E59F99B4-16B1-431C-9361-EC32D2D6FA39";
        private static readonly string userCompanyId = string.Empty;
        private static readonly int useryId = 0;

        #endregion


        public static string UserCompanyId
        {
            get
            {
                return AppSettings.GetValueOrDefault(settingsKey, userCompanyId);
            }
            set
            {
                AppSettings.AddOrUpdateValue(settingsKey, value);
            }
        }
        public static int UseryId
        {
            get
            {
                return AppSettings.GetValueOrDefault(settingsKey, useryId);
            }
            set
            {
                AppSettings.AddOrUpdateValue(settingsKey, value);
            }
        }

    }
}
