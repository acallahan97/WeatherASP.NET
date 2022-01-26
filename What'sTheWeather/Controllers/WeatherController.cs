using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using What_sTheWeather.Models;

namespace What_sTheWeather.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeather repo;

        public WeatherController(IWeather repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var weather = new Weather();
            return View(weather);
        }

        public IActionResult GetWeather(Weather weather)
        {
            var client = new HttpClient();
            var weather1 = new Weather();
            var weatherURL = $"http://api.openweathermap.org/data/2.5/forecast?q={weather.CityName}&appid={weather.Key}&units=imperial";
            var response = client.GetStringAsync(weatherURL).Result;
            weather1.JSON = response;
            JObject formattedResponse = JObject.Parse(response);
            weather1.Farenheit = (double)formattedResponse["list"][0]["main"]["temp"];
            weather1.TempFeelsLike = (double)formattedResponse["list"][0]["main"]["feels_like"];
            weather1.TempMax = (double)formattedResponse["list"][0]["main"]["temp_max"];
            weather1.TempMin = (double)formattedResponse["list"][0]["main"]["temp_min"];
            weather1.Humidity = (long)formattedResponse["list"][0]["main"]["humidity"];
            weather1.Pressure = (long)formattedResponse["list"][0]["main"]["pressure"];
            return View(weather1);
        }
    }
}
