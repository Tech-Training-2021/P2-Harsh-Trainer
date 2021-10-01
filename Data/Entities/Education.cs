using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Entities
{
    public partial class Education
    {
        public int EduId { get; set; }
        public string QualificationName { get; set; }
        public string YearOfPassing { get; set; }
        public decimal Percentage { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
