using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Entities.Models.Standup
{
    public class WorkYesterday : BaseModel
    {
        public string WorkOfYesterday { get; set; }
        public Guid ProjectId { get; set; }
        public Guid StandupId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [ForeignKey("StandupId")]
        public Standup Standup { get; set; }

        public Obstacle Obstacles { get; set; }
    }
}
