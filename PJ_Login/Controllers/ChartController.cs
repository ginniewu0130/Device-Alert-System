using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PJ_Login.Data;
using PJ_Login.Models;
using PJ_Login.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

//測試用 改良LogChartController
namespace PJ_Login.Controllers
{
    public class ChartController : Controller
    {
        private readonly LogDBContext _context;

        public ChartController(LogDBContext context)
        {
            _context = context;
        }

        private List<LogDBViewModel> GetChartData()
        {
            List<Chart> charts = _context.Charts.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (Chart chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action
                });
            }
            return bars;
        }

        public IActionResult BarAccept()
        {
            List<LogDBViewModel> bars = GetChartData();
            return View(bars);
        }

        public IActionResult BarTimeout()
        {
            List<LogDBViewModel> bars = GetChartData();
            return View(bars);
        }

        public IActionResult BarIpConn()
        {
            List<LogDBViewModel> bars = GetChartData();
            return View(bars);
        }

        public IActionResult BarDeny()
        {
            List<LogDBViewModel> bars = GetChartData();
            return View(bars);
        }

        public IActionResult BarClientRst()
        {
            List<LogDBViewModel> bars = GetChartData();
            return View(bars);
        }

        public IActionResult BarClose()
        {
            List<LogDBViewModel> bars = GetChartData();
            return View(bars);
        }

        public IActionResult BarServerRst()
        {
            List<LogDBViewModel> bars = GetChartData();
            return View(bars);
        }
    }
}
