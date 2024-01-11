using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Query.PurchaseQueries;

public class PurchaseByIdQueryHandler : IRequestHandler<GetPurchaseByIdQuery, ApiResponse<PurchaseResponse>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public PurchaseByIdQueryHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<PurchaseResponse>> Handle(GetPurchaseByIdQuery request,
        CancellationToken cancellationToken)
    {
        var value = await _context.Set<Purchase>()
            .Include(x => x.Film)
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.PurchaseId == request.PurchaseId, cancellationToken);
        if (value is null)
            return new ApiResponse<PurchaseResponse>("Purchase not found");

        var purchaseResponse = _mapper.Map<PurchaseResponse>(value);
        return new ApiResponse<PurchaseResponse>(purchaseResponse);
    }
}