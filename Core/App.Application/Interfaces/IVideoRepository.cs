using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces
{
    public interface IVideoRepository : IGenericRepository<Video>
    {
        Task<Video?> GetVideoWithSubtitlesAsync(string id);
        Task<List<Video>> GetVideosByLanguageAsync(string languageId);
    }
}
