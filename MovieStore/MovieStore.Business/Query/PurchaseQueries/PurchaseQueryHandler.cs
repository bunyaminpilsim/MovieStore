using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Query.PurchaseQueries;

public class PurchaseQueryHandler : IRequestHandler<GetAllPurchasesQuery, ApiResponse<IEnumerable<PurchaseResponse>>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public PurchaseQueryHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<IEnumerable<PurchaseResponse>>> Handle(GetAllPurchasesQuery request,
        CancellationToken cancellationToken)
    {
        var values = await _context.Set<Purchase>()
            .Include(x => x.Film)
            .Include(x => x.Customer)
            .ToListAsync(cancellationToken);
        var mappedlist = _mapper.Map<IEnumerable<PurchaseResponse>>(values);
        return new ApiResponse<IEnumerable<PurchaseResponse>>(mappedlist);
    }
}