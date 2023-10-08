using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Models;
using wapp_dolcicerqueira.Services.Interfaces;

namespace wapp_dolcicerqueira.Controllers
{
    public class FriendsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRecipeService _recipeService;
        private readonly IFriendsService _friendsService;
        public FriendsController(IUserService userService, IWebHostEnvironment webHostEnvironment, IRecipeService recipeService, IFriendsService friendsService)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
            _recipeService = recipeService;
            _friendsService = friendsService;
        }

        public IActionResult AddFriend(int id)
        {
            int idUser;
            if (int.TryParse(Request.Cookies["Id"], out idUser))
            {

                Friends friend = new Friends
                {
                    UserOne = idUser,
                    UserTwo = id,
                    Status = false
                };

                _friendsService.Save(friend);

                

                return RedirectToAction("GetById", "User", new { id = id });
            }
            return RedirectToAction("GetById", "User", new { id = id });
        }

    }
}
