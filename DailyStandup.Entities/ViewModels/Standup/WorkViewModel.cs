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
    public class WorkViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Work Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Related Project is required")]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        public IEnumerable<ProjectViewModel> Projects { get; set; }
    }
}
