using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;

class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

class EmployeeRepository
{
    private readonly string filePath = "employees.json";
    public List<Employee> Employees { get; private set; } = new List<Employee>();

    public void Load()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                Employees = JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading data: " + ex.Message);
        }
    }

    public void Save()
    {
        try
        {
            string json = JsonSerializer.Serialize(Employees, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving data: " + ex.Message);
        }
    }
}

class Program
{
    static EmployeeRepository repository = new EmployeeRepository();
    static readonly object locker = new object();

    static void Main()
    {
        repository.Load();
        while (true)
        {
            Console.WriteLine("\n--- Employee Management System ---");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Edit Employee Age");
            Console.WriteLine("3. List Employees");
            Console.WriteLine("4. Search Employee");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new Thread(AddEmployee).Start();
                    break;
                case "2":
                    new Thread(EditEmployee).Start();
                    break;
                case "3":
                    new Thread(ListEmployees).Start();
                    break;
                case "4":
                    new Thread(SearchEmployee).Start();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Thread.Sleep(1000); // Let threads run briefly before re-showing menu
        }
    }

    static void AddEmployee()
    {
        Console.Write("Enter name: ");
        string? name = Console.ReadLine();

        Console.Write("Enter age: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Invalid age.");
            return;
        }

        Console.Write("Enter city: ");
        string? city = Console.ReadLine();

        Thread.Sleep(1000); // Simulate processing

        lock (locker)
        {
            repository.Employees.Add(new Employee { Name = name!, Age = age, City = city! });
            repository.Save();
            Console.WriteLine("Employee added.");
        }
    }

    static void EditEmployee()
    {
        Console.Write("Enter employee name to edit: ");
        string? name = Console.ReadLine();

        Console.Write("Enter new age: ");
        if (!int.TryParse(Console.ReadLine(), out int newAge))
        {
            Console.WriteLine("Invalid age.");
            return;
        }

        Thread.Sleep(1000); // Simulate processing

        lock (locker)
        {
            var emp = repository.Employees.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (emp != null)
            {
                emp.Age = newAge;
                repository.Save();
                Console.WriteLine("Employee updated.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }

    static void ListEmployees()
    {
        Thread.Sleep(1000); // Simulate processing

        lock (locker)
        {
            if (repository.Employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.WriteLine("\n-- Employee List --");
            foreach (var emp in repository.Employees)
            {
                Console.WriteLine($"Name: {emp.Name}, Age: {emp.Age}, City: {emp.City}");
            }
        }
    }

    static void SearchEmployee()
    {
        Console.WriteLine("Search by: 1. Name  2. Age");
        string? option = Console.ReadLine();

        lock (locker)
        {
            if (option == "1")
            {
                Console.Write("Enter name to search: ");
                string? name = Console.ReadLine();
                var results = repository.Employees.Where(e => e.Name.Contains(name!, StringComparison.OrdinalIgnoreCase)).ToList();

                if (results.Count == 0)
                {
                    Console.WriteLine("No employees found.");
                }
                else
                {
                    foreach (var e in results)
                    {
                        Console.WriteLine($"Name: {e.Name}, Age: {e.Age}, City: {e.City}");
                    }
                }
            }
            else if (option == "2")
            {
                Console.Write("Enter age to search: ");
                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    var results = repository.Employees.Where(e => e.Age == age).ToList();

                    if (results.Count == 0)
                    {
                        Console.WriteLine("No employees found.");
                    }
                    else
                    {
                        foreach (var e in results)
                        {
                            Console.WriteLine($"Name: {e.Name}, Age: {e.Age}, City: {e.City}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid age.");
                }
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}
