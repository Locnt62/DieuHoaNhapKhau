using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
   public  interface INewsProvider : IDataProvider<News>
    {
        List<News> GetAllActive(int startIndex, int count, ref int totalItems, string lang);
        List<News> GetAll(int startIndex, int count, ref int totalItems, string lang);

        List<News> Search(int startIndex, int length, ref int total, string lang);

        List<News> GetAllByCate(int id, int startIndex, int count, ref int totalItems, string lang);

        News GetByShortName(string shortname, string lang);
        List<News> GetByShortNameCate(string name, int startIndex, int count, ref int totalItems, string lang);
    }
}
