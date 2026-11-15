
using System.ComponentModel.DataAnnotations;

namespace MYAcademi_PortfolioProject.Entities
{
    public class Experience
    {
        public int ExperienceId { get; set; }

        [Required(ErrorMessage = "Deneyim başlığı zorunludur.")]
        [StringLength(150)]
        [Display(Name = "Deneyim Başlığı")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Şirket adı zorunludur.")]
        [StringLength(150)]
        [Display(Name = "Şirket Adı")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [StringLength(1000)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(100)]
        [Display(Name = "Kategori")]
        public string CategoryName { get; set; }

        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}
