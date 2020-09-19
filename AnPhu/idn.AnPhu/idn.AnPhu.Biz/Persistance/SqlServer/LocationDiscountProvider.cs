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
    public class LocationDiscountProvider : DataAccessBase, ILocationDiscountProvider
    {
        public void Add(LocationDiscount item)
        {
            var comm = this.GetCommand("LocationDiscounts_Add");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "LocationDiscountValue", item.LocationDiscountValue);
            comm.AddParameter<string>(this.Factory, "LocationDiscountName", item.LocationDiscountName);
            comm.AddParameter<string>(this.Factory, "Note", item.Note);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<string>(this.Factory, "Language", item.Language);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);

            comm.SafeExecuteNonQuery();

            /*  throw new NotImplementedException();*/


        }

        public LocationDiscount Get(LocationDiscount dummy)
        {
            /*   throw new NotImplementedException();*/
            var comm = this.GetCommand("LocationDiscounts_Get");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", dummy.LocationDiscountId);
            var dt = this.GetTable(comm);
            var item = EntityBase.ParseListFromTable<LocationDiscount>(dt).FirstOrDefault();
            return item ?? null;
        }

        public List<LocationDiscount> GetAll(string lang)
        {
            /*  throw new NotImplementedException();*/
            var comm = this.GetCommand("LocationDiscounts_GetAll");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Language", lang);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<LocationDiscount>(dt);
        }

        public List<LocationDiscount> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<LocationDiscount> GetAllActive(string lang)
        {
            /*throw new NotImplementedException();*/
            var comm = this.GetCommand("LocationDiscounts_GetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Language", lang);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<LocationDiscount>(dt);
        }

        public void Remove(LocationDiscount item)
        {
            var comm = this.GetCommand("LocationDiscounts_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", item.LocationDiscountId);
            comm.SafeExecuteNonQuery();
           /* throw new NotImplementedException();*/
        }

        public void Update(LocationDiscount @new, LocationDiscount old)
        {
            /*throw new NotImplementedException();*/
            var model = @new;
            model.LocationDiscountId = old.LocationDiscountId;
            var comm = this.GetCommand("LocationDiscounts_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", model.LocationDiscountId);
            comm.AddParameter<string>(this.Factory, "LocationDiscountValue", model.LocationDiscountValue);
            comm.AddParameter<string>(this.Factory, "LocationDiscountName", model.LocationDiscountName);
            comm.AddParameter<string>(this.Factory, "Note", model.Note);
            comm.AddParameter<string>(this.Factory, "Language", model.Language);
            comm.AddParameter<bool>(this.Factory, "IsActive", model.IsActive);


            comm.SafeExecuteNonQuery();
        }
    }
}
