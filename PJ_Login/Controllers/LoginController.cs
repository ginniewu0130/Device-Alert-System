﻿using Microsoft.AspNetCore.Mvc;
using PJ_Login.Data;
using PJ_Login.Models;
using PJ_Login.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
                    // 登入成功，導向主頁
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
    
    }
}