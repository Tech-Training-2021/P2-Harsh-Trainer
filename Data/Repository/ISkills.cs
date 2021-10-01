using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data.Repository
{
    public interface ISkills
    {
        IEnumerable<Data.Entities.Experiecnce> getAllSkills();
        void addSkill(Data.Entities.Experiecnce exp);
        void editSkill(int id, Data.Entities.Experiecnce exp);
        IEnumerable<Data.Entities.Experiecnce> getExperienceByUserId(int id);
    }
}
