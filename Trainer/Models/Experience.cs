using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Trainer.Models
{
    public class Experience
    {
        [DisplayName("Experience Id")]

        public int ExpId { get; set; }
        [DisplayName("Company Name")]
        [Required(ErrorMessage = "This Field Is Required")]
        public string CompanyName { get; set; }
        [DisplayName("Start Date")]
        [Required(ErrorMessage = "This Field Is Required")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        [Required(ErrorMessage = "This Field Is Required")]
        public DateTime EndDate { get; set; }
        [DisplayName("User Id")]
        [Required(ErrorMessage = "This Field Is Required")]
        public int UserId { get; set; }
        [DisplayName("Skill Name")]
        [Required(ErrorMessage = "This Field Is Required")]
        public string Skill { get; set; }
    }
}
