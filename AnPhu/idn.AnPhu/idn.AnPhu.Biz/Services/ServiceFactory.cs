using idn.AnPhu.Biz.Persistance.SqlServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
    public class ServiceFactory
    {
        static Hashtable services = new Hashtable();

        static ServiceFactory()
        {
            #region["Auth"]
            services.Add(typeof(Sys_UserManager), new Sys_UserManager(new Sys_UserProvider()));
            services.Add(typeof(Sys_GroupManager), new Sys_GroupManager(new Sys_GroupProvider()));
            services.Add(typeof(CustomerManager), new CustomerManager(new CustomerProvider()));
            services.Add(typeof(LocationDiscountManager), new LocationDiscountManager(new LocationDiscountProvider()));
            services.Add(typeof(LocationManager), new LocationManager(new LocationProvider()));
            services.Add(typeof(ManufactersManager), new ManufactersManager(new ManufactersProvider()));
            services.Add(typeof(NewCategoryManager), new NewCategoryManager(new NewCategoryProvider()));
            services.Add(typeof(NewManager), new NewManager(new NewsProvider()));
            services.Add(typeof(SlideManager), new SlideManager(new SlideProvider()));
            #endregion
        }

        public static T GetService<T>()
        {
            foreach (var service in services.Values)
            {
                if (service is T)
                {
                    return (T)service;
                }
            }
            return default(T);
        }

        public static Sys_UserManager Sys_UserManager
        {
            get
            {
                return (Sys_UserManager)services[typeof(Sys_UserManager)];
            }
            set
            {
                services[typeof(Sys_UserManager)] = value;
            }
        }
        public static Sys_GroupManager Sys_GroupManager
        {
            get
            {
                return (Sys_GroupManager)services[typeof(Sys_GroupManager)];
            }
            set
            {
                services[typeof(Sys_GroupManager)] = value;
            }
        }

        public static CustomerManager CustomerManager
        {
            get
            {
                return (CustomerManager)services[typeof(CustomerManager)];
            }

            set
            {
                services[typeof(CustomerManager)] = value;
            }
        }

        public static LocationDiscountManager LocationDiscountManager
        {
            get
            {
                return (LocationDiscountManager)services[typeof(LocationDiscountManager)];
            }

            set
            {
                services[typeof(LocationDiscountManager)] = value;
            }
        }


        public static LocationManager LocationManager
        {
            get
            {
                return (LocationManager)services[typeof(LocationManager)];
            }

            set
            {
                services[typeof(LocationManager)] = value;
            }
        }


        public static ManufactersManager ManufactersManager
        {
            get
            {
                return (ManufactersManager)services[typeof(ManufactersManager)];
            }

            set
            {
                services[typeof(ManufactersManager)] = value;
            }
        }


        public static NewCategoryManager NewCategoryManager
        {
            get
            {
                return (NewCategoryManager)services[typeof(NewCategoryManager)];
            }

            set
            {
                services[typeof(NewCategoryManager)] = value;
            }
        }


        public static NewManager NewManager
        {
            get
            {
                return (NewManager)services[typeof(NewManager)];
            }

            set
            {
                services[typeof(NewManager)] = value;
            }
        }

        public static SlideManager SlideManager
        {
            get
            {
                return (SlideManager)services[typeof(SlideManager)];
            }

            set
            {
                services[typeof(SlideManager)] = value;
            }
        }
    }
}
