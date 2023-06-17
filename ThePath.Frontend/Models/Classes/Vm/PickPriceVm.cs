using ThePath.Frontend.Models.Enum;

namespace ThePath.Frontend.Models.Classes.Vm;

public class PickPriceVm
{
    public TypeEntertainment TypeEntertainment { get; set; }
    public long Price { get; set; }
    public IntervalMoney IntervalMoney { get; set; }
}
