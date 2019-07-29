using MSUniversity.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSUniversity.DAL
{
    public class TeacherRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MSUniversity"].ToString();
        public bool Add(Teacher teacher)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SaveTeacher", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", teacher.Name);
            command.Parameters.AddWithValue("@Address", teacher.Address);
            command.Parameters.AddWithValue("@Email", teacher.Email);
            command.Parameters.AddWithValue("@ContactNo", teacher.ContactNo);
            command.Parameters.AddWithValue("@Designation", teacher.Designation);
            command.Parameters.AddWithValue("@DepartmentId", teacher.DepartmentId);
            command.Parameters.AddWithValue("@CreditToTaken",teacher.CreditToTaken);
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
