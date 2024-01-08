using AutoMapper;
using MediatR;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;

namespace MovieStore.Business.Command.MovieCommands;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public UpdateMovieCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<Movie>().FindAsync(request.MovieId);
        if (entity is not null)
            throw new InvalidOperationException("Movie not found");
        _mapper.Map(request.Model, entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}