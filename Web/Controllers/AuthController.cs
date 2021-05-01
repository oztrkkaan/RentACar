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
        IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            var registerResult = _userService.Register(model.RegisterUserDto);
            if (!registerResult.Success)
            {
                ModelState.ValidateModel(registerResult.ValidationErrors, typeof(RegisterUserDto));
                return View(model);
            }
            return View(model);
        }
    }
}