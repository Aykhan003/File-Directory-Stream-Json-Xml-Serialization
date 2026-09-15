namespace ConsoleApp44;

internal class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();
    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }
    public void GetEmployeesById(int id)
    {
        var employee = Employees.Find(e => e.Id == id);
        if (employee != null)
        {
            employee.ShowInfo();
        }
        else
        {
            Console.WriteLine($"Employee with Id {id} not found.");
        }
    }
    public void RemoveEmployeeById(int id)
    {
        var employee = Employees.Find(e => e.Id == id);
        if (employee != null)
        {
            Employees.Remove(employee);
            Console.WriteLine($"Employee with Id {id} removed.");
        }
        else
        {
            Console.WriteLine($"Employee with Id {id} not found.");
        }
    }
}
