﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Common.Entities
{
    public class FunctionalDefectStory
    {
        [Key]
        public int FunctionalDefectStory_Id { get; set; }
        [MaxLength(50)]
        public string FunDefectStryCode { get; set; }
        public int Defect_Id { get; set; }
        public int Administrators_Id { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        [MaxLength(500)]
        public string Banner { get; set; }
        public int Resolver_Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FixDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        public FunctionalDefect FunctionalDefect { get; set; }
        public Administrators Administrators { get; set; }
        [NotMapped]
        public Administrators Resolver { get; set; }
    }
}