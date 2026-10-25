using Employee_Salary_managment_System.Data;
using Employee_Salary_managment_System.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Salary_managment_System.Repository
{
    public class EmployeeRepository
    {
        public void AddEmployee()
        {
            Console.Write("Employee Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Name : ");
            string name = Console.ReadLine();

            Console.Write("Department : ");
            string department = Console.ReadLine();

            Console.Write("Designation : ");
            string designation = Console.ReadLine();

            Console.Write("Basic Salary : ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            using (SqlConnection con = DbContext.GetConnection())
            {
                string query =
                @"INSERT INTO Employee
                (EmployeeId,Name,Department,Designation,BasicSalary)
                VALUES
                (@Id,@Name,@Department,@Designation,@Salary)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Department", department);
                cmd.Parameters.AddWithValue("@Designation", designation);
                cmd.Parameters.AddWithValue("@Salary", salary);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Employee Added Successfully");
        }

        public void ViewEmployee()
        {
            using (SqlConnection con = DbContext.GetConnection())
            {
                string query = "SELECT * FROM Employee";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("\n-------------------------");

                    Console.WriteLine("Employee Id : " + reader["EmployeeId"]);
                    Console.WriteLine("Name : " + reader["Name"]);
                    Console.WriteLine("Department : " + reader["Department"]);
                    Console.WriteLine("Designation : " + reader["Designation"]);
                    Console.WriteLine("Basic Salary : " + reader["BasicSalary"]);
                }
            }
        }

        public void SearchEmployee()
        {
            Console.Write("Enter Employee Id : ");

            int id = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = DbContext.GetConnection())
            {
                string query =
                "SELECT * FROM Employee WHERE EmployeeId=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine("\nEmployee Found");

                    Console.WriteLine("Employee Id : " + reader["EmployeeId"]);
                    Console.WriteLine("Name : " + reader["Name"]);
                    Console.WriteLine("Department : " + reader["Department"]);
                    Console.WriteLine("Designation : " + reader["Designation"]);
                    Console.WriteLine("Basic Salary : " + reader["BasicSalary"]);
                }
                else
                {
                    Console.WriteLine("Employee Not Found");
                }
            }
        }

        public void UpdateEmployee()
        {
            Console.Write("Employee Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("New Name : ");
            string name = Console.ReadLine();

            Console.Write("New Department : ");
            string department = Console.ReadLine();

            Console.Write("New Designation : ");
            string designation = Console.ReadLine();

            Console.Write("New Salary : ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            using (SqlConnection con = DbContext.GetConnection())
            {
                string query =
                @"UPDATE Employee
                SET Name=@Name,
                    Department=@Department,
                    Designation=@Designation,
                    BasicSalary=@Salary
                WHERE EmployeeId=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Department", department);
                cmd.Parameters.AddWithValue("@Designation", designation);
                cmd.Parameters.AddWithValue("@Salary", salary);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Employee Updated Successfully");
                else
                    Console.WriteLine("Employee Not Found");
            }
        }

        public void DeleteEmployee()
        {
            Console.Write("Employee Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = DbContext.GetConnection())
            {
                string query =
                "DELETE FROM Employee WHERE EmployeeId=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Employee Deleted Successfully");
                else
                    Console.WriteLine("Employee Not Found");
            }
        }

        public void CalculateSalary()
        {
            Console.Write("Enter Employee Id : ");

            int id = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = DbContext.GetConnection())
            {
                string query =
                "SELECT * FROM Employee WHERE EmployeeId=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    decimal basicSalary =
                        Convert.ToDecimal(reader["BasicSalary"]);

                    decimal hra = basicSalary * 0.20m;
                    decimal allowance = basicSalary * 0.10m;
                    decimal deduction = basicSalary * 0.05m;

                    decimal netSalary =
                        basicSalary + hra + allowance - deduction;

                    Console.WriteLine("\n===== Salary Details =====");

                    Console.WriteLine("Basic Salary : " + basicSalary);
                    Console.WriteLine("HRA : " + hra);
                    Console.WriteLine("Allowance : " + allowance);
                    Console.WriteLine("Deduction : " + deduction);
                    Console.WriteLine("Net Salary : " + netSalary);
                }
                else
                {
                    Console.WriteLine("Employee Not Found");
                }
            }
        }

        public void GenerateSalarySlip()
        {
            Console.Write("Enter Employee Id : ");

            int id = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = DbContext.GetConnection())
            {
                string query =
                "SELECT * FROM Employee WHERE EmployeeId=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    decimal basic =
                        Convert.ToDecimal(reader["BasicSalary"]);

                    decimal hra = basic * 0.20m;
                    decimal allowance = basic * 0.10m;
                    decimal deduction = basic * 0.05m;

                    decimal netSalary =
                        basic + hra + allowance - deduction;

                    Console.WriteLine("\n=================================");
                    Console.WriteLine("      EMPLOYEE SALARY SLIP");
                    Console.WriteLine("=================================");

                    Console.WriteLine("Employee Id : " + reader["EmployeeId"]);
                    Console.WriteLine("Name : " + reader["Name"]);
                    Console.WriteLine("Department : " + reader["Department"]);
                    Console.WriteLine("Designation : " + reader["Designation"]);

                    Console.WriteLine("---------------------------------");

                    Console.WriteLine("Basic Salary : " + basic);
                    Console.WriteLine("HRA : " + hra);
                    Console.WriteLine("Allowance : " + allowance);
                    Console.WriteLine("Deduction : " + deduction);

                    Console.WriteLine("---------------------------------");

                    Console.WriteLine("Net Salary : " + netSalary);

                    Console.WriteLine("=================================");
                }
                else
                {
                    Console.WriteLine("Employee Not Found");
                }
            }
        }

    }
}
