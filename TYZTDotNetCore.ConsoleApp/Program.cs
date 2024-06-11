// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZackDotNet.ConsoleApp.AdoDotNetExamples;
using ZackDotNet.ConsoleApp.DapperExamples;
using ZackDotNet.ConsoleApp.EFCoreExamples;
using ZackDotNet.ConsoleApp.Services;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.ReadKey();



//SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
//stringBuilder.DataSource = "ZACK";
//stringBuilder.InitialCatalog = "DotNet";
//stringBuilder.UserID = "sa";
//stringBuilder.Password = "sa@123";

//SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

//connection.Open();
//Console.WriteLine("Connection Open.");

//string query = "select * from tbl_blog";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//sqlDataAdapter.Fill(dt);

//connection.Close();
//Console.WriteLine("Connection Close.");


//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("Blog Id =====>"+dr["BlogId"]);
//    Console.WriteLine("Blog Title  =====>" + dr["BlogTitle"]);
//    Console.WriteLine("Blog Author  =====>" + dr["BlogAuthor"]);
//    Console.WriteLine("Blog Content  =====>" + dr["BlogContent"]);
//    Console.WriteLine("------------------------------");

//}
//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title", "author", "content");
//adoDotNetExample.Update(12, "test title", "test author", "test content");
//adoDotNetExample.Delete(11);
//adoDotNetExample.Edit(1); 
//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Run();

var connectionString = ConnectionStrings.SqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

var serviceProvider = new ServiceCollection()
    .AddScoped(n => new AdoDotNetExample(sqlConnectionStringBuilder))
    .AddScoped(n => new DapperExample(sqlConnectionStringBuilder))
    .AddDbContext<AppDbContent>(opt =>
{
    opt.UseSqlServer(connectionString);
})
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider();

//AppDbContent db =serviceProvider.GetRequiredService<AppDbContent>();

//var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetExample>();
//adoDotNetExample.Read();

//var dapperExample = serviceProvider.GetRequiredService<DapperExample>();
//dapperExample.Run();

var eFCoreExample = serviceProvider.GetRequiredService<EFCoreExample>();
eFCoreExample.Run();

Console.ReadKey();

