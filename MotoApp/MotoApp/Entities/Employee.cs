namespace MotoApp.Entities
{
    public class Employee : EntityBaase
    {
        public string FirstName { get; set; }

        public override string ToString() => $"Id: {Id}, FirstName: {FirstName}";
    }
}
