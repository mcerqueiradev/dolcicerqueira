using wapp_dolcicerqueira.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using wapp_dolcicerqueira.Domain.Entities;
using System.Collections.Generic;
using wapp_dolcicerqueira.Models;
using System.Threading.Tasks;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace wapp_dolcicerqueira.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;
        private readonly IRatingService _ratingService;
        private readonly IFavoriteService _favoriteService;
        private readonly IFriendsService _friendsService;
        public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment, IRecipeService recipeService, ICategoryService categoryService, IRatingService ratingService, IFavoriteService favoriteService, IFriendsService friendsService)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
            _recipeService = recipeService;
            _categoryService = categoryService;
            _ratingService = ratingService;
            _favoriteService = favoriteService;
            _friendsService = friendsService;
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        public IActionResult GetById(int id)
        {
            AllModels am = new AllModels();
            am.User = _userService.GetById(id);
            am.RecipesaApproved = _recipeService.RecipesApproved();
            am.RecipesaApprovedById = am.RecipesaApproved.Where(r => r.AuthorId == id && r.IsApproved).ToList();
            int idUser;
            if (int.TryParse(Request.Cookies["Id"], out idUser))
            {
                am.Friend = _friendsService.GetFriendByUserIds(idUser, id);
                am.Friends = _friendsService.GetFriendRequest(idUser);
            }

            return View(am);
        }
        public IActionResult GetAll()
        {
            AllModels am = new AllModels();
            am.Users = _userService.GetAll();
            return View(am);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Users user)
        {
            int idUser;
            if (int.TryParse(Request.Cookies["Id"], out idUser))
            {
                if (user.Upload != null)
                {
                    await SaveImage(user);
                }
                _userService.Save(user);
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public IActionResult UpdateByUserId(Users user)
        {
            int idUser;
            if (int.TryParse(Request.Cookies["Id"], out idUser))
            {
                user = _userService.GetById(user.Id);
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser(Users user)
        {
            if (user.Upload != null)
            {
                await SaveImage(user);
            }
            _userService.Save(user);
            return RedirectToAction("Dashboard", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Save(Users user)
        {
            if (user.Upload != null)
            {
                await SaveImage(user);
            }

            _userService.Save(user);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> SaveImage([FromForm] Users user)
        {
            if (user.Upload == null || user.Upload.Length == 0)
            {
                ModelState.AddModelError("Upload", "Nenhuma imagem selecionada");
            }

            // Verifica a extensão do arquivo para garantir que seja uma imagem
            string fileExtension = Path.GetExtension(user.Upload.FileName).ToLower();
            if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
            {
                ModelState.AddModelError("Upload", "Somente arquivos de imagem .jpg, .jpeg ou .png são permitidos");
            }

            // Gera um nome único para o arquivo de imagem
            string fileName = $"{Guid.NewGuid().ToString()}{fileExtension}";

            // Salva o arquivo de imagem na pasta "images" no diretório raiz do projeto
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "avatar", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await user.Upload.CopyToAsync(stream);
            }

            // Atribui o nome do arquivo ao objeto Recipe para salvar no banco de dados
            user.ImageUrl = fileName;

            // Salva o objeto Recipe no banco de dados
            // ...

            return RedirectToAction("Index");
        }
    }
}
