using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserDataAccess;

namespace WebAPIDemo
{
    public class UserSecurity
    {
        public static bool Login(string username, string mdp)
        {
            using (USERSDBEntities entities = new USERSDBEntities())
            {
                return entities.Users.Any(User => User.EMAIL.Equals(
                    username, StringComparison.OrdinalIgnoreCase) && User.MDP == mdp);
            }
        }
    }
}