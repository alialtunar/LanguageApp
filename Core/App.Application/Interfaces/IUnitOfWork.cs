using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IVideoRepository VideoRepository { get; }
        ILanguageRepository LanguageRepository { get; }
        ISubtitleRepository SubtitleRepository { get; }
        ISubtitleTranslationRepository SubtitleTranslationRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
