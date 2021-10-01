using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainer.Mapper
{
    public class RoleMapper
    {
        public static Trainer.Models.Role Map(Data.Entities.Role role)
        {
            return new Trainer.Models.Role()
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName
            };
        }
    }
}
