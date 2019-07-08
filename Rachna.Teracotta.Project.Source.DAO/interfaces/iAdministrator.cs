using Rachna.Teracotta.Project.Source.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachna.Teracotta.Project.Source.DAO.interfaces
{
    public interface iAdministrator
    {
        Administrators Create(Administrators administrators);
        EmailTracker CreateEmailTracker(EmailTracker EmailTracker);
        List<Administrators> List();
        Administrators Detail(int id);
        List<EmailTracker> ListEmailTracker();
        Administrators Update(Administrators administrators);
        int CreateChatMessage(AdminChatting adminChatting);
        List<AdminChatting> ListChatMessage();
        AdminActivity CreateActivity(AdminActivity adminActivity);
        List<AdminActivity> ListActivity();
        List<AdminActivity> ListActivityByAdmin(int adminId);
    }
}
