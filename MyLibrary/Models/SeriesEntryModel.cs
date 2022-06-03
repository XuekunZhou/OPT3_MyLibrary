namespace MyLibrary.Models
{
    public class SeriesEntryModel: EntryModel
    {
        public ICollection<EpisodeModel>? Episodes { get; set; }
        public int Size { get; set; }
    }
}