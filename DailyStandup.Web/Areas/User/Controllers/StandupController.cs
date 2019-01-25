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
    public class StandupController : BaseController
    {
        private readonly IWorkService _workService;
        private readonly IObstacleService _obstacleService;
        private readonly IProjectService _projectService;
        public StandupController(
            IWorkService workService,
            IProjectService projectService,
            IObstacleService obstacleService
            )
        {
            _workService = workService;
            _obstacleService = obstacleService;
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                await _workService.Create(viewModel);

                return View(viewModel);
            }
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddObstacle(ObstacleViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _obstacleService.Create(viewModel);

                return Json(result);
            }

            return Json(new DataResult
            {
                Status = Status.Failed,
                Message = $"{ModelState.Values.SelectMany(m => m.Errors).Select(m=>m.ErrorMessage)}"
            });
        }

        public async Task<IActionResult> UpdateObstacle(ObstacleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _obstacleService.Update(viewModel);

                return Json(result);
            }

            return Json(new DataResult
            {
                Status = Status.Failed,
                Message = $"{ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage)}"
            });
        }
    }
}
