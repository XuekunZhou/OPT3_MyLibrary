namespace MyLibrary.Models
{
    public class SeriesEntryModel: EntryModel
    {
        public ICollection<EpisodeEntryModel>? Episodes { get; set; }

    }
}