using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.WeekOpdracht.Business.Entities
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }

        [Required]
        public int SenderId { get; set; }

        public virtual User Sender { get; set; }

        public DateTime DateTimeSend { get; set; }
    }
}
