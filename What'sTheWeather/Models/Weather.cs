using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using What_sTheWeather.Models;

namespace What_sTheWeather.Models
{
    public class Weather
    {
        public string CityName { get; set; }
        public double Farenheit { get; set; }
        public double TempFeelsLike { get; set; }
        public string Key { get; set; }
        public string JSON { get; set; }
        public double Temp { get; set; }

        public double TempMin { get; set; }

        public double TempMax { get; set; }

        public long Pressure { get; set; }

        public long SeaLevel { get; set; }

        public long GrndLevel { get; set; }

        public long Humidity { get; set; }

        public double TempKf { get; set; }
    }
}
