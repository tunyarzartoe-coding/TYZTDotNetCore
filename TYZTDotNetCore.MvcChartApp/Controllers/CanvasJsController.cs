using Microsoft.AspNetCore.Mvc;

namespace TYZTDotNetCore.MvcChartApp.Controllers
{
    public class CanvasJsController : Controller
    {
        private readonly ILogger<CanvasJsController> _logger;

        public CanvasJsController(ILogger<CanvasJsController> logger)
        {
            _logger = logger;
        }

        public IActionResult LineChart()
        {
            _logger.LogInformation("Line Chart...");
            return View();
        }
        public IActionResult AnimatedChart()
        {
            return View();
        }
    }
}
