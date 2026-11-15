
using System.ComponentModel.DataAnnotations;

namespace MYAcademi_PortfolioProject.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }

        [Required(ErrorMessage = "Yetenek başlığı zorunludur.")]
        [StringLength(100)]
        [Display(Name = "Yetenek Başlığı")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Yetenek açıklaması zorunludur.")]
        [StringLength(500)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required(ErrorMessage = "İkon yolu zorunludur.")]
        [StringLength(250)]
        [Display(Name = "İkon Yolu")]
        public string IconUrl { get; set; }

        public List<SkillSkillItem> SkillSkillItems { get; set; } = new();
    }
}
