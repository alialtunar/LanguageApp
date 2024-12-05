using App.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Language:BaseEntity
    {
        public string LanguageName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public ICollection<Video> Videos { get; set; } = new List<Video>();
        public ICollection<Subtitle> Subtitles { get; set; } = new List<Subtitle>();
        public ICollection<SubtitleTranslation> Translations { get; set; } = new List<SubtitleTranslation>();

    }
}
