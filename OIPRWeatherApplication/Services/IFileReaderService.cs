using OIPRWeatherApplication.Models;
using System.Collections.Generic;

namespace OIPRWeatherApplication.Services
{
    // The assumption here is that we might want to allow users to
    // read data from a file with a different file extension
    public interface IFileReaderService
    {
        List<CityData> ReadFromFile();
    }
}
