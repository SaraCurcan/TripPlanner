using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The title is required")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "The destination is required")]
        public string Destination { get; set; } = string.Empty;

        [Required(ErrorMessage = "The description is required")]
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? OrganizerId { get; set; }

        public virtual IdentityUser? Organizer { get; set; }
        public virtual ICollection<IdentityUser> Participants { get; set; } = new List<IdentityUser>();
        public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    }
}
