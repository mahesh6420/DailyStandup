using DailyStandup.Entities.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Entities.Models.Standup
{
    public class UserProject : BaseModel
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("UserId")]
        public Project Project { get; set; }
    }
}
