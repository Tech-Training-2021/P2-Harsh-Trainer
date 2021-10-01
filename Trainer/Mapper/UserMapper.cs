using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trainer.Mapper
{
    public class UserMapper
    {
        public static Trainer.Models.User Map(Data.Entities.User user)
        {
            return new Trainer.Models.User()
            {
                User_Id = user.UserId,
                Name = user.Name,
                MobileNumber = user.MobileNumber,
                Email = user.Email,
                Password = user.Password,
                Role_Id = user.Role.RoleName
            };
        }
        public static Data.Entities.User Map(Trainer.Models.User user)
        {
            return new Data.Entities.User()
            {
                Name = user.Name,
                MobileNumber = user.MobileNumber,
                Email = user.Email,
            };
        }

        public static Data.Entities.User Map(Trainer.Models.UserViewModel user)
        {
            return new Data.Entities.User()
            {
                Name = user.Register.Name,
                MobileNumber = user.Register.MobileNumber,
                Email = user.Register.Email,
                Password = Trainer.EncryptionDecryption.EncryptionDecryption.EncryptString(user.Register.Password),
                RoleId = user.Register.Role,
            };
        }

        public static Data.Entities.User Map(Trainer.Models.Register user, int role)
        {
            return new Data.Entities.User()
            {
                Name = user.Name,
                MobileNumber = user.MobileNumber,
                Email = user.Email,
                Password = Trainer.EncryptionDecryption.EncryptionDecryption.EncryptString(user.Password),
                RoleId = role
            };
        }
        public static Data.Entities.User MapData(Trainer.Models.Login login)
        {
            return new Data.Entities.User()
            {
                Email = login.Email,
                Password = Trainer.EncryptionDecryption.EncryptionDecryption.EncryptString(login.Password),
            };
        }
    }
}