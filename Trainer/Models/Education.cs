using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainer.Models
{
    public class Education
    {
        public int EduId { get; set; }
        public string QualificationName { get; set; }
        public string YearOfPassing { get; set; }
        public decimal Percentage { get; set; }
        public int UserId { get; set; }
    }
}
