using MyPrimerAPI.DAL.Models;

namespace MyPrimerAPI.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieAsync(int id);
        Task<bool> CreateMovieAsync(Movie movie);
        Task<bool> UpdateMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(int id);
        Task<bool> SaveAsync(); // Agregamos este para guardar cambios
    }
}
