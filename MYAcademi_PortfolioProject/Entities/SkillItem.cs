
using System.ComponentModel.DataAnnotations;

namespace MYAcademi_PortfolioProject.Entities
{
    public class SkillItem
    {
        public int SkillItemId { get; set; }

        [Required(ErrorMessage = "Yetenek adı zorunludur.")]
        [StringLength(100)]
        [Display(Name = "Yetenek Adı")]
        public string SkillItemTitle { get; set; }

        public List<SkillSkillItem> SkillSkillItems { get; set; } = new();

        public List<ProjectSkillItem> ProjectSkillItems { get; set; } = new();
    }
}
