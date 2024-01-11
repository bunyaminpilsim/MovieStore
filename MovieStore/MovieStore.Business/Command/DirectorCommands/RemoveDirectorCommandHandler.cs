using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;

namespace MovieStore.Business.Command.DirectorCommands;

public class RemoveDirectorCommandHandler : IRequestHandler<RemoveDirectorCommand, ApiResponse>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public RemoveDirectorCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse> Handle(RemoveDirectorCommand request, CancellationToken cancellationToken)
    {
        var director = await _context.Set<Director>().FirstOrDefaultAsync(x => x.DirectorId == request.DirectorId,
            cancellationToken);
        if (director is null)
            return new ApiResponse("Director not found");

        _context.Set<Director>().Remove(director);
        await _context.SaveChangesAsync(cancellationToken);

        return new ApiResponse();
    }
}