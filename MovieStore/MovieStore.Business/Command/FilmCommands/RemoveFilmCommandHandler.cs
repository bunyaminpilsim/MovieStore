using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;

namespace MovieStore.Business.Command.FilmCommands;

public class RemoveFilmCommandHandler : IRequestHandler<RemoveFilmCommand, ApiResponse>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public RemoveFilmCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse> Handle(RemoveFilmCommand request, CancellationToken cancellationToken)
    {
        var film = await _context.Set<Film>().FirstOrDefaultAsync(x => x.FilmId == request.FilmId,
            cancellationToken: cancellationToken);
        if (film is null)
            return new ApiResponse("Film not found");

        _context.Set<Film>().Remove(film);
        await _context.SaveChangesAsync(cancellationToken);

        return new ApiResponse();
    }
}