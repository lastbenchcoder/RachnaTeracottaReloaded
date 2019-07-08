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
    public class InvitationsController : ApiController
    {
        protected IUnityContainer container;

        public InvitationsController(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        // GET: api/Store
        public IEnumerable<Invitations> Get()
        {
            bInvitations _bInvitations = container.Resolve<bInvitations>();
            return _bInvitations.List();
        }

        // GET: api/Store/5
        public Invitations Get(int id)
        {
            return container.Resolve<bInvitations>().Detail(id);
        }

        // POST: api/Store
        public Invitations Post([FromBody]Invitations value)
        {
            bInvitations abc = container.Resolve<bInvitations>();
            value = abc.Create(value);
            return value;
        }

        // PUT: api/Store/5
        public Invitations Put(int id, [FromBody]Invitations value)
        {
            bInvitations abc = container.Resolve<bInvitations>();
            Invitations invitations = abc.Detail(id);

            invitations.Invitation_Status = value.Invitation_Status;
            invitations.Role = value.Role;
            invitations.Send_Activity_Mail = value.Send_Activity_Mail;
            invitations.Store_Id = value.Store_Id;
            invitations.Invitation_UpdatedDate = DateTime.Now;

            invitations = abc.Update(invitations);
            return invitations;
        }
    }
}
