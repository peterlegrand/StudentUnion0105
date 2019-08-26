using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Data
{
    public class SuDbContext : IdentityDbContext<SuUser>
    {
        public SuDbContext(DbContextOptions<SuDbContext> options): base(options)
        {

        }
        public DbSet<SuClassificationModel> dbClassification { get; set; }
        public DbSet<SuClassificationStatusModel> dbClassificationStatus { get; set; }
        public DbSet<SuClassificationLanguageModel> dbClassificationLanguage { get; set; }
        public DbSet<SuClassificationLevelModel> dbClassificationLevel { get; set; }
        public DbSet<SuClassificationLevelLanguageModel> dbClassificationLevelLanguage { get; set; }
        public DbSet<SuLanguageModel> dbLanguage { get; set; }
        public DbSet<SuClaim> dbClaim { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SuClaim>().HasData(
                new SuClaim
                {
                    Id = 1,
                    ClaimGroup = "Classification",
                    Claim = "Classification"
                },

                new SuClaim
                {
                    Id = 3,
                    ClaimGroup = "Classification",
                    Claim = "ClassificationPage"
                },

                new SuClaim
                {
                    Id = 4,
                    ClaimGroup = "Administration",
                    Claim = "Roles"
                },

            new SuClaim
            {
                Id = 2,
                ClaimGroup = "Classification",
                Claim = "ClassificationLevel"
            }
                ) ;
            
        }
    }
}
