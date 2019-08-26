using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.IdentityViewModels;
using StudentUnion0105.Models;

namespace StudentUnion0105.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly UserManager<SuUser> userManager;

        public UserController(UserManager<SuUser> userManager, SignInManager<SuUser> signInManager)
        {
            this.userManager = userManager;
            SignInManager = signInManager;
        }

        public SignInManager<SuUser> SignInManager { get; }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new SuUser { UserName = registerViewModel.Email, Email = registerViewModel.Email };
                var result = await userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(registerViewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Logout()
        {

            await SignInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt");

            }

            return View(loginViewModel);
        }

    }
}