using AutoMapper;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<FilmRequest, Film>();
        CreateMap<Film, FilmResponse>();

        CreateMap<ActorRequest, Actor>();
        CreateMap<Actor, ActorResponse>();

        CreateMap<DirectorRequest, Director>();
        CreateMap<Director, DirectorResponse>();
    }
}