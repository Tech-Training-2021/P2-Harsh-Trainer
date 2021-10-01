using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
namespace Data.Repository
{
    public interface ITrainer
    {
        IEnumerable<User> getAllUser();
        int addUser(User user);
        void editUser(int id, User user);
        User getUserById(int id);

    }
}
