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
                return entities.Doctors.Any(Doctor => Doctor.EMAIL.Equals(
                    username, StringComparison.OrdinalIgnoreCase) && Doctor.MDP == mdp);
            }
        }
    }
}