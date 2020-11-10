using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using MovieStoreApi.MessageProducer.Sender;
using MovieStoreApi.Worker.Options;

namespace MovieStoreApi.Worker
{
    public class MovieWorker : IMovieWorker
    {
        private readonly IMovieSender _movieSender;

        private readonly string _apiUrl;
        private readonly string _apiKey;
        public MovieWorker(IOptions<WorkerOptions> workerOptions, IMovieSender movieSender)
        {
            _movieSender = movieSender;
            _apiUrl = workerOptions.Value.ApiUrl;
            _apiKey = workerOptions.Value.ApiKey;
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var url = new Uri(QueryHelpers.AddQueryString(_apiUrl, "api_key", _apiKey));

                var workerRequest = new HttpClient();
                workerRequest.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await workerRequest.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();

                 _movieSender.SendMovie(jsonString);

                await Task.Delay(TimeSpan.FromHours(1));
            }
        }
    }
}
