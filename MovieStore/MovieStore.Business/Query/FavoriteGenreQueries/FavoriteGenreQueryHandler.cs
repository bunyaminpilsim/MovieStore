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
    FavoriteGenreQueryHandler : IRequestHandler<GetAllFavoriteGenresQuery,
    ApiResponse<IEnumerable<FavoriteGenreResponse>>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public FavoriteGenreQueryHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<IEnumerable<FavoriteGenreResponse>>> Handle(GetAllFavoriteGenresQuery request,
        CancellationToken cancellationToken)
    {
        var values = await _context.Set<FavoriteGenre>()
            .Include(x => x.Customer)
            .ToListAsync(cancellationToken);
        var mappedlist = _mapper.Map<IEnumerable<FavoriteGenreResponse>>(values);
        return new ApiResponse<IEnumerable<FavoriteGenreResponse>>(mappedlist);
    }
}