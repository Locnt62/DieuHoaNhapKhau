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
    public class LocationDiscountController : AdministratorController
    {

        private LocationDiscountManager LocationDiscountManager
        {
            get { return ServiceFactory.LocationDiscountManager; }
        }
        // GET: Auth/Location
        public ActionResult Index()
        {
            var list = LocationDiscountManager.GetAll(Culture);

            return View(list);
        }


        [HttpGet]

        public ActionResult Create()
        {
            LocationDiscount data = new LocationDiscount();
            return View("Create", data);
        }



        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]


        public ActionResult Create(LocationDiscount model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            if(model != null)
            {
                var createBy = "";
                model.LocationDiscountValue = model.LocationDiscountName.ToUrlSegment(250).ToLower();
                if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
                {
                    createBy = CUtils.StrTrim(UserState.UserName);
                }
                model.CreateBy = createBy;
                model.Language = Culture;
                LocationDiscountManager.Add(model);
                resultEntry.Success = true;
                resultEntry.AddMessage("Tạo mới thành phố thành công!");
                resultEntry.RedirectUrl = Url.Action("Create", "LocationDiscount", new { area = "Auth" });

            }
            else
            {
                resultEntry.Detail = "dư lieu null";
            }
            return Json(resultEntry);
        }

        [HttpGet]

        public ActionResult Update(int locationdiscountid)
        {
            if (CUtils.IsNullOrEmpty(locationdiscountid))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var locate = LocationDiscountManager.Get(new LocationDiscount() { LocationDiscountId = locationdiscountid });
            if(locate != null)
            {
                return View(locate);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]

        public ActionResult Update(LocationDiscount model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var exitsData = "";
            if(model != null && !CUtils.IsNullOrEmpty(model.LocationDiscountId))
            {
                var news = LocationDiscountManager.Get(new LocationDiscount() { LocationDiscountId = model.LocationDiscountId });
                if(news != null)
                {
                    model.LocationDiscountValue = model.LocationDiscountName.ToUrlSegment(250).ToLower();
                    model.Language = Culture;
                    LocationDiscountManager.Update(model, news);
                    resultEntry.Success = true;
                    resultEntry.AddMessage("Cập nhật thành phố thành công !");
                    resultEntry.RedirectUrl = Url.Action("Index", "LocationDiscount", new { area = "Auth" });
                }
                else
                {
                    resultEntry.Success = true;
                    exitsData = "Mã danh mục '" + model.LocationDiscountId + "' không có trong hệ thống!";
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

        public ActionResult Delete(int locationdiscountid)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var news = new LocationDiscount() { LocationDiscountId = locationdiscountid };
            LocationDiscountManager.Remove(news);
            resultEntry.Success = true;
            resultEntry.AddMessage("Xóa thành phố thành công!");
            return Json(resultEntry);
        }

    }
}