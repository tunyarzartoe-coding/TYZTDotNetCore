using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using ZackDotNet.RestApi.Db;
using ZackDotNet.RestApi.Models;

namespace ZackDotNet.RestApi.Controllers
{
    //end point
    [Route("api/[controller]")]
    [ApiController]
    public class BLogController : ControllerBase
    {
        private readonly AppDbContent _content;
        
        public BLogController()
        {
            _content = new AppDbContent();
        }
        [HttpGet]
        public IActionResult Read()
        {
            var lst = _content.Blogs.ToList();
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _content.Blogs.FirstOrDefault(x=> x.BlogId == id);
            if(item is null)
            {
                return NotFound("No data found!");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _content.Blogs.Add(blog);
            var result = _content.SaveChanges();
            string message = result > 0 ? "Saving Successful!" : "Saving Failed!";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id , BlogModel blog)
        {
            var item = _content.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found!");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            var result = _content.SaveChanges();
            string message = result > 0 ? "Updating Successful!" : "Updating Failed!";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,BlogModel blog)
        {
            var item = _content.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found!");
            }
            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }
            var result = _content.SaveChanges();
            string message = result > 0 ? "Updating Successful!" : "Updating Failed!";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _content.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found!");
            }
            _content.Blogs.Remove(item);
            var result = _content.SaveChanges();
            string message = result > 0 ? "Deleting Successful!" : "Deleting Failed!";
            return Ok(message);
        }
    }
}
