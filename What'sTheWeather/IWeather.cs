using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using What_sTheWeather.Models;

namespace What_sTheWeather
{
   public interface IWeather
    {
        public IEnumerable<Weather> GetTheWeather();
        
    }
}
