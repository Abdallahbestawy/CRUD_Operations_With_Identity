using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Pkcs;
using tran1.ViewModel;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace tran1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signManager;

        public AccountController(UserManager<IdentityUser> _userManager,SignInManager<IdentityUser> _signManager)
        {
            userManager = _userManager;
            signManager = _signManager;
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationAccountViewModel newAccount)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.UserName=newAccount.UserName;
                user.Email=newAccount.Email;
                IdentityResult result= await userManager.CreateAsync(user,newAccount.Password);  
                if (result.Succeeded)
                {
                    // create cookie
                    await signManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Department");
                }
                foreach(var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(newAccount);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoignViewModel loignUser)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loignUser.UserName);
                if(user != null)
                {
                    SignInResult result =await signManager.PasswordSignInAsync(user, loignUser.Password,false,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Department");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Incorrect UserName &Password");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Incorrect UserName &Password");
                }

            }
            return View(loignUser);

        }
        public async Task<IActionResult> Logout()
        {
           await signManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        /////////////////////////////////////////////////////
        /// AddAdmin ///////////////////////////////////////
        public IActionResult AddAdmin()
        {
            return View("Registration");
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegistrationAccountViewModel newAccount)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = newAccount.UserName;
                user.Email = newAccount.Email;
                IdentityResult result = await userManager.CreateAsync(user, newAccount.Password);
                if (result.Succeeded)
                {
                    // AddRole
                    userManager.AddToRoleAsync(user, "Admin");
                    // create cookie
                    await signManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Department");
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(newAccount);
        }
    }
}
