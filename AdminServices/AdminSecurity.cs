using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserDataAccess;

namespace WebAPIDemo
{
    public class AdminSecurity
    {
        public static bool Login(string username, string mdp)
        {
            using (USERSDBEntities entities = new USERSDBEntities())
            {
                return entities.Admins.Any(Admin => Admin.A_LOGIN.Equals(
                        username, StringComparison.OrdinalIgnoreCase) && Admin.A_MDP == mdp);
            }
        }
    }
}