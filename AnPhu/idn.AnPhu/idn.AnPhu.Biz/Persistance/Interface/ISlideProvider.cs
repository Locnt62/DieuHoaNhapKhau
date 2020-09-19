using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface ISlideProvider : IDataProvider<Slide>
    {
        List<Slide> GetAllActive(string lang);
        List<Slide> Search(string lang);
    }
}
