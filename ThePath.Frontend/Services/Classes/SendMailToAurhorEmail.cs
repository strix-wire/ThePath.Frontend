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
        private readonly string _toName;
        private readonly string _toAddress;

        public SendMailToAurhorEmail(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = new Uri(configuration.GetValue<string>("ConnectionStrings:EmailService"));
            _toName = configuration.GetValue<string>("EmailServiceVariable:ToName");
            _toAddress = configuration.GetValue<string>("EmailServiceVariable:ToAddress");
        }

        public async Task<bool> SendAsync(MailToAuthorEmailDto mailToAuthorEmail)
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

        private StringContent CreateBodyRequest(MailToAuthorEmailDto mailToAuthorEmail)
        {
            mailToAuthorEmail.ToAddress = _toAddress;
            mailToAuthorEmail.ToName = _toName;
            var body = JsonConvert.SerializeObject(mailToAuthorEmail);
            var bodyReadyForRequest = JsonConvert.SerializeObject(new { Value = body });

            return new StringContent(bodyReadyForRequest, Encoding.UTF8, "application/json");
        }
    }
}
