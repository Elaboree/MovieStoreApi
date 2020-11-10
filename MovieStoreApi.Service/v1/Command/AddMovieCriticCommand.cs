using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreApi.Service.v1.Command
{
    public class AddMovieCriticCommand :IRequest
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
