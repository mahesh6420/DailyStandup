using DailyStandup.Entities.Models.Standup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Entities.ViewModels.Standup
{
    public class ObstacleViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Work Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Related Yesterda's work is required")]
        public Guid WorkId { get; set; }

        [ForeignKey("WorkId")]
        public Work Work { get; set; }

        public IEnumerable<WorkViewModel> Works { get; set; }
    }
}
