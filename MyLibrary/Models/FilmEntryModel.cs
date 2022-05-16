using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class FilmEntryModel : EntryModel
    {
        [Range(0, int.MaxValue)]
        public int LengthInMinutes { get; set; }
    }
}