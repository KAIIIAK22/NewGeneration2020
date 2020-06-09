using html.Interfaces;
using html.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces;
using System.Threading.Tasks;
using BLL.Contracts;
using System.Windows;

namespace html.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IUsersService usersService, IAuthenticationService authenticationService)
        {
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }




        // GET: Account/Login
        public ActionResult Login()
        {
            Console.WriteLine("ModelState.IsValid " + ModelState.IsValid);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            
            if (ModelState.IsValid)
            {

                var isUserExist = (await _usersService.IsUserExistByEmailAsync(new UserDto
                {
                    UserEmail = model.EmailOrLogin,
                    UserPassword = model.Password
                })|| await _usersService.IsUserExistByNameAsync(new UserDto
                {
                    UserNick = model.EmailOrLogin,
                    UserPassword = model.Password
                }));
              
                
                if (isUserExist)
                {
                    bool canAuthorize;
                    if (model.EmailOrLogin.Contains('@'))
                    {
                         canAuthorize = await _usersService.IsUserExistAsync(new UserDto
                        {
                            UserEmail = model.EmailOrLogin,
                            UserPassword = model.Password
                        });
                       
                    }
                    else
                    {
                         canAuthorize = await _usersService.IsUserExistAsync(new UserDto
                        {
                            UserNick = model.EmailOrLogin,
                            UserPassword = model.Password
                        });
                        
                    }
                    
                    var ipAddress = HttpContext.Request.UserHostAddress;
                    AttemptDTO attemptDto = new AttemptDTO
                    {
                        NickOrEmail = model.EmailOrLogin,
                        IpAddress = ipAddress,
                        IsSuccess = canAuthorize
                    };

                    await _usersService.AddAttemptAsync(new AttemptDTO
                    {
                        NickOrEmail = model.EmailOrLogin,
                        IpAddress = ipAddress,
                        IsSuccess = canAuthorize
                    });

                    

                    if (canAuthorize)
                    {

                        var userDto = await _usersService.FindUserAsync(new UserDto
                        {
                            //в этой проверке UserEmail = nickOrEmail
                            UserEmail = model.EmailOrLogin,
                            UserPassword = model.Password
                        });


                        FormsAuthentication.SetAuthCookie(model.EmailOrLogin, true);
                        var claim = _authenticationService.ClaimTypesСreation(userDto);
                        _authenticationService.OwinCookieAuthentication(HttpContext.GetOwinContext(), claim);

                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", "User is not found");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User not found");
                }
            }

            return View(model);
        }











        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {

                var IfUserExist = (await _usersService.IsUserExistByEmailAsync(new UserDto
                {
                    UserEmail = model.Email,
                    UserPassword = model.Password
                }) || await _usersService.IsUserExistByNameAsync(new UserDto
                {
                    UserNick = model.Nick,
                    UserPassword = model.Password
                }));
                var ipAddress = HttpContext.Request.UserHostAddress;



                if (IfUserExist == false)
                {
                    //Create a new user




                    await _usersService.AddUserAsync(new UserDto
                    {
                        UserNick = model.Nick,
                        UserEmail = model.Email,
                        UserPassword = model.Password
                    });

                    await _usersService.AddAttemptAsync(new AttemptDTO
                    {
                        NickOrEmail = model.Email,
                        IpAddress = ipAddress,
                        IsSuccess = true
                    });
                    await _usersService.AddAttemptAsync(new AttemptDTO
                    {
                        NickOrEmail = model.Nick,
                        IpAddress = ipAddress,
                        IsSuccess = true
                    });

                    var userDto = await _usersService.FindUserAsync(new UserDto
                    {
                        UserNick = model.Nick,
                        UserEmail = model.Email,
                        UserPassword = model.Password
                    });

                    var claim = _authenticationService.ClaimTypesСreation(userDto);
                    _authenticationService.OwinCookieAuthentication(HttpContext.GetOwinContext(), claim);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "User already exists");
                }
            }

            return View(model);
        }



        
        public ActionResult LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
            HttpContext.GetOwinContext().Authentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Account", "Login");
            //FormsAuthentication.SignOut();
            //Session.Abandon();
            //return RedirectToAction("Index", "Home");
        }





    }
}