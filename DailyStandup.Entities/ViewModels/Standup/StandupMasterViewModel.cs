using DailyStandup.Entities.Models.Standup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Entities.ViewModels.Standup
{
    public class StandupMasterViewModel
    {
        public Guid Id { get; set; }

        public DateTime WorkDate { get; set; }
        //public Guid WorkTodayId { get; set; }
        //public Guid WorkYesterdayId { get; set; }
        //public Guid ObstacleId { get; set; }

        //public string WorkTodayDescription { get; set; }
        //public string WorkYesterdayDescription { get; set; }
        //public string ObstacleDescription { get; set; }

        public StandupDetailViewModel StandupDetailViewModel { get; set; }

        public IList<Project> Projects { get; set; }
    }
}
