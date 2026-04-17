using System.ComponentModel.DataAnnotations;

namespace BLOGPOST_ASP_MVC.Models
{
    public class UpdateBlogDTOs
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le champ titre est requis")]
        [MaxLength(50, ErrorMessage = "Le titre ne peut pas dépasser 50 caractères")]
        [MinLength(5, ErrorMessage = "Le titre doit faire au minimum 5 caractères")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Le contenu est requis")]
        [MaxLength(500, ErrorMessage = "Le contenu ne peut dépasser 500 caractères")]
        public string Content { get; set; }

        public bool IsVisible { get; set; }
    }
}
