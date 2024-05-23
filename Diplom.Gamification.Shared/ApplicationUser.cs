using Microsoft.AspNetCore.Identity;

namespace Diplom.Gamification.Shared
{
    public class ApplicationUser : IdentityUser
    {
        public int Rating { get; set; }
        public string? AvatarLink { get; set; }
    }
}
