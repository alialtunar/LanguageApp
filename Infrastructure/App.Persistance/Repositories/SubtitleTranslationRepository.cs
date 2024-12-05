using App.Application.Interfaces;
using App.Domain.Entities;
using App.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Persistance.Repositories
{
    public class SubtitleTranslationRepository : GenericRepository<SubtitleTranslation>, ISubtitleTranslationRepository
    {
        public SubtitleTranslationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<SubtitleTranslation>> GetTranslationsBySubtitleAsync(string subtitleId)
        {
            return await _context.Set<SubtitleTranslation>()
                .Include(t => t.Language)
                .Where(t => t.SubtitleId == subtitleId)
                .ToListAsync();
        }

        public async Task<List<SubtitleTranslation>> GetTranslationsByLanguageAsync(string languageId)
        {
            return await _context.Set<SubtitleTranslation>()
                .Include(t => t.Subtitle)
                .Where(t => t.LanguageId == languageId)
                .ToListAsync();
        }
    }
}
