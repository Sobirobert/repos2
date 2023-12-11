using MotoApp.Components.CSVReader.Models;

namespace MotoApp.Components.CsvReader.Models;

public interface ICsvReader
{
    List<Car> ProcessCars(string filePath);

    List<Manufacturer> ProcessManufacturesrs(string filePath);
}