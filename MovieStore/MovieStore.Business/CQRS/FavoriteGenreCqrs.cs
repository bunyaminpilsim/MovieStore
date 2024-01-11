using MediatR;
using MovieStore.Base.Response;
using MovieStore.Schema;

namespace MovieStore.Business.CQRS;

// Bir müşteri için tüm favori türleri getirmek için kullanılan sorgu
public record GetAllFavoriteGenresQuery() : IRequest<ApiResponse<IEnumerable<FavoriteGenreResponse>>>;

// Belirli bir ID'ye sahip favori türü getirmek için kullanılan sorgu
public record GetFavoriteGenreByIdQuery(int FavoriteGenreId) : IRequest<ApiResponse<FavoriteGenreResponse>>;

// Yeni bir favori türü oluşturmak için kullanılan komut
public record CreateFavoriteGenreCommand(FavoriteGenreRequest Model) : IRequest<ApiResponse<FavoriteGenreResponse>>;

// Mevcut bir favori türü güncellemek için kullanılan komut
public record UpdateFavoriteGenreCommand(int FavoriteGenreId, FavoriteGenreRequest Model) : IRequest<ApiResponse>;

// Bir favori türü silmek için kullanılan komut
public record RemoveFavoriteGenreCommand(int FavoriteGenreId) : IRequest<ApiResponse>;