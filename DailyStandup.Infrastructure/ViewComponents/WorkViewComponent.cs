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
    public class WorkListTodayViewComponent : ViewComponent
    {
        private readonly IWorkService _workService;
        private readonly IProjectService _projectService;

        public WorkListTodayViewComponent(IWorkService workService, IProjectService projectService)
        {
            _workService = workService;
            _projectService = projectService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string viewName = null)
        {
            if (viewName.ToLowerInvariant() == ViewName.Form.ToString().ToLowerInvariant())
            {
                return View("WorkForm", new WorkViewModel {
                    Projects = await _projectService.GetAll()
                });
            }

            if (viewName.ToLowerInvariant() == ViewName.List.ToString().ToLowerInvariant())
            {
                return View("WorkList", await _workService.GetAll());
            }

            if (viewName.ToLowerInvariant() == ViewName.Today.ToString().ToLowerInvariant())
            {
                return View("WorkList", await _workService.GetAll("today"));
            }

            if (viewName.ToLowerInvariant() == ViewName.Yesterday.ToString().ToLowerInvariant())
            {
                return View("WorkList", await _workService.GetAll("yesterday"));
            }

            if (viewName.ToLowerInvariant() == ViewName.Old.ToString().ToLowerInvariant())
            {
                return View("WorkList", await _workService.GetAll("old"));
            }

            return View(await _workService.GetAll());
        }
    }
}
