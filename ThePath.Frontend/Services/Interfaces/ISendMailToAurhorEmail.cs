using ThePath.Frontend.Models.Classes;

namespace ThePath.Frontend.Services.Interfaces
{
    public interface ISendMailToAurhorEmail
    {
        public Task<bool> SendAsync(MailToAuthorEmailDto mailToAuthorEmail); 
    }
}
