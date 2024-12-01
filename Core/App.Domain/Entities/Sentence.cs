using App.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Sentence:BaseEntity
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string SentenceText { get; set; } = string.Empty;

        public string VideoId { get; set; }
        public Video Video { get; set; }

        public ICollection<Translation> Translations { get; set; } = new List<Translation>();

    }
}
