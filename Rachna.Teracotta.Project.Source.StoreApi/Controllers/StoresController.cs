using Rachna.Teracotta.Project.Source.Common.Entities;
using Rachna.Teracotta.Project.Source.DAO.bal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace Rachna.Teracotta.Project.Source.StoreApi.Controllers
{
    public class StoresController : ApiController
    {
        protected IUnityContainer container;

        public StoresController(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        // GET: api/Store
        public IEnumerable<Stores> Get()
        {
            bStores _bStores = container.Resolve<bStores>();
            return _bStores.List();
        }

        // GET: api/Store/5
        public Stores Get(int id)
        {
            return container.Resolve<bStores>().Detail(id);
        }

        // POST: api/Store
        public Stores Post([FromBody]Stores value)
        {
            bStores abc = container.Resolve<bStores>();
            value = abc.Create(value);
            return value;
        }

        // PUT: api/Store/5
        public Stores Put(int id, [FromBody]Stores value)
        {
            bStores abc = container.Resolve<bStores>();
            Stores stores = abc.Detail(id);

            stores.Store_Logo = value.Store_Logo;
            stores.Store_Name = value.Store_Name;
            stores.Store_Description = value.Store_Description;
            stores.Store_Status = value.Store_Status;
            stores.Store_UpdatedDate = DateTime.Now;

            stores = abc.Update(stores);
            return stores;
        }
    }
}
