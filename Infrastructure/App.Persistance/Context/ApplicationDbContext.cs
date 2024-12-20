﻿using App.Domain.Abstract;
using App.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Persistance.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options) { }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Subtitle> Subtitles { get; set; }
        public DbSet<SubtitleTranslation> SubtitleTranslations { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public int MyProperty { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
