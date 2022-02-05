using Microsoft.Data.SqlClient;

namespace DbDataLibrary.Database
{
    public sealed class ConnectionChecker
    {
        #region Fields

        private readonly DBconnectionString dBconnectionString;

        #endregion Fields

        #region Constructor

        public ConnectionChecker()
        {
            dBconnectionString = DBconnectionString.GetInstance();
        }

        #endregion Constructor

        #region Methods

        public bool CouldConnect()
        {
            bool isError = false;
            using (var conn = new SqlConnection(dBconnectionString.ConString))
            {
                try
                {
                    conn.Open();
                    conn.Close();
                }
                catch (SqlException)
                {
                    isError = true;
                }
            }
            return isError;
        }

        #endregion Methods
    }
}