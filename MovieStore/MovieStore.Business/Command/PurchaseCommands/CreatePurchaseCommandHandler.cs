using AutoMapper;
using MediatR;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Command.PurchaseCommands;

public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, ApiResponse<PurchaseResponse>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public CreatePurchaseCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<PurchaseResponse>> Handle(CreatePurchaseCommand request,
        CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Purchase>(request.Model);
        var entityResult = await _context.Set<Purchase>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        var purchaseResponse = _mapper.Map<PurchaseResponse>(entityResult.Entity);
        return new ApiResponse<PurchaseResponse>(purchaseResponse);
    }
}