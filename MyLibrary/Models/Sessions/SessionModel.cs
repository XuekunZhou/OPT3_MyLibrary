#nullable disable
namespace MyLibrary.Models 
{
    public abstract class SessionModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public DateTime DateOfSession { get; set; }
        public EntryModel Entry { get; set; }
        public ApplicationUser User { get; set; }
    }
}