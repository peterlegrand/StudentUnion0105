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
        public DbSet<SuClassificationValueModel> dbClassificationValue { get; set; }
        public DbSet<SuClassificationValueLanguageModel> dbClassificationValueLanguage  { get; set; }
        public DbSet<SuContentTypeLanguageModel> dbContentTypeLanguage { get; set; }
        public DbSet<SuOrganizationLanguageModel> dbOrganizationLanguage { get; set; }
        public DbSet<SuOrganizationModel> dbOrganization { get; set; }
        public DbSet<SuOrganizationStatusModel> dbOrganizationStatus { get; set; }
        public DbSet<SuOrganizationTypeLanguageModel> dbOrganizationTypeLanguage { get; set; }
        public DbSet<SuOrganizationTypeModel> dbOrganizationType { get; set; }
        public DbSet<SuProjectLanguageModel> dbProjectLanguage { get; set; }
        public DbSet<SuProjectModel> dbProject { get; set; }
        public DbSet<SuProjectStatusModel> dbProjectStatus { get; set; }
        public DbSet<SuContentTypeModel> dbContentType { get; set; }
        public DbSet<SuLanguageModel> dbLanguage { get; set; }

        public DbSet<SuClaim> dbClaim { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SuClassificationLevelModel>()
                .HasMany(b => b.ClassificationValues)
                .WithOne(a => a.ClassificationLevel)
                .HasConstraintName("FKClassificationValuestoLevel")//.Metadata.DeleteBehavior = DeleteBehavior.Restrict;
                .HasForeignKey(b => b.ClassificationLevelId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict)
                ;

            //        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            //.SelectMany(t => t.GetForeignKeys())
            //.Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            //        foreach (var fk in cascadeFKs)
            //            fk.DeleteBehavior = DeleteBehavior.Restrict;

            //        base.OnModelCreating(modelBuilder);

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            modelBuilder.Entity<SuClassificationModel>()
                .HasOne(u => u.ClassificationStatus)
                .WithMany(u => u.Classifications) //.Metadata.DeleteBehavior = DeleteBehavior.Restrict;
                .HasForeignKey(u => u.ClassificationStatusId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SuClassificationLevelModel>()
                .HasOne(u => u.Classification)
                .WithMany(u => u.ClassificationLevels) //.Metadata.DeleteBehavior = DeleteBehavior.Restrict;
                .HasForeignKey(u => u.ClassificationId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SuClassificationLevelLanguageModel>()
                .HasOne(u => u.ClassificationLevel)
                .WithMany(u => u.ClassificationLevelLanguages) //.Metadata.DeleteBehavior = DeleteBehavior.Restrict;
                .HasForeignKey(u => u.ClassificationLevelId)
                .OnDelete(DeleteBehavior.Restrict);



            //modelBuilder.Entity<SuClassificationValueModel>()
            //    .HasOne(u => u.ClassificationLevel)
            //    .WithMany(u => u.ClassificationValues)//.Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            //    .HasForeignKey(u => u.ClassificationLevelId)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SuClassificationValueLanguageModel>()
                .HasOne(u => u.ClassificationValue)
                .WithMany(u => u.ClassificationValueLanguages)//.Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            .HasForeignKey(u => u.ClassificationValueId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SuClassificationLanguageModel>()
                .HasOne(u => u.Classification)
                .WithMany(u => u.ClassificationLanguages)
                .HasForeignKey(u => u.ClassificationId)
                .OnDelete(DeleteBehavior.Restrict);

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
