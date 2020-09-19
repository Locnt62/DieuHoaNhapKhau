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
    public class NewCategoryProvider : DataAccessBase, INewCategoryProvider
    {
        public void Add(NewCategory item)
        {
            var comm = this.GetCommand("sp_NewCategory_Insert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "NewCateShortName", item.NewCateShortName);
            comm.AddParameter<string>(this.Factory, "NewCateName", item.NewCateName);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
            comm.AddParameter<string>(this.Factory, "Language", item.Language);
            comm.SafeExecuteNonQuery();
            /* throw new NotImplementedException();*/
        }

        public NewCategory Get(NewCategory dummy)
        {
            var comm = this.GetCommand("sp_NewCategory_Get");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "NewCategoryId", dummy.NewCategoryId);

            var dt = this.GetTable(comm);
            var html = EntityBase.ParseListFromTable<NewCategory>(dt).FirstOrDefault();
            return html ?? null;
            /* throw new NotImplementedException();*/
        }

        public List<NewCategory> GetAll(string lang)
        {
            var comm = this.GetCommand("sp_NewCategory_GetAll");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Language", lang);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<NewCategory>(dt);
            /*throw new NotImplementedException();*/
        }

        public List<NewCategory> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<NewCategory> GetAllActive(string lang)
        {
            var comm = this.GetCommand("sp_NewCategory_GetAllActive");
            comm.AddParameter<string>(this.Factory, "Language", lang);
            if (comm == null) return null;
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<NewCategory>(dt);
            /* throw new NotImplementedException();*/
        }

        public void Remove(NewCategory item)
        {
            var comm = this.GetCommand("sp_NewCategory_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "MewCategoryId", item.NewCategoryId);
            comm.SafeExecuteNonQuery();
            /*throw new NotImplementedException();*/
        }

        public void Update(NewCategory @new, NewCategory old)
        {
            var item = @new;
            var comm = this.GetCommand("sp_NewCategory_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewCategoryId", old.NewCategoryId);
            comm.AddParameter<string>(this.Factory, "NewCateName", item.NewCateName);
            comm.AddParameter<string>(this.Factory, "NewCateShortName", item.NewCateShortName);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
            comm.AddParameter<string>(this.Factory, "Language", item.Language);
            comm.SafeExecuteNonQuery();
            /*    throw new NotImplementedException();*/
        }
    }
}
