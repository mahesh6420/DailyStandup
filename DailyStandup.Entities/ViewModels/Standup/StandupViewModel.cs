using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Entities.ViewModels.Standup
{
    public class StandupViewModel
    {
        public WorkViewModel WorkViewModel { get; set; }
        public ObstacleViewModel ObstacleViewModel { get; set; }
    }
}
