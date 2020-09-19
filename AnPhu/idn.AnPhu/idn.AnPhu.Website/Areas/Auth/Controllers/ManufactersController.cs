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
    public class ManufactersController : AdministratorController
    {


        private ManufactersManager ManufactersManager
        {
            get { return ServiceFactory.ManufactersManager; }
        }
        // GET: Auth/Manufacters
        public ActionResult Index()
        {
            var list = ManufactersManager.GetAll(Culture);
            return View(list);
        }


        [HttpGet]

        public ActionResult Create()
        {
            Manufacters data = new Manufacters();
            return View("Create", data);
        }


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Manufacters model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            if (model != null)
            {
                var createBy = "";
                model.ManufactShortName = model.ManufactName.ToUrlSegment(250).ToLower();
                if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
                {
                    createBy = CUtils.StrTrim(UserState.UserName);
                }

                model.CreateBy = createBy;
                model.Language = Culture;
                ManufactersManager.Add(model);
                resultEntry.Success = true;
                resultEntry.AddMessage("Tạo mới hãng thành công!");
                resultEntry.RedirectUrl = Url.Action("Create", "Manufacters", new { area = "Auth" });
            }
            else
            {
                resultEntry.Detail = "dư lieu null";
            }
            return Json(resultEntry);
        }

        [HttpGet]

        public ActionResult Update(int ManufacterId)
        {
            if (CUtils.IsNullOrEmpty(ManufacterId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var manu = ManufactersManager.Get(new Manufacters() { ManufactId = ManufacterId });
            if(manu != null)
            {
                return View(manu);
            }
            else
            {
                return HttpNotFound();
            }
        }


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]


        public ActionResult Update(Manufacters model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var exitsData = "";
            if(model != null && !CUtils.IsNullOrEmpty(model.ManufactId))
            {
                var manu = ManufactersManager.Get(new Manufacters() { ManufactId = model.ManufactId });
                if(manu != null)
                {
                    model.ManufactShortName = model.ManufactName.ToUrlSegment(250).ToLower();
                    model.Language = Culture;
                    ManufactersManager.Update(model, manu);
                    resultEntry.Success = true;
                    resultEntry.AddMessage("Cập nhật hãng thành công !");
                    resultEntry.RedirectUrl = Url.Action("Index", "Manufacters", new { area = "Auth" });
                }
                else
                {
                    resultEntry.Success = true;
                    exitsData = "Mã danh mục '" + model.ManufactId + "' không có trong hệ thống!";
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

        public ActionResult Delete(int id)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var news = new Manufacters() { ManufactId = id };
            ManufactersManager.Remove(news);
            resultEntry.Success = true;
            resultEntry.AddMessage("Xóa hãng thành công!");
            return Json(resultEntry);
        }






    }
}