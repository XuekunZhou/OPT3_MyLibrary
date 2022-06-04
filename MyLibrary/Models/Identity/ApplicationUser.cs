using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MyLibrary.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Range(0,2)]
        public int defaultOverview { get; set; }
        public Boolean listsArePublic { get; set; }

        public ICollection<ApplicationUser>? Friends { get; set; }

        public ApplicationUser()
        {
        }

        public ApplicationUser(string email, string username)
        {
            this.Email = email;
            this.UserName = username;
        }

        public bool IsFriendsWith(ApplicationUser user)
        {
            if (this == user)
            {
                return true;
            }
            if (Friends != null) 
            {
                return Friends.Contains(user);
            }
            return false;
        }

        public void SetDefaultOverview(int period)
        {
            if (period == 0)
                defaultOverview = 0;
            
            else if (period == 1)
                defaultOverview = 1;

            else if (period == 2)
                defaultOverview = 2;
        }

        public void AddFriend(ApplicationUser user)
        {
            if(Friends == null)
            {
                Friends = new List<ApplicationUser>();
            }
            Friends.Add(user);
        }

        public void RemoveFriend(ApplicationUser user)
        {
            if (Friends != null)
            {
                Friends.Remove(user);
            }
        }
    }
}