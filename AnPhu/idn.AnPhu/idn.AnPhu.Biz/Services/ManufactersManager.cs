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
    public class ManufactersManager : DataManagerBase<Manufacters>
    {
        public ManufactersManager() : base() { }
        public ManufactersManager(IDataProvider<Manufacters> provider) : base(provider) { }


        private IManufactersProvider ManufacterProvider
        {
            get { return (IManufactersProvider)Provider; }
        }

        public List<Manufacters> GetAll(string lang)
        {
            return ManufacterProvider.GetAll(lang);
        }
        public List<Manufacters> GetAllActive(string lang)
        {
            return ManufacterProvider.GetAllActive(lang);
        }


    }
}
