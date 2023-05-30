using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021027.DomainModels;

namespace _19T1021027.DataLayers
{
    public interface ICustomerDAL
    {
        /// <summary>
        /// tìm kiếm và lấy danh sách các khách hàng dưới dạng phân trang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng hiển thị trên mỗi trang (0 tức là không yêu cầu phân trang)</param>
        /// <param name="searchValue">tên cần tìm kiếm (chuỗi rỗng nếu không tìm kiếm theo tên)</param>
        /// <returns></returns>
        IList<Customer> List(int page = 1, int pageSize = 5, string searchValue = "");
        /// <summary>
        /// đếm số khách hàng tìm được
        /// </summary>
        /// <param name="searchValue">Tên cần tìm kiếm (chuỗi rỗng nếu không tìm kiếm theo tên)</param>
        /// <returns></returns>
        int Count(string searchValue = "");
        /// <summary>
        /// Bổ sung thêm một khách hàng
        /// </summary>
        /// <param name="data">Lớp chứa đối tượng bổ sung</param>
        /// <returns>ID của khach hàng được tạo mới</returns>
        int Add(Customer data);
        /// <summary>
        /// cập nhật thông tin của khách hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Customer data);
        /// <summary>
        /// xóa một khách hàng dựa vào mã của khách hàng
        /// </summary>
        /// <param name="customerID">mã của khách hàng cần xóa</param>
        /// <returns></returns>
        bool Delete(int customerID);
        /// <summary>
        /// Lấy thông tin của 1 khách hàng dựa vào mã của khách hàng
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        Customer Get(int customerID);
        /// <summary>
        /// Kiểm tra xem khách hàng hiện có dữ liệu liên quan hay không
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        bool InUsed(int customerID);
    }
}
