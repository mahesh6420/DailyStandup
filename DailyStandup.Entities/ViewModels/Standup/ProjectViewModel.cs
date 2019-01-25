using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Entities.ViewModels.Standup
{
    public class ProjectViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Short Descpription")]
        [MaxLength(50, ErrorMessage = "Please write {0} with max length {1}")]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Long Descpription")]
        public string LongDescription { get; set; }
    }
}
