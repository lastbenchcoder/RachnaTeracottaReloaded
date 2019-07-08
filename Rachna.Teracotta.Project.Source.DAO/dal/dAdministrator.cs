using Rachna.Teracotta.Project.Source.Common.Entities;
using Rachna.Teracotta.Project.Source.DAO.App_Data;
using Rachna.Teracotta.Project.Source.DAO.Helper;
using Rachna.Teracotta.Project.Source.DAO.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.DAO.dal
{
    public class dAdministrator : iAdministrator
    {
        public RachnaDBContext context;
        public dAdministrator()
        {
            context = new RachnaDBContext();
        }

        public Administrators Create(Administrators administrators)
        {
            try
            {
                int maxAdministratorsId = 0;
                if (context.Administrator.ToList().Count > 0)
                    maxAdministratorsId = context.Administrator.Max(m => m.Administrators_Id);
                maxAdministratorsId = (maxAdministratorsId > 0) ? (maxAdministratorsId + 1) : 1;
                administrators.AdminCode = "RT" + maxAdministratorsId + "ADMCODE" + (maxAdministratorsId + 1);

                administrators.Password = PasswordProtect.Encrypt(administrators.Password);
                administrators.Admin_CreatedDate = DateTime.Now;
                administrators.Admin_UpdatedDate = DateTime.Now;
                context.Administrator.Add(administrators);
                context.SaveChanges();
                return administrators;
            }
            catch (Exception ex)
            {
                administrators.ErrorMessage = ex.Message;
                return administrators;
            }
        }

        public EmailTracker CreateEmailTracker(EmailTracker EmailTracker)
        {
            context.EmailTracker.Add(EmailTracker);
            context.SaveChanges();
            return EmailTracker;
        }

        public List<Administrators> List()
        {
            List<Administrators> administrators = new List<Administrators>();
            try
            {
                administrators = context.Administrator.Include("Store").ToList();
                return administrators;
            }
            catch (Exception ex)
            {
                administrators[0].ErrorMessage = ex.Message;
                return administrators;
            }
        }

        public List<EmailTracker> ListEmailTracker()
        {
            List<EmailTracker> EmailTracker = new List<EmailTracker>();
            EmailTracker = context.EmailTracker.ToList();
            return EmailTracker;
        }

        public Administrators Update(Administrators administrators)
        {
            try
            {
                administrators.Password = PasswordProtect.Encrypt(administrators.Password);
                var entity = context.Administrator.Where(c => c.Administrators_Id == administrators.Administrators_Id).AsQueryable().FirstOrDefault();
                if (entity == null)
                {
                    context.Administrator.Add(administrators);
                }
                else
                {
                    context.Entry(entity).CurrentValues.SetValues(administrators);
                }

                context.SaveChanges();
                return administrators;
            }
            catch (Exception ex)
            {
                administrators.ErrorMessage = ex.Message;
                return administrators;
            }
        }

        public int CreateChatMessage(AdminChatting adminChatting)
        {
            try
            {
                context.AdminChatting.Add(adminChatting);
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                return 404;
            }
        }

        public List<AdminChatting> ListChatMessage()
        {
            List<AdminChatting> adminChatting = new List<AdminChatting>();
            try
            {
                adminChatting = context.AdminChatting.Include("Administrators").ToList();
                return adminChatting;
            }
            catch (Exception ex)
            {
                adminChatting[0].ErrorMessage = ex.Message;
                return adminChatting;
            }
        }

        public AdminActivity CreateActivity(AdminActivity adminActivity)
        {
            try
            {
                context.AdminActivity.Add(adminActivity);
                context.SaveChanges();
                return adminActivity;
            }
            catch (Exception ex)
            {
                adminActivity.ErrorMessage = ex.Message;
                return adminActivity;
            }
        }

        public List<AdminActivity> ListActivity()
        {
            List<AdminActivity> administrators = new List<AdminActivity>();
            try
            {
                administrators = context.AdminActivity.Include("Administrators").ToList();
                return administrators;
            }
            catch (Exception ex)
            {
                administrators[0].ErrorMessage = ex.Message;
                return administrators;
            }
        }

        public List<AdminActivity> ListActivityByAdmin(int adminId)
        {
            List<AdminActivity> administrators = new List<AdminActivity>();
            try
            {
                administrators = context.AdminActivity.Include("Administrators").Where(m => m.Administrators_Id == adminId).ToList();
                return administrators;
            }
            catch (Exception ex)
            {
                administrators[0].ErrorMessage = ex.Message;
                return administrators;
            }
        }

        public Administrators Detail(int id)
        {
            return context.Administrator.Where(m => m.Administrators_Id == id).FirstOrDefault();
        }
    }
}