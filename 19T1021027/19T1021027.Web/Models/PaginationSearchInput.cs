using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021027.Web.Models
{
    /// <summary>
    /// Biểu diễn dữ liệu đầu vào để tìm kiếm , phân trang chung 
    /// </summary>
    public class PaginationSearchInput
    {
        /// <summary>
        /// Trang cần hiện thị
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Số dòng cân hiển  thị trên mỗi trang 
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Giá trị cần tìm 
        /// </summary>
        public string SearchValue { get; set; }
    }
}