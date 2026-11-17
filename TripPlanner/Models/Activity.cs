using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "The description is required")]
        public string Description { get; set; } = string.Empty;


        public string Status { get; set; } = "To Do";
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string MediaType { get; set; } = "Image";
        public string? MediaPath { get; set; }

        public int TripId { get; set; }
        public virtual Trip Trip { get; set; } = null!;

        public string? AssignedUserId { get; set; }
        public virtual IdentityUser? AssignedUser { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
