using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace PJ_Login.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult SalesReport()
        {
            return View();
        }

        [Authorize(Roles = "Administrator,HR")]
        public IActionResult HrReport()
        {
            return View();
        }
    }
}
