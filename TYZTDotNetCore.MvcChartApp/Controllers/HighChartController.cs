using Microsoft.AspNetCore.Mvc;

namespace TYZTDotNetCore.MvcChartApp.Controllers
{
    public class HighChartController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }
        public IActionResult SplineChart()
        {
            return View();
        }
    }
}
