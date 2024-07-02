using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TYZTDotNetCore.MvcApp2.Db;
using TYZTDotNetCore.MvcApp2.Models;


namespace TYZTDotNetCore.MvcApp2.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex()
        {
            var lst = await _db.Blogs
                .AsNoTracking()
                .OrderByDescending(x => x.BlogId)
                .ToListAsync();
            return View("BlogIndex",lst);
        }

        [ActionName("Create")]
        public IActionResult CreateBlog()
        {
            return View("CreateBlog");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> CreateBlog(BlogModel blog)
        {
            await _db.Blogs.AddAsync(blog);
            var result = await _db.SaveChangesAsync();
            //return View("CreateBlog");
            var message = new MessageModel()
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Saving Successful." : "Saving Failed."
            };
            return Json(message);
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> EditBlog(int id)
        {
            var item = await _db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item == null)
            {
                return Redirect("/Blog");
            }
            return View("EditBlog", item);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> UpdateBlog(int id, BlogModel blog)
        {
            var item = await _db.Blogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BlogId == id);
            if (item == null)
            {
                return Redirect("/Blog");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            _db.Entry(item).State = EntityState.Modified;

            var result = await _db.SaveChangesAsync();
            var message = new MessageModel()
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Updating Successful." : "Updating Failed."
            };
            return Json(message);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteBlog(BlogModel blog)
        {
            var item = await _db.Blogs
               .FirstOrDefaultAsync(x => x.BlogId == blog.BlogId);
            if (item == null)
            {
                return Redirect("/Blog");
            }
            _db.Blogs.Remove(item);
            var result = await _db.SaveChangesAsync();

            var message = new MessageModel()
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Deleting Successful." : "Deleting Failed."
            };
            return Json(message);
        }
    }
}
