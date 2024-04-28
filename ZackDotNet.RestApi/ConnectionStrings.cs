using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZackDotNet.RestApi
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "ZACK",
            InitialCatalog = "DotNet",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true,
        };

    }
}
