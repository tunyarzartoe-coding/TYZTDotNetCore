using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using TYZTDotNetCore.RestApi.Models;

namespace ZackDotNet.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
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
            List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            }).ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult EditBlog(int id)
        {
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
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BLogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
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
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BLogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
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
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                updateFields.Add("[BlogTitle] = @BlogTitle");
                parameters.Add(new SqlParameter("@BlogTitle", SqlDbType.NVarChar) { Value = blog.BlogTitle });
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                updateFields.Add("[BlogAuthor] = @BlogAuthor");
                parameters.Add(new SqlParameter("@BlogAuthor", SqlDbType.NVarChar) { Value = blog.BlogAuthor });
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                updateFields.Add("[BlogContent] = @BlogContent");
                parameters.Add(new SqlParameter("@BlogContent", SqlDbType.NVarChar) { Value = blog.BlogContent });
            }

            if (updateFields.Count == 0)
            {
                return BadRequest("No Data to Update!");
            }

            string updateString = string.Join(", ", updateFields);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
                      SET {updateString}
                      WHERE BlogId = @BlogId";

            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            foreach (var parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }
            cmd.Parameters.Add(new SqlParameter("@BlogId", SqlDbType.Int) { Value = id });
            int result = cmd.ExecuteNonQuery();
            connection.Close();

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
            string query = "select * from Tbl_Blog where BlogId = @BlogId";

            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            DataRow dr = dt.Rows[0];
            var item = new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            };

            return item;

        }
    }
}
