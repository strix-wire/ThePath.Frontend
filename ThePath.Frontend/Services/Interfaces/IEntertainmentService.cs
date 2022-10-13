using ThePath.Frontend.Models.Classes;

namespace ThePath.Frontend.Services.Interfaces
{
    public interface IEntertainmentService
    {
        public Task<bool> CreateAsync(EntertainmentServiceCreateDto entertainmentServiceCreateDto);
    }
}
