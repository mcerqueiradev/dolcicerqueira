using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Models;
using wapp_dolcicerqueira.Services.Interfaces;

namespace wapp_dolcicerqueira.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult GetAll()
        {
            AllModels am = new AllModels();
            am.Products = _productService.GetAll();
            return View(am);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        public IActionResult GetById(int id)
        {
            AllModels am = new AllModels();
            am.Product = _productService.GetById(id);
            return View(am);
        }

        [HttpPost]
        public IActionResult SaveProduct(Product product)
        {
            _productService.Save(product);
            return RedirectToAction("Index", "Home");
        }

    }
}
