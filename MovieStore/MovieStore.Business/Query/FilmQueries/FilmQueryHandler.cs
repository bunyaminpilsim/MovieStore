using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Query.FilmQueries;

public class FilmQueryHandler : IRequestHandler<GetAllFilmQuery, ApiResponse<IEnumerable<FilmResponse>>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public FilmQueryHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<IEnumerable<FilmResponse>>> Handle(GetAllFilmQuery request,
        CancellationToken cancellationToken)
    {
        var values = await _context.Set<Film>()
            .Include(x => x.Directors)
            .Include(x => x.Actors)
            .ToListAsync(cancellationToken);
        var mappedlist = _mapper.Map<IEnumerable<FilmResponse>>(values);
        return new ApiResponse<IEnumerable<FilmResponse>>(mappedlist);
    }
}