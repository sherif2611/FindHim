﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using Project1.ViewModels;
using System.Net;
using System.Security.Claims;

namespace Project1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult SavedRegiester(UserModel user)
        {
            var context = new FindHimDbContext();
            var OldUser=context.Users.Where(a=>a.Email==user.Email).FirstOrDefault();
            if (OldUser==null)
            {
                var new_user = new User()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,
                    Password = user.Password,
                };
                context.Users.Add(new_user);
                context.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ModelState.AddModelError("Email", "This email is already registered.");
                return View("Register", user);
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> SavedLoginAsync(UserModel user) 
        {
            var context= new FindHimDbContext();
            var userLogin=context.Users.Where(a=>a.Email==user.Email).Select(a=>a.Password).FirstOrDefault();
            if(userLogin!=null)
            {
                if (userLogin == user.Password)
                {
                    var ClaimsIdentity = new ClaimsIdentity("MyCookie");
                    ClaimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email,ClaimValueTypes.String));            
                    var princiaple = new ClaimsPrincipal(ClaimsIdentity);
                    Thread.CurrentPrincipal = princiaple;
                    await HttpContext.SignInAsync("MyCookie", princiaple);
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        public async Task<RedirectToActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
    }
}
