using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using What_sTheWeather.Models;

namespace What_sTheWeather
{
    public class WeatherRepo : IWeather
    {
        private readonly IDbConnection _conn;

        public WeatherRepo(IDbConnection conn)
        {
            _conn = conn;
        }


        public IEnumerable<Weather> GetTheWeather()
        {
            return _conn.Query<Weather>("SELECT * FROM WEATHER;");
        }

    }
}
