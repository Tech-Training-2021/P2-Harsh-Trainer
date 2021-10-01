using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainer.Models
{
    public class Experience
    {
        public int ExpId { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public string Skill { get; set; }
    }
}
