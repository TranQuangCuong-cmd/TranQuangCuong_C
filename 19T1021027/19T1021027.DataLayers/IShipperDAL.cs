using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021027.DomainModels;

namespace _19T1021027.DataLayers
{
    public interface IShipperDAL
    {
        /// <summary>
        /// tìm kiếm và lấy danh sách các người giao hàng dưới dạng phân trang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng hiển thị trên mỗi trang (0 tức là không yêu cầu phân trang)</param>
        /// <param name="searchValue">tên cần tìm kiếm (chuỗi rỗng nếu không tìm kiếm theo tên)</param>
        /// <returns></returns>
        IList<Shipper> List(int page = 1, int pageSize = 0, string searchValue = "");
        /// <summary>
        /// đếm số người giao hàng tìm được
        /// </summary>
        /// <param name="searchValue">Tên cần tìm kiếm (chuỗi rỗng nếu không tìm kiếm theo tên)</param>
        /// <returns></returns>
        int Count(string searchValue = "");
        /// <summary>
        /// Bổ sung thêm một người giao hàng
        /// </summary>
        /// <param name="data">Lớp chứa đối tượng bổ sung</param>
        /// <returns>ID của người giao hàng được tạo mới</returns>
        int Add(Shipper data);
        /// <summary>
        /// cập nhật thông tin của người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Shipper data);
        /// <summary>
        /// xóa một người giao hàng dựa vào mã của người giao hàng
        /// </summary>
        /// <param name="shipperID">mã của người giao hàng cần xóa</param>
        /// <returns></returns>
        bool Delete(int shipperID);
        /// <summary>
        /// Lấy thông tin của 1 người giao hàng dựa vào mã của người giao hàng
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        Shipper Get(int shipperID);
        /// <summary>
        /// Kiểm tra xem người giao hiện có dữ liệu liên quan hay không
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        bool InUsed(int shipperID);
    }
}
