using System;
namespace MovieStoreApi.Service.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OverView { get; set; }
        public bool Video { get; set; }
        public bool Adult { get; set; }
        public decimal VoteAverage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal UserRating { get; set; }
        public string UserComment { get; set; }
    }
}
