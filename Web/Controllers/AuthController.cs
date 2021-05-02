using BusinessLogic.Abstract;
using Entity.Dtos.Web.Auth;
using Entity.ViewModels.Web.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helper.FluentValidation;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var loginResult = _authService.Login(model.LoginUserDto, HttpContext);
            if (!loginResult.Success)
            {
                ModelState.AddModelError("LoginMessage", loginResult.Message);
                return View(model);
            }
            return RedirectToAction("Index","Panel");
        }
        public ActionResult Register()
        {
            return View();
        }
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

            return View(model);
        }
    }
}