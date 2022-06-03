#nullable disable
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class EpisodeEntryModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateOfEntry { get; set; }
        public SeriesEntryModel Series { get; set; }
        public ApplicationUser User { get; set; }
    }
}