using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Employee_Salary_managment_System.Data
{
    public static class DbContext
    {
        private static string connectionString =
 @"Server=DESKTOP-143J8TJ\SQLEXPRESS;
Database=EmployeeDb;
Trusted_Connection=True;
TrustServerCertificate=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
