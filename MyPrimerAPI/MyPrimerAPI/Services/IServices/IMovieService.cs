using MyPrimerAPI.DAL.Models.Dtos;

namespace MyPrimerAPI.Services.IServices
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id);
        Task<MovieDto> CreateMovieAsync(MovieCreateDto movieCreateDto);
        Task<MovieDto> UpdateMovieAsync(int id, MovieCreateDto movieCreateDto);
        Task<bool> DeleteMovieAsync(int id);
    }
}
