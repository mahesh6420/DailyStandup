using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Infrastructure.ApplicationController
{
    public class BaseController : Controller
    {
        protected internal IActionResult RedirectToLogin()
        {
            return RedirectToAction("login", "Account", new { area = "User"});
        }

        protected internal IActionResult RedirectToDashboard()
        {
            return RedirectToAction("Index", "Dashboard", new { area = "User"});
        }

        protected internal IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToDashboard();
            }
        }

        public string GetAreaName()
        {
            return this.ControllerContext.RouteData.Values["area"].ToString();
        }

        public string GetControllerName()
        {
            return this.ControllerContext.RouteData.Values["controller"].ToString();
        }

        public string GetActionName()
        {
            return this.ControllerContext.RouteData.Values["action"].ToString();
        }
    }
}
