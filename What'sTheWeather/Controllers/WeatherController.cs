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
            weather1.Farenheit = formattedResponse["list"][0]["main"].ToString();
            return View(weather1);
        }
    }
}
