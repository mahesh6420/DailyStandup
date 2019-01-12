using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Entities.Models.Standup
{
    public class Obstacle : BaseModel
    {
        public string Description { get; set; }
        public bool IsSolved { get; set; }
        public Guid ProjectId { get; set; }
        public Guid WorkYesterdayId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Projects { get; set; }

        [ForeignKey("WorkYesterdayId")]
        public WorkYesterday WorkYesterday { get; set; }
    }
}
