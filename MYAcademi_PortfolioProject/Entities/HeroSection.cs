using System.ComponentModel.DataAnnotations;

namespace MYAcademi_PortfolioProject.Entities
{
    public class HeroSection
    {
        public int HeroSectionId { get; set; }

        [Required(ErrorMessage = "Karşılama yazısı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Karşılama yazısı en fazla 100 karakter olabilir.")]
        public string Greeting { get; set; }

        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        [StringLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fotoğraf yolu boş bırakılamaz.")]
        public string MainImageUrl { get; set; }
    }
}