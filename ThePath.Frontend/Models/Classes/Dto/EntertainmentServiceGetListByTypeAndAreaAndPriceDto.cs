﻿using ThePath.Frontend.Models.Enum;

namespace ThePath.Frontend.Models.Classes.Dto
{
    public class EntertainmentServiceGetListByTypeAndAreaAndPriceDto
    {
        public Area Area { get; set; }
        public double Price { get; set; }
        public TypeEntertainment TypeEntertainment { get; set; }
    }
}