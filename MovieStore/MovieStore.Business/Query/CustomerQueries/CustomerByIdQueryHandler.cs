using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Query.CustomerQueries;

public class CustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, ApiResponse<CustomerResponse>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public CustomerByIdQueryHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<CustomerResponse>> Handle(GetCustomerByIdQuery request,
        CancellationToken cancellationToken)
    {
        var value = await _context.Set<Customer>()
            .Include(x => x.Purchases)
            .Include(x => x.FavoriteGenres)
            .FirstOrDefaultAsync(x => x.CustomerId == request.CustomerId, cancellationToken);
        if (value is null)
            return new ApiResponse<CustomerResponse>("Customer not found");

        var customerResponse = _mapper.Map<CustomerResponse>(value);
        return new ApiResponse<CustomerResponse>(customerResponse);
    }
}