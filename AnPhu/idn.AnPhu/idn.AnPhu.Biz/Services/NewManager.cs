using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
    public class NewManager : DataManagerBase<News>
    {
        public NewManager() : base() { }
        public NewManager(IDataProvider<News> provider) : base(provider) { }

        private INewsProvider NewsProvider
        {
            get { return (INewsProvider)Provider; }
        }

        public List<News> GetAll(int startIndex, int length, ref int total)
        {
            return NewsProvider.GetAll(startIndex, length, ref total);
        }
        public List<News> GetAllActive(int startIndex, int length, ref int total, string lang)
        {
            return NewsProvider.GetAllActive(startIndex, length, ref total, lang);
        }
        public List<News> Search(int startIndex, int length, ref int total, string lang)
        {
            return NewsProvider.Search(startIndex, length, ref total, lang);
        }
        public News GetByShortName(string shortname, string lang)
        {
            return NewsProvider.GetByShortName(shortname, lang);
        }
        public List<News> GetAllByCate(int id, int startIndex, int length, ref int total, string lang)
        {
            return NewsProvider.GetAllByCate(id, startIndex, length, ref total, lang);
        }
        public List<News> GetByShortNameCate(string name, int startIndex, int length, ref int total, string lang)
        {
            return NewsProvider.GetByShortNameCate(name, startIndex, length, ref total, lang);
        }


    }
}
