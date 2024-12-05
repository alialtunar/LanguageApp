using App.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Subtitle : BaseEntity
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Text { get; set; } = string.Empty;
        public string VideoId { get; set; }
        public Video Video { get; set; }
        public string LanguageId { get; set; }
        public Language Language { get; set; }
        public ICollection<SubtitleTranslation> Translations { get; set; } = new List<SubtitleTranslation>();
    }
}

