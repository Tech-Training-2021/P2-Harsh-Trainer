using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainer.Mapper
{
    public class SkillsMapper
    {
        public static Data.Entities.Experiecnce Map(Trainer.Models.Experience exp, int id)
        {
            return new Data.Entities.Experiecnce()
            {
                CompanyName = exp.CompanyName,
                StartDate = exp.StartDate,
                EndDate = exp.EndDate,
                Skill = exp.Skill,
                UserId = id
            };
        }
        public static Trainer.Models.Experience Map(Data.Entities.Experiecnce exp)
        {
            return new Trainer.Models.Experience()
            {
                ExpId= exp.ExpId,
                CompanyName = exp.CompanyName,
                StartDate = exp.StartDate,
                EndDate = exp.EndDate,
                Skill = exp.Skill,
            };
        }
    }
}
