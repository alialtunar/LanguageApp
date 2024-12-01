using App.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Translation:BaseEntity
    {
        public string SentenceId { get; set; }
        public Sentence Sentence { get; set; }
        public string LanguageId { get; set; }
        public Language Language { get; set; }
        public string TranslationText { get; set; } = string.Empty;
    }
}
