using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces
{
    public interface ISubtitleTranslationRepository : IGenericRepository<SubtitleTranslation>
    {
        Task<List<SubtitleTranslation>> GetTranslationsBySubtitleAsync(string subtitleId);
        Task<List<SubtitleTranslation>> GetTranslationsByLanguageAsync(string languageId);
    }
}
