using Microsoft.AspNetCore.Mvc;
using PJ_Login.Data;
using PJ_Login.Models;
using System.Collections.Generic;
using System.Linq;

namespace PJ_Login.Controllers
{
    public class ChartController : Controller
    {
        private readonly ChartDBContext _context;
        public ChartController(ChartDBContext context)
        {
            _context = context;
        }
        public IActionResult Chart()
        {
            List<Output> outputs = _context.Outputs.ToList();
            List<Output3> output3s = _context.Output3s.ToList();
            var labels = _context.Outputs.Select(x => x.SrcIp).Distinct().ToList();
            var datas = _context.Output3s.Select(x => x.Action).Distinct().ToList();

            var chartVM = new ChartViewModel
            {
                Labels = labels,
                Datas = datas
            };
            return View(chartVM);
        }
    }
}
