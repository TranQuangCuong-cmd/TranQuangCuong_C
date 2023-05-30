using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021027.DataLayers;
using _19T1021027.DomainModels;

namespace _19T1021027.BusinessLayers
{
    /// <summary>
    /// các chức năng liên quan đến tài khoản
    /// </summary>
    public static class UserAccountService
    {
        private static IUserAccountDAL employeeAccountDB;
        private static IUserAccountDAL customerAccountDB;
        /// <summary>
        /// 
        /// </summary>
        static UserAccountService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            employeeAccountDB = new DataLayers.SQL_Server.EmployeeAccountDAL(connectionString);
            customerAccountDB = new DataLayers.SQL_Server.CustomerAccountDAL(connectionString);
        }

        public static UserAccount Authorize (AccountTypes accountTypes, string userName, string password)
        {
            if (accountTypes == AccountTypes.Employ)
                return employeeAccountDB.Authorize(userName, password);
            else
            {
                return customerAccountDB.Authorize(userName, password);
            }
        }
        public static bool ChangePassword(AccountTypes accountTypes, string userName, string oldPassword, string newPassword)
        {
            if (accountTypes == AccountTypes.Employ)
                return employeeAccountDB.ChangePassword(userName, oldPassword, newPassword);
            else
                return customerAccountDB.ChangePassword(userName, oldPassword, newPassword);
        }
    }
}