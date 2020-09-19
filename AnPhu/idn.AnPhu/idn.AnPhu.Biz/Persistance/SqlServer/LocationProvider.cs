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
    public class LocationProvider : DataAccessBase, ILocationProvider
    {
        public void Add(Locations item)
        {
            /*  throw new NotImplementedException();*/
            var comm = this.GetCommand("Location_Add");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", item.LocationDiscountId);
            comm.AddParameter<string>(this.Factory, "LocationName", item.LocationName);
            comm.AddParameter<string>(this.Factory, "LocationValue", item.LocationValue);
            comm.AddParameter<string>(this.Factory, "Note", item.Note);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<string>(this.Factory, "Language", item.Language);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);

            comm.SafeExecuteNonQuery();
        }

        public Locations Get(Locations dummy)
        {
            /*throw new NotImplementedException();*/
            var comm = this.GetCommand("Location_Get");
            if(comm == null) return null;
            comm.AddParameter<int>(this.Factory, "LocationId", dummy.LocationId);
            var dt = this.GetTable(comm);
            var item = EntityBase.ParseListFromTable<Locations>(dt).FirstOrDefault();
            return item ?? null;
        }

        public List<Locations> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<Locations> GetAllActiveParentId(int id)
        {
            var comm = this.GetCommand("Location_GetAllActiveByParentId");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", id);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Locations>(dt);
            /*throw new NotImplementedException();*/
        }

        public List<Locations> GetAllByParentId(int id)
        {
            var comm = this.GetCommand("Location_GetAllByParentId");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", id);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Locations>(dt);
            /*throw new NotImplementedException();*/
        }

        public void Remove(Locations item)
        {
            var comm = this.GetCommand("Location_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "LocationId", item.LocationId);

            comm.SafeExecuteNonQuery();
            /* throw new NotImplementedException();*/
        }

        public void Update(Locations @new, Locations old)
        {
            /*  throw new NotImplementedException();*/

            var item = @new;
            item.LocationId = old.LocationId;
            var comm = this.GetCommand("Location_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "LocationId", item.LocationId);
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", item.LocationDiscountId);
            comm.AddParameter<string>(this.Factory, "LocationName", item.LocationName);
            comm.AddParameter<string>(this.Factory, "LocationValue", item.LocationValue);
            comm.AddParameter<string>(this.Factory, "Note", item.Note);
            comm.AddParameter<string>(this.Factory, "Language", item.Language);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
        }
    }
}
