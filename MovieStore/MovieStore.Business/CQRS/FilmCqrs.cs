using MediatR;
using MovieStore.Base.Response;
using MovieStore.Schema;

namespace MovieStore.Business.CQRS;

 // Tüm filmleri getirmek için kullanılan sorgu
    public record GetAllFilmQuery() : IRequest<ApiResponse<IEnumerable<FilmResponse>>>;

    // Belirli bir ID'ye sahip filmi getirmek için kullanılan sorgu
    public record GetFilmByIdQuery(int FilmId) : IRequest<ApiResponse<FilmResponse>>;

    // Yeni bir film oluşturmak için kullanılan komut
    public record CreateFilmCommand(FilmRequest Model) : IRequest<ApiResponse<FilmResponse>>;

    // Mevcut bir filmi güncellemek için kullanılan komut
    public record UpdateFilmCommand(int FilmId, FilmRequest Model) : IRequest<ApiResponse>;

    // Bir filmi silmek için kullanılan komut
    public record RemoveFilmCommand(int FilmId) : IRequest<ApiResponse>;