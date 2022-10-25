using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silas.Web.Models.ViewModels;
using Silas.Web.Services;

namespace Silas.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        AuthService _authService;


        public AuthenticationController()
        {
            _authService = new AuthService();
        }

        [AllowAnonymous]
        [HttpPost("Auth")]
        public IActionResult Auth([FromForm] LoginViewModel login)
        {
            var response = _authService.Authentication(login);
            if (response.Authorized)
                return RedirectToAction("Index", "Clientes", new { accessToken = response.AccessToken });
            return RedirectToAction("Login", "Login", new { response = "Fail" });

        }



    }
}
