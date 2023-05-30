using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021027.DomainModels;

namespace _19T1021027.DataLayers
{
    public interface IEmployeeDAL
    {
        /// <summary>
        /// tìm kiếm và lấy danh sách các nhân viên dưới dạng phân trang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng hiển thị trên mỗi trang (0 tức là không yêu cầu phân trang)</param>
        /// <param name="searchValue">tên cần tìm kiếm (chuỗi rỗng nếu không tìm kiếm theo tên)</param>
        /// <returns></returns>
        IList<Employee> List(int page = 1, int pageSize = 0, string searchValue = "");
        /// <summary>
        /// đếm số nhân viên tìm được
        /// </summary>
        /// <param name="searchValue">Tên cần tìm kiếm (chuỗi rỗng nếu không tìm kiếm theo tên)</param>
        /// <returns></returns>
        int Count(string searchValue = "");
        /// <summary>
        /// Bổ sung thêm một nhân viên
        /// </summary>
        /// <param name="data">Lớp chứa đối tượng bổ sung</param>
        /// <returns>ID của nhân viên được tạo mới</returns>
        int Add(Employee data);
        /// <summary>
        /// cập nhật thông tin của nhân viên
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Employee data);
        /// <summary>
        /// xóa một nhân viên dựa vào mã của nhân viên
        /// </summary>
        /// <param name="employeeID">mã của nhân viên cần xóa</param>
        /// <returns></returns>
        bool Delete(int employeeID);
        /// <summary>
        /// Lấy thông tin của 1 nhân viên dựa vào mã của nhân viên
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        Employee Get(int employeeID);
        /// <summary>
        /// Kiểm tra xem nhân viên hiện có dữ liệu liên quan hay không
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        bool InUsed(int employeeID);
    }
}
