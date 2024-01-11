using AutoMapper;
using MediatR;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Command.DirectorCommands;

public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, ApiResponse<DirectorResponse>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public async Task<ApiResponse<DirectorResponse>> Handle(CreateDirectorCommand request,
        CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Director>(request.Model);
        var entityResult = await _context.Set<Director>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        var directorResponse = _mapper.Map<DirectorResponse>(entityResult.Entity);
        return new ApiResponse<DirectorResponse>(directorResponse);
    }
}