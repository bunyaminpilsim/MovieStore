using MediatR;
using MovieStore.Base.Response;
using MovieStore.Schema;

namespace MovieStore.Business.CQRS;

public record GetAllDirectorsQuery() : IRequest<ApiResponse<IEnumerable<DirectorResponse>>>;

// Belirli bir ID'ye sahip kişiyi getirmek için kullanılan sorgu
public record GetDirectorByIdQuery(int DirectorId) : IRequest<ApiResponse<DirectorResponse>>;

// Yeni bir kişi oluşturmak için kullanılan komut
public record CreateDirectorCommand(DirectorRequest Model) : IRequest<ApiResponse<DirectorResponse>>;

// Mevcut bir kişiyi güncellemek için kullanılan komut
public record UpdateDirectorCommand(int DirectorId, DirectorRequest Model) : IRequest<ApiResponse>;

// Bir kişiyi silmek için kullanılan komut
public record RemoveDirectorCommand(int DirectorId) : IRequest<ApiResponse>;