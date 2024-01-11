using MediatR;
using MovieStore.Base.Response;
using MovieStore.Schema;

namespace MovieStore.Business.CQRS;

public record GetAllActorsQuery() : IRequest<ApiResponse<IEnumerable<ActorResponse>>>;

// Belirli bir ID'ye sahip kişiyi getirmek için kullanılan sorgu
public record GetActorByIdQuery(int ActorId) : IRequest<ApiResponse<ActorResponse>>;

// Yeni bir kişi oluşturmak için kullanılan komut
public record CreateActorCommand(ActorRequest Model) : IRequest<ApiResponse<ActorResponse>>;

// Mevcut bir kişiyi güncellemek için kullanılan komut
public record UpdateActorCommand(int ActorId, ActorRequest Model) : IRequest<ApiResponse>;

// Bir kişiyi silmek için kullanılan komut
public record RemoveActorCommand(int ActorId) : IRequest<ApiResponse>;