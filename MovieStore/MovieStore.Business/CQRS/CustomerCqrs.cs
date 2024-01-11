using MediatR;
using MovieStore.Base.Response;
using MovieStore.Schema;

namespace MovieStore.Business.CQRS;

// Tüm müşterileri getirmek için kullanılan sorgu
public record GetAllCustomersQuery() : IRequest<ApiResponse<IEnumerable<CustomerResponse>>>;

// Belirli bir ID'ye sahip müşteriyi getirmek için kullanılan sorgu
public record GetCustomerByIdQuery(int CustomerId) : IRequest<ApiResponse<CustomerResponse>>;

// Yeni bir müşteri oluşturmak için kullanılan komut
public record CreateCustomerCommand(CustomerRequest Model) : IRequest<ApiResponse<CustomerResponse>>;

// Mevcut bir müşteriyi güncellemek için kullanılan komut
public record UpdateCustomerCommand(int CustomerId, CustomerRequest Model) : IRequest<ApiResponse>;

// Bir müşteriyi silmek için kullanılan komut
public record RemoveCustomerCommand(int CustomerId) : IRequest<ApiResponse>;