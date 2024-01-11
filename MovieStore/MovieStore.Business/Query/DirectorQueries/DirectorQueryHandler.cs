using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Query.DirectorQueries;

public class DirectorQueryHandler : IRequestHandler<GetAllDirectorsQuery, ApiResponse<IEnumerable<DirectorResponse>>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public DirectorQueryHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<IEnumerable<DirectorResponse>>> Handle(GetAllDirectorsQuery request,
        CancellationToken cancellationToken)
    {
        var values = await _context.Set<Director>()
            .Include(x => x.DirectedFilms)
            .ToListAsync(cancellationToken);
        var mappedlist = _mapper.Map<IEnumerable<DirectorResponse>>(values);
        return new ApiResponse<IEnumerable<DirectorResponse>>(mappedlist);
    }
}