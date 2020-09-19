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
    public class SlideManager : DataManagerBase<Slide>
    {
        public SlideManager() : base() { }
        public SlideManager(IDataProvider<Slide> provider) : base(provider) { }
        private ISlideProvider SlideProvider
        {
            get { return (ISlideProvider)Provider; }
        }
        public List<Slide> Search(string lang)
        {
            return SlideProvider.Search(lang);
        }
        public List<Slide> GetAllActive(string lang)
        {
            return SlideProvider.GetAllActive(lang);
        }

    }
}
