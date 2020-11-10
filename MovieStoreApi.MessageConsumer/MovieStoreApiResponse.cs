using MovieStoreApi.Service.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieStoreApi.MessageConsumer
{
    public class MovieStoreApiConsumerResponse
    {
        [JsonProperty("results")]
        public List<MovieTransformModel> MovieList { get; set; }
    }
}
