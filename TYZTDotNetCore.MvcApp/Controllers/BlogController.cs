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
            var lst = await _db.Blogs.ToListAsync();
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
    }
}
