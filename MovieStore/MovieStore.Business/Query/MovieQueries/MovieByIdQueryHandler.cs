using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Query.MovieQueries;

public class MovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieResponse>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public MovieByIdQueryHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MovieResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _context.Set<Movie>()
            .Include(x => x.Director)
            .Include(x => x.Actors).FirstOrDefaultAsync(x => x.MovieId == request.MovieId, cancellationToken);
        return _mapper.Map<MovieResponse>(value);
    }
}