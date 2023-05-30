using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021027.DomainModels;

namespace _19T1021027.DataLayers
{
    /// <summary>
    /// ĐỊnh nghĩa các phép xử lý liên quan đến dữ liệu tài khoản người dùng 
    /// </summary>
   public  interface IUserAccountDAL
    {
        /// <summary>
        /// Kiêm tra thông tin người dùng có hợp lệ hay là không 
        /// Nếu hợp lệ thì trả về thông tin của tài khoản , ngược lại trả về null
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="Photo"></param>
        /// <returns></returns>
        UserAccount Authorize(string userName, string password);
        /// <summary>
        /// đổi mật khẩu
        /// </summary>
        /// <param name="userNaem"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        bool ChangePassword(string userNaem, string oldPassword, string newPassword);
    }
}
