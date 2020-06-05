using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper
{

    public static class LoginManager
    {
        private static DB _DB;

        public static void Init(DB dB)
        {
            _DB = dB;
        }

        public static bool login(string username, string password)
        {
            if (_DB.VerifyUser(username, password) == true){return true;}
            else{return false;}

        }

    }
}
