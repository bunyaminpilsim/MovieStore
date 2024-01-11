using AutoMapper;
using MediatR;
using MovieStore.Base.Response;
using MovieStore.Business.CQRS;
using MovieStore.Data.Context;
using MovieStore.Data.Entities;
using MovieStore.Schema;

namespace MovieStore.Business.Command.CustomerCommands;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ApiResponse<CustomerResponse>>
{
    private readonly MovieStoreContext _context;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(MovieStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse<CustomerResponse>> Handle(CreateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Customer>(request.Model);
        var entityResult = await _context.Set<Customer>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        var customerResponse = _mapper.Map<CustomerResponse>(entityResult.Entity);
        return new ApiResponse<CustomerResponse>(customerResponse);
    }
}