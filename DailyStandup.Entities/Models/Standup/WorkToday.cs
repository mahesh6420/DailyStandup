﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Entities.Models.Standup
{
    public class WorkToday : BaseModel
    {
        public string WorkOfToday { get; set; }
        public Guid ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Projects { get; set; }
    }
}