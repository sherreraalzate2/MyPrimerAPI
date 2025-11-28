using System.ComponentModel.DataAnnotations;

namespace MyPrimerAPI.DAL.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int Duration { get; set; } // Duration in minutes
        public string? Description { get; set; }
        [Required]
        [MaxLength(10)]
        public int Clasification { get; set; } 

    }
}
