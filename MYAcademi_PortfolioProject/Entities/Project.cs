
using System.ComponentModel.DataAnnotations;

namespace MYAcademi_PortfolioProject.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Proje başlığı zorunludur.")]
        [StringLength(150)]
        [Display(Name = "Proje Başlığı")]
        public string ProjectTitle { get; set; }

        [Required(ErrorMessage = "Proje açıklaması zorunludur.")]
        [StringLength(1500)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Proje görseli zorunludur.")]
        [StringLength(250)]
        [Display(Name = "Görsel Yolu")]
        public string ImageUrl { get; set; }

        [StringLength(300)]
        [Url(ErrorMessage = "Geçerli bir proje URL'si giriniz.")]
        [Display(Name = "Proje URL")]
        public string? ProjectUrl { get; set; }

        [StringLength(300)]
        [Url(ErrorMessage = "Geçerli bir GitHub URL'si giriniz.")]
        [Display(Name = "GitHub URL")]
        public string? GithubUrl { get; set; }

        [StringLength(100)]
        [Display(Name = "Durum Metni")]
        public string? StatusText { get; set; }

        [StringLength(100)]
        [Display(Name = "Durum İkonu")]
        public string? StatusIcon { get; set; }

        [Display(Name = "Öne Çıkarılsın mı?")]
        public bool IsFeatured { get; set; }

        [Display(Name = "Görüntülenme Sırası")]
        public int DisplayOrder { get; set; }

        public List<ProjectCategory> ProjectCategories { get; set; } = new();

        public List<ProjectSkillItem> ProjectSkillItems { get; set; } = new();
    }
}
