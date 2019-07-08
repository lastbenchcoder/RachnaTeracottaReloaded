﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Common.Entities
{
    public class Invitations_Audit
    {
        [Key]
        [Column("invitation_audit_id")]
        public int Audit_Invitation_Id { get; set; }
        [Column("invitation_id")]
        public int Invitation_Id { get; set; }
        [MaxLength(50)]
        [Column("invitation_code")]
        public string Invitation_Code { get; set; }
        [MaxLength(15)]
        [Column("role")]
        public string Role { get; set; }
        [Column("store_id")]
        public int Store_Id { get; set; }
        [MaxLength(300)]
        [Column("emailid")]
        public string Invitation_EmailId { get; set; }
        [MaxLength(15)]
        [Column("status")]
        public string Invitation_Status { get; set; }
        [Column("datecreated")]
        public DateTime Invitation_CreatedDate { get; set; }
        [Column("dateupdated")]
        public DateTime Invitation_UpdatedDate { get; set; }
    }
}