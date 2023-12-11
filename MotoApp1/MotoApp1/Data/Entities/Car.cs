using MotoApp.Data.Entities;
using System.Text;

public class Car : EntityBaase
{
    public string? Name { get; set; }
    public string? Color { get; set; }
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }
    public string Type { get; set; }

    // Calculated Properties
    public int? NameLenght { get; set; }

    public decimal? TotalSale { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new(1024);

        sb.AppendLine($"{Name} ID: {Id}");
        sb.AppendLine($" Color: {Color}  Type: {(Type ?? "n/a")}");
        sb.AppendLine($" {StandardCost:c}  Price: {ListPrice:c}");
        if (NameLenght.HasValue)
        {
            sb.AppendLine($"  Name Length: {NameLenght}");
        }
        if (TotalSale.HasValue)
        {
            sb.AppendLine($"  Total Sale: {TotalSale:c}");
        }
        return sb.ToString();
    }
}