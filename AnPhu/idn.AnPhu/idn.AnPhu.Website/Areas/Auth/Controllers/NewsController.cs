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
    public class NewsController : AdministratorController
    {

        private NewManager NewManager
        {
            get { return ServiceFactory.NewManager; }
        }


        private NewCategoryManager NewCategoryManager
        {
            get { return ServiceFactory.NewCategoryManager; }
        }

        [HttpGet]
        // GET: Auth/News
        public ActionResult Index()
        {
            var totalItems = 0;
            var listNews = NewManager.Search(0, 1000, ref totalItems, Culture);
            var categories = NewCategoryManager.GetAllActive(Culture);
            ViewBag.Categories = categories;
            List<NewCategory> listcate = NewCategoryManager.GetAllActive(Culture);
            var listTree = Helpers.ShowCates.ShowCategories(listcate, "");
            ViewBag.ListTrees = listTree;
            return View(listNews);
            /* return View();*/
        }


        [HttpGet]


        public ActionResult Create()
        {
            News data = new News();
            var categories = NewCategoryManager.GetAllActive(Culture);
            ViewBag.Categories = categories;
            return View("Create", data);
        }


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]


        public ActionResult Create(News model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            if (model != null)
            {
                model.Language = Culture;
                model.NewShortName = model.NewTitle.ToUrlSegment(250).ToLower();
                var createBy = "";
                if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
                {
                    createBy = CUtils.StrTrim(UserState.UserName);
                }
                model.CreateBy = createBy;
                resultEntry.Success = true;
                resultEntry.AddMessage("Tạo mới  tin tức thành công!");
                resultEntry.RedirectUrl = Url.Action("Create", "News", new { area = "Auth" });
            }
            else
            {
                resultEntry.Detail = "dư lieu null";
            }
            return Json(resultEntry);
        }


        [HttpGet]

        public ActionResult Update(int NewsId)
        {
            var categories = NewCategoryManager.GetAllActive(Culture);
            ViewBag.Categories = categories;
            if (CUtils.IsNullOrEmpty(NewsId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cate = NewManager.Get(new News() { NewsId = NewsId });
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


        public ActionResult Update(News model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var exitsData = "";
            if(model != null && !CUtils.IsNullOrEmpty(model.NewsId))
            {
                var cate = NewManager.Get(new News() { NewsId = model.NewsId });
                if(cate != null)
                {
                    model.Language = Culture;
                    model.NewShortName = model.NewTitle.ToUrlSegment(250).ToLower();
                    NewManager.Update(model, cate);
                    resultEntry.Success = true;
                    resultEntry.AddMessage("Cập nhật tin tức thành công !");
                    resultEntry.RedirectUrl = Url.Action("Index", "News", new { area = "Auth" });
                }
                else
                {
                    resultEntry.Success = true;
                    exitsData = "Mã danh mục '" + model.NewsId + "' không có trong hệ thống!";
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

        public ActionResult Delete(int NewsId)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var news = new News() { NewsId = NewsId };
            NewManager.Remove(news);
            resultEntry.Success = true;
            resultEntry.AddMessage("Xóa tin tức thành công!");
            return Json(resultEntry);
        }
    }
}