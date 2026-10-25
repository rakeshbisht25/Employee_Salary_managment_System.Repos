using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee_Salary_managment_System.Repository;

namespace Employee_Salary_managment_System.Services
{
    public class EmployeeServices
    {
        public EmployeeRepository _repo;
        public EmployeeServices()
        {
            _repo = new EmployeeRepository(); 
        }
        public void AddEmployee()
        {
            Console.WriteLine("Validation Started");
            _repo.AddEmployee();
            Console.WriteLine("Employee Added");
        }
        public void ViewEmployee()
        {
            _repo.ViewEmployee();
        }
        public void SearchEmployee()
        {
            _repo.SearchEmployee();
        }
        public void UpdateEmployee()
        {
            _repo.UpdateEmployee();
        }
        public void DeleteEmployee()
        {
            _repo.DeleteEmployee();
        }
        public void CalculateSalary()
        {
            _repo.CalculateSalary();
        }
        public void GenerateSalarySlip()
        {
            _repo.GenerateSalarySlip();
        }
    }
}
