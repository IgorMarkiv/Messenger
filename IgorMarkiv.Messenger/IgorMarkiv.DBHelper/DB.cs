using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DBHelper.Model;
using System.Data.Entity;

namespace DBHelper
{
    public class DB
    {
        public bool VerifyUser(string username, string password)
        {
            using (var context = new IgorMarkivMessengerDBEntities())
            {
                Users user = context.Users.Where(u => u.user == username && u.password == password).FirstOrDefault();
                if (user != null) { return true; }
                else { return false; }
            }
        }

    }
}

        