using App.Application.Interfaces;
using App.Domain.Entities;
using App.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Persistance.Repositories
{
    public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Language?> GetLanguageByCodeAsync(string languageCode)
        {
            return await _context.Set<Language>()
                .FirstOrDefaultAsync(l => l.LanguageCode == languageCode);
        }
    }
}
