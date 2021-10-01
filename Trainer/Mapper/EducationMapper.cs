using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainer.Mapper
{
    public class EducationMapper
    {
        public static Data.Entities.Education Map(Trainer.Models.Education edu, int id)
        {
            return new Data.Entities.Education()
            {
                UserId = id,
                Percentage = edu.Percentage,
                QualificationName = edu.QualificationName,
                YearOfPassing = edu.YearOfPassing,
            };
        }
        public static Trainer.Models.Education Map(Data.Entities.Education edu)
        {
            return new Trainer.Models.Education()
            {
                EduId = edu.EduId,
                UserId = edu.UserId,
                Percentage = edu.Percentage,
                QualificationName = edu.QualificationName,
                YearOfPassing = edu.YearOfPassing,
            };
        }
    }
}
