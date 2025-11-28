namespace MyPrimerAPI.DAL.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string? Description { get; set; }
        public string Classification { get; set; } 
        public DateTime CreatedDate { get; set; }
    }
}
