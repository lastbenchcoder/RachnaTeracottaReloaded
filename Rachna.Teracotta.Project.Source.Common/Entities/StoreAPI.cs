using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachna.Teracotta.Project.Source.Common.Entities
{
    [Table("tbl_api")]
    public class StoreAPI
    {
        [Key]
        [Column("api_id")]
        public int API_Id { get; set; }

        [MaxLength(50)]
        [Column("category")]
        public string Category { get; set; }

        [MaxLength(50)]
        [Column("title")]
        public string Title { get; set; }

        [MaxLength(500)]
        [Column("description")]
        public string Description { get; set; }

        [MaxLength(500)]
        [Column("url")]
        public string URL { get; set; }

        [MaxLength(50)]
        [Column("content_type")]
        public string Type { get; set; }

        [Column("input_json")]
        public string Input_JSON { get; set; }

        [MaxLength(50)]
        [Column("developed_by")]
        public string DevelopedBy { get; set; }

        [MaxLength(50)]
        [Column("status")]
        public string Status { get; set; }

        [Column("datecreated")]
        public string DateCreated { get; set; }

        [Column("dateupdated")]
        public string DateUpdated { get; set; }
    }
}
