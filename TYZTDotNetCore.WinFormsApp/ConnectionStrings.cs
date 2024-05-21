
using System.Data.SqlClient;

namespace ZackDotNet.WinFormsApp
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "ZACK",
            InitialCatalog = "DotNet",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true,
        };

    }
}
