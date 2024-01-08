using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Query.MovieQueries;

public class MovieQueryHandler : IRequestHandler<GetAllMovieQuery, IEnumerable<MovieResponse>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public MovieQueryHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieResponse>> Handle(GetAllMovieQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Set<Movie>()
            .Include(x => x.Director)
            .Include(x => x.Actors)
            .ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MovieResponse>>(values);
    }
}