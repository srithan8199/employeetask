using System;
using employeetask.Managers;

class Program
{
    static void Main(string[] args)
    {
        EmployeeManager manager = new EmployeeManager();

        while (true)
        {
            Console.WriteLine("=============================");
            Console.WriteLine(" Employee Management System");
            Console.WriteLine("=============================");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Update Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. Display Employees");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.AddEmployee();
                    break;
                case "2":
                    manager.UpdateEmployee();
                    break;
                case "3":
                    manager.DeleteEmployee();
                    break;
                case "4":
                    manager.DisplayEmployees();
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}