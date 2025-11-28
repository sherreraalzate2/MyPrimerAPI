using AutoMapper;
using MyPrimerAPI.DAL.Models;
using MyPrimerAPI.DAL.Models.Dtos;
using MyPrimerAPI.Repository.IRepository;
using MyPrimerAPI.Services.IServices;

namespace MyPrimerAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            // Convertimos la lista de Películas a lista de MovieDto 
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateDto movieCreateDto)
        {
            // 1. Convertimos el DTO (lo que llega) a Entidad (lo que se guarda)
            var movie = _mapper.Map<Movie>(movieCreateDto);

            // 2. Guardamos en BD
            await _movieRepository.CreateMovieAsync(movie);

            // 3. Devolvemos el objeto creado convertido a DTO (para que tenga el ID nuevo)
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> UpdateMovieAsync(int id, MovieCreateDto movieCreateDto)
        {
            var movieExisting = await _movieRepository.GetMovieAsync(id);
            if (movieExisting == null) return null;

            // Actualizamos los datos usando el Mapper
            // Esto copia los datos del DTO a la entidad existente
            _mapper.Map(movieCreateDto, movieExisting);

            await _movieRepository.UpdateMovieAsync(movieExisting);

            return _mapper.Map<MovieDto>(movieExisting);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);
            if (movie == null) return false;

            return await _movieRepository.DeleteMovieAsync(id);
        }
    }
}
