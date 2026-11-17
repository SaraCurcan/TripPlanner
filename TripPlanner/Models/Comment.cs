using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Comment cannot be empty")]
        public string Text { get; set; } = string.Empty;

        public DateTime PostedAt { get; set; } = DateTime.Now;

        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; } = null!;

        public string? UserId { get; set; }
        public virtual IdentityUser? User { get; set; }

    }
}
