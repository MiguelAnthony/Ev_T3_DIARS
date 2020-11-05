using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Ev_T3_DIARS.Controllers;
using Ev_T3_DIARS.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace T3_N00035616.Controllers
{
    public class AuthController : BaseController
    {
        private readonly T3Context context;
        private readonly IConfiguration configuration;
        public IHostEnvironment hostEnv;

        public AuthController(T3Context context, IHostEnvironment hostEnv, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.configuration = configuration;
            this.hostEnv = hostEnv;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = context.Users
                .Where(o => o.Usuario == username && o.Contrasenia == CreateHash(password))
                .FirstOrDefault();
            //validar si el usuario existe, y si el password es correcto
            if (user != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Login", "Usuario o contraseña incorrectos.");
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return View("Login");
        }
        private string CreateHash(string input)
        {
            var sha = SHA256.Create();
            input += configuration.GetValue<string>("Token");
            var hash = sha.ComputeHash(Encoding.Default.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        } /* ...::: CAMBIE DESDE ACA PARA ABAJO :::... */
        [HttpPost]
        public ActionResult Registrar(User user, string contrasenia, string passwordConf)
        {
            if (contrasenia != passwordConf) // <-- para convalidar contraseña y confirmacion de contraseña
                ModelState.AddModelError("PasswordConf", "Las contraseñas no coinciden");

            if (ModelState.IsValid)
            {
                user.Contrasenia = CreateHash(contrasenia);
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View("Registrar", user);
        }
    }
}