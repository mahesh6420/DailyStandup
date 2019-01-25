using DailyStandup.Common.Enums;
using DailyStandup.Entities.ViewModels.Standup;
using DailyStandup.Infrastructure.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Infrastructure.ViewComponents
{
    public class ObstacleViewComponent : ViewComponent
    {
        private readonly IObstacleService _obstacleService;
        private readonly IWorkService _workService;

        public ObstacleViewComponent(IObstacleService obstacleService, IWorkService workService)
        {
            _obstacleService = obstacleService;
            _workService = workService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string viewName = null)
        {
            if (viewName.ToLowerInvariant() == ViewName.Form.ToString().ToLowerInvariant())
            {
                return View("ObstacleForm", new ObstacleViewModel {
                    Works = await _workService.GetAll(Day.Yesterday.ToString()
                    )});
            }

            if (viewName.ToLowerInvariant() == ViewName.List.ToString().ToLowerInvariant())
            {
                return View("ObstacleList", await _obstacleService.GetAll());
            }

            if (viewName.ToLowerInvariant() == ViewName.Today.ToString().ToLowerInvariant())
            {
                return View("ObstacleList", await _obstacleService.GetAll("today"));
            }

            if (viewName.ToLowerInvariant() == ViewName.Yesterday.ToString().ToLowerInvariant())
            {
                return View("ObstacleList", await _obstacleService.GetAll("yesterday"));
            }

            if (viewName.ToLowerInvariant() == ViewName.Old.ToString().ToLowerInvariant())
            {
                return View("ObstacleList", await _obstacleService.GetAll("old"));
            }

            return View(await _obstacleService.GetAll());
        }
    }
}
