using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;

namespace MovieStore.Business.Command.CustomerCommands;

public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommand, ApiResponse>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public RemoveCustomerCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _context.Set<Customer>().FirstOrDefaultAsync(x => x.CustomerId == request.CustomerId,
            cancellationToken: cancellationToken);
        if (customer is null)
            return new ApiResponse("Customer not found");

        _context.Set<Customer>().Remove(customer);
        await _context.SaveChangesAsync(cancellationToken);

        return new ApiResponse();
    }
}