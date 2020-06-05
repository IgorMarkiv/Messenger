using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HELIX.LoginDLL;
using HELIX.ExceptionDLL;

namespace Helix.DBHelper
{
    public static class RegistrationManager
    {

        private static DB _DB;

        public static void Init(DB dB)
        {
            _DB = dB;
        }

        public static void RegisterWithRole(string login, string inputFirstname, string InputLastname, string password, string email, bool role)
        {
            string salt = Util.GenerateSalt();
            string encPassword = Util.EncodePassword(password, salt);
            if (_DB.CheckIfRegistrationNotRepeated(login, email))
            {
                if (!_DB.CreateUser(login, inputFirstname, InputLastname,  encPassword, email, salt, role))
                    throw new HelixException(HelixExceptionCode.E04);
            }
            else
                throw new HelixException(HelixExceptionCode.E08);
        }

        public static bool IsFirstRegistrationNeeded()
        {
            return _DB.CheckIfGlobalAdminExists();
        }
    }
}
