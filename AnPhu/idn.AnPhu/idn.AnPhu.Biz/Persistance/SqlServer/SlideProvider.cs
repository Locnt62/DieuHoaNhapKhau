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
    public class SlideProvider : DataAccessBase, ISlideProvider
    {
        public void Add(Slide item)
        {
            var comm = this.GetCommand("sp_SlideBanner_Insert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "SlideBannerImage", item.SlideBannerImage);
            comm.AddParameter<string>(this.Factory, "SlideBannerDes", item.SlideBannerDes);
            comm.AddParameter<string>(this.Factory, "Note", item.Note);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<string>(this.Factory, "Language", item.Language);


            comm.SafeExecuteNonQuery();

            /* throw new NotImplementedException();*/
        }

        public Slide Get(Slide dummy)
        {
            /*throw new NotImplementedException();*/
            var comm = this.GetCommand("sp_SlideBanner_Get");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "SlideBannerId", dummy.SlideBannerId);
            var dt = this.GetTable(comm);
            var html = EntityBase.ParseListFromTable<Slide>(dt).FirstOrDefault();
            return html ?? null;
        }

        public List<Slide> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<Slide> GetAllActive(string lang)
        {
            /*throw new NotImplementedException();*/
            var comm = this.GetCommand("sp_SlideBanner_GetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Language", lang);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Slide>(dt);
        }

        public void Remove(Slide item)
        {
            var comm = this.GetCommand("sp_SlideBanner_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "SlideBannerId", item.SlideBannerId);
            comm.SafeExecuteNonQuery();
            /*   throw new NotImplementedException();*/
        }

        public List<Slide> Search(string lang)
        {
            var comm = this.GetCommand("sp_SlideBanner_Search");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Language", lang);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Slide>(dt);
            /* throw new NotImplementedException();*/
        }

        public void Update(Slide @new, Slide old)
        {
            var item = @new;
            var comm = this.GetCommand("sp_SlideBanner_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "SlideBannerId", old.SlideBannerId);
            comm.AddParameter<string>(this.Factory, "SlideBannerImage", item.SlideBannerImage);
            comm.AddParameter<string>(this.Factory, "SlideBannerDes", item.SlideBannerDes);
            comm.AddParameter<string>(this.Factory, "Note", item.Note);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Language", item.Language);
            comm.SafeExecuteNonQuery();
            /*   throw new NotImplementedException();*/
        }
    }
}
