using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Quananvat.DTO;

namespace Quananvat.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { AccountDAO.instance = value; }
        }
        private AccountDAO() { }
        public bool Login (string username, string password)
        {
            string query = "usp_login @username , @password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {username, password });
            return result.Rows.Count > 0;
        }

        public bool updateaccount(string username, string displayname, string password, string newpass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec usp_updateaccount @username , @displayname , @password , @newpassword", new object[] {username, displayname, password, newpass });

            return result > 0;
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("select username, displayname, type from dbo.account");
        }

        public Account GetAccountByUserName(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from account where username ='" + username + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }

        public bool InsertAccount(string name, string displayName, int type)
        {
            string query = string.Format("insert dbo.account(username, displayname, type) values (N'{0}',N'{1}',{2})", name, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateAccount(string username, string displayname, int type)
        {
            string query = string.Format("update dbo.account set displayname = N'{1}', type = {2} where username = N'{0}'", username, displayname, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAccount(string username)
        {
            string query = string.Format("delete account where username = N'{0}'", username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool ResetPassword(string username)
        {
            string query = string.Format("update account set password = N'0' where username = N'{0}'", username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
