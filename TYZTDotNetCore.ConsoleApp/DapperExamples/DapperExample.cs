using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZackDotNet.ConsoleApp.Dtos;
using ZackDotNet.ConsoleApp.Services;

namespace ZackDotNet.ConsoleApp.DapperExamples;

internal class DapperExample
{
    public void Run()
    {
        Read();
        //Edit(1);
        //Edit(100);
        //Create("title 1", "author 1", "content 1");
        //Update(13,"title 2", "author 2", "content 2");
        //Delete(14);

    }
    private void Read()
    {
        string query = "select * from tbl_blog";
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        List<BlogDto> lst = db.Query<BlogDto>(query).ToList();

        foreach (BlogDto item in lst)
        {
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

            Console.WriteLine("------------------------------");

        }
        // using IDbConnection db1 = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        //{
        //    db.Open();
        //}
        //db1

    }
    private void Edit(int id)
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        var item = db.Query<BlogDto>("select * from tbl_blog where blogId = @BlogId", new BlogDto { BlogId = id }).FirstOrDefault();
        if (item is null)
        {
            Console.Write("No data found!");
            return;
        }
        Console.WriteLine(item.BlogId);
        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);

        Console.WriteLine("------------------------------");

    }
    private void Create(string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        string query =
            @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,@BlogAuthor,@BLogContent)";
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Saving Success." : "Saving Failed.";
        Console.WriteLine(message);
    }

    private void Update(int id, string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogId = id,
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        string query = @"UPDATE [dbo].[Tbl_Blog]
                  SET [BlogTitle] = @BlogTitle,
                      [BlogAuthor] = @BlogAuthor,
                      [BlogContent] = @BlogContent
                       WHERE BlogId = @BlogId";
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Updating Success." : "Updating Failed.";
        Console.WriteLine(message);
    }

    private void Delete(int id)
    {
        var item = new BlogDto
        {
            BlogId = id,
        };
        string query = @"DELETE From [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Deleting Success." : "Deleting Failed.";
        Console.WriteLine(message);
    }
}
