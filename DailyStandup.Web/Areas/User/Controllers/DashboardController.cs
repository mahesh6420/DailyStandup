using DailyStandup.Infrastructure.ApplicationController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class DashboardController : BaseController
    {
        public DashboardController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
