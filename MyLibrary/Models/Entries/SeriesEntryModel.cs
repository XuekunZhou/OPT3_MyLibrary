using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class SeriesEntryModel: EntryModel
    {
        public ICollection<SeriesSessionModel>? Episodes { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name ="Episodes watches")]
        public int TotalEpisodesWatched { get; set; }
    }
}