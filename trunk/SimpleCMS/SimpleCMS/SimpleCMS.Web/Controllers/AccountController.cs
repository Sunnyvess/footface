using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using SimpleCMS.Web.Models;
using SimpleCMS.Core.Repositories;
using SimpleCMS.Web.Models.Account;

namespace SimpleCMS.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
      

        public AccountController(IUserRepository userRepository)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException("userRepository");
            }

            this._userRepository = userRepository;

         
        }

        public ActionResult LogIn()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model, string returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    if (this._userRepository.UserExists(model.UserName, model.Password))
                    {

                        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                       

                        if (this.Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return this.Redirect(returnUrl);
                        }

                        return this.RedirectToAction("Index", "Home");
                    }

                  
                    this.ModelState.AddModelError("", "Neispravno korisničko ime ili lozinka.");
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError("", "Došlo je do nepoznate greške prilikom prijave." + ex.InnerException + "       " + ex.Message);
                }

            }


            return this.View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var user = this._userRepository.Create();
                    model.CopyValuesToCoreEntity(user);

                    this._userRepository.Add(user);

                    FormsAuthentication.SetAuthCookie(model.UserName, false);

                    return this.RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError("", "Došlo je do nepoznate greške prilikom registracije. \n\r" + ex.InnerException + "\n\r" + ex.Message + "\n\r" + ex.StackTrace);
                }
            }

            return this.View(model);
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var user = this._userRepository.FindByUserName(this.User.Identity.Name);

                    bool changePasswordSucceeded = this._userRepository.ChangePassword(user.Id, model.OldPassword, model.NewPassword);

                    if (changePasswordSucceeded)
                    {
                        return this.View("ChangePasswordSuccess");
                    }

                    this.ModelState.AddModelError("OldPassword", "Trenutna lozinka nije ispravna.");
                }
                catch (Exception)
                {
                    this.ModelState.AddModelError("", "Došlo je do nepoznate greške prilikom promjene lozinke.");
                }
            }

            return this.View(model);
        }
    }
}
