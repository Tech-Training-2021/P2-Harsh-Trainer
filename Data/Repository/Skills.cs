using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
namespace Data.Repository
{
    public class Skills : ISkills
    {
        private TrainerContext db;
        public Skills(TrainerContext db)
        {
            this.db = db;
        }
        public IEnumerable<Data.Entities.Experiecnce> getAllSkills()
        {
            return db.Experiecnces
                    .ToList();
        }

        public void addSkill(Data.Entities.Experiecnce exp)
        {
            db.Experiecnces.Add(exp);
            Save();

        }
        public void editSkill(int id, Data.Entities.Experiecnce exp)
        {
            Data.Entities.Experiecnce expData = (from u in db.Experiecnces
                                                 where u.ExpId == id
                                                 select u).FirstOrDefault();
            if (expData != null)
            {
                expData.CompanyName = exp.CompanyName;
                expData.StartDate = exp.StartDate;
                expData.EndDate = exp.EndDate;
                expData.Skill = exp.Skill;
                Save();
            }
            else
            {
                throw new ArgumentException("Experience Not Found  By id =" + id);
            }
        }
        public IEnumerable<Data.Entities.Experiecnce> getExperienceByUserId(int id)
        {
            return db.Experiecnces.Where(c => c.UserId == id).ToList();
        }
        public Data.Entities.Experiecnce getExperienceById(int id)
        {
            return db.Experiecnces.Where(c => c.ExpId == id).FirstOrDefault();
        }
        public void deleteExp(int id)
        {
            var data = db.Experiecnces.Where(c => c.ExpId == id).FirstOrDefault();
            db.Experiecnces.Remove(data);
            Save();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
