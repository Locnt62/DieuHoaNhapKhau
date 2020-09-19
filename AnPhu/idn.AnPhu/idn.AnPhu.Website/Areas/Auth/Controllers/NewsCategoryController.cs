using Client.Core.Extensions;
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
    public class NewsCategoryController : AdministratorController
    {

        private NewCategoryManager NewCategoryManager
        {
            get { return ServiceFactory.NewCategoryManager; }
        }

        [HttpGet]
        // GET: Auth/NewsCategory
        public ActionResult Index()
        {

            var totalItems = 0;
            var listCates = NewCategoryManager.GetAll(Culture);
            return View(listCates);
        }

        [HttpGet]

        public ActionResult Create()
        {
            NewCategory data = new NewCategory();
            var categories = NewCategoryManager.GetAllActive(Culture);
            ViewBag.Categories = categories;
            return View("Create", data);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]

        public ActionResult Create(NewCategory model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            if (model != null)
            {
                var createBy = "";
                model.NewCateShortName = model.NewCateName.ToUrlSegment(250).ToLower();
                model.Language = Culture;
                if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
                {
                    createBy = CUtils.StrTrim(UserState.UserName);
                }
                model.CreateBy = createBy;
                NewCategoryManager.Add(model);
                resultEntry.Success = true;
                resultEntry.AddMessage("Tạo mới danh mục tin tức thành công!");
                resultEntry.RedirectUrl = Url.Action("Create", "NewsCategory", new { area = "Auth" });

            }
            else
            {
                resultEntry.Detail = "dư lieu null";
            }
            return Json(resultEntry);
        }

        [HttpGet]

        public ActionResult Update(int newCategoryId)
        {
            var categories = NewCategoryManager.GetAllActive(Culture);
            ViewBag.Categories = categories;
            if (CUtils.IsNullOrEmpty(newCategoryId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cate = NewCategoryManager.Get(new NewCategory() { NewCategoryId = newCategoryId });
            if(cate != null)
            {
                return View(cate);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]

        public ActionResult Update(NewCategory model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var exitsData = "";
            if(model != null && !CUtils.IsNullOrEmpty(model.NewCategoryId))
            {
                var cate = NewCategoryManager.Get(new NewCategory() { NewCategoryId = model.NewCategoryId });
                if(cate != null)
                {
                    model.Language = Culture;
                    model.NewCateShortName = model.NewCateName.ToUrlSegment(250).ToLower();
                    NewCategoryManager.Update(model, cate);
                    resultEntry.Success = true;
                    resultEntry.AddMessage("Cập nhật danh mục tin tức thành công !");
                    resultEntry.RedirectUrl = Url.Action("Index", "NewsCategory", new { area = "Auth" });
                }
                else
                {
                    resultEntry.Success = true;
                    exitsData = "Mã danh mục '" + model.NewCategoryId + "' không có trong hệ thống!";
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


        public ActionResult Delete(int newCategoryId)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var news = new NewCategory() { NewCategoryId = newCategoryId };
            NewCategoryManager.Remove(news);
            resultEntry.Success = true;
            resultEntry.AddMessage("Xóa danh mục tin tức thành công!");
            return Json(resultEntry);
        }

    }
}