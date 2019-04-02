using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net.Mail;

namespace RestaurantApp
{
    class OauthController
    {

        static restDataSetTableAdapters.usersTableAdapter usersTableAdapter = new restDataSetTableAdapters.usersTableAdapter();
        static restDataSetTableAdapters.TableAdapterManager TableAdapter = new restDataSetTableAdapters.TableAdapterManager();
        static restDataSet ds = new restDataSet();

        public static string getHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        public static bool ConfirmRegistration(string login, string password, string email)
        {
            string salt = "";
            bool success = false;
            if ((usersTableAdapter.GetData().FindByuser_id(login) == null) && (!EmailExists(email)))
            {
                usersTableAdapter.Insert(login, getHashSha256(salt + password), email);
                TableAdapter.UpdateAll(ds);
                success = true;
            }
            try
            {
                MailAddress m = new MailAddress(email);
            }
            catch (FormatException)
            {
                success = false;
            }
            return success;
        }
        
        public static bool CheckAutorization(string login, string password)
        {
            bool success = false;
            if (usersTableAdapter.GetData().FindByuser_id(login) != null)
            {
                if (usersTableAdapter.GetData().FindByuser_id(login).hash == getHashSha256(password))
                    success = true;
            }
            return success;
        }

        public static bool EmailExists(string email)
        {
            bool result = false;
            foreach (restDataSet.usersRow r in usersTableAdapter.GetData().Rows)
            {
                if (r.email == email)
                    result = true;
            }
            return result;
        }
    }
}
