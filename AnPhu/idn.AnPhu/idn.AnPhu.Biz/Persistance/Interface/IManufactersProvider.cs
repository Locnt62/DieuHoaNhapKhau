using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface IManufactersProvider : IDataProvider<Manufacters>
    {
        List<Manufacters> GetAll(string lang);

        List<Manufacters> GetAllActive(string lang);
    }
}
