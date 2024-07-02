using Microsoft.AspNetCore.Mvc;
using TYZTDotNetCore.MvcChartApp.Models;

namespace TYZTDotNetCore.MvcChartApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult SimplePieChart()
        {
            SimplePieChartModel model = new SimplePieChartModel();
            model.Lables = new List<string>() { "Team A", "Team B", "Team C", "Team D", "Team E" };
            model.Series = new List<int> { 44, 55, 13, 43, 22 };
            return View(model);
        }
    }
}
