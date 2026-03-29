using Microsoft.AspNetCore.Mvc;
using ValleyProject.Entities.Model;
using ValleyProject.Repositories.Interface;

namespace ValleyProject.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepo _userRepo;

        public AuthController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserInfo ui)
        {
            var userinfo =await _userRepo.GetUserInfo(ui.UserName,ui.Password);
            HttpContext.Session.SetInt32("Id",userinfo.Id);
            HttpContext.Session.SetString("userName",userinfo.UserName);
            return RedirectToAction("Index","Country");
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserInfo um)
        {
            var user = new UserInfo
            {
                UserId = um.UserId,
                UserName = um.UserName,
                Password = um.Password
            };
            var result = _userRepo.RegisterUser(user);
            return RedirectToAction("Login");
        }
    }
}
