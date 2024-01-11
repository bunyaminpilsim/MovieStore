using AutoMapper;
using MediatR;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Command.FilmCommands;

public class CreateFilmCommandsHandler : IRequestHandler<CreateFilmCommand, ApiResponse<FilmResponse>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public CreateFilmCommandsHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<FilmResponse>> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Film>(request.Model);
        var entityResult = await _context.Set<Film>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        var filmResponse = _mapper.Map<FilmResponse>(entityResult.Entity);
        return new ApiResponse<FilmResponse>(filmResponse);
    }
}