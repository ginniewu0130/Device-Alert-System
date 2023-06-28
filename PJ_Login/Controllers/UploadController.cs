using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System;

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
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                // 檢查副檔名
                if (extension == ".csv" || extension == ".txt")
                {
                    try
                    {
                        // 檔案儲存路徑 (桌面)
                        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), file.FileName + ".txt");

                        // 讀取 CSV 檔案內容
                        using (var reader = new StreamReader(file.OpenReadStream()))
                        {
                            string content = reader.ReadToEnd();

                            // 轉換為 TXT 格式 (這裡只是示例，你可以根據需要進行更複雜的處理)
                            string txtContent = ConvertToTxt(content);

                            // 儲存轉換後的 TXT 檔案
                            System.IO.File.WriteAllText(filePath, txtContent, Encoding.UTF8);

                            ViewBag.Message = "檔案已成功轉換並儲存於桌面。";
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "轉換檔案時發生錯誤：" + ex.Message;
                    }
                }
                else
                {
                    ViewBag.Message = "請上傳 CSV 或 TXT 檔案。";
                }
            }

            return View();
        }
        private string ConvertToTxt(string csvContent)
        {
            
            return csvContent;
        }
    }
}
