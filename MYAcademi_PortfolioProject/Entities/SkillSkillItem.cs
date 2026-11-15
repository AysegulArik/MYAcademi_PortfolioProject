
using System.ComponentModel.DataAnnotations;

namespace MYAcademi_PortfolioProject.Entities
{
    public class SkillSkillItem
    {
        [Required]
        [Display(Name = "Yetenek")]
        public int SkillId { get; set; }

        public Skill Skill { get; set; } = null!;

        [Required]
        [Display(Name = "Yetenek Detayı")]
        public int SkillItemId { get; set; }

        public SkillItem SkillItem { get; set; } = null!;
    }
}
