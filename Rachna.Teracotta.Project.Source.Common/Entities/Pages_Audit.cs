﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Common.Entities
{
    public class Pages_Audit
    {
        [Key]
        public int Page_Audit_Id { get; set; }
        public int Page_Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        public int Administrators_Id { get; set; }
    }
}