using MediatR;
using MovieStore.Base.Response;
using MovieStore.Schema;

namespace MovieStore.Business.CQRS;

// Tüm satın alma işlemlerini getirmek için kullanılan sorgu
public record GetAllPurchasesQuery() : IRequest<ApiResponse<IEnumerable<PurchaseResponse>>>;

// Belirli bir ID'ye sahip satın alma işlemini getirmek için kullanılan sorgu
public record GetPurchaseByIdQuery(int PurchaseId) : IRequest<ApiResponse<PurchaseResponse>>;

// Yeni bir satın alma işlemi oluşturmak için kullanılan komut
public record CreatePurchaseCommand(PurchaseRequest Model) : IRequest<ApiResponse<PurchaseResponse>>;