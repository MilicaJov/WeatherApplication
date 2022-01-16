using OIPRWeatherApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OIPRWeatherApplication.Services
{
    public class FileCityDataService : ICityDataService
    {
        List<CityData> CitiesData { get; }

        // Dictionary was added in order to improve search speed in case of a large number
        // of data per city or per date in a file, because it is faster then searching a list
        Dictionary<string, List<CityData>> CitiesDataByCity { get; } = new Dictionary<string, List<CityData>>();
        Dictionary<DateTime, List<CityData>> CitiesDataByDate { get; } = new Dictionary<DateTime, List<CityData>>();

        public FileCityDataService(IFileReaderService fileReaderService)
        {
            CitiesData = fileReaderService.ReadFromFile();
            foreach (var c in CitiesData.Select(c => c.City).Distinct())
            {
                CitiesDataByCity.Add(c.ToLower(), CitiesData.Where(city => city.City.Equals(c)).ToList());
            }
            foreach (var d in CitiesData.Select(c => c.Date).Distinct())
            {
                CitiesDataByDate.Add(d, CitiesData.Where(city => city.Date.Date.Equals(d.Date)).ToList());
            }
        }

        public List<CityData> GetAll()
        {
            return this.CitiesData;
        }

        public List<CityData> GetAllForOneCity(string city)
        {
            CitiesDataByCity.TryGetValue(city.ToLower(), out List<CityData> cityData);
            return cityData;
        }

        public List<CityData> GetAllForOneDate(DateTime date)
        {
            CitiesDataByDate.TryGetValue(date, out List<CityData> cityData);
            return cityData;
        }
    }
}
