using App.Domain.Entities;

namespace App.Application.Interfaces
{
    public interface ILanguageRepository : IGenericRepository<Language>
    {
        Task<Language?> GetLanguageByCodeAsync(string languageCode);
    }
}
