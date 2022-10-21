using Newtonsoft.Json;
using System;
using System.Text;
using System.Web;
using ThePath.Frontend.Models.Classes.Dto;
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
            ////----------------------------------------
            ////ONLY MOCK YET
            ////----------------------------------------
            //entertainmentServiceCreateDto.Price = 750;
            //entertainmentServiceCreateDto.TypeEntertainment = Models.Enum.TypeEntertainment.CafesAndRestaurants;
            //entertainmentServiceCreateDto.Details = "Best of the best cafe";
            //entertainmentServiceCreateDto.Area = Models.Enum.Area.Soviet;
            //entertainmentServiceCreateDto.Latitude = 56.4757818;
            //entertainmentServiceCreateDto.Longitude = 85.085551;
            ////----------------------------------------

            //var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, _remoteServiceBaseUrl + "/Create")
            //{
            //    Content = CreateBodyRequest(entertainmentServiceCreateDto)
            //};
            //HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);
            //if (response.IsSuccessStatusCode)
            //{
            //    return true;
            //}

            return false;
        }

        public async Task<EntertainmentDetailsVm> GetEntertainmentAsync(EntertainmentServiceGetDto dto)
        {
            var urlWithParameters = CreateUrlWithParameters("/DetailsEntertainment",
                "Id", dto.Id.ToString());
            HttpResponseMessage response = await _httpClient.GetAsync(urlWithParameters);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var vmJson = await response.Content.ReadAsStringAsync();
            var vmModel = JsonConvert.DeserializeObject<EntertainmentDetailsVm>(vmJson);

            return vmModel;
        }

        public async Task<IList<EntertainmentLookupDtoByTypeAndAreaAndPrice>> GetEntertainmentListByTypeAndAreaAndPriceAsync
            (EntertainmentServiceGetListByTypeAndAreaAndPriceDto dto)
        {
            var urlWithParameters = CreateUrlWithParameters("/GetEntertainmentListByTypeAndAreaAndPrice",
                "Area", dto.Area.ToString(), "TypeEntertainment", dto.TypeEntertainment.ToString(), "Price", dto.Price.ToString());
            HttpResponseMessage response = await _httpClient.GetAsync(urlWithParameters);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var vmJson = await response.Content.ReadAsStringAsync();
            var vmModel = JsonConvert.DeserializeObject<EntertainmentServiceListByTypeAndAreaAndPriceVm>(vmJson);

            return vmModel.EntertainmentsListByTypeAndAreaAndPriceVm;
        }

        /// <summary>
        /// odd parameters - key,
        /// even parameters - value
        /// </summary>
        /// <param name="addUrl"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private string CreateUrlWithParameters(string addUrl, params string[] parameters)
        {
            UriBuilder uriBuilder = new(_remoteServiceBaseUrl + addUrl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            for (int i = 0; i < parameters.Length; i += 2)
            {
                query[parameters[i]] = parameters[i + 1];
            }

            uriBuilder.Query = query.ToString();
            
            return uriBuilder.ToString();
        }
    }
}
