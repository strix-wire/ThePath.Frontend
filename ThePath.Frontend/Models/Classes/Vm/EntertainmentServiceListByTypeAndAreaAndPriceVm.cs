using ThePath.Frontend.Models.Enum;

namespace ThePath.Frontend.Models.Classes.Vm;

public class EntertainmentServiceListByTypeAndAreaAndPriceVm
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public long Price { get; set; }
    public string City { get; set; }
    public TypeEntertainment TypeEntertainment { get; set; }
    public string? Details { get; set; }
    public Area Area { get; set; }
    /// <summary>
    /// Maybe not worked with double
    /// </summary>
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }
    public string? UrlImage { get; set; }
    public byte? Ranking { get; set; }
}
