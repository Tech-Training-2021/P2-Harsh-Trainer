using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class Trainer : ITrainer
    {
        private TrainerContext db;
        public Trainer(TrainerContext db)
        {
            this.db = db;
        }
        public IEnumerable<User> getAllUser()
        {
            return db.Users
                    .Include("Roles")
                    .ToList();
        }
        public int addUser(User user)
        {
            var userid = db.Users.Add(user);

            Save();
            return userid.Entity.UserId;
        }
        public Data.Entities.User userLogin(string email, string password)
        {
            var finduser = db.Users
                    .Include(g => g.Role)
                    .Where(c => c.Email == email && c.Password == password)
                    .FirstOrDefault();
            /* var finduser = (from userdata in db.Users
                             where ((userdata.Email == user.Email) && (userdata.Password == user.Password))
                             select userdata).FirstOrDefault();*/
            if (finduser == null)
            {
                return null;
            }
            else
            {
                return finduser;
            }
        }
        public void editUser(int id, User user)
        {
            User userData = (from u in db.Users
                             where u.UserId == id
                             select u).FirstOrDefault();
            if (userData != null)
            {
                userData.Name = user.Name;
                userData.Email = user.Email;
                userData.MobileNumber = user.MobileNumber;
                /* db.Users.Update(user);*/
                Save();
            }
            else
            {
                throw new ArgumentException("User Not Found  By id =" + id);
            }
        }
        public IEnumerable<Role> getRoles()
        {
            return db.Roles.ToList();
        }
        public User getUserById(int id)
        {
            return db.Users.Include("Role").Where(c => c.UserId == id).FirstOrDefault();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
