
using System.Data.SqlClient;

namespace TYZTDotNetCore.WindowFormsApSqlInjection
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
