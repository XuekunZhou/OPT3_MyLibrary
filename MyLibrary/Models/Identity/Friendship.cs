#nullable disable
using Microsoft.EntityFrameworkCore;

namespace MyLibrary.Models
{

    public class Friendship
    {
        public int Id { get; set; }
        public ApplicationUser UserOne { get; set; }
        public ApplicationUser UserTwo { get; set; }
    }
}