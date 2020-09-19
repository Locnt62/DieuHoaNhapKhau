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
    public class CustomerProvider : DataAccessBase, ICustomerProvider
    {
        public void Add(Customer item)
        {
            var comm = this.GetCommand("Customer_Add");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "Name", item.Name);
            comm.AddParameter<string>(this.Factory, "Address", item.Address);
            comm.AddParameter<string>(this.Factory, "Email", item.Email);
            comm.AddParameter<string>(this.Factory, "Phone", item.Phone);
            comm.AddParameter<string>(this.Factory, "Username", item.UserName);
            comm.AddParameter<string>(this.Factory, "Password", item.Password);
            comm.AddParameter<int>(this.Factory, "IsActive", item.IsActive);

            comm.SafeExecuteNonQuery();
            /*throw new NotImplementedException();*/
        }

        public Customer Get(Customer dummy)
        {
            var comm = this.GetCommand("Customer_Get");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "CustomerId", dummy.CustomerId);


            var dt = this.GetTable(comm);
            var item = EntityBase.ParseListFromTable<Customer>(dt).FirstOrDefault();
            return item ?? null;
            /*  throw new NotImplementedException();*/
        }

        public List<Customer> GetAll()
        {
            var comm = this.GetCommand("Customer_GetAll");
            if (comm == null) return null;
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Customer>(dt);
            /*throw new NotImplementedException();*/
        }

        public List<Customer> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllActive()
        {
            var comm = this.GetCommand("Customer_GetAllActive");
            if (comm == null) return null;
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Customer>(dt);
          /*  throw new NotImplementedException();*/
        }

        public Customer GetByPhone(string phone)
        {
            var comm = this.GetCommand("Customer_GetByPhone");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Phone", phone);



            var dt = this.GetTable(comm);
            var item = EntityBase.ParseListFromTable<Customer>(dt).FirstOrDefault();
            return item ?? null;
            /* throw new NotImplementedException();*/
        }

        public void Remove(Customer item)
        {
            var comm = this.GetCommand("Customer_Delete");
            if (comm == null) return ;

            comm.AddParameter<int>(this.Factory, "CustomerId", item.CustomerId);
            comm.SafeExecuteNonQuery();
           /* throw new NotImplementedException();*/
        }

        public void Update(Customer @new, Customer old)
        {
            var item = @new;
            var comm = this.GetCommand("Customer_Update");
            if (comm == null) return;


            comm.AddParameter<int>(this.Factory, "CustomerId", old.CustomerId);
            comm.AddParameter<string>(this.Factory, "Name", item.Name);
            comm.AddParameter<string>(this.Factory, "Address", item.Address);
            comm.AddParameter<string>(this.Factory, "Email", item.Email);
            comm.AddParameter<string>(this.Factory, "Phone", item.Phone);
            comm.AddParameter<string>(this.Factory, "Username", item.UserName);
            comm.AddParameter<string>(this.Factory, "Password", item.Password);
            comm.AddParameter<int>(this.Factory, "IsActive", item.IsActive);


            comm.SafeExecuteNonQuery();

            /*throw new NotImplementedException();*/
        }
    }
}
