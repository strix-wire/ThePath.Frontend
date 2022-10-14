using ThePath.Frontend.Models.Classes.Dto;
using ThePath.Frontend.Models.Classes.Vm;

namespace ThePath.Frontend.Services.Interfaces
{
    public interface IEntertainmentService
    {
        //Need only to admin, moder
        //public Task<bool> CreateAsync(EntertainmentServiceCreateDto entertainmentServiceCreateDto);
        //public Task<bool> GetEntertainmentAsync(EntertainmentServiceGetDto entertainmentServiceGetDto);
        public Task<IList<EntertainmentServiceListByTypeAndAreaAndPriceVm>> GetEntertainmentListByTypeAndAreaAndPriceAsync
            (EntertainmentServiceGetListByTypeAndAreaAndPriceDto dto);
    }
}
