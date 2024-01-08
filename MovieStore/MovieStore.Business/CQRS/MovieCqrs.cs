using MediatR;
using MovieStore.Schema;

namespace MovieStore.Business.CQRS;

public record GetAllMovieQuery():IRequest<IEnumerable<MovieResponse>>;
public record GetMovieByIdQuery(int MovieId):IRequest<MovieResponse>;

public record CreateMovieCommand(MovieRequest Model) : IRequest<MovieResponse>;

public record UpdateMovieCommand(int MovieId, MovieRequest Model) : IRequest;
public record RemoveMovieCommand(int MovieId):IRequest;