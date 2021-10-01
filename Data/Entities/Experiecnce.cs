using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Entities
{
    public partial class Experiecnce
    {
        public int ExpId { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public string Skill { get; set; }

        public virtual User User { get; set; }
    }
}
