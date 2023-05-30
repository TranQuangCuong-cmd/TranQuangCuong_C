using _19T1021027.BusinessLayers;
using _19T1021027.DomainModels;
using _19T1021027.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19T1021027.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [RoutePrefix("product")]
    public class ProductController : Controller
    {
        private const int PAGE_SIZE = 9;
        private const string Product_SEARCH = "SearchProductCondition";
        /// <summary>
        /// Tìm kiếm, hiển thị mặt hàng dưới dạng phân trang
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ProductSearchInput condition = Session[Product_SEARCH] as ProductSearchInput;

            if (condition == null)
            {
                condition = new ProductSearchInput()
                {
                    Page = 1,
                    PageSize = PAGE_SIZE,
                    SearchValue = "",
                    SuplierId = 0,
                    CategoryId = 0
                };
            }

            return View(condition);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Search(ProductSearchInput condition)
        {
            int rowCount = 0;
            var data = ProductDataService.ListProducts(condition.Page, condition.PageSize, condition.SearchValue, condition.CategoryId, condition.SuplierId, out rowCount);

            var result = new ProductSearchOuput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };
            Session[Product_SEARCH] = condition;

            return View(result);
        }


        /// <summary>
        /// Tạo mặt hàng mới
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var data = new Product()
            {
                ProductID = 0
            };
            ViewBag.Title = "Bổ sung sản phẩm";
            return View(data);
        }
        /// <summary>
        /// Cập nhật thông tin mặt hàng, 
        /// Hiển thị danh sách ảnh và thuộc tính của mặt hàng, điều hướng đến các chức năng
        /// quản lý ảnh và thuộc tính của mặt hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
                return RedirectToAction("index");

            var data = ProductDataService.getProduct(id);
            if (data == null)
                return RedirectToAction("index");
            var Editmodel = new ProductEditModel()
            {
                Attributes = ProductDataService.ListAttributes(id),
                Photos = ProductDataService.ListPhotos(id),
                Data = data
            };
            return View(Editmodel);
        }



        /// <summary>
        /// lưu dl gửi từ trang create hoặc trang edit
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProduct(Product data, HttpPostedFileBase uploadPhotos)
        {

            if (string.IsNullOrWhiteSpace(data.ProductName))
                ModelState.AddModelError("ProductName", "Tên sản phẩm không được để trống");
            if (string.IsNullOrWhiteSpace(data.Price.ToString()))
                ModelState.AddModelError("Price", "Giá không được để trống");
            if (string.IsNullOrWhiteSpace(data.Unit))
                ModelState.AddModelError("Unit", "Đơn vị không được để trống");


            //Xử lý ảnh
            if (uploadPhotos != null)
            {
                string path = Server.MapPath("~/Photo");
                string fileName = $"{DateTime.Now.Ticks}_{uploadPhotos.FileName}";
                string filePath = System.IO.Path.Combine(path, fileName);
                uploadPhotos.SaveAs(filePath);
                data.Photo = fileName;
            }
            else if(data.Photo == null)
            {
                ModelState.AddModelError("Photo", "Ảnh không được để trống");
            }

            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }


            if (data.ProductID == 0)
            {

                var productNewId = ProductDataService.AddProduct(data);
                return RedirectToAction($"Edit/{productNewId}");
            }
            else
            {
                ProductDataService.UpdateProduct(data);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Xóa mặt hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        public ActionResult Delete(int id = 0)
        {
            if (id <= 0)
                return RedirectToAction("index");

            if (Request.HttpMethod == "GET")
            {
                var data = ProductDataService.getProduct(id);
                if (data == null)
                {
                    return RedirectToAction("index");
                }
                return View(data);
            }
            else
            {
                ProductDataService.DeleteProduct(id);
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Các chức năng quản lý ảnh của mặt hàng
        /// </summary>
        /// <param name="method"></param>
        /// <param name="productID"></param>
        /// <param name="PhotosID"></param>
        /// <returns></returns>
        [Route("Photo/{method?}/{productID?}/{PhotosID?}")]
        
        public ActionResult Photo(string method = "add", int productID = 0, long PhotosID = 0)
        {
            if (productID <= 0 || (method.Equals("edit") && PhotosID <= 0))
            {
                if (productID > 0)
                {
                    return RedirectToAction($"Edit/{productID}");
                }
                return RedirectToAction("index");
            }
            else
            {
                var data = new ProductPhoto();
                switch (method)
                {

                    case "add":
                        ViewBag.Title = "Bổ sung ảnh";
                        data.ProductID = productID;
                        data.PhotoID = 0;
                        return View(data);

                    case "edit":
                        ViewBag.Title = "Thay đổi ảnh";
                        data = ProductDataService.GetPhoto(PhotosID);
                        return View(data);
                    case "delete":
                        ProductDataService.DeletePhoto(PhotosID);
                        return RedirectToAction($"Edit/{productID}"); //return RedirectToAction("Edit", new { productID = productID });
                    default:
                        return RedirectToAction("Index");
                }
            }
        }
        [ValidateAntiForgeryToken]
        public ActionResult SavePhotos(ProductPhoto data, HttpPostedFileBase uploadPhotos)
        {
            //Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(data.Description))
                ModelState.AddModelError("Description", "Mô tả sản phẩm không được để trống");
            if (string.IsNullOrWhiteSpace(data.DisplayOrder.ToString()))
                ModelState.AddModelError("DisplayOrder", "Thứ tự hiển thị không được để trống");

            //Xử lý ảnh
            if (uploadPhotos != null)
            {
                string path = Server.MapPath("~/Photo");
                string fileName = $"{DateTime.Now.Ticks}_{uploadPhotos.FileName}";
                string filePath = System.IO.Path.Combine(path, fileName);
                uploadPhotos.SaveAs(filePath);
                data.Photo = fileName;
            }
            else if(data.Photo == null)
            {
                ModelState.AddModelError("Photo", "Ảnh không được để trống");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.title = data.PhotoID == 0 ? "Bổ sung Photos" : "cập nhật Photos";
                return View("Photos", data);
            }

            if (data.PhotoID != 0)
            {
                ProductDataService.UpdatePhoto(data);
            }
            else
            {
                ProductDataService.AddPhoto(data);
            }
            return RedirectToAction($"Edit/{data.ProductID}");
        }

        /// <summary>
        /// Các chức năng quản lý thuộc tính của mặt hàng
        /// </summary>
        /// <param name="method"></param>
        /// <param name="productID"></param>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        [Route("attribute/{method?}/{productID}/{attributeID?}")]
        public ActionResult Attribute(string method = "add", int productID = 0, int attributeID = 0)
        {
            if ( productID <= 0 || (method.Equals("edit") && attributeID <= 0))
            {
                if (productID > 0)
                {
                    return RedirectToAction($"Edit/{productID}");
                }
                return RedirectToAction("index");
            }
            var data = new ProductAttribute();
            switch (method)
            {
                case "add":
                    ViewBag.Title = "Bổ sung thuộc tính";
                    data.ProductID = productID;
                    data.AttributeID = 0;
                    return View(data);
                case "edit":
                    ViewBag.Title = "Thay đổi thuộc tính";
                    data = ProductDataService.GetAttribute(attributeID);
                    return View(data);
                case "delete":
                    ProductDataService.DeleteAttribute(attributeID);
                    return RedirectToAction($"Edit/{productID}"); //return RedirectToAction("Edit", new { productID = productID });
                default:
                    return RedirectToAction("Index");
            }
        }

        [ValidateAntiForgeryToken]
        public ActionResult SaveAttribute(ProductAttribute data)
        {

            if (string.IsNullOrWhiteSpace(data.AttributeName))
                ModelState.AddModelError("AttributeName", "Tên thuộc tính không được để trống");
            if (string.IsNullOrWhiteSpace(data.AttributeValue))
                ModelState.AddModelError("AttributeValue", "Giá trị thuộc tính không được để trống");
            if (string.IsNullOrWhiteSpace(data.DisplayOrder.ToString()))
                ModelState.AddModelError("DisplayOrder", "Thứ tự hiển thị không được để trống");

            if (!ModelState.IsValid)
            {
                ViewBag.title = data.AttributeID == 0 ? "Bổ sung thuộc tính" : "cập nhật thuộc tính";
                return View("Attribute", data);
            }


            if (data.AttributeID != 0)
            {
                ProductDataService.UpdateAttribute(data);
            }
            else
            {
                ProductDataService.AddAttribute(data);
            }
            return RedirectToAction($"Edit/{data.ProductID}");
        }

    }
}