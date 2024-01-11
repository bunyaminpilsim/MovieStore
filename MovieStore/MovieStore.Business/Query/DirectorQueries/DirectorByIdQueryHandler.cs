using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Query.DirectorQueries;

public class DirectorByIdQueryHandler : IRequestHandler<GetDirectorByIdQuery, ApiResponse<DirectorResponse>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public DirectorByIdQueryHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<DirectorResponse>> Handle(GetDirectorByIdQuery request,
        CancellationToken cancellationToken)
    {
        var value = await _context.Set<Director>()
            .Include(x => x.DirectedFilms)
            .FirstOrDefaultAsync(x => x.DirectorId == request.DirectorId, cancellationToken);
        if (value is null)
            return new ApiResponse<DirectorResponse>("Director not found");

        var directorResponse = _mapper.Map<DirectorResponse>(value);
        return new ApiResponse<DirectorResponse>(directorResponse);
    }
}