using Newtonsoft.Json;
using System;

namespace MovieStoreApi.Service.Models
{
    public class MovieTransformModel
    {
        [JsonProperty("id")]
        public long TmdbId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("overview")]
        public string OverView { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("vote_average")]
        public decimal VoteAverage { get; set; }

        [JsonProperty("release_date")]
        public DateTime RelaseDate { get; set; }
    }
}
