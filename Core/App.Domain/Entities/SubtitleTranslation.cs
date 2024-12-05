using App.Domain.Abstract;

namespace App.Domain.Entities
{
    public class SubtitleTranslation : BaseEntity
    {
        public string SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }
        public string LanguageId { get; set; }
        public Language Language { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
