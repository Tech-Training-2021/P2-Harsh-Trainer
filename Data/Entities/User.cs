using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Entities
{
    public partial class User
    {
        public User()
        {
            Educations = new HashSet<Education>();
            Experiecnces = new HashSet<Experiecnce>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Experiecnce> Experiecnces { get; set; }
    }
}
