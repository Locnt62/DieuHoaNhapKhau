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
    public class SlideController : AdministratorController
    {
        private SlideManager SlideManager
        {
            get { return ServiceFactory.SlideManager; }
        }

        // GET: Auth/Slide
        public ActionResult Index()
        {
            var listSlide = SlideManager.Search(Culture);
            return View(listSlide);
        }

        [HttpGet]

        public ActionResult Create()
        {
            Slide data = new Slide();
            return View("Create", data);

        }


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]


        public ActionResult Create(Slide model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            if (model != null)
            {
                var createBy = "";
                model.Language = Culture;
                if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
                {
                    createBy = CUtils.StrTrim(UserState.UserName);
                }
                model.CreateBy = createBy;
                SlideManager.Add(model);
                resultEntry.Success = true;
                resultEntry.AddMessage("Tạo mới Side thành công!");
                resultEntry.RedirectUrl = Url.Action("Create", "Slide", new { area = "Auth" });

            }
            else
            {
                resultEntry.Detail = "dư lieu null";
            }
            return Json(resultEntry);
        }


        [HttpGet]
        public ActionResult Update(int SlideId)
        {
            if (CUtils.IsNullOrEmpty(SlideId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var slide = SlideManager.Get(new Slide() { SlideBannerId = SlideId });
            if(slide != null)
            {
                return View(slide);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]


        public ActionResult Update(Slide model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var exitsData = "";
            if(model !=  null && !CUtils.IsNullOrEmpty(model.SlideBannerId))
            {
                var slide = SlideManager.Get(new Slide() { SlideBannerId = model.SlideBannerId });
                if(slide != null)
                {
                    model.Language = Culture;
                    SlideManager.Update(model, slide);
                    resultEntry.Success = true;
                    resultEntry.AddMessage("Cập nhật slidebanner thành công !");
                    resultEntry.RedirectUrl = Url.Action("Index", "Slide", new { area = "Auth" });
                }
                else
                {
                    resultEntry.Success = true;
                    exitsData = "Mã danh mục '" + model.SlideBannerId + "' không có trong hệ thống!";
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


        public ActionResult Delete(int SlideId)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var news = new Slide() { SlideBannerId = SlideId };
            SlideManager.Remove(news);
            resultEntry.Success = true;
            resultEntry.AddMessage("Xóa slide thành công!");
            return Json(resultEntry);
        }


    }
}