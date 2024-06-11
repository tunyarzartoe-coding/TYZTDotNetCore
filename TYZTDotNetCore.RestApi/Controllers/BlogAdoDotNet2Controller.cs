using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using TYZTDotNetCore.RestApi.Models;
using TYZTDotNetCore.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ZackDotNet.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        //private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService
        //    (ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        private readonly AdoDotNetService _adoDotNetService;

        public BlogAdoDotNet2Controller(AdoDotNetService doDotNetService)
        {
            _adoDotNetService = doDotNetService;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            //connection.Open();
            //SqlCommand cmd = new SqlCommand(query, connection);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);
            //connection.Close();
            //List<BlogModel> lst = new List<BlogModel>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    BlogModel blog = new BlogModel();
            //    blog.BlogId = Convert.ToInt32(dr["BlogId"]);
            //    blog.BlogAuthor = Convert.ToString(dr["BlogAuthor"]);
            //    blog.BlogTitle = Convert.ToString(dr["BlogTitle"]);
            //    blog.BlogContent = Convert.ToString(dr["BlogContent"]);
            //    lst.Add(blog);
            //}
            //BlogModel blog = new BlogModel
            //{
            //    BlogId = Convert.ToInt32(dr["BlogId"]),
            //    BlogTitle = Convert.ToString(dr["BlogTitle"]),
            //    BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //    BlogContent = Convert.ToString(dr["BlogContent"])
            //};
            //List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            //{
            //    BlogId = Convert.ToInt32(dr["BlogId"]),
            //    BlogTitle = Convert.ToString(dr["BlogTitle"]),
            //    BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //    BlogContent = Convert.ToString(dr["BlogContent"])
            //}).ToList();
            var lst = _adoDotNetService.Query<BlogModel>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult EditBlog(int id)
        {
            //string query = "select * from tbl_blog where blogId = @BlogId";
            //AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            //parameters[0] = new AdoDotNetParameter("@BlogId", id);
            //var lst = _adoDotNetService.Query<BlogModel>(query, parameters);

            //var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query,
            //    new AdoDotNetParameter("@BlogId", id) 
            // );

            var item = FindById(id);

            if (item is null)
            {
                return NotFound("No data found!");
            }

            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,@BlogAuthor,@BLogContent)";

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BLogContent", blog.BlogContent)

                );

            string message = result > 0 ? "Saving Success." : "Saving Failed.";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found!");
            }
            blog.BlogId = id;
            string query = @"UPDATE [dbo].[Tbl_Blog]
                  SET [BlogTitle] = @BlogTitle,
                      [BlogAuthor] = @BlogAuthor,
                      [BlogContent] = @BlogContent
                       WHERE BlogId = @BlogId";
            int result = _adoDotNetService.Execute(query,
                   new AdoDotNetParameter("@BlogId", blog.BlogId),
                   new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                   new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                   new AdoDotNetParameter("@BLogContent", blog.BlogContent)

                   );
            string message = result > 0 ? "Updating Success." : "Updating Failed.";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found!");
            }

            List<string> updateFields = new List<string>();
            List<AdoDotNetParameter> parameters = new List<AdoDotNetParameter>();

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                updateFields.Add("[BlogTitle] = @BlogTitle");
                parameters.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogTitle));
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                updateFields.Add("[BlogAuthor] = @BlogAuthor");
                parameters.Add(new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor));
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                updateFields.Add("[BlogContent] = @BlogContent");
                parameters.Add(new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            }

            if (updateFields.Count == 0)
            {
                return BadRequest("No Data to Update!");
            }

            string updateString = string.Join(", ", updateFields);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
                      SET {updateString}
                      WHERE BlogId = @BlogId";

            parameters.Add(new AdoDotNetParameter("@BlogId", id));

            int result = _adoDotNetService.Execute(query, parameters.ToArray());
            string message = result > 0 ? "Updating Success." : "Updating Failed.";
            return Ok(message);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"delete from [dbo].[Tbl_Blog] WHERE BlogId = @BlogId ";
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found!");
            }
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Deleting Success." : "Deleting Failed.";
            return Ok(message);
        }
        private BlogModel? FindById(int id)
        {
            string query = "select * from tbl_blog where blogId = @BlogId";
            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query,
                new AdoDotNetParameter("@BlogId", id)
             );

            return item;

        }
    }
}
