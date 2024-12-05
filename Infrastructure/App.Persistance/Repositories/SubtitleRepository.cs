using App.Application.Interfaces;
using App.Domain.Entities;
using App.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Persistance.Repositories
{
    public class SubtitleRepository : GenericRepository<Subtitle>, ISubtitleRepository
    {
        public SubtitleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Subtitle>> GetSubtitlesByVideoAsync(string videoId)
        {
            return await _context.Subtitles
                .Include(s => s.Language)
                .Include(s => s.Translations)
                    .ThenInclude(t => t.Language)
                .Where(s => s.VideoId == videoId)
                .ToListAsync();
        }

        public async Task<List<Subtitle>> GetSubtitlesByLanguageAsync(string languageId)
        {
            return await _context.Subtitles
                .Include(s => s.Video)
                .Include(s => s.Translations)
                .Where(s => s.LanguageId == languageId)
                .ToListAsync();
        }
    }
}
