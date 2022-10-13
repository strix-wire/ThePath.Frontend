using ThePath.Frontend.Models.Classes;

namespace ThePath.Frontend.Services.Interfaces
{
    public interface IEntertainmentService
    {
        //Need only to admin, moder
        public Task<bool> CreateAsync(EntertainmentServiceCreateDto entertainmentServiceCreateDto);
        public Task<bool> GetEntertainmentAsync(EntertainmentServiceGetDto entertainmentServiceGetDto);
    }
}
