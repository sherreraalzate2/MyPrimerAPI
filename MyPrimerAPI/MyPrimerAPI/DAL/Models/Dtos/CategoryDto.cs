using System.ComponentModel.DataAnnotations;

namespace MyPrimerAPI.DAL.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoria es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre de la categoria no puede tener más de 100 caracteres.")]

        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}
