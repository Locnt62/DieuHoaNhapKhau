using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class ManufactersProvider : DataAccessBase, IManufactersProvider
    {
        public void Add(Manufacters item)
        {
            /* throw new NotImplementedException();*/
            var com = this.GetCommand("Manufacters_Add");
            if (com == null) return;
            com.AddParameter<string>(this.Factory, "ManufactName", item.ManufactName);
            com.AddParameter<string>(this.Factory, "ManufactShortName", item.ManufactShortName);
            com.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            com.AddParameter<string>(this.Factory, "Language", item.Language);
            com.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            com.SafeExecuteNonQuery();
        }

        public Manufacters Get(Manufacters dummy)
        {
            /*throw new NotImplementedException();*/
            var com = this.GetCommand("Manufacters_Get");
            if (com == null) return null;
            com.AddParameter<int>(this.Factory, "ManufactId", dummy.ManufactId);
            var dt = this.GetTable(com);
            var item = EntityBase.ParseListFromTable<Manufacters>(dt).FirstOrDefault();
            return item ?? null;
        }

        public List<Manufacters> GetAll(string lang)
        {
            /* throw new NotImplementedException();*/
            var comm = this.GetCommand("Manufacters_GetAll");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Language", lang);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Manufacters>(dt);
        }

        public List<Manufacters> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<Manufacters> GetAllActive(string lang)
        {
            /*   throw new NotImplementedException();*/
            var comm = this.GetCommand("Manufacters_GetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Language", lang);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Manufacters>(dt);
        }

        public void Remove(Manufacters item)
        {
            /*throw new NotImplementedException();*/
            var comm = this.GetCommand("Manufacters_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ManufactId", item.ManufactId);
            comm.SafeExecuteNonQuery();
        }

        public void Update(Manufacters @new, Manufacters old)
        {
            var item = @new;
            item.ManufactId = old.ManufactId;
            var comm = this.GetCommand("Manufacters_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ManufactId", item.ManufactId);
            comm.AddParameter<string>(this.Factory, "ManufactName", item.ManufactName);
            comm.AddParameter<string>(this.Factory, "ManufactShortName", item.ManufactShortName);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Language", item.Language);
            comm.SafeExecuteNonQuery();

            /* throw new NotImplementedException();*/
        }
    }
}
