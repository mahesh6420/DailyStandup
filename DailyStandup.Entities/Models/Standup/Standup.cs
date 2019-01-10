using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Entities.Models.Standup
{
    public class Standup : BaseModel
    {
        public DateTime WorkDate { get; set; }

        public Guid WorkTodayId { get; set; }
        public Guid WorkYesterdayId { get; set; }
        public Guid ObstacleId { get; set; }

        [ForeignKey("WorkTodayId")]
        public WorkToday WorkToday { get; set; }

        [ForeignKey("WorkYesterdayId")]
        public WorkYesterday WorkYesterday { get; set; }

        [ForeignKey("ObstacleId")]
        public Obstacle Obstacle { get; set; }
    }
}
