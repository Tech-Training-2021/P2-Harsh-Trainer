using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
namespace Data.Repository
{
    public interface IExperience
    {
        IEnumerable<Education> getAllEducation();
        void addEducation(Education edu);
        void editEducation(int id, Education edu);
        IEnumerable<Education> getEducationByUserId(int id);
        /* Education getEducationById(int id);*/
    }
}
