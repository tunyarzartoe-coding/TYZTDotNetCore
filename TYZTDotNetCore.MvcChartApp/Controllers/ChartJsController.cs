using Microsoft.AspNetCore.Mvc;
using TYZTDotNetCore.MvcChartApp.Models;

namespace TYZTDotNetCore.MvcChartApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult ExampleChart()
        {
            return View();
        }
        public IActionResult InterpolationLineChart()
        {
            return View();
        }
        public IActionResult LineStylingChart()
        {
            var model = new LineStylingChartModel
            {
                Labels = new List<string> { "January", "February", "March", "April", "May", "June", "July" },
                DataSets = new List<DataSets>
                {
                    new DataSets
                    {
                        Label = "Unfilled",
                        Fill = false,
                        BgColor = "rgb(54, 162, 235)",
                        BorderColor = "rgb(54, 162, 235)",
                        BorderDash = new List<int>(),
                        Data = new List<int> { 65, -59, 80, 81, -56, 55, 40 }
                    },
                    new DataSets
                    {
                        Label = "Dashed",
                        Fill = false,
                        BgColor = "rgb(75, 192, 192)",
                        BorderColor = "rgb(75, 192, 192)",
                        BorderDash = new List<int> { 5, 5 },
                        Data = new List<int> { -28, 48, -40, 19, 86, 27, 90 }
                    },
                    new DataSets
                    {
                        Label = "Filled",
                        Fill = true,
                        BgColor = "rgb(255, 99, 132)",
                        BorderColor = "rgb(255, 99, 132)",
                        BorderDash = new List<int>(),
                        Data = new List<int> { 18, -48, 77, 9, 100, -27, 40 }
                    }
                }
            };

            return View(model);
        }
    }
}
