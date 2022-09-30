using System;
using System.Net;
using Microsoft.Extensions.Options;
using RestSharp;

namespace SearchItunes.Data
{
    public interface IRestRepo
    {
        RepoResponse<T> Get<T>(string requestUri);
        RepoResponse<ItunesDto> GetItunes(string searchTerm);
    }

    public class RestRepo : IRestRepo
    {
        private readonly RestClient _restClient;

        public RestRepo(IOptions<ApiSettings> apiSettings)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            _restClient = new RestClient { BaseUrl = new Uri(apiSettings.Value.BaseUrl) };
        }

        public RepoResponse<T> Get<T>(string requestUri)
        {
            var request = new RestRequest(Method.GET) { Resource = requestUri };

            return Execute<T>(request);
        }

        public RepoResponse<ItunesDto> GetItunes(string searchTerm)
        {
            return Get<ItunesDto>($"search?term={searchTerm}");
        }

        private RepoResponse<T> Execute<T>(RestRequest request)
        {
            var response = _restClient.Execute<T>(request);

            if (response.IsSuccessful)
                return new RepoResponse<T> { Status = RepoResponseStatus.Success, Data = response.Data };

            return new RepoResponse<T>
            {
                Status = response.StatusCode == HttpStatusCode.NotFound
                    ? RepoResponseStatus.RecordNotFound
                    : RepoResponseStatus.Error,
                Data = response.Data
            };
        }
    }
}