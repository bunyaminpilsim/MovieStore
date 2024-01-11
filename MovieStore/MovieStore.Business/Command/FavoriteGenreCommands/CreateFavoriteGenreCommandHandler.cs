using AutoMapper;
using MediatR;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Command.FavoriteGenreCommands;

public class
    CreateFavoriteGenreCommandHandler : IRequestHandler<CreateFavoriteGenreCommand, ApiResponse<FavoriteGenreResponse>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public CreateFavoriteGenreCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<FavoriteGenreResponse>> Handle(CreateFavoriteGenreCommand request,
        CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<FavoriteGenre>(request.Model);
        var entityResult = await _context.Set<FavoriteGenre>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        var favoriteGenreResponse = _mapper.Map<FavoriteGenreResponse>(entityResult.Entity);
        return new ApiResponse<FavoriteGenreResponse>(favoriteGenreResponse);
    }
}