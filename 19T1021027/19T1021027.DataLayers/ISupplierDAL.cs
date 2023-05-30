using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021027.DomainModels;

namespace _19T1021027.DataLayers
{
    /// <summary>
    /// định nghĩa các phép xử lý dữ liệu trên nhà cung cấp
    /// (sử dụng cách này dẫn đến viết lawoj đi lặp lại các kiểu code giống nhau
    /// cho các đối dượng dữ liệu tương tự như Customer, Employee,...) => không dùng
    /// </summary>
    public interface ISupplierDAL
    {
        /// <summary>
        /// tìm kiếm và lấy danh sách các nhà cung cấp dưới dạng phân trang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng hiển thị trên mỗi trang (0 tức là không yêu cầu phân trang)</param>
        /// <param name="searchValue">tên cần tìm kiếm (chuỗi rỗng nếu không tìm kiếm theo tên)</param>
        /// <returns></returns>
        IList<Supplier> List(int page = 1, int pageSize = 0, string searchValue = "");
        /// <summary>
        /// đếm số nhà cung cấp tìm được
        /// </summary>
        /// <param name="searchValue">Tên cần tìm kiếm (chuỗi rỗng nếu không tìm kiếm theo tên)</param>
        /// <returns></returns>
        int Count(string searchValue = "");
        /// <summary>
        /// Bổ sung thêm một nhà cung cấp
        /// </summary>
        /// <param name="data">Lớp chứa đối tượng bổ sung</param>
        /// <returns>ID của nhà cung cấp được tạo mới</returns>
        int Add(Supplier data);
        /// <summary>
        /// cập nhật thông tin của nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Supplier data);
        /// <summary>
        /// xóa một nhà cung cấp dựa vào mã của nahf cung cấp
        /// </summary>
        /// <param name="supplierID">mã của nhà cung cấp cần xóa</param>
        /// <returns></returns>
        bool Delete(int supplierID);
        /// <summary>
        /// Lấy thông tin của 1 nhà cung cấp dựa vào mã của nhà cung cấp
        /// </summary>
        /// <param name="suplierID"></param>
        /// <returns></returns>
        Supplier Get(int suplierID);
        /// <summary>
        /// Kiểm tra xem nahf cung cấp hiện có dữ liệu liên quan hay không
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        bool InUsed(int supplierID);
    }
}
