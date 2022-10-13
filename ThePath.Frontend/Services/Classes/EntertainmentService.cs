using Newtonsoft.Json;
using System.Text;
using ThePath.Frontend.Models.Classes;
using ThePath.Frontend.Services.Interfaces;

namespace ThePath.Frontend.Services.Classes
{
    public class EntertainmentService : IEntertainmentService
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _remoteServiceBaseUrl;

        public EntertainmentService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = new Uri(configuration.GetValue<string>("ConnectionStrings:EntertainmentService"));
        }

        public async Task<bool> CreateAsync(EntertainmentServiceCreateDto entertainmentServiceCreateDto)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, _remoteServiceBaseUrl + "api/v1/Entertainment/Create");
            httpRequestMessage.Content = CreateBodyRequest(entertainmentServiceCreateDto);
            HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        private StringContent CreateBodyRequest(EntertainmentServiceCreateDto entertainmentServiceCreateDto)
        {
            //----------------------------------------
            //ONLY MOCK YET
            //----------------------------------------
            entertainmentServiceCreateDto.Price = 750;
            entertainmentServiceCreateDto.TypeEntertainment = Models.Enum.TypeEntertainment.CafesAndRestaurants;
            entertainmentServiceCreateDto.Details = "Best of the best cafe";
            entertainmentServiceCreateDto.Area = Models.Enum.Area.Soviet;
            entertainmentServiceCreateDto.Latitude = 56.4757818;
            entertainmentServiceCreateDto.Longitude = 85.085551;
            //----------------------------------------
            var body = JsonConvert.SerializeObject(entertainmentServiceCreateDto);
            var bodyReadyForRequest = JsonConvert.SerializeObject(new { Value = body });

            return new StringContent(bodyReadyForRequest, Encoding.UTF8, "application/json");
        }
    }
}
