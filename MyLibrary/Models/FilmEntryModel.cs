using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class FilmEntryModel : EntryModel
    {
        [Range(0, int.MaxValue)]
        public int LengthInMinutes { get; set; }
    }
}