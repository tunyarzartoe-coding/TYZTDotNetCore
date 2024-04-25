// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using ZackDotNet.ConsoleApp;

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
DapperExample dapperExample = new DapperExample();
dapperExample.Run();

Console.ReadKey();

