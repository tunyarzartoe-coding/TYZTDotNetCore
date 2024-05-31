using Microsoft.EntityFrameworkCore;
using TYZTDotNetCore.NLayer.DataAccess.Models;

namespace TYZTDotNetCore.NLayer.DataAccess.Db
{
    internal class AppDbContent : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
