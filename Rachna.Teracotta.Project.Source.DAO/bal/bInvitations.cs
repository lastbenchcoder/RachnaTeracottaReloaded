using Rachna.Teracotta.Project.Source.Common.Entities;
using Rachna.Teracotta.Project.Source.DAO.Helper;
using Rachna.Teracotta.Project.Source.DAO.interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.DAO.bal
{
    public class bInvitations
    {
        iInvitations _iInvitations;
        public bInvitations(iInvitations iInvitations)
        {
            _iInvitations = iInvitations;
        }
        public Invitations Create(Invitations invitations)
        {
            invitations = _iInvitations.Create(invitations);
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Invitations", "New Invitation " + invitations.Invitation_EmailId +
                    "( " + invitations.Invitation_Id + "  and " + invitations.Invitation_Code + " ) created successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New SubCategory Created", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return invitations;
        }
        public List<Invitations> List()
        {
            return _iInvitations.List();
        }
        public Invitations Update(Invitations invitations)
        {
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Invitations", "Invitation Updation done on " + invitations.Invitation_EmailId +
                    "( " + invitations.Invitation_Id + "  and " + invitations.Invitation_Code + " ) successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Invitation Updation", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _iInvitations.Update(invitations);
        }
        public List<Invitations_Audit> AuditList()
        {
            return _iInvitations.AuditList();
        }

        public Invitations Detail(int invitation_id)
        {
            return _iInvitations.Detail(invitation_id);
        }
    }
}