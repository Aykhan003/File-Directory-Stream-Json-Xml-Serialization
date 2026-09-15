using ConsoleApp44;
using System.Text.Json;

string directory = "C:\\Users\\User\\source\\repos\\ConsoleApp44\\ConsoleApp44\\";
string path = Path.Combine(directory, "aykhan");
string filePath = Path.Combine(path, "task.json");
if (!Directory.Exists(path))
{
    Directory.CreateDirectory(path);
}
if (!File.Exists(filePath))
{
    File.Create(filePath).Close();
}
while (true)
{
    Console.WriteLine("1. Add Employee");
    Console.WriteLine("2. Get Employee by Id");
    Console.WriteLine("3. Remove Employee by Id");
    Console.WriteLine("4. Exit");
    Console.Write("Select an option: ");
    string option = Console.ReadLine();
    switch (option)
    {
        case "1":
            AddEmployee(filePath);
            break;
        case "2":
            GetEmployeeById(filePath);
            break;
        case "3":
            RemoveEmployeeById();
            break;
        case "4":
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

void AddEmployee(string filePath)
{
    Console.WriteLine("Enter employee details:");
    Console.Write("Id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Salary: ");
    decimal salary = Convert.ToDecimal(Console.ReadLine());
    Employee newEmployee = new Employee(id, name, salary);
    string json = File.ReadAllText(filePath);
    Department department1;
    if (string.IsNullOrWhiteSpace(json))
    {
        department1 = new Department();
    }
    else
    {
        department1 = JsonSerializer.Deserialize<Department>(json);
    }
    department1.Employees.Add(newEmployee);
    string updatedJson = JsonSerializer.Serialize(department1);
    File.WriteAllText(filePath, updatedJson);
    Console.WriteLine("Employee added successfully.");
}
void GetEmployeeById(string filePath)
{
    Console.Write("Enter employee Id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    string json = File.ReadAllText(filePath);
    if (string.IsNullOrWhiteSpace(json))
    {
        Console.WriteLine("No employees found.");
        return;
    }
    Department department1 = JsonSerializer.Deserialize<Department>(json);
    department1.GetEmployeesById(id);
}
void RemoveEmployeeById()
{
    Console.Write("Enter employee Id to remove: ");
    int id = Convert.ToInt32(Console.ReadLine());
    string json = File.ReadAllText(filePath);
    if (string.IsNullOrWhiteSpace(json))
    {
        Console.WriteLine("No employees found.");
        return;
    }
    Department department1 = JsonSerializer.Deserialize<Department>(json);
    department1.RemoveEmployeeById(id);
    string updatedJson = JsonSerializer.Serialize(department1);
    File.WriteAllText(filePath, updatedJson);
    Console.WriteLine("Employee removed successfully.");
}