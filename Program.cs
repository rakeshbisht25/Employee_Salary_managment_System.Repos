using Microsoft.Data.SqlClient;
using System;
using Employee_Salary_managment_System.Data;
using Employee_Salary_managment_System.Services;
namespace Employee_Salary_managment_System

{
    public class Program
    {


        static void Main(string[] args)
        {
            EmployeeServices services = new EmployeeServices();
            

            while (true)
            {

                Console.WriteLine("=======================================");
                Console.WriteLine(" Employee Salary Management System ");
                Console.WriteLine("=======================================");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Calculate Salary");
                Console.WriteLine("7. Generate Salary Slip");
                Console.WriteLine("0. Exit");

                Console.Write("\nEnter Your Choice : ");


                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        services.AddEmployee();
                        break;
                        

                    case 2:
                        services.ViewEmployee();
                        break;

                    case 3:
                        services.SearchEmployee();
                        break;

                    case 4:
                        services.UpdateEmployee();
                        break;

                    case 5:
                        services.DeleteEmployee();
                        break;

                    case 6:
                        services.CalculateSalary();
                        break;

                    case 7:
                        services.GenerateSalarySlip();
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

                Console.WriteLine("\nPress Any Key To Continue...");
                Console.ReadKey();
            }
        }

       
    }
}
