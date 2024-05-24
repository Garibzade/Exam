using GaribExam.Models;
using GaribExam.ViewModels.AccountVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace GaribExam.Controllers
{
    public class AccountController(UserManager<AppUser> _maneger,SignInManager<AppUser> _signin) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
		public async Task< IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid) 
                return View();
            AppUser user = new AppUser
            {
                Name = vm.Name,
                Surname=vm.SurName,
                Email = vm.Email,
                UserName=vm.Username,
                

            };
            var result=await _maneger.CreateAsync(user,vm.Password);
            if (!result.Succeeded) 
            {
                foreach (var item in result.Errors)
                {
					ModelState.AddModelError("", item.Description);
				}
                return View();
            }
			return RedirectToAction(nameof(Login));
		}

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginVM vm)
        {
            AppUser user =await _maneger.FindByNameAsync(vm.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Isdiadeci adi veya parol yalnisdir");
                return View(vm);
            }
            var result = await _signin.CheckPasswordSignInAsync(user,vm.Password,false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Isdiadeci adi veya parol yalnisdir");
                return View(vm);
            }

            return RedirectToAction("Index","Home");


        }

        public async Task<IActionResult> SignOut()
        {
            await _signin.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}
