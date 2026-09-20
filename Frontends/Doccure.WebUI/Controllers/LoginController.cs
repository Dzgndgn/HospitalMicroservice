using Doccure.WebUI.Dtos.LoginDtos;
using Doccure.WebUI.Services.LoginServices;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginDto dto)
        {
            var token = await _loginService.LoginAsync(dto);
            if(token == null)
                return View("Error");
            HttpContext.Session.SetString("JwtToken", token);
            return RedirectToAction("Index", "Branch",new {area = "Admin"});
        }
    }
}
