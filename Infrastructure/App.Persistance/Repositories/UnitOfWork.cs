using App.Application.Interfaces;
using App.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        //private IProductRepository _productRepository;
        //private ICategoryRepository _categoryRepository;
        private IVideoRepository _videoRepository;
        private ISubtitleTranslationRepository _subtitleTranslationRepository;
        private ILanguageRepository _languageRepository;
        private ISubtitleRepository _subtitleRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        //public IProductRepository Products =>
        //    _productRepository ??= new ProductRepository(_context);

        //public ICategoryRepository Categories =>
        //    _categoryRepository ??= new CategoryRepository(_context);

        public IVideoRepository VideoRepository =>
        _videoRepository ??= new VideoRepository(_context);

        public ISubtitleRepository SubtitleRepository =>
        _subtitleRepository ??= new SubtitleRepository(_context);

        public ISubtitleTranslationRepository SubtitleTranslationRepository =>
    _subtitleTranslationRepository ??= new SubtitleTranslationRepository(_context);

        public ILanguageRepository LanguageRepository =>
    _languageRepository ??= new LanguageRepository(_context);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
