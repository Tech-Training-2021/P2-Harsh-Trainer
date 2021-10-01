using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
namespace Data.Repository
{
    public class Experience : IExperience
    {
        private TrainerContext db;
        public Experience(TrainerContext db)
        {
            this.db = db;
        }
        public IEnumerable<Education> getAllEducation()
        {
            return db.Educations
                    .ToList();
        }
        public void addEducation(Education edu)
        {
            db.Educations.Add(edu);
            Save();

        }
        public void editEducation(int id, Education edu)
        {
            Education eduData = (from u in db.Educations
                                 where u.EduId == id
                                 select u).FirstOrDefault();
            if (eduData != null)
            {
                eduData.Percentage = edu.Percentage;
                eduData.QualificationName = edu.QualificationName;
                eduData.YearOfPassing = edu.YearOfPassing;
                Save();
            }
            else
            {
                throw new ArgumentException("Education Not Found  By id =" + id);
            }
        }
        public IEnumerable<Education> getEducationByUserId(int id)
        {
            return db.Educations.Where(c => c.UserId == id).ToList();
        }
        public Education getEducationByEduId(int id)
        {
            return db.Educations.Where(c => c.EduId == id).FirstOrDefault();
        }
        public void deleteEducationData(int id)
        {
            var data = db.Educations.Where(c => c.EduId == id).FirstOrDefault();
            db.Educations.Remove(data);
            Save();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
