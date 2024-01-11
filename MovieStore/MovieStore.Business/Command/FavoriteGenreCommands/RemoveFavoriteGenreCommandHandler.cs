using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;

namespace MovieStore.Business.Command.FavoriteGenreCommands;

public class RemoveFavoriteGenreCommandHandler : IRequestHandler<RemoveFavoriteGenreCommand, ApiResponse>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public RemoveFavoriteGenreCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse> Handle(RemoveFavoriteGenreCommand request, CancellationToken cancellationToken)
    {
        var director = await _context.Set<FavoriteGenre>()
            .FirstOrDefaultAsync(x => x.FavoriteGenreId == request.FavoriteGenreId,
                cancellationToken);
        if (director is null)
            return new ApiResponse("FavoriteGenre not found");

        _context.Set<FavoriteGenre>().Remove(director);
        await _context.SaveChangesAsync(cancellationToken);

        return new ApiResponse();
    }
}