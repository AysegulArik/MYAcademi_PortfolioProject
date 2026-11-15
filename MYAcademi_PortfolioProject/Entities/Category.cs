
using System.ComponentModel.DataAnnotations;

namespace MYAcademi_PortfolioProject.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir.")]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Kategori kısa adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Kategori kısa adı en fazla 100 karakter olabilir.")]
        [Display(Name = "Kategori Slug")]
        public string CategorySlug { get; set; }

        public List<ProjectCategory> ProjectCategories { get; set; } = new();
    }
}
