using Microsoft.AspNetCore.Mvc;
using OIPRWeatherApplication.Models;
using OIPRWeatherApplication.Services;
using System;
using System.Collections.Generic;

namespace OIPRWeatherApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDataController : ControllerBase
    {
        static readonly ICityDataService service = new FileCityDataService(new CSVReaderService());

        [HttpGet("data")]
        public ActionResult<List<CityData>> GetAllData()
        {
            return service.GetAll();
        }

        [HttpGet("data/{date}")]
        public ActionResult<List<CityData>> GetAllCities(DateTime date)
        {
            List<CityData> cities = service.GetAllForOneDate(date);
            return (cities != null && cities.Count > 0) ? cities : NotFound();
        }

        [HttpGet("city/{city}")]
        public ActionResult<List<CityData>> GetCityDataForAllDates(string city)
        {
            List<CityData> cities = service.GetAllForOneCity(city);
            return (cities != null && cities.Count > 0) ? cities : NotFound();
        }
    }
}
