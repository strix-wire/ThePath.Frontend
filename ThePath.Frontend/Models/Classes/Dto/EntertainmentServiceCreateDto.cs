using ThePath.Frontend.Models.Enum;

namespace ThePath.Frontend.Models.Classes.Dto
{
    public class EntertainmentServiceCreateDto
    {
        /// <summary>
        /// Not used yet
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// In rub
        /// </summary>
        public long Price { get; set; }
        public TypeEntertainment TypeEntertainment { get; set; }
        public string? Details { get; set; }
        public Area Area { get; set; }
        /// <summary>
        /// Maybe not worked with double
        /// </summary>
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
