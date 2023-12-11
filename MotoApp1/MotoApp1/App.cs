using MotoApp.Components.CsvReader.Models;
using MotoApp.Data;
using System.Xml.Linq;

namespace MotoApp;

public class App : IApp
{
    private readonly ICsvReader _csvReader;
    private readonly MotoAppDbContext _dbContext;

    public App(ICsvReader csvReader, MotoAppDbContext dbContext)
    {
        _csvReader = csvReader;
        _dbContext = dbContext;
        _dbContext.Database.EnsureCreated();
    }

    public void Run()
    {
        var cars = _csvReader.ProcessCars("D:\\repos2\\repos2\\MotoApp1\\MotoApp1\\Resources\\Files\\fuel.csv");

        ///////

        //var cars = _csvReader.ProcessCars("D:\\repos2\\repos2\\MotoApp1\\MotoApp1\\Resources\\Files\\fuel.csv");
        //var manufacturers = _csvReader.ProcessManufacturesrs("D:\\repos2\\repos2\\MotoApp1\\MotoApp1\\Resources\\Files\\manufacturers.csv");

        //var groups = cars.GroupBy(x => x.Manufacturer)
        //    .Select(g=> new
        //    {
        //        Name = g.Key,
        //        Max = g.Max(c => c.Combined),
        //        Average = g.Average(c => c.Combined)
        //    })
        //    .OrderBy(x => x.Average);                                    //łączysz dwa pliki przy pomocy GroupBy

        //foreach (var group in groups)
        //{
        //    Console.WriteLine($"{group.Name}");
        //    Console.WriteLine($"{group.Max}");
        //    Console.WriteLine($"{group.Average}");

        ///////////

        //}
        //var carsInCountry = cars.Join(
        //    manufacturers,
        //    c => new { c.Manufacturer, c.Year},
        //    m => new { Manufacturer = m.Name, m.Year },
        //    (car, manufacturers) =>
        //    new
        //    {                                                        // łączysz dwa pliki przy pomocy Join
        //        manufacturers.Country,
        //        car.Name,
        //        car.Combined
        //    }
        //    )
        //    .OrderByDescending(x => x.Combined)
        //    .ThenBy(x => x.Name);

        //foreach (var car in carsInCountry)
        //{
        //    Console.WriteLine($"Country: {car.Country}");
        //    Console.WriteLine($"\t Name: {car.Name}");
        //    Console.WriteLine($"\t Combined: {car.Combined}");
        //}

        ////////////////////

        //var groups = manufacturers.GroupJoin(
        //    cars,
        //    manufacturer => manufacturer.Name,
        //    car => car.Manufacturer,
        //    (m, g) => new
        //    {                                                               //// łączysz dwa pliki przy pomocy GroupJoin  połączenie metod Join i GroupBy
        //        Manufacturer = m,
        //        Cars = g
        //    })
        //    .OrderBy(x => x.Manufacturer.Name);

        //foreach (var group in groups)
        //{
        //    Console.WriteLine($"Manufacturer: {group.Manufacturer.Name}");
        //    Console.WriteLine($"\t Cars: {group.Cars.Count()}");
        //    Console.WriteLine($"\t Combined: {group.Cars.Max(x => x.Combined)}");
        //    Console.WriteLine($"\t Combined: {group.Cars.Min(x => x.Combined)}");
        //    Console.WriteLine($"\t Combined: {group.Cars.Average(x => x.Combined)}");
        //}
    }

    private static void QuertyXml()
    {
        var document = XDocument.Load("fuel.xml");
        var names = document
            .Element("Cars")
            .Elements("Car")
            .Where(x => x.Attribute("Manufacturer")?.Value == "BMW")
            .Select(x => x.Attribute("Name")?.Value);

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    private void CreateXml()
    {
        var records = _csvReader.ProcessCars("D:\\repos2\\repos2\\MotoApp1\\MotoApp1\\Resources\\Files\\fuel.csv");

        var document = new XDocument();
        var cars = new XElement("Cars", records                         //Generowanie pliku XML z pliku CSV
            .Select(x =>
                new XElement("Car",
                    new XAttribute("Name", x.Name),
                    new XAttribute("Combined", x.Combined),
                    new XAttribute("Manufacturer", x.Manufacturer))));
        document.Add(cars);
        document.Save("fuel.xml");
    }
}