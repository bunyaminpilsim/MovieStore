using AutoMapper;
using MediatR;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;

namespace MovieStore.Business.Command.FilmCommands;

public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommand, ApiResponse>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public UpdateFilmCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse> Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<Film>().FindAsync(request.FilmId,cancellationToken);
        if (entity is not null)
            return new ApiResponse("Film not found");
        _mapper.Map(request.Model, entity);
        await _context.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}