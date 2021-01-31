using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }        

        [Route("signup", Name ="signup")]
        public IActionResult Signup()
        {            
            return View();
        }
        
        [Route("signup", Name = "signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel userModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(userModel);
                if(!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                } else 
                {
                    ModelState.Clear();
                }                            
            }
            return View(userModel);
        }

        [Route("signin", Name = "signin")]
        public IActionResult SignIn()
        {
            return View();
        }

        [Route("signin", Name = "signin")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.SignInAsync(signInModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }
            return View();
        }

        [Route("logout", Name = "logout")]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
