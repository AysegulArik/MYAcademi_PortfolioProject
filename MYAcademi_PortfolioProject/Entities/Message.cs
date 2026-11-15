
using System.ComponentModel.DataAnnotations;

namespace MYAcademi_PortfolioProject.Entities
{
    public class Message
    {
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Gönderen adı zorunludur.")]
        [StringLength(100)]
        [Display(Name = "Gönderen Adı")]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [StringLength(150)]
        [Display(Name = "Gönderen E-posta")]
        public string SenderEmail { get; set; }

        [Required(ErrorMessage = "Konu alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Konu")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj alanı zorunludur.")]
        [StringLength(2000)]
        [Display(Name = "Mesaj Detayı")]
        public string MessageDetail { get; set; }

        [Display(Name = "Gönderim Tarihi")]
        public DateTime SendDate { get; set; }

        [Display(Name = "Okundu mu?")]
        public bool IsRead { get; set; }
    }
}
