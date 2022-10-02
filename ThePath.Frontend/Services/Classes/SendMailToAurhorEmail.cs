using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using ThePath.Frontend.Models.Classes;
using ThePath.Frontend.Services.Interfaces;

namespace ThePath.Frontend.Services.Classes
{
    public class SendMailToAurhorEmail : ISendMailToAurhorEmail
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _remoteServiceBaseUrl;

        public SendMailToAurhorEmail(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = new Uri(configuration.GetValue<string>("ConnectionStrings:EmailService"));
        }

        public async Task<bool> SendAsync(MailToAuthorEmail mailToAuthorEmail)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, _remoteServiceBaseUrl + "api/v1/Email");
            httpRequestMessage.Content = CreateBodyRequest(mailToAuthorEmail);
            HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        private StringContent CreateBodyRequest(MailToAuthorEmail mailToAuthorEmail)
        {
            var body = JsonConvert.SerializeObject(mailToAuthorEmail);
            var bodyReadyForRequest = "{\"Value\": \"" + body + "\"}";

            var del = "{\"Value\":\"{\\\"FromName\\\":\\\"Vasily\\\",\\\"FromAddress\\\":\\\"vasily_pavlodsadasadsv_98@mail.ru\\\",\\\"ToName\\\":\\\"aAnd\\\",\\\"ToAddress\\\":\\\"strix.wire@gmail.com\\\",\\\"Subject\\\":\\\"ThePath\\\",\\\"Body\\\":\\\"текстпользователяИЗМЕНИТЬ\\\"}\"}";

            return new StringContent(bodyReadyForRequest, Encoding.UTF8, "application/json");
        }
    }
}
