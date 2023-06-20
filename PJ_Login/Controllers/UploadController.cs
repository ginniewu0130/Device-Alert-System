using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PJ_Login.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult UploadFile()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            // 檢查是否有上傳的檔案
            if (file != null)
            {
                //先回傳view看看
                ViewBag.FileName = file.FileName;
            }

            return View();
        }
    }
}
