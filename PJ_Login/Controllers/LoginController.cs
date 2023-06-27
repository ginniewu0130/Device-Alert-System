using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PJ_Login.Data;
using PJ_Login.Models;
using PJ_Login.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PJ_Login.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginContext _context;
        public LoginController(LoginContext context)
        {
            _context = context;
        }
      
        //登入頁面
        public IActionResult LoginPage()
        {
            var loginVM = new LoginViewModel
            {
                UserLogin = new UserLogin()
            };

            return View(loginVM);
        }
        
        // 登入動作
        [HttpPost]
        public IActionResult LoginPage(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                //查詢資料庫中是否存在符合輸入的帳號密碼
                var existingUser = _context.UserLogins.FirstOrDefault(u => u.Account == loginVM.UserLogin.Account && u.Password == loginVM.UserLogin.Password);

                if (existingUser != null)
                {
                    // 登入成功，設定身分驗證 Cookie
                    var claims = new List<Claim>{
                        new Claim(ClaimTypes.Name, existingUser.Account)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // 登入失敗，顯示錯誤訊息或其他操作
                    ModelState.AddModelError("", "帳號或密碼錯誤");
                }
            }

            return View(loginVM);
        }
        /*--------帳號管理部分---------*/
        //[Authorize(Roles = "Admin")]
        [Authorize]
        public IActionResult AccountManage()
        {
            var usersmodel = _context.UserLogins.ToList();
            return View(usersmodel);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                // 處理保存新用戶的邏輯
                _context.UserLogins.Add(userLogin);
                _context.SaveChanges();

                return RedirectToAction("AccountManage");
            }

            return View(userLogin);
        }
        
        public IActionResult Edit(int id)
        {
            var userLogin = _context.UserLogins.FirstOrDefault(u => u.UserId == id);

            if (userLogin == null)
            {
                return NotFound();
            }

            return View(userLogin);
        }

        [HttpPost]
        public IActionResult Edit(int id, UserLogin userLogin)
        {
            if (id != userLogin.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // 處理更新用戶資料的邏輯
                _context.UserLogins.Update(userLogin);
                _context.SaveChanges();

                return RedirectToAction("AccountManage");
            }

            return View(userLogin);
        }
        
        public IActionResult Details(int id)
        {
            var userLogin = _context.UserLogins.FirstOrDefault(u => u.UserId == id);

            if (userLogin == null)
            {
                return NotFound();
            }

            return View(userLogin);
        }
        
        public IActionResult Delete(int id)
        {
            var userLogin = _context.UserLogins.FirstOrDefault(u => u.UserId == id);

            if (userLogin == null)
            {
                return NotFound();
            }

            return View(userLogin);
        }
        
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var userLogin = _context.UserLogins.FirstOrDefault(u => u.UserId == id);

            if (userLogin == null)
            {
                return NotFound();
            }

            _context.UserLogins.Remove(userLogin);
            _context.SaveChanges();

            return RedirectToAction("AccountManage");
        }

    }
}