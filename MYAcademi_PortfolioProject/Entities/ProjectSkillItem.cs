
using System.ComponentModel.DataAnnotations;

namespace MYAcademi_PortfolioProject.Entities
{
    public class ProjectSkillItem
    {
        [Required]
        [Display(Name = "Proje")]
        public int ProjectId { get; set; }

        public Project Project { get; set; } = null!;

        [Required]
        [Display(Name = "Yetenek")]
        public int SkillItemId { get; set; }

        public SkillItem SkillItem { get; set; } = null!;
    }
}
