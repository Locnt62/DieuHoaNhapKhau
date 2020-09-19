using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class NewsProvider : DataAccessBase, INewsProvider
    {
        public void Add(News item)
        {
            var comm = this.GetCommand("sp_News_Insert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "NewTitle", item.NewTitle);
            comm.AddParameter<string>(this.Factory, "NewShortName", item.NewShortName);
            comm.AddParameter<string>(this.Factory, "NewBody", item.NewBody);
            comm.AddParameter<string>(this.Factory, "NewImage", item.NewImage);
            comm.AddParameter<string>(this.Factory, "NewKeyword", item.NewKeyword);
            comm.AddParameter<int>(this.Factory, "CountView", item.CountView);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<int>(this.Factory, "NewCategoryId", item.NewCategoryId);
            comm.AddParameter<string>(this.Factory, "NewSummary", item.NewSummary);
            comm.AddParameter<int>(this.Factory, "IsHot", item.IsHot);
            comm.AddParameter<string>(this.Factory, "Language", item.Language);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.SafeExecuteNonQuery();
            /* throw new NotImplementedException();*/
        }

        public News Get(News dummy)
        {
            var comm = this.GetCommand("sp_News_Get");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "NewId", dummy.NewsId);
            var dt = this.GetTable(comm);
            var html = EntityBase.ParseListFromTable<News>(dt).FirstOrDefault();
            return html ?? null;
            /*throw new NotImplementedException();*/
        }

        public List<News> GetAll(int startIndex, int length, ref int total, string lang)
        {
            var comm = this.GetCommand("sp_News_GetAll");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "Length", length);
            comm.AddParameter<string>(this.Factory, "Language", lang);
            var totalItem = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItem.Direction = ParameterDirection.Output;
            var dt = this.GetTable(comm);
            if (totalItem.Value != DBNull.Value)
            {
                total = Convert.ToInt32(totalItem.Value);
            }
            return EntityBase.ParseListFromTable<News>(dt);

            /* throw new NotImplementedException();*/
        }

        public List<News> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<News> GetAllActive(int startIndex, int length, ref int total, string lang)
        {
            /* throw new NotImplementedException();*/
            var comm = this.GetCommand("sp_News_GetAllActive");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "Length", length);
            comm.AddParameter<string>(this.Factory, "Language", lang);
            var totalItem = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItem.Direction = ParameterDirection.Output;
            var dt = this.GetTable(comm);
            if (totalItem.Value != DBNull.Value)
            {
                total = Convert.ToInt32(totalItem.Value);
            }
            return EntityBase.ParseListFromTable<News>(dt);

        }

        public List<News> GetAllByCate(int id, int startIndex, int length, ref int total, string lang)
        {
            /*throw new NotImplementedException();*/
            var comm = this.GetCommand("sp_News_GetAllByCate");
            if(comm ==null) { return null; }
            comm.AddParameter<int>(this.Factory, "NewCategoryId", id);
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "Length", length);
            comm.AddParameter<string>(this.Factory, "Language", lang);
            var totalItem = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItem.Direction = ParameterDirection.Output;

            var dt = this.GetTable(comm);
            if (totalItem.Value != DBNull.Value)
            {
                total = Convert.ToInt32(totalItem.Value);
            }
            return EntityBase.ParseListFromTable<News>(dt);
        }

        public News GetByShortName(string shortname, string lang)
        {
            /*throw new NotImplementedException();*/
            var comm = this.GetCommand("sp_News_GetByShortName");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "NewShortName", shortname);
            comm.AddParameter<string>(this.Factory, "Language", lang);
            var dt = this.GetTable(comm);
            var html = EntityBase.ParseListFromTable<News>(dt).FirstOrDefault();
            return html ?? null;

        }

        public List<News> GetByShortNameCate(string name, int startIndex, int length, ref int total, string lang)
        {
            /* throw new NotImplementedException();*/
            var comm = this.GetCommand("sp_News_GetByShortNameCate");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "NewCateShortName", name);
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "Length", length);
            comm.AddParameter<string>(this.Factory, "Language", lang);
            var totalItem = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItem.Direction = ParameterDirection.Output;
            var dt = this.GetTable(comm);
            if (totalItem.Value != DBNull.Value)
            {
                total = Convert.ToInt32(totalItem.Value);
            }
            return EntityBase.ParseListFromTable<News>(dt);

        }

        public void Remove(News item)
        {
            /* throw new NotImplementedException();*/
            var comm = this.GetCommand("sp_News_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewId", item.NewsId);
            comm.SafeExecuteNonQuery();
        }

        public List<News> Search(int startIndex, int length, ref int total, string lang)
        {
            /*throw new NotImplementedException();*/
            var comm = this.GetCommand("sp_News_Search");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "Length", length);
            comm.AddParameter<string>(this.Factory, "Language", lang);
            var totalItem = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItem.Direction = ParameterDirection.Output;
            var dt = this.GetTable(comm);
            if (totalItem.Value != DBNull.Value)
            {
                total = Convert.ToInt32(totalItem.Value);
            }
            return EntityBase.ParseListFromTable<News>(dt);
        }

        public void Update(News @new, News old)
        {
            var item = @new;
            item.NewsId = old.NewsId;
            var comm = this.GetCommand("sp_News_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewId", old.NewsId);
            comm.AddParameter<string>(this.Factory, "NewTitle", item.NewTitle);
            comm.AddParameter<string>(this.Factory, "NewShortName", item.NewShortName);
            comm.AddParameter<string>(this.Factory, "NewBody", item.NewBody);
            comm.AddParameter<string>(this.Factory, "NewImage", item.NewImage);
            comm.AddParameter<string>(this.Factory, "NewKeyword", item.NewKeyword);
            comm.AddParameter<int>(this.Factory, "CountView", item.CountView);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "NewCategoryId", item.NewCategoryId);
            comm.AddParameter<string>(this.Factory, "NewSummary", item.NewSummary);
            comm.AddParameter<int>(this.Factory, "IsHot", item.IsHot);
            comm.AddParameter<string>(this.Factory, "Language", item.Language);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.SafeExecuteNonQuery();
            /*throw new NotImplementedException();*/
        }
    }
}
