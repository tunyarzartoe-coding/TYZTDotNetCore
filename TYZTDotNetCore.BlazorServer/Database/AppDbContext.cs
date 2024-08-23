using Microsoft.EntityFrameworkCore;
using TYZTDotNetCore.BlazorServer.Models;

namespace TYZTDotNetCore.BlazorServer.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
