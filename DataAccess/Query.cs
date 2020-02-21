using FirstApp.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.DataAccess
{
    class Query
    {
        private SqlConnection connection;

        public Query()
        {
            Connector connector = new Connector();
            connection = connector.GetConnection();
        }

        public List<Dictionary<string, string>> SelectGetAll()
        {
            List<Dictionary<string, string>> employees = new List<Dictionary<string, string>>();
            connection.Open();
            SqlCommand query = new SqlCommand("select employee_id, first_name, last_name from hr.employees", connection);
            SqlDataReader reader = query.ExecuteReader();
            while(reader.Read())
            {
                Dictionary<string, string> employee = new Dictionary<string, string>();
                employee.Add("employee_id", reader["employee_id"].ToString());
                employee.Add("first_name", reader["first_name"].ToString());
                employee.Add("last_name", reader["last_name"].ToString());

                employees.Add(employee);
            }
            connection.Close();
            return employees;
        }

        public Dictionary<string, string> GetOne(int employeeId)
        {
            Dictionary<string, string> employee = new Dictionary<string, string>();
            connection.Open();

            SqlCommand query = new SqlCommand("select employee_id, first_name, last_name from hr.copy_emp where employee_id = " + employeeId, connection);
            SqlDataReader reader = query.ExecuteReader();
            reader.Read();
            employee.Add("employee_id", reader["employee_id"].ToString());
            employee.Add("first_name", reader["first_name"].ToString());
            employee.Add("last_name", reader["last_name"].ToString());

            connection.Close();

            return employee;
        }
    }
}
