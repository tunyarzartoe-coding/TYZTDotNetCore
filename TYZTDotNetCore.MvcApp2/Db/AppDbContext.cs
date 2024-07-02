using Microsoft.EntityFrameworkCore;
using TYZTDotNetCore.MvcApp2.Models;

namespace TYZTDotNetCore.MvcApp2.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        //}
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
