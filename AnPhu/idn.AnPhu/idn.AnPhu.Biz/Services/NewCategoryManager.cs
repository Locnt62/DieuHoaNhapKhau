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
    public class NewCategoryManager : DataManagerBase<NewCategory>
    {
        public NewCategoryManager() : base() { }
        public NewCategoryManager(IDataProvider<NewCategory> provider) : base(provider) { }

        private INewCategoryProvider NewCategoryProvider
        {
            get { return (INewCategoryProvider)Provider; }
        }
        public List<NewCategory> GetAllActive(string lang)
        {
            return NewCategoryProvider.GetAllActive(lang);
        }
        public List<NewCategory> GetAll(string lang)
        {
            return NewCategoryProvider.GetAll(lang);
        }

    }
}
