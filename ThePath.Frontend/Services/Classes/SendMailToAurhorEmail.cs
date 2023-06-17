using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using ThePath.Frontend.Models.Classes.Dto;
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

        public async Task<bool> SendAsync(MailToAuthorEmailDto mailToAuthorEmailDto)
        {
            mailToAuthorEmailDto.ToAddress = _toAddress;
            mailToAuthorEmailDto.ToName = _toName;

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_remoteServiceBaseUrl + "api/v1/Email",
                mailToAuthorEmailDto);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
