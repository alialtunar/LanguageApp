using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces
{
    public interface ISubtitleRepository : IGenericRepository<Subtitle>
    {
        Task<List<Subtitle>> GetSubtitlesByVideoAsync(string videoId);
        Task<List<Subtitle>> GetSubtitlesByLanguageAsync(string languageId);
    }
}
