﻿
using System.Data.SqlClient;

namespace TYZTDotNetCore.NLayer.DataAccess
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
