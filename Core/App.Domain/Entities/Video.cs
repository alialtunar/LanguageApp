using App.Domain.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace App.Domain.Entities
{
    public class Video:BaseEntity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public TimeSpan Duration { get; set; }
        public ICollection<Sentence> Sentences { get; set; } = new List<Sentence>();

    }
}
