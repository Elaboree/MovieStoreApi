using MediatR;
using MovieStoreApi.Service.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreApi.Service.v1.Query
{
    public class GetMovieQuery : IRequest<GetMovieQueryResponse>
    {
        [Required]
        public int MovieId { get; set; }
    }
    public class GetMovieQueryResponse
    {
        public MovieModel Movie { get; set; }
    }
}
