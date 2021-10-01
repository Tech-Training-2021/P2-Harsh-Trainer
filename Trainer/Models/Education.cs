using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Trainer.Models
{
    public class Education
    {
        [DisplayName("Id")]
        public int EduId { get; set; }
        [DisplayName("Qualification Name")]
        [Required(ErrorMessage = "This Field Is Required")]
        public string QualificationName { get; set; }
        [DisplayName("Year Of Passing")]
        [Required(ErrorMessage = "This Field Is Required")]

        public string YearOfPassing { get; set; }
        [DisplayName("Percentage")]
        [Required(ErrorMessage = "This Field Is Required")]

        public decimal Percentage { get; set; }
        [DisplayName("User Id")]
        [Required(ErrorMessage = "This Field Is Required")]

        public int UserId { get; set; }
    }
}
