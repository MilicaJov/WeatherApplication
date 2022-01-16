using OIPRWeatherApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace OIPRWeatherApplication.Services
{
    public class CSVReaderService : IFileReaderService
    {
        private readonly string filePath;

        public CSVReaderService()
        {
            filePath = @"Resources\temps.csv";
        }

        public CSVReaderService(string filePath)
        {
            this.filePath = filePath;
        }

        public List<CityData> ReadFromFile()
        {
            var reader = new StreamReader(filePath);
            var citiesData = new List<CityData>();

            reader.ReadLine(); // Skip column names
            while (!reader.EndOfStream)
            {
                var cityData = reader.ReadLine();
                var cityInfo = cityData.Split(',');
                string cityName = cityInfo[0];
                DateTime date = DateTime.Parse(cityInfo[1]);
                int maximumTemperature = int.Parse(cityInfo[2]);
                int minimumTemperature = int.Parse(cityInfo[3]);
                citiesData.Add(new CityData()
                {
                    City = cityName,
                    Date = date,
                    Max = maximumTemperature,
                    Min = minimumTemperature
                });
            }

            return citiesData;
        }
    }
}
