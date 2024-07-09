using Microsoft.AspNetCore.Mvc;

namespace TYZTDotNetCore.MvcChartApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult ExampleChart()
        {
            return View();
        }
    }
}
