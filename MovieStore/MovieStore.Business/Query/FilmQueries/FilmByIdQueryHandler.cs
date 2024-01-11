using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Query.FilmQueries;

public class FilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery, ApiResponse<FilmResponse>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public async Task<ApiResponse<FilmResponse>> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _context.Set<Film>()
            .Include(x => x.Directors)
            .Include(x => x.Actors)
            .FirstOrDefaultAsync(x => x.FilmId == request.FilmId, cancellationToken);
        if (value is null)
            return new ApiResponse<FilmResponse>("Film not found");

        var filmResponse = _mapper.Map<FilmResponse>(value);
        return new ApiResponse<FilmResponse>(filmResponse);
    }
}