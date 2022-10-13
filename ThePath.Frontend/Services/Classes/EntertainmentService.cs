using Newtonsoft.Json;
using System.Text;
using ThePath.Frontend.Models.Classes;
using ThePath.Frontend.Models.Classes.Vm;
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

        //Need only to admin, moder
        public async Task<bool> CreateAsync(EntertainmentServiceCreateDto entertainmentServiceCreateDto)
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

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, _remoteServiceBaseUrl + "/Create")
            {
                Content = CreateBodyRequest(entertainmentServiceCreateDto)
            };
            HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> GetEntertainmentAsync(EntertainmentServiceGetDto entertainmentServiceGetDto)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, _remoteServiceBaseUrl)
            {
                Content = CreateBodyRequest(entertainmentServiceGetDto)
            };
            HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<IList<EntertainmentServiceListByTypeAndAreaAndPriceVm>> GetEntertainmentListByTypeAndAreaAndPriceAsync
            (EntertainmentServiceGetListByTypeAndAreaAndPriceDto dto)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, _remoteServiceBaseUrl)
            {
                Content = CreateBodyRequest(dto)
            };
            HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                return null;
            }

            var vmJson = await response.Content.ReadAsStringAsync();

            var vmModel = JsonConvert.DeserializeObject<IList<EntertainmentServiceListByTypeAndAreaAndPriceVm>>(vmJson);

            return vmModel;
        }

        private StringContent CreateBodyRequest<T>(T entertainmentServiceCreateDto)
        {
            var body = JsonConvert.SerializeObject(entertainmentServiceCreateDto);
            var bodyReadyForRequest = JsonConvert.SerializeObject(new { Value = body });

            return new StringContent(bodyReadyForRequest, Encoding.UTF8, "application/json");
        }
    }
}
