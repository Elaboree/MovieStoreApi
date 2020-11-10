using MediatR;
using MovieStoreApi.Service.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreApi.Service.v1.Query
{
    public class GetMoviesQuery :IRequest<GetMoviesQueryResponse>
    {
        [Required]
        public int PageIndex { get; set; }
        [Required]
        public int PageSize { get; set; }
    }

    public class GetMoviesQueryResponse
    {
        public List<MovieModel> Movies { get; set; }
    }
}
