namespace MotoApp.Data.Entities
{
    public class BusinessPartner : EntityBaase
    {
        public string? Name { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}";
    }
}