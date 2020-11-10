using System;
using System.Collections.Generic;

namespace MovieStoreApi.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public long TmdbId { get; set; }
        public string Title { get; set; }
        public string OverView { get; set; }
        public bool Video { get; set; }
        public bool Adult { get; set; }
        public decimal VoteAverage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Critic> Critics { get; set; }
    }
}
