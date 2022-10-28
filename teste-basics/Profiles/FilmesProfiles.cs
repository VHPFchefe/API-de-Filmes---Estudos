using AutoMapper;
using Data.Dtos;
using Models;

namespace Profiles
{
    public class FilmesProfiles : Profile
    {
        public FilmesProfiles() 
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
