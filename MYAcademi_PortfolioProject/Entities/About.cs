
using System.ComponentModel.DataAnnotations;

namespace MYAcademi_PortfolioProject.Entities
{
    public class About
    {
        public int AboutId { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        [Display(Name = "Birinci Açıklama")]
        public string Description { get; set; }

        [Required(ErrorMessage = "İkinci açıklama alanı zorunludur.")]
        [StringLength(1000, ErrorMessage = "İkinci açıklama en fazla 1000 karakter olabilir.")]
        [Display(Name = "İkinci Açıklama")]
        public string Description2 { get; set; }

        [Required(ErrorMessage = "Görsel yolu zorunludur.")]
        [Display(Name = "Profil Görseli")]
        public string ImageUrl { get; set; }

        [Display(Name = "Deneyim")]
        public string Experience { get; set; }

        [Display(Name = "Eğitim Sayısı")]
        public string EducationCount { get; set; }

        [Display(Name = "Öğrenci Sayısı")]
        public string StudentCount { get; set; }

        [StringLength(500, ErrorMessage = "Profil bilgisi en fazla 500 karakter olabilir.")]
        [Display(Name = "Profil Bilgisi")]
        public string? ProfileInfo { get; set; }

        [StringLength(100, ErrorMessage = "Pozisyon en fazla 100 karakter olabilir.")]
        [Display(Name = "Pozisyon Başlığı")]
        public string? PositionTitle { get; set; }

        [Display(Name = "Özgeçmiş Bağlantısı")]
        public string? ResumeUrl { get; set; }
    }
}
