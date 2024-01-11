using AutoMapper;
using MediatR;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;

namespace MovieStore.Business.Command.DirectorCommands;

public class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand, ApiResponse>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public UpdateDirectorCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<Director>().FindAsync(request.DirectorId, cancellationToken);
        if (entity is not null)
            return new ApiResponse("Director not found");
        _mapper.Map(request.Model, entity);
        await _context.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}