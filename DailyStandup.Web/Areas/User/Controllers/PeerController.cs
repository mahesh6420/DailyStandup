using DailyStandup.Entities.Models.User;
using DailyStandup.Infrastructure.ApplicationController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Web.Areas.User.Controllers
{
    [Area("user")]
    [Authorize]
    public class PeerController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public PeerController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.OrderBy(m=>m.FirstName).ToListAsync());
        }
    }
}
