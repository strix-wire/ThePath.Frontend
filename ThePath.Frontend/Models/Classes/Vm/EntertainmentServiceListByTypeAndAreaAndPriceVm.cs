using ThePath.Frontend.Models.Classes.Dto;
using ThePath.Frontend.Models.Enum;

namespace ThePath.Frontend.Models.Classes.Vm;

public class EntertainmentServiceListByTypeAndAreaAndPriceVm
{
    public IList<EntertainmentLookupDtoByTypeAndAreaAndPrice> EntertainmentsListByTypeAndAreaAndPriceVm { get; set; }
}
