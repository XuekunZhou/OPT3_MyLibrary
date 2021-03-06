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
            if (this != user && Friends != null)
            {
                return Friends.Contains(user);
            }

             return true;
        }

        public void SetPrivacy(bool set)
        {
            listsArePublic = set;
        }

        public void SetDefaultOverview(int period)
        {
            defaultOverview = period;
        }

        public void AddFriend(ApplicationUser user)
        {
            if(Friends != null)
            {
                Friends.Add(user);
            }
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