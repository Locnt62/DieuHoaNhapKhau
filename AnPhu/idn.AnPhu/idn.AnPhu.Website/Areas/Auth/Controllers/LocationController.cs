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
    public class LocationController : AdministratorController
    {
        private LocationDiscountManager LocationDiscountManager
        {
            get { return ServiceFactory.LocationDiscountManager; }
        }

        private LocationManager LocationManager
        {
            get { return ServiceFactory.LocationManager; }
        }
        // GET: Auth/Location

        [HttpGet]
        public ActionResult Index(int LocationDiscountId)
        {
            var list = LocationManager.GetAllByParentId(LocationDiscountId);

            return View(list);
        }


        [HttpGet]

        public ActionResult Create()
        {
            Locations data = new Locations();
            var listcity = LocationDiscountManager.GetAll(Culture);
            ViewBag.Listcity = listcity;
            return View("Create", data);
        }


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]


        public ActionResult Create(Locations model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            if (model != null)
            {
                var createBy = "";
                if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
                {
                    createBy = CUtils.StrTrim(UserState.UserName);
                }
                model.LocationValue = model.LocationName.ToUrlSegment(250).ToLower();
                model.CreateBy = createBy;
                model.Language = Culture;
                LocationManager.Add(model);
                resultEntry.Success = true;
                resultEntry.AddMessage("Tạo mới quận huyện thành công!");
                resultEntry.RedirectUrl = Url.Action("Create", "Location", new { area = "Auth", locationDiscountId = model.LocationDiscountId });
            }
            else
            {
                resultEntry.Detail = "dư lieu null";
            }
            return Json(resultEntry);
        }

        [HttpGet]

        public ActionResult Update(int LocationId)
        {
            var listcity = LocationDiscountManager.GetAll(Culture);
            ViewBag.Listcity = listcity;
            if (CUtils.IsNullOrEmpty(LocationId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var locations = LocationManager.Get(new Locations() { LocationId = LocationId });
            if(locations != null)
            {
                return View(locations);
            }
            else
            {
                return HttpNotFound();
            }
        }


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]


        public ActionResult Update(Locations model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var exitsData = "";
            if(model != null && !CUtils.IsNullOrEmpty(model.LocationId))
            {
                var locations = LocationManager.Get(new Locations() { LocationId = model.LocationId });
                if(locations != null)
                {
                    model.LocationValue = model.LocationName.ToUrlSegment(250).ToLower();
                    model.Language = Culture;
                    LocationManager.Update(model, locations);
                    resultEntry.Success = true;
                    resultEntry.AddMessage("Cập nhật thuộc tính thành công !");
                    resultEntry.RedirectUrl = Url.Action("Index", "Location", new { area = "Auth", locationDiscountId = model.LocationDiscountId });

                }
                else
                {
                    resultEntry.Success = true;
                    exitsData = "Mã danh mục '" + model.LocationId + "' không có trong hệ thống!";
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

        public ActionResult Delete(int locationid)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var news = new Locations() { LocationId = locationid };
            LocationManager.Remove(news);
            resultEntry.Success = true;
            resultEntry.AddMessage("Xóa quận huyện thành công!");
            return Json(resultEntry);
        }


    }
}