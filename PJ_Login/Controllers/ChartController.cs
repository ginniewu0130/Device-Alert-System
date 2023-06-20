using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PJ_Login.Data;
using PJ_Login.Models;
using System.Collections.Generic;
using System.Linq;

namespace PJ_Login.Controllers
{
    public class ChartController : Controller
    {
        private readonly ChartDBContext _ctx;
        public ChartController(ChartDBContext context)
        {
            _ctx = context;
        }
        [Authorize]
        public IActionResult ChartSelection()
        {
            // 建立下拉式選單的選項
            var chartOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "chart", Text = "Chart 1" },
                new SelectListItem { Value = "chart2", Text = "Chart 2" }
            };

            ViewBag.ChartOptions = chartOptions;

            return View();
        }
        [HttpPost]
        public IActionResult DisplayChart(string chartType)
        {
            if (chartType == "chart")
            {                
                return View("Chart"); 
            }
            else if (chartType == "chart2")
            {              
                return View("Chart2"); 
            }

            return RedirectToAction("ChartSelection"); // 若沒有選擇有效的選項，重新導向回選擇頁面
        }


        public IActionResult Chart()
        {
            List<Output> outputs = _ctx.Outputs.ToList();
            List<Output3> output3s = _ctx.Output3s.ToList();
            var labels = _ctx.Outputs.Select(x => x.SrcIp).Distinct().ToList();
            var datas = _ctx.Output3s.Select(x => x.Action).Distinct().ToList();

            var chartVM = new ChartViewModel
            {
                Labels = labels,
                Datas = datas
            };
            return View(chartVM);
        }

        public IActionResult Chart2()
        {
            return View();
        }

    }
}
