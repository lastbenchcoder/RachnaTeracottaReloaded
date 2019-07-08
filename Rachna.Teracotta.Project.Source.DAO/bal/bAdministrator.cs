using Rachna.Teracotta.Project.Source.Common.Entities;
using Rachna.Teracotta.Project.Source.DAO.Helper;
using Rachna.Teracotta.Project.Source.DAO.interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.DAO.bal
{
    public  class bAdministrator
    {
        iAdministrator _administrator;
        public bAdministrator(iAdministrator administrator)
        {
            _administrator = administrator;
        }
        public  Administrators Create(Administrators administrators)
        {            
            administrators = _administrator.Create(administrators);
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Administrator", "New Administrator " + administrators.EmailId +
                    "( " + administrators.Administrators_Id + "  and " + administrators.AdminCode + " ) created successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New Administrator Created", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return administrators;
        }

        public  EmailTracker CreateEmailTracker(EmailTracker EmailTracker)
        {           
            return _administrator.CreateEmailTracker(EmailTracker);
        }

        public  List<Administrators> List()
        {           
            return _administrator.List();
        }

        public  List<EmailTracker> ListEmailTracker()
        {
            return _administrator.ListEmailTracker();
        }

        public  Administrators Update(Administrators administrators)
        {
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Administrator", "Administrator Updation done on " + administrators.EmailId +
                    "( " + administrators.Administrators_Id + "  and " + administrators.AdminCode + " ) successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Administrator Updation", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _administrator.Update(administrators);
        }

        public  int CreateChatMessage(AdminChatting adminChatting)
        {
            return _administrator.CreateChatMessage(adminChatting);
        }

        public  List<AdminChatting> ListChatMessage()
        {
            return _administrator.ListChatMessage();
        }

        public  AdminActivity Create(AdminActivity adminActivity)
        {
            return _administrator.CreateActivity(adminActivity);
        }

        public  List<AdminActivity> ListActivity()
        {
            return _administrator.ListActivity();
        }

        public  List<AdminActivity> ListActivityByAdmin(int adminId)
        {
            return _administrator.ListActivityByAdmin(adminId);
        }

        public Administrators Detail(int id)
        {
            return _administrator.Detail(id);
        }
    }
}