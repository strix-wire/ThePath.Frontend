using ThePath.Frontend.Models.Classes.Dto;
using ThePath.Frontend.Models.Classes.Vm;

namespace ThePath.Frontend.Services.Interfaces
{
    public interface IEntertainmentService
    {
        //Need only to admin, moder
        //public Task<bool> CreateAsync(EntertainmentServiceCreateDto entertainmentServiceCreateDto);
        public Task<EntertainmentDetailsVm> GetEntertainmentAsync(EntertainmentServiceGetDto dto);
        public Task<IList<EntertainmentLookupDtoByTypeAndAreaAndPrice>> GetEntertainmentListByTypeAndAreaAndPriceAsync
            (EntertainmentServiceGetListByTypeAndAreaAndPriceDto dto);
    }
}
