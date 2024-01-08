using AutoMapper;
using MediatR;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Command.MovieCommands;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieResponse>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public CreateMovieCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MovieResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Movie>(request.Model);
        var entityResult = await _context.Set<Movie>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var movieResponse = _mapper.Map<MovieResponse>(entityResult.Entity);
        return movieResponse;
    }
}