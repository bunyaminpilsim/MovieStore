using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Query.ActorQueries;

public class ActorQueryHandler : IRequestHandler<GetAllActorsQuery, ApiResponse<IEnumerable<ActorResponse>>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public ActorQueryHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<IEnumerable<ActorResponse>>> Handle(GetAllActorsQuery request,
        CancellationToken cancellationToken)
    {
        var values = await _context.Set<Actor>()
            .Include(x => x.Films)
            .ToListAsync(cancellationToken);
        var mappedlist = _mapper.Map<IEnumerable<ActorResponse>>(values);
        return new ApiResponse<IEnumerable<ActorResponse>>(mappedlist);
    }
}