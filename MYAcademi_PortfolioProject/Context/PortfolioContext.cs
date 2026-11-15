using Microsoft.EntityFrameworkCore;
using MYAcademi_PortfolioProject.Entities;

namespace MYAcademi_PortfolioProject.Context
{
    public class PortfolioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-N0BN8PV\\SQLEXPRESS; Database=PortfolioDayDb; integrated security=True; Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Project - Category ilişkisi
            modelBuilder.Entity<ProjectCategory>()
                .HasKey(x => new { x.ProjectId, x.CategoryId });

            modelBuilder.Entity<ProjectCategory>()
                .HasOne(x => x.Project)
                .WithMany(x => x.ProjectCategories)
                .HasForeignKey(x => x.ProjectId);

            modelBuilder.Entity<ProjectCategory>()
                .HasOne(x => x.Category)
                .WithMany(x => x.ProjectCategories)
                .HasForeignKey(x => x.CategoryId);


            // Project - SkillItem ilişkisi
            modelBuilder.Entity<ProjectSkillItem>()
                .HasKey(x => new { x.ProjectId, x.SkillItemId });

            modelBuilder.Entity<ProjectSkillItem>()
                .HasOne(x => x.Project)
                .WithMany(x => x.ProjectSkillItems)
                .HasForeignKey(x => x.ProjectId);

            modelBuilder.Entity<ProjectSkillItem>()
                .HasOne(x => x.SkillItem)
                .WithMany(x => x.ProjectSkillItems)
                .HasForeignKey(x => x.SkillItemId);
            // Skill - SkillItem ilişkisi
            modelBuilder.Entity<SkillSkillItem>()
                .HasKey(x => new { x.SkillId, x.SkillItemId });

            modelBuilder.Entity<SkillSkillItem>()
     .HasOne(x => x.Skill)
     .WithMany(x => x.SkillSkillItems)
     .HasForeignKey(x => x.SkillId)
     .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SkillSkillItem>()
                .HasOne(x => x.SkillItem)
                .WithMany(x => x.SkillSkillItems)
                .HasForeignKey(x => x.SkillItemId);
        }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<HeroSection> HeroSections { get; set; }
        public DbSet<HeroTitle> HeroTitles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillItem> SkillItems { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }

        public DbSet<ProjectSkillItem> ProjectSkillItems { get; set; }
        public DbSet<SkillSkillItem> SkillSkillItems { get; set; }
        public DbSet<About> Abouts { get; set; }


    }
}
