﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Common.Entities
{
    public class ProductFeatures
    {
        [Key]
        [Column(Order = 0)]
        public int Product_Feature_Id { get; set; }
        [MaxLength(50)]
        public string Product_Feature_Code { get; set; }
        public int Product_Id { get; set; }
        public int Administrators_Id { get; set; }
        [MaxLength(50)]
        public string Product_Feature_Type { get; set; }
        public DateTime Product_Feature_CreatedDate { get; set; }
        public DateTime Product_Feature_UpdatedDate { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        public Administrators Admin { get; set; }
        public Product Product { get; set; }
    }
}