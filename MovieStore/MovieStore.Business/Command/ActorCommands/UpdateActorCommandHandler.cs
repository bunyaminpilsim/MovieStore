using AutoMapper;
using MediatR;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;

namespace MovieStore.Business.Command.ActorCommands;

public class UpdateActorCommandHandler: IRequestHandler<UpdateActorCommand, ApiResponse>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public UpdateActorCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<Actor>().FindAsync(request.ActorId);
        if (entity is not null)
            return new ApiResponse("Actor not found");
        _mapper.Map(request.Model, entity);
        await _context.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}