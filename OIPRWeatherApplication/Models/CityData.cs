using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OIPRWeatherApplication.Models
{
    public class CityData
    {
        public string City { get; set; }
        public DateTime Date { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
    }
}
