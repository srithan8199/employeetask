using System;
using employeetask.Data;
using employeetask.Models;

namespace employeetask.Managers
{
    public class EmployeeManager
    {
        private readonly ApplicationDbContext _context;

        public EmployeeManager()
        {
            _context = new ApplicationDbContext();
        }

        
        public void AddEmployee()
        {
            try
            {
                Console.WriteLine("Enter Employee Details:");

                string name;
                while (true)
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name)) break;
                    Console.WriteLine("Name is required. Please enter a valid name.");
                }

                int age;
                while (true)
                {
                    Console.Write("Age: ");
                    if (int.TryParse(Console.ReadLine(), out age) && age >= 18 && age <= 65) break;
                    Console.WriteLine("Age must be between 18 and 65. Please enter a valid age.");
                }

                string department;
                while (true)
                {
                    Console.Write("Department: ");
                    department = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(department)) break;
                    Console.WriteLine("Department is required. Please enter a valid department.");
                }

                double salary;
                while (true)
                {
                    Console.Write("Salary: ");
                    if (double.TryParse(Console.ReadLine(), out salary) && salary > 0) break;
                    Console.WriteLine("Salary must be greater than zero. Please enter a valid salary.");
                }

                Employee employee = new Employee { Name = name, Age = age, Department = department, Salary = salary };

                _context.Employees.Add(employee);
                _context.SaveChanges();

                Console.WriteLine("Employee added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void UpdateEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to update: ");
                int id = int.Parse(Console.ReadLine());

                var employee = _context.Employees.Find(id);
                if (employee == null)
                {
                    Console.WriteLine("Employee not found.");
                    return;
                }

                Console.Write("Enter new name (press enter to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name)) employee.Name = name;

                Console.Write("Enter new age (press enter to keep current): ");
                string ageInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(ageInput))
                {
                    if (int.TryParse(ageInput, out int age) && age >= 18 && age <= 65)
                    {
                        employee.Age = age;
                    }
                    else
                    {
                        Console.WriteLine("Invalid age. Keeping current age.");
                    }
                }

                Console.Write("Enter new department (press enter to keep current): ");
                string department = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(department)) employee.Department = department;

                Console.Write("Enter new salary (press enter to keep current): ");
                string salaryInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(salaryInput))
                {
                    if (double.TryParse(salaryInput, out double salary) && salary > 0)
                    {
                        employee.Salary = salary;
                    }
                    else
                    {
                        Console.WriteLine("Invalid salary. Keeping current salary.");
                    }
                }

                _context.SaveChanges();
                Console.WriteLine("Employee updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DeleteEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                var employee = _context.Employees.Find(id);
                if (employee == null)
                {
                    Console.WriteLine("Employee not found.");
                    return;
                }

                _context.Employees.Remove(employee);
                _context.SaveChanges();
                Console.WriteLine("Employee deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DisplayEmployees()
        {
            var employees = _context.Employees.ToList();
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.WriteLine("{0,-5} {1,-20} {2,-5} {3,-15} {4,-10}", "ID", "Name", "Age", "Department", "Salary");
            foreach (var employee in employees)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-5} {3,-15} {4,-10}", employee.Id, employee.Name, employee.Age, employee.Department, employee.Salary);
            }
        }
    }
}
