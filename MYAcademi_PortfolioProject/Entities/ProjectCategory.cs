
using System.ComponentModel.DataAnnotations;

namespace MYAcademi_PortfolioProject.Entities
{
    public class ProjectCategory
    {
        [Required]
        [Display(Name = "Proje")]
        public int ProjectId { get; set; }

        public Project Project { get; set; } = null!;

        [Required]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}
