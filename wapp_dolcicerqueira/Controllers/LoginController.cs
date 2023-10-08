using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Models;
using wapp_dolcicerqueira.Repositories.Interfaces;

namespace wapp_dolcicerqueira.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(LoginModel loginModel)
        {
            Users user = _userRepository.GetUserLogin(loginModel.Email, loginModel.Password);
            wapp_dolcicerqueira.Models.AllModels.UserCheck = user;
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);

            if (user != null && loginModel.Email == user.Email && loginModel.Password == user.Password)
            {
                    Response.Cookies.Append("Id", user.Id.ToString(), options);
                    loginModel.UserModel = user;
                    return RedirectToAction("Index", "Home");
               
           
            }
            else
            {
                TempData["ErrorMessage"] = $"Your email or password is wrong. Please try again.";
                return RedirectToAction("Index", "Login");
            }

        }
    }
}
