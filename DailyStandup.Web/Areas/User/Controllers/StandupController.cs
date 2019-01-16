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
    public class StandupController : BaseController
    {
        private readonly IStandupService _standupService;
        private readonly IProjectService _projectService;
        public StandupController(IStandupService standupService, IProjectService projectService)
        {
            _standupService = standupService;
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            WorkViewModel model = new WorkViewModel()
            {
                Projects = await _projectService.GetAll(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                await _standupService.Create(viewModel);

                viewModel.Projects = await _projectService.GetAll();
                return View(viewModel);
            }

            viewModel.Projects = await _projectService.GetAll();
            return View(viewModel);
        }
    }
}
