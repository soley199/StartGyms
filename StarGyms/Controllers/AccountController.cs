using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StarGyms.Models;
using System.Web.Security;

namespace StarGyms.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountModel m)
        {
            string msg = string.Empty;
            string returnUrl = string.Empty;
            bool SiEntra = false;
            if (Request.UrlReferrer != null)
            {
                var q = HttpUtility.ParseQueryString(Request.UrlReferrer.Query);
                returnUrl = q["ReturnUrl"];
            }
            //string ip = (string.IsNullOrEmpty(Request.ServerVariables["HTTP_X_FORWARDED_FOR"]) ? Request.ServerVariables["REMOTE_ADDR"] : Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(',')[0]);
            //if (string.IsNullOrEmpty(ip.Replace("::1", "")))
            //{
            //    ip = "127.0.0.1";
            //}
            if (ModelState.IsValid)
            {
                byte TimeOut = 30;
                if (m.GetAccount())
                {
                    Session["IdUsuario"] = m.Usuario.IdUsuario;
                    Session["NombreCompleto"] = m.Usuario.NombreCompleto;
                    Session["UserName"] = m.Usuario.IdUsuario;
                    Session.Timeout = TimeOut; // Tiempo en que se permite estar dentro de la sesion
                    FormsAuthentication.Initialize();
                    FormsAuthentication.SetAuthCookie(m.UserName, true);
                    var authTicket = new FormsAuthenticationTicket(
                        1, // Versión
                        m.UserName, // Nombre de Usuario
                        DateTime.Now, // Fecha de Creación
                        DateTime.Now.AddMinutes(TimeOut), // Fecha que Expira
                        false, // Persistente
                        "",
                        FormsAuthentication.FormsCookiePath);
                    var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(authCookie);
                    SiEntra = true;
                }
                else
                {
                    msg = "Usuario o Contraseña Incorrecta.";
                }
            }

            ModelState.Clear();
            if (SiEntra)
            {
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("Mensaje", msg);
            }
            return View(m);
        }

        [Authorize]
        public ActionResult Salir()
        {
            //Request.Cookies.Clear();
            //Response.Cookies.Clear();
            //Session.Abandon();
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}