using Microsoft.AspNetCore.Mvc;
using PJ_Login.Data;
using PJ_Login.Models;
using PJ_Login.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PJ_Login.Controllers
{
    public class LogChartController : Controller
    {
        private readonly LogDBContext _context;
        public LogChartController(LogDBContext context)
        {
            _context = context;
        }
        public IActionResult bar_accept()
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
            return View(bars);
        }
        public IActionResult bar_timeout()
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
            return View(bars);
        }
        public IActionResult bar_ip_conn()
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
            return View(bars);
        }
        public IActionResult bar_deny()
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
            return View(bars);
        }
        public IActionResult bar_client_rst()
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
            return View(bars);
        }
        public IActionResult bar_close()
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
            return View(bars);
        }
        public IActionResult bar_server_rst()
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
            return View(bars);
        }
    }
}
