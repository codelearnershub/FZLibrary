using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using LibaryManagementSystem2.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LibaryManagementSystem.Interfaces;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models.ViewModels;

namespace LibaryManagementsyste.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleService _roleService;

        public AuthController(IUserService userService, IUserRoleService userRoleService, IRoleService roleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _roleService = roleService;
        }

        public IActionResult Index()
        {

            return View();
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {

            User user = new User
            {
                Email = vm.Email,
                Password = vm.Password,
            };

            User users = _userService.LoginUser(user);

            if (user == null)
            {
                ViewBag.Message = "Not Found";
                return View();
            }

            var role = _userRoleService.FindRole(user.Id);
            if (role == "Super Admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "Super Admin")

                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var props = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
            }
            else if (role == "Librarian")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "Librarian")


                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var props = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
            }
            else if (role == "Store Manager")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "Store Manager")


                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var props = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
            }


            if (role == "Super Admin")
            {
                return RedirectToAction("ListUser", "SuperAdmin");
            }
            else if (role == "Librarian")
            {
                return RedirectToAction("Index", "Flock");
            }
            else {
                return NotFound();
            }


        }

        public async Task<IActionResult> Logout()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User userlogin = _userService.FindById(userId);
            ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}

// {
//     public class AuthController : Controller
//     {

//         public IUserService _userService;
//         public IUserRepository _userRepository;

//         public AuthController(IUserService userService, IUserRepository userRepository)
//         {
//             _userService = userService;
//             _userRepository = userRepository;
//         }

//         public IActionResult Index()
//         {
            
//             return View();
//         }

//         [HttpGet]
//         public IActionResult Register()
//         {
//             return View();
//         }

//         [HttpPost]
//         public IActionResult Register(User vm)
//         {
       
//             _userService.RegisterUser(vm.Email, vm.FirstName, vm.LastName, vm.Gender, vm.Password, vm.ConfirmPassword);
//             return View();
//         }

//         [HttpGet]
//         public IActionResult Login()
//         {
            
//             return View();
//         }

//         [HttpPost]
//         public async Task<IActionResult> Login(User vm)
//         {
//             // var RoleId = User.RoleId;

//             User user = _userService.Login(vm.Email, vm.Password);

//             if (user == null) return View();

           
//                 var claims = new List<Claim>
//                 {
//                     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
//                     new Claim(ClaimTypes.Email, user.Email)
//                 };

//                 var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

//                 var principal = new ClaimsPrincipal(identity);

//                 var props = new AuthenticationProperties();

//                 await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);


//                 if(user.RoleId == 1)
//                 {
//                     return RedirectToAction("Index", "AdminDashBoard");
//                 }
//                 else
//                 {
//                     return RedirectToAction("Index", "AdminDashBoard");
//                 }

                


             
            
           
//         }

//         public async Task<IActionResult> Logout()
//         {
//             await HttpContext.SignOutAsync();
//             return RedirectToAction("Login");
//         }



//     }
// }
