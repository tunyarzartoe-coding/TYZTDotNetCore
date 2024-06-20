using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TYZTDotNetCore.MvcApp.Db;
using TYZTDotNetCore.MvcApp.Models;

namespace TYZTDotNetCore.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var lst = await _db.Blogs
                .AsNoTracking()
                .OrderByDescending(x => x.BlogId)
                .ToListAsync();
            return View(lst);
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
            return Redirect("/Blog");
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

            await _db.SaveChangesAsync();
            return Redirect("/Blog");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var item = await _db.Blogs
               .FirstOrDefaultAsync(x => x.BlogId == id);
            if (item == null)
            {
                return Redirect("/Blog");
            }
            _db.Blogs.Remove(item);
            await _db.SaveChangesAsync();

            return Redirect("/Blog");
        }
    }
}
