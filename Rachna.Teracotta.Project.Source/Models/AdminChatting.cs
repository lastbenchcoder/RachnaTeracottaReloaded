using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rachna.Teracotta.Project.Source.Models
{
    [Table("tbl_admin_chat_message")]
    public class AdminChatting
    {
        [Key]
        [Column("admin_chat_id")]
        public int Admin_Chatting_Id { get; set; }

        [Column("admin_id")]
        public int Administrators_Id { get; set; }

        [MaxLength(450)]
        [Column("chat_message")]
        public string Message { get; set; }

        [Column("datecreated")]
        public DateTime CreatedDate { get; set; }

        [Column("dateupdated")]
        public DateTime UpdatedDate { get; set; }

        [NotMapped]
        public string ErrorMessage;

        public Administrators Administrators { get; set; }
    }
}