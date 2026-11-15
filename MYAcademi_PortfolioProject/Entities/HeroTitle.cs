using System.ComponentModel.DataAnnotations;

namespace MYAcademi_PortfolioProject.Entities
{
    public class HeroTitle
    {
        public int HeroTitleId { get; set; }

        [Required(ErrorMessage = "Başlık alanı boş bırakılamaz.")]
        public string Title { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }

    }
}
