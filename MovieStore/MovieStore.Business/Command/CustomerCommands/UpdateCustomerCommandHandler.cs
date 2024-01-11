using AutoMapper;
using MediatR;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;

namespace MovieStore.Business.Command.CustomerCommands;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ApiResponse>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<Customer>().FindAsync(request.CustomerId, cancellationToken);
        if (entity is not null)
            return new ApiResponse("Customer not found");
        _mapper.Map(request.Model, entity);
        await _context.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}