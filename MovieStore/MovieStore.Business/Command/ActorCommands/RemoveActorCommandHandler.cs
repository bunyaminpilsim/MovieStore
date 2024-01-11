using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;

namespace MovieStore.Business.Command.ActorCommands;

public class RemoveActorCommandHandler : IRequestHandler<RemoveActorCommand, ApiResponse>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public RemoveActorCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse> Handle(RemoveActorCommand request, CancellationToken cancellationToken)
    {
        var actor = await _context.Set<Actor>().FirstOrDefaultAsync(x => x.ActorId == request.ActorId,
            cancellationToken: cancellationToken);
        if (actor is null)
            return new ApiResponse("Actor not found");

        _context.Set<Actor>().Remove(actor);
        await _context.SaveChangesAsync(cancellationToken);

        return new ApiResponse();
    }
}