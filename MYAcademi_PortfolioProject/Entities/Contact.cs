
using System.ComponentModel.DataAnnotations;

namespace MYAcademi_PortfolioProject.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(100)]
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [StringLength(500)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [StringLength(150)]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Konum alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Konum")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [StringLength(20)]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }
    }
}
