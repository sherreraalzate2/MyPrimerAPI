using AutoMapper;
using MyPrimerAPI.DAL.Models;
using MyPrimerAPI.DAL.Models.Dtos;

namespace MyPrimerAPI.MoviesMapper
{
    public class Mappers : Profile 
    {
        public Mappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDto>().ReverseMap();

            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MovieCreateDto>().ReverseMap();
        }
    }
}
