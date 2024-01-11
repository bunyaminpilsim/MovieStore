using AutoMapper;
using MediatR;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Command.ActorCommands;

public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, ApiResponse<ActorResponse>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public CreateActorCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<ActorResponse>> Handle(CreateActorCommand request,
        CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Actor>(request.Model);
        var entityResult = await _context.Set<Actor>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        var actorResponse = _mapper.Map<ActorResponse>(entityResult.Entity);
        return new ApiResponse<ActorResponse>(actorResponse);
    }
}