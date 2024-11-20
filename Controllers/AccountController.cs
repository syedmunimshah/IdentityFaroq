using IdentityFaroq.Models;
using IdentityFaroq.Models.DataTransfers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityFaroq.Controllers
{
    public class AccountController : Controller
    {
        private readonly myContextDb _myContextDb;
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(myContextDb myContextDb, UserManager<IdentityUser> userManager)
        {
            _myContextDb = myContextDb;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            var user = new IdentityUser
            {
                UserName = registerViewModel.Name,
                Email = registerViewModel.Email
            };

            var hashpassword = new PasswordHasher<IdentityUser>();
            user.PasswordHash = hashpassword.HashPassword(user, registerViewModel.Password);

            var identityResult = await _userManager.CreateAsync(user);

            await _userManager.AddToRoleAsync(user,"User");

            if(identityResult.Succeeded)
            {
                //Success

                return RedirectToAction("Register");

            }
            //Failure ya error
            return View();
        }


        //[HttpPost]
        //public async IActionResult Register(User user)
        //{
        //    await _myContextDb.Tbl_user.Add(user);
        //   await _myContextDb.SaveChangesAsync();
        //    return View();
        //}

        public IActionResult Login()
        {
            return View();
        }
        



    }
}
