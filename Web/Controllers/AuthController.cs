using BusinessLogic.Abstract;
using Entity.Dtos.Web.Auth;
using Entity.ViewModels.Web.Auth;
using System.Web.Mvc;
using Web.Helper.FluentValidation;

namespace Web.Controllers
{
    [RoutePrefix("kimlik")]
    public class AuthController : Controller
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [Route("giris-yap")]
        public ActionResult Login()
        {
            return View();
        }
        [Route("giris-yap")]
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var loginResult = _authService.Login(model.LoginUserDto, HttpContext);
            if (!loginResult.Success)
            {
                ModelState.AddModelError("LoginMessage", loginResult.Message);
                return View(model);
            }
            return RedirectToAction("Index", "Panel");
        }
        [Route("kayit-ol")]
        public ActionResult Register()
        {
            return View();
        }
        [Route("kayit-ol")]
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            var registerResult = _authService.Register(model.RegisterUserDto);
            if (!registerResult.Success)
            {
                ModelState.ValidateModel(registerResult.ValidationErrors, typeof(RegisterUserDto));
                return View(model);
            }

            _authService.Login(new LoginUserDto() { Email = model.RegisterUserDto.Email, Password = model.RegisterUserDto.Password }, HttpContext);

            return RedirectToAction("Index","Panel");
        }
    }
}