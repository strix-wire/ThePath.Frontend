using ThePath.Frontend.Models.Enum;

namespace ThePath.Frontend.ViewConverterLanguage
{
    internal static class ResultListEntertainmentLanguage
    {
        public static string TypeEntertainmentConvertToTitle(TypeEntertainment typeEntertainment)
        {
            switch (typeEntertainment)
            {
                case TypeEntertainment.Cinema:
                    return "кинотеатров в Томске";
                case TypeEntertainment.CafesAndRestaurants:
                    return "кафе и ресторанов в Томске";
                case TypeEntertainment.RecreationCenters:
                    return "баз отдыха в Томске";
                case TypeEntertainment.Saunas:
                    return "саун в Томске";
                case TypeEntertainment.Attraction:
                    return "достопримечательностей в Томске";
                case TypeEntertainment.EntertainmentForChildren:
                    return "развлечения для детей в Томске";
                case TypeEntertainment.Sport:
                    return "мест для спорта в Томске";
                case TypeEntertainment.HorseRides:
                    return "конных прогулок в Томске";
                case TypeEntertainment.InterestingPlacesInTomsk:
                    return "интересных места Томска";
                default:
                    return "";
            }
        }
    }
}
