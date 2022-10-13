using ThePath.Frontend.Models.Classes.Dto;

namespace ThePath.Frontend.Services.Interfaces
{
    public interface ISendMailToAurhorEmail
    {
        public Task<bool> SendAsync(MailToAuthorEmailDto mailToAuthorEmail); 
    }
}
