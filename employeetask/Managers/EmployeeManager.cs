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

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Department: ");
                string department = Console.ReadLine();

                Console.Write("Salary: ");
                double salary = double.Parse(Console.ReadLine());

                Employee employee = new Employee {Name = name, Age = age, Department = department, Salary = salary };

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
                if (!string.IsNullOrWhiteSpace(ageInput)) employee.Age = int.Parse(ageInput);

                Console.Write("Enter new department (press enter to keep current): ");
                string department = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(department)) employee.Department = department;

                Console.Write("Enter new salary (press enter to keep current): ");
                string salaryInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(salaryInput)) employee.Salary = double.Parse(salaryInput);

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

            Console.WriteLine("ID\tName\tAge\tDepartment\tSalary");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Id}\t{employee.Name}\t{employee.Age}\t{employee.Department}\t{employee.Salary}");
            }
        }
    }
}
