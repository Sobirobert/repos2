using MotoApp.Entities;
using MotoApp.Repositories;
using MotoApp.Data;

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());

AddEmployee(employeeRepository);
AddMenager(employeeRepository);
WriteAllConsole(employeeRepository);

static void AddEmployee(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Adam" });
    employeeRepository.Add(new Employee { FirstName = "Piotr" });
    employeeRepository.Add(new Employee { FirstName = "Zuzia" });
    employeeRepository.Save();
}

static void AddMenager(IWriteRepository<Menager> menagerRepository)
{
    menagerRepository.Add(new Menager { FirstName = "Przemek" });
    menagerRepository.Add(new Menager { FirstName = "Tomek" });
    menagerRepository.Save();
}

static void WriteAllConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items) 
    {
        Console.WriteLine(item);
    }
}