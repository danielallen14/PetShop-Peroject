using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetShop.Client.Models;
using PetShop.Service;
using System.Diagnostics;

namespace PetShop.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimalService animalService;
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger,IAnimalService animalService)
        {
            _logger = logger;
            this.animalService = animalService;
        }

        public IActionResult Index()
        {

            return View(animalService.GetTop2Animals());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    return View();
        //}
        //public IActionResult Logout()
        //{
        //    _signInManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}

        //public async Task<IActionResult> Register()
        //{
        //    IdentityUser user = new IdentityUser
        //    {
        //        UserName = "amirad",
        //    };

        //    var result = await _userManager.CreateAsync(user, "123qwe!@#QWE");

        //    if (result.Succeeded)
        //    {
        //        return Content("user created successfully");
        //    }

        //    return Content("Failed to create user");
        //}
    }
}