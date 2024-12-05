using App.Application.Interfaces;
using App.Domain.Entities;
using App.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Persistance.Repositories
{
    public class VideoRepository : GenericRepository<Video>, IVideoRepository
    {
        public VideoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Video?> GetVideoWithSubtitlesAsync(string id)
        {
            return await _context.Videos
                .Include(v => v.Language)
                .Include(v => v.Subtitles)
                    .ThenInclude(s => s.Language)
                .Include(v => v.Subtitles)
                    .ThenInclude(s => s.Translations)
                        .ThenInclude(t => t.Language)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<Video>> GetVideosByLanguageAsync(string languageId)
        {
            return await _context.Videos
                .Include(v => v.Language)
                .Where(v => v.LanguageId == languageId)
                .ToListAsync();
        }
    }
}
