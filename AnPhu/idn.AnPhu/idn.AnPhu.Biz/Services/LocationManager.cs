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
    public class LocationManager : DataManagerBase<Locations>
    {
        public LocationManager() : base() { }
        public LocationManager(IDataProvider<Locations> provider) : base(provider) { }

        private ILocationProvider LocationProvider
        {
            get { return (ILocationProvider)Provider; }
        }

        public List<Locations> GetAllByParentId(int id)
        {
            return LocationProvider.GetAllByParentId(id);
        }
        public List<Locations> GetAllActiveByParentId(int id)
        {
            return LocationProvider.GetAllActiveParentId(id);
        }
    }
}
