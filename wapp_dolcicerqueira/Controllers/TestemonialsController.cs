using Microsoft.AspNetCore.Mvc;
using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Services.Interfaces;

namespace wapp_dolcicerqueira.Controllers
{
    public class TestemonialsController : Controller
    {
        private readonly ITestemonialsService _testemonialsService;
        public TestemonialsController(ITestemonialsService testemonialsService)
        {
            _testemonialsService = testemonialsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Testemonials testemonials)
        {
            _testemonialsService.Save(testemonials);
            return RedirectToAction("Index", "Home");
        }

   

    }
}
