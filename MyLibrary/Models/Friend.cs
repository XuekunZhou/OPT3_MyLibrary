#nullable disable
using Microsoft.EntityFrameworkCore;

namespace Models
{
    [Keyless]
    public class Friend
    {
        public ApplicationUser UserOne { get; set; }
        public ApplicationUser UserTwo { get; set; }
    }
}