using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TYZTDotNetCore.MvcApp.Db;

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
    }
}
