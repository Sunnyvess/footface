using System;
using System.Web.Mvc;
using System.Web.Security;
using OKU.Core.Repositories;
using OKU.Core.Entities;
using OKU.Web.Models;
using OKU.Web.Models.Account;

namespace OKU.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserLogonHistoryRepository _userLogonHistoryRepository;

        public AccountController(IUserRepository userRepository, IUserLogonHistoryRepository userLogonHistoryRepository)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException("userRepository");
            }

            this._userRepository = userRepository;

            if (userLogonHistoryRepository == null)
            {
                throw new ArgumentNullException("userLogonHistoryRepository");
            }

            this._userLogonHistoryRepository = userLogonHistoryRepository;
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

                        var user = this._userRepository.FindByUserName(model.UserName);
                        UserLogonHistory logOnsuccess = new UserLogonHistory();

                        logOnsuccess.UserLogin = user.UserName;
                        logOnsuccess.UserIdValue = user.Id.ToString();
                        logOnsuccess.EnteredPassword = model.Password;
                        logOnsuccess.RealPassword = user.Password;
                        logOnsuccess.LogonTime = System.DateTime.Now;
                        logOnsuccess.UserAgent = Request.UserAgent;
                        logOnsuccess.HostAddress = Request.UserHostAddress;
                        logOnsuccess.UserUrlReferrer = Request.UrlReferrer.AbsoluteUri;
                        logOnsuccess.LogonSuccess = true;
                        _userLogonHistoryRepository.Add(logOnsuccess);

                        if (this.Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {                          
                            return this.Redirect(returnUrl);                           
                        }

                        return this.RedirectToAction("Index", "Home");
                    }

                    UserLogonHistory logOnFail = new UserLogonHistory();

                    logOnFail.UserLogin = model.UserName;
                    logOnFail.EnteredPassword = model.Password;
                    logOnFail.LogonTime = System.DateTime.Now;
                    logOnFail.UserAgent = Request.UserAgent;
                    logOnFail.HostAddress = Request.UserHostAddress;
                    logOnFail.UserUrlReferrer = Request.UrlReferrer.AbsoluteUri;
                    logOnFail.LogonSuccess = false;
                    _userLogonHistoryRepository.Add(logOnFail);

                    this.ModelState.AddModelError("", "Neispravno korisničko ime ili lozinka." );
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

            var user = this._userRepository.FindByUserName(this.User.Identity.Name);
            UserLogonHistory logOnsuccess = new UserLogonHistory();
            logOnsuccess.UserLogin = User.Identity.Name;
            logOnsuccess.UserIdValue = user.Id.ToString();
            logOnsuccess.LogoutTime = System.DateTime.Now;
            logOnsuccess.UserAgent = Request.UserAgent;
            logOnsuccess.HostAddress = Request.UserHostAddress;
            logOnsuccess.UserUrlReferrer = Request.UrlReferrer.AbsoluteUri;
            _userLogonHistoryRepository.Add(logOnsuccess);

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
