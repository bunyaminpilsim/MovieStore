using AutoMapper;
using MediatR;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;

namespace MovieStore.Business.Command.FavoriteGenreCommands;

public class UpdateFavoriteGenreCommandHandler : IRequestHandler<UpdateFavoriteGenreCommand, ApiResponse>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public UpdateFavoriteGenreCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse> Handle(UpdateFavoriteGenreCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<FavoriteGenre>().FindAsync(request.FavoriteGenreId, cancellationToken);
        if (entity is not null)
            return new ApiResponse("FavoriteGenre not found");
        _mapper.Map(request.Model, entity);
        await _context.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}