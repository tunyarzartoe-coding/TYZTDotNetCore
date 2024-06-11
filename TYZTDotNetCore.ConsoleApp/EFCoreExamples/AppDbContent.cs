using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZackDotNet.ConsoleApp.Dtos;
using ZackDotNet.ConsoleApp.Services;

namespace ZackDotNet.ConsoleApp.EFCoreExamples
{
    public class AppDbContent : DbContext
    {
        public AppDbContent(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        //}
        public DbSet<BlogDto> Blogs { get; set; }
    }
}
