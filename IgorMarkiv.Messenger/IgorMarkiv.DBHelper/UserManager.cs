using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HELIX.LoginDLL;
using HELIX.ExceptionDLL;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.Web;
using Helix.DBHelper.Model;
using System.Text.RegularExpressions;

namespace Helix.DBHelper
{
    public static class UserManager
    {

        private static DB _DB;

        public static void Init(DB dB)
        {
            _DB = dB;
        }

        public static List<string> GetSessionList(int userid) // - Igor Markiv - i added this becouse i need list of session keys
        {
            return _DB.GetSessionsList(userid);
        }

        

        public static Users GetUserDataById(int userId)
        {
            var users = _DB.Get_user_by_id(userId);
            return users;
        }

        public static void DeleteUser(int userId, int adminId, string adminSessionKey)
        {
            if (GetLoggedInUserRole(adminId, adminSessionKey) != true)
                throw new HelixException("E13"); //User has no rights to delete
            if (userId == adminId)
                throw new HelixException(HelixExceptionCode.E00); // Tries to delete himself/herself
            if (!_DB.RemoveUser(userId))
                throw new HelixException(HelixExceptionCode.E03);
        }

        public static void UpdateUserData(int userId, string new_login, string new_firstname, string new_last_name, string newEmail, string newPassword, bool newRole)
        {
            if (!_DB.UpdateUserData(userId, new_login, new_firstname, new_last_name, newEmail, newPassword, newRole))
                throw new HelixException(HelixExceptionCode.E04);
        }

        public static bool GetLoggedInUserRole(int userId, string sessionKey)
        {
            if (!SessionManager.VerifySession(userId, sessionKey))
                throw new HelixException(HelixExceptionCode.E11);
            else
                //return _DB.GetUserRole(userId).ToLower(); 
                return _DB.GetUserRole(userId);
        }

        public static bool IsGlobalAdminRegistered()
        {
            List<Users> usersTable = _DB.GetAllUsers();

            if (usersTable.Count != 0){
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Bun_User_by_id(int user_id)
        {
            if(_DB.Ban_User_by_id(user_id) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Unban_user_by_id(int user_id)
        {
            if (_DB.Unban_user_by_id(user_id) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Check_if_user_banned_by_id(int user_id)
        {
            if(_DB.Check_if_user_banned_by_id(user_id) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static UserPrincipal GetUserPrincipal(out string user_login)
        {
            UserPrincipal principal = null;
            IIdentity identity = HttpContext.Current.User.Identity;
            user_login = identity.GetLogin();
            //username = Regex.Replace(identity.Name, "HELIX/", ""); //UTCAIN/p1234567
            if (string.IsNullOrWhiteSpace(user_login))
                throw new Exception("Could not get current principal identity name");

            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, identity.GetDomain()))
                principal = UserPrincipal.FindByIdentity(pc, user_login);

            return principal;
        }

        public static bool CheckADUser(out string username, out bool is_admin)
        {
            username = "";
            string email = "test@example.com";
            UserPrincipal up = null;
            is_admin = false;
            up = UserManager.GetUserPrincipal(out username); // username = UTCAIN/p1234567



            if (up != null)
            {
                Users user = _DB.GetUser_by_user_name(username);
                if (user != null)
                {
                    if (user.is_admin == true)
                    {
                        is_admin = true;
                    }
                    else
                    {
                        is_admin = false;
                    }
                }
                else
                {
                    Users newuser = _DB.Add_new_user_ad(username, is_admin, email);
                    if (newuser != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            else
            {
                return false;
            }
            return true;
        }

        public static string GetDomain(this IIdentity identity)
        {
            string s = identity.Name;
            int stop = s.IndexOf("\\");
            return (stop > -1) ? s.Substring(0, stop) : string.Empty;
        }

        public static string GetLogin(this IIdentity identity)
        {
            string s = identity.Name;
            int stop = s.IndexOf("\\");
            return (stop > -1) ? s.Substring(stop + 1, s.Length - stop - 1) : s;
        }


        public static string GetUserName_by_id(int user_id)
        {
            string user_name = _DB.GetUserName_by_id(user_id);
            if (user_name != null)
            {
                return user_name;
            }
            else
            {
                throw new HelixException(HelixExceptionCode.E03 + "Not find UserName in db!");
            }
        }

        public static bool? Check_user_role(int user_id)
        {
            bool? user_role = _DB.Check_user_role(user_id);
            if (user_role != null)
            {
                return user_role;
            }
            else
            {
                throw new HelixException(HelixExceptionCode.E03 + "Not find UserName in db!");
            }
        }

        public static void  Register_first_admin()
        {
            _DB.Register_first_admin();
        }

        public static bool Check_if_login_not_repeat(int user_id, string login)
        {
            if (_DB.Check_if_login_not_repeat(user_id, login) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Check_if_email_not_repeat(int user_id,  string email)
        {
            if (_DB.Check_if_email_not_repeat(user_id, email) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool is_user_ad_by_user_id(int user_id)
        {
            return _DB.is_user_ad_by_user_id(user_id);
        }

        public static bool Check_if_user_is_ad_user_by_id(int user_id)
        {
            return _DB.Check_if_user_is_ad_user_by_id(user_id);
        }

    }
}
