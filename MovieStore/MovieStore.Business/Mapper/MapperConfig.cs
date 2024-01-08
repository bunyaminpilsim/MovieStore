using AutoMapper;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<MovieRequest, Movie>();
        CreateMap<Movie, MovieResponse>().ForMember(dest => dest.DirectorName,
            opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname));

        CreateMap<ActorRequest, Actor>();
        CreateMap<Actor, ActorResponse>();

        CreateMap<DirectorRequest, Director>();
        CreateMap<Director, DirectorResponse>();
    }
}