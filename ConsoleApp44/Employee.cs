namespace ConsoleApp44;

internal class Employee
{
    public Employee(int id, string name, decimal salary)
    {
        Id = id;
        Name = name;
        Salary = salary;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public void ShowInfo()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, Salary: {Salary}");
    }
}
