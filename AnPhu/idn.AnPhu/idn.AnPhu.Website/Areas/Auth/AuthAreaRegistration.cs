using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth
{
    public class AuthAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Auth";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "auth_login",
                "{culture}/dang-nhap",
                new { culture = "vi", controller = "Account", action = "Login" },
                new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
                "auth_home",
                "{culture}/quan-tri",
                new { culture = "vi", controller = "Home", action = "Index" },
                new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
                "auth_sys_user",
                "{culture}/quan-tri/nguoi-dung",
                new { culture = "vi", controller = "Sys_User", action = "Index" },
                new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );
            context.MapRoute(
                name: "auth_sys_user_create",
                url: "{culture}/quan-tri/nguoi-dung/tao-moi",
                defaults: new
                {
                    culture = "vi",
                    area = "Auth",
                    controller = "Sys_User",
                    action = "Create",
                },
                namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );

            context.MapRoute(
               name: "auth_sys_user_update",
               url: "{culture}/quan-tri/nguoi-dung/cap-nhat",
               defaults: new
               {
                   culture = "vi",
                   area = "Auth",
                   controller = "Sys_User",
                   action = "Update",
               },
               namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
           );
            context.MapRoute(
              name: "auth_sys_user_detail",
              url: "{culture}/quan-tri/nguoi-dung/chi-tiet",
              defaults: new
              {
                  culture = "vi",
                  area = "Auth",
                  controller = "Sys_User",
                  action = "Detail",
              },
              namespaces: new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
          );







            context.MapRoute(
                "Auth_default",
                "{culture}/Auth/{controller}/{action}/{id}",
                new { culture = "vi", controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "idn.AnPhu.Website.Areas.Auth.Controllers" }
            );



            //context.MapRoute(
            //    "Auth_default",
            //    "Auth/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}