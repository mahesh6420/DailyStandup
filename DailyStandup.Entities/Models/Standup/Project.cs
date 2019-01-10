using DailyStandup.Entities.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Entities.Models.Standup
{
    public class Project : BaseModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public bool IsArchieved { get; set; }
        //public Guid ProjectUserId { get; set; }

        //[ForeignKey("ProjectUserId")]
        //public ProjectUser ProjectUsers { get; set; }
    }
}
