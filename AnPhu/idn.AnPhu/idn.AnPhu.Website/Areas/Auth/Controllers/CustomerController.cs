using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using idn.AnPhu.Utils;
using idn.AnPhu.Website.Controllers;
using idn.AnPhu.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
    public class CustomerController : AdministratorController
    {

        private CustomerManager CustomerManager
        {
            get { return ServiceFactory.CustomerManager; }
        }
        // GET: Auth/Customer
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Search()
        {
            var list = CustomerManager.GetAll();
            return View(list);
        }


        [HttpGet]

        public ActionResult Create()
        {
            Customer data = new Customer();
            var cate = CustomerManager.GetAllActive();
            ViewBag.Categories = cate;
            return View("Create", data);
        }


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]


        public ActionResult Create(Customer model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            if(model != null)
            {
                CustomerManager.Add(model);
                resultEntry.Success = true;
                resultEntry.AddMessage("Tạo mới khách hàng thành công!");
                resultEntry.RedirectUrl = Url.Action("Create", "Customer", new { area = "Auth" });
            }
            else
            {
                resultEntry.Detail = "dư lieu null";
            }
            return Json(resultEntry);
        }


        [HttpGet]


        public ActionResult Update(int CustomerId)
        {
            var categories = CustomerManager.GetAllActive();
            ViewBag.Categories = categories;
            if (CUtils.IsNullOrEmpty(CustomerId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var custom = CustomerManager.Get(new Customer() { CustomerId = CustomerId });
            if(custom != null)
            {
                return View(custom);
            }
            else
            {
                return HttpNotFound();
            }
        }


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]

        public ActionResult Update(Customer model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var exitsData = "";
            if(model != null && !CUtils.IsNullOrEmpty(model.CustomerId))
            {
                var customs = CustomerManager.Get(new Customer() { CustomerId = model.CustomerId });
                if(customs != null)
                {
                    CustomerManager.Update(model, customs);
                    resultEntry.Success = true;
                    resultEntry.AddMessage("Cập nhật khách hàng thành công!");
                    resultEntry.RedirectUrl = Url.Action("Search", "Customer", new { area = "Auth" });
                }
                else
                {
                    resultEntry.Success = true;
                    exitsData = "Mã danh mục '" + model.CustomerId + "' không có trong hệ thống!";
                }
            }
            else
            {
                resultEntry.Success = true;
                exitsData = "Mã danh mục trống!";
            }
            resultEntry.AddMessage(exitsData);
            return Json(resultEntry);
        }


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]


        public ActionResult Delete(int CustomerId)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var custom = new Customer() { CustomerId = CustomerId };
            CustomerManager.Remove(custom);
            resultEntry.Success = true;
            resultEntry.AddMessage("Xóa khách hàng thành công!");
            return Json(resultEntry);
        }





    }
}