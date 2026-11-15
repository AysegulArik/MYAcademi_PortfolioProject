using System.ComponentModel.DataAnnotations;

namespace MYAcademi_PortfolioProject.Entities
{
    public class Education
    {
        public int EducationId { get; set; }

        [Required(ErrorMessage = "Eğitim seviyesi boş geçilemez.")]
        [MaxLength(50)]
        public string Degree { get; set; }

        [MaxLength(150)]
        public string? SchoolName { get; set; }

        [Required(ErrorMessage = "Bölüm adı boş geçilemez.")]
        [MaxLength(150)]
        public string Department { get; set; }

        [Required(ErrorMessage = "Açıklama alanı boş geçilemez.")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Kategori/Etiket seçilmelidir.")]
        [MaxLength(50)]
        public string Category { get; set; }

    }
}
