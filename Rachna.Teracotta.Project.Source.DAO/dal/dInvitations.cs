using Rachna.Teracotta.Project.Source.Common.Entities;
using Rachna.Teracotta.Project.Source.DAO.App_Data;
using Rachna.Teracotta.Project.Source.DAO.Helper;
using Rachna.Teracotta.Project.Source.DAO.interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.DAO.dal
{
    public class dInvitations :iInvitations
    {
        public RachnaDBContext context;
        public dInvitations()
        {
            context = new RachnaDBContext();
        }

        public Invitations Create(Invitations invitations)
        {
            try
            {
                int maxInvitationId = 0;
                if (context.Invitation.ToList().Count > 0)
                    maxInvitationId = context.Invitation.Max(m => m.Invitation_Id);
                maxInvitationId = (maxInvitationId > 0) ? (maxInvitationId + 1) : 1;
                invitations.Invitation_Code = "RT" + maxInvitationId + "INVTCODE" + (maxInvitationId + 1);
                invitations.Invitation_CreatedDate = DateTime.Now;
                invitations.Invitation_UpdatedDate = DateTime.Now;
                context.Invitation.Add(invitations);
                context.SaveChanges();
                return invitations;
            }
            catch (Exception ex)
            {
                invitations.ErrorMessage = ex.Message;
                return invitations;
            }            
        }

        public List<Invitations> List()
        {
            List<Invitations> invitations = new List<Invitations>();
            try
            {
                invitations = context.Invitation.Include("Store").ToList();
                return invitations;
            }
            catch (Exception ex)
            {
                invitations[0].ErrorMessage = ex.Message;
                return invitations;
            }
        }

        public Invitations Update(Invitations invitations)
        {
            try
            {
                context.Entry(invitations).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return invitations;
            }
            catch (Exception ex)
            {
                invitations.ErrorMessage = ex.Message;
                return invitations;
            }
        }

        public List<Invitations_Audit> AuditList()
        {
            List<Invitations_Audit> invitations = new List<Invitations_Audit>();
            try
            {
                invitations = context.Invitations_Audit.ToList();
                return invitations;
            }
            catch (Exception ex)
            {
                return invitations;
            }
        }

        public Invitations Detail(int invitation_id)
        {
            return context.Invitation.Where(m => m.Store_Id == invitation_id).FirstOrDefault();
        }
    }
}