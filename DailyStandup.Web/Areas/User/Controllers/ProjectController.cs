using DailyStandup.Common.Enums;
using DailyStandup.Entities.Models;
using DailyStandup.Entities.ViewModels.Standup;
using DailyStandup.Infrastructure.ApplicationController;
using DailyStandup.Infrastructure.Interfaces.IServices;
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
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            return View(_projectService.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectViewModel projectViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            DataResult result = await _projectService.Create(projectViewModel);

            if(result.Status == Status.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            return Json(result);
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            return View(await _projectService.GetById(id));
        }
    }
}
