using DailyStandup.Common.Enums;
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
        private readonly IStandupService _standupService;

        public WorkListTodayViewComponent(IStandupService standupService)
        {
            _standupService = standupService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string day)
        {
                return View(await _standupService.GetAllByDate(DateTime.Today));
        }
    }
}
