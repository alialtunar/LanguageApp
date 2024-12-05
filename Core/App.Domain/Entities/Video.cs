using App.Domain.Abstract;

namespace App.Domain.Entities
{
    public class Video:BaseEntity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public TimeSpan Duration { get; set; }
        public string LanguageId { get; set; }
        public Language Language { get; set; }
        public ICollection<Subtitle> Subtitles { get; set; } = new List<Subtitle>();

    }
}
