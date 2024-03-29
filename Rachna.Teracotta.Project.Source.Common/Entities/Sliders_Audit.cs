﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Common.Entities
{
    public class Sliders_Audit
    {
        [Key]
        [Column("slider_audit_id")]
        public int Slider_Audit_Id { get; set; }
        [Column("slider_id")]
        public int Slider_Id { get; set; }
        [MaxLength(50)]
        [Column("slider_code")]
        public string Slider_Code { get; set; }
        [MaxLength(200)]
        [Column("title")]
        public string Slider_TItle { get; set; }
        [MaxLength(250)]
        [Column("description")]
        public string Slider_Description { get; set; }
        [MaxLength(50)]
        [Column("btn_text")]
        public string ButtonText { get; set; }
        [MaxLength(450)]
        [Column("banner")]
        public string Slider_Photo { get; set; }
        [MaxLength(450)]
        [Column("redirect_url")]
        public string Slider_RedirectUrl { get; set; }
        [Column("datecreated")]
        public DateTime Slider_CreatedDate { get; set; }
        [Column("dateupdated")]
        public DateTime Slider_UpdatedDate { get; set; }
        [Column("admin_id")]
        public int Administrators_Id { get; set; }
    }
}