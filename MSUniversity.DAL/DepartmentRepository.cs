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
    }
}
