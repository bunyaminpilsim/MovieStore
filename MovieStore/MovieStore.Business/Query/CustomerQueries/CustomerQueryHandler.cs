using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Query.CustomerQueries;

public class CustomerQueryHandler : IRequestHandler<GetAllCustomersQuery, ApiResponse<IEnumerable<CustomerResponse>>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public CustomerQueryHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<IEnumerable<CustomerResponse>>> Handle(GetAllCustomersQuery request,
        CancellationToken cancellationToken)
    {
        var values = await _context.Set<Customer>()
            .Include(x => x.Purchases)
            .Include(x => x.FavoriteGenres)
            .ToListAsync(cancellationToken);
        var mappedlist = _mapper.Map<IEnumerable<CustomerResponse>>(values);
        return new ApiResponse<IEnumerable<CustomerResponse>>(mappedlist);
    }
}