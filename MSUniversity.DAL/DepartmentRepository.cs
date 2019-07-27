using MSUniversity.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace MSUniversity.DAL
{
    public class DepartmentRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MSUniversity"].ToString();
        public bool Add(Department department)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("AddDepartment",connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", department.Name);
            command.Parameters.AddWithValue("@Code",department.Code);
            connection.Open();
            int rowsAffected=command.ExecuteNonQuery();
            connection.Close();
            if(rowsAffected>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Department> GetAll()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("GetAllDepartment", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            connection.Open();
            da.Fill(dt);
            connection.Close();
            var departments = new List<Department>();
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var department = new Department();
                department.Name = dt.Rows[i]["Name"].ToString();
                department.Code = dt.Rows[i]["Code"].ToString();
                departments.Add(department);
            }
            return departments;
        }
    }
}
