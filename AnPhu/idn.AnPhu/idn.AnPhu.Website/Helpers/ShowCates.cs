using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace idn.AnPhu.Website.Helpers
{
    public static class ShowCates
    {
        public static string ShowCategories(List<NewCategory> list, string name, int parentid = 0)
        {
            //List<NewCategory> listCate = new List<NewCategory>();
            string strMenu = "";
            foreach (NewCategory item in list)
            {
                if (item.ParentId == parentid)
                {
                    strMenu += "<li> " + item.NewCateName + " </li>";
                    ShowCategories(list, "|--" + name, item.NewCategoryId);
                }

            }
            return strMenu;
        }
    }
}