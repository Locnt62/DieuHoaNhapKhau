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
    public class LocationDiscountManager : DataManagerBase<LocationDiscount>
    {

        public LocationDiscountManager() : base() { }
        public LocationDiscountManager(IDataProvider<LocationDiscount> provider) : base(provider) { }

        private ILocationDiscountProvider LocationDiscountProvider
        {
            get { return (ILocationDiscountProvider)Provider; }
        }


        public List<LocationDiscount> GetAll(string lang) {
            return LocationDiscountProvider.GetAll(lang);
        }

        public List<LocationDiscount> GetAllActive(string lang)
        {
            return LocationDiscountProvider.GetAllActive(lang);
        }
    }
}
