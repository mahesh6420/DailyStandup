using DailyStandup.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Entities.Models
{
    public class DataResult
    {
        public Status Status{ get; set; }
        public string Message { get; set; }
        public string ReturnId { get; set; }
        public string ReturnUrl { get; set; }
    }
}
