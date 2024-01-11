using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Query.ActorQueries;

public class ActorByIdQueryHandler : IRequestHandler<GetActorByIdQuery, ApiResponse<ActorResponse>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public ActorByIdQueryHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<ActorResponse>> Handle(GetActorByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _context.Set<Actor>()
            .Include(x => x.Films)
            .FirstOrDefaultAsync(x => x.ActorId == request.ActorId, cancellationToken);
        if (value is null)
            return new ApiResponse<ActorResponse>("Actor not found");

        var actorResponse = _mapper.Map<ActorResponse>(value);
        return new ApiResponse<ActorResponse>(actorResponse);
    }
}