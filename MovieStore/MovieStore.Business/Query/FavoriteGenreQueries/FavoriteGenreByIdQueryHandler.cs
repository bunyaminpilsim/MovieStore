using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Query.FavoriteGenreQueries;

public class
    FavoriteGenreByIdQueryHandler : IRequestHandler<GetFavoriteGenreByIdQuery, ApiResponse<FavoriteGenreResponse>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public FavoriteGenreByIdQueryHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<FavoriteGenreResponse>> Handle(GetFavoriteGenreByIdQuery request,
        CancellationToken cancellationToken)
    {
        var value = await _context.Set<FavoriteGenre>()
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.FavoriteGenreId == request.FavoriteGenreId, cancellationToken);
        if (value is null)
            return new ApiResponse<FavoriteGenreResponse>("FavoriteGenre not found");

        var favoriteGenreResponse = _mapper.Map<FavoriteGenreResponse>(value);
        return new ApiResponse<FavoriteGenreResponse>(favoriteGenreResponse);
    }
}