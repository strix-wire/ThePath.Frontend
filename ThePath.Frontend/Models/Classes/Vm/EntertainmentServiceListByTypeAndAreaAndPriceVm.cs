using ThePath.Frontend.Models.Enum;

namespace ThePath.Frontend.Models.Classes.Vm
{
    public class EntertainmentServiceListByTypeAndAreaAndPriceVm
    {
        /// <summary>
        /// In rub
        /// </summary>
        public long Price { get; set; }
        public TypeEntertainment TypeEntertainment { get; set; }
        public string? Details { get; set; }
        public Area Area { get; set; }
    }
}
