using AutoMapper;
using MediatR;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;

namespace MovieStore.Business.Command.MovieCommands;

public class RemoveMovieCommandHandler : IRequestHandler<RemoveMovieCommand>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public RemoveMovieCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(RemoveMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<Movie>().FindAsync(request.MovieId);
        if (entity is not null)
            throw new InvalidOperationException("Movie not found");
        _context.Set<Movie>().Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}