using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.WeekOpdracht.Business.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
    }
}
