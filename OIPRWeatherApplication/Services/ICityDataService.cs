using OIPRWeatherApplication.Models;
using System;
using System.Collections.Generic;

namespace OIPRWeatherApplication.Services
{
    // The assumption here is that there might be another way of geting the data,
    // for example a database, and then we would't need to use a structure like a
    // dictionary in order to achieve faster fetching of data
    public interface ICityDataService
    {
        List<CityData> GetAll();
        List<CityData> GetAllForOneCity(string city);
        List<CityData> GetAllForOneDate(DateTime date);
    }
}
