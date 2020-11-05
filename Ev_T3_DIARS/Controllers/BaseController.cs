using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ev_T3_DIARS.Models;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc;

namespace Ev_T3_DIARS.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly T3Context context;
        public BaseController(T3Context context)
        {
            this.context = context;
        }
        protected User LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = context.Users.Where(o => o.Usuario == claim.Value).FirstOrDefault();
            return user;
        }
    }
}