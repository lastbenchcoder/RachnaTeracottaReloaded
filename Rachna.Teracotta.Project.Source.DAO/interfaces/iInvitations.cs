using Rachna.Teracotta.Project.Source.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachna.Teracotta.Project.Source.DAO.interfaces
{
    public interface iInvitations
    {
        Invitations Create(Invitations invitations);
        List<Invitations> List();
        Invitations Update(Invitations invitations);
        List<Invitations_Audit> AuditList();
        Invitations Detail(int invitation_id);
    }
}
