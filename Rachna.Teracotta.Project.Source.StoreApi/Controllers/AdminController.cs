using Rachna.Teracotta.Project.Source.Common.Entities;
using Rachna.Teracotta.Project.Source.DAO.bal;
using Rachna.Teracotta.Project.Source.DAO.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace Rachna.Teracotta.Project.Source.StoreApi.Controllers
{
    public class AdminController : ApiController
    {
        protected IUnityContainer container;

        public AdminController(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        // GET: api/Admin
        public IEnumerable<Administrators> Get()
        {
            bAdministrator _bAdministrator = container.Resolve<bAdministrator>();
            return _bAdministrator.List();
        }

        // GET: api/Admin/5
        public Administrators Get(int id)
        {
            return container.Resolve<bAdministrator>().Detail(id);
        }

        // POST: api/Admin
        public Administrators Post([FromBody]Administrators value)
        {
            bAdministrator admin = container.Resolve<bAdministrator>();
            value = admin.Create(value);
            return value;
        }

        // PUT: api/Admin/5
        public Administrators Put(int id, [FromBody]Administrators value)
        {
            value.Admin_UpdatedDate = DateTime.Now;
            bAdministrator abc = container.Resolve<bAdministrator>();
            Administrators administrators = abc.Detail(id);

            administrators = value;

            administrators = abc.Update(administrators);
            return administrators;
        }
    }
}
