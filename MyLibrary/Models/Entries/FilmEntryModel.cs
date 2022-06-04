using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class FilmEntryModel : EntryModel
    {
        [Range(0, int.MaxValue)]
        [Display(Name ="Length (min)")]
        public int LengthInMinutes { get; set; }
    }
}