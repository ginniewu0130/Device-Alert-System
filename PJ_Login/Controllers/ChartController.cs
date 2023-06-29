using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PJ_Login.Data;
using PJ_Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PJ_Login.Controllers
{
    public class ChartController : Controller
    {
       
        [Authorize]
        public IActionResult ChartSelection()
        {
            var chartOptions = Enum.GetValues(typeof(ChartType))
                .Cast<ChartType>()
                .Select(c => new SelectListItem { Value = c.ToString(), Text = GetChartTypeName(c) })
                .ToList();

            ViewBag.ChartOptions = chartOptions;

            return View();
        }
        [HttpPost]
        public IActionResult DisplayChart(string chartType)
        {
            if (Enum.TryParse(chartType, out ChartType selectedChart))
            {
                switch (selectedChart)
                {
                    case ChartType.Chart1:
                        return RedirectToAction("Chart1");

                    case ChartType.Chart2:
                        return RedirectToAction("Chart2");

                    case ChartType.Chart3:
                        return RedirectToAction("Chart3");
                    
                    case ChartType.Chart4:
                        return RedirectToAction("Chart4");

                    case ChartType.Chart5:
                        return RedirectToAction("Chart5");
                    
                    case ChartType.Chart6:
                        return RedirectToAction("Chart6");
                    
                    case ChartType.Chart7:
                        return RedirectToAction("Chart7");
                }
            }

            return RedirectToAction("ChartSelection");
        }

        public enum ChartType
        {
            Chart1,
            Chart2,
            Chart3,
            Chart4,
            Chart5,
            Chart6,
            Chart7
        }
        private string GetChartTypeName(ChartType chartType)
        {
            switch (chartType)
            {
                case ChartType.Chart1:
                    return "Chart 1";

                case ChartType.Chart2:
                    return "Chart 2";

                case ChartType.Chart3:
                    return "Chart 3";

                case ChartType.Chart4:
                    return "Chart 4";
                
                case ChartType.Chart5:
                    return "Chart 5";
                
                case ChartType.Chart6:
                    return "Chart 6";
                
                case ChartType.Chart7:
                    return "Chart 7";

                default:
                    return string.Empty;
            }
        }
        //[HttpGet]
        //public IActionResult GetChart(string chartType)
        //{
        //    switch (chartType)
        //    {
        //        case "Chart1":
        //            return PartialView("Chart1");

        //        case "Chart2":
        //            return PartialView("Chart2");

        //        case "Chart3":
        //            return PartialView("Chart3");

        //        default:
        //            return Content("Invalid chart type.");
        //    }
        //}
    }
}
