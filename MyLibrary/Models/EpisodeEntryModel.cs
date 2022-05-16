using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class EpisodeEntryModel: EntryModel
    {
        [Range(0, int.MaxValue)]
        public int LengthInMin { get; set; }

        public SeriesEntryModel MyProperty { get; set; }
    }
}