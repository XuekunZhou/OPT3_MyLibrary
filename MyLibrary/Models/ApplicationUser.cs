using Microsoft.AspNetCore.Identity;

namespace Models 
{
    public class ApplicationUser: IdentityUser
    {
        public Boolean listsArePublic { get; set; }

        public ICollection<ApplicationUser>? Friends { get; set; }
    }
}