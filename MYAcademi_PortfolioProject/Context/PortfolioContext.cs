using Microsoft.EntityFrameworkCore;
using MYAcademi_PortfolioProject.Entities;

namespace MYAcademi_PortfolioProject.Context
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<HeroSection> HeroSections { get; set; }
        public DbSet<HeroTitle> HeroTitles { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
