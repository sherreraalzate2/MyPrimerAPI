using System.ComponentModel.DataAnnotations;

namespace MyPrimerAPI.DAL.Models.Dtos
{
    public class MovieCreateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Duration { get; set; }

        public string? Description { get; set; }

        // ESTA ES LA CLAVE: Debe tener doble 's'
        [Required]
        [MaxLength(10)]
        public string Classification { get; set; }
    }
}
