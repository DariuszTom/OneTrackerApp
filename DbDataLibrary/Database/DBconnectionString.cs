using Microsoft.Data.SqlClient;
using System.Runtime.InteropServices;

namespace DbDataLibrary.Database
{
    public sealed class DBconnectionString
    {
        #region Singelton

        private DBconnectionString()
        { }

        private static DBconnectionString _instance;
        private static readonly object _lock = new object();

        public static DBconnectionString GetInstance([Optional] string connectionString)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        if (connectionString != null) _conString = connectionString;
                        _instance = new DBconnectionString();
                    }
                }
            }
            return _instance;
        }

        #endregion Singelton

        #region Fields

        /// <summary>
        /// Please Make this fields secure as you will change database from Local to server
        /// DESKTOP-CCVKBBL\almos
        /// </summary>
        private static string _conString = $"DESKTOP-CCVKBBL";

        private static string _InitalCatalog = "OneTrackerDB";

        #endregion Fields

        #region Properties

        public string ConString { get => CreateConString($"Data Source={_conString}"); }
        public static string SetInitalCatalog { set => _InitalCatalog = value; }

        #endregion Properties

        #region PrivateMethods

        private static string CreateConString(string initial)
        {
            var myBuilder = new SqlConnectionStringBuilder(initial)
            {
                ConnectRetryCount = 3,
                InitialCatalog = _InitalCatalog,
                UserID = "YourLogin",
                Password = "YourPassword"
            };
            return myBuilder.ConnectionString;
        }

        #endregion PrivateMethods
    }
}