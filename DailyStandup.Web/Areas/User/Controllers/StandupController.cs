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

        public IActionResult Create()
        {
            StandupMasterViewModel model = new StandupMasterViewModel()
            {
                    Projects = _projectService.GetAll().ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(StandupDetailViewModel viewModel)
        {

            if(ModelState.IsValid)
            {
                StandupMasterViewModel model = new StandupMasterViewModel()
                {
                    StandupDetailViewModel = viewModel,
                    Projects = _projectService.GetAll().ToList()
                };

                return View(model);
            }

            return View();
        }
    }
}
