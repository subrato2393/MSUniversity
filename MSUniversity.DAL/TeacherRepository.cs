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
            command.Parameters.AddWithValue("@CreditToTaken", teacher.CreditToTaken);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Teacher> GetAll()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("GetAllTeacher", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            connection.Open();
            da.Fill(dt);
            connection.Close();
            var teachers = new List<Teacher>();

            for (int i = 0; i < dt.Rows.Count;i++)
            {
                var teacher = new Teacher();
                teacher.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                teacher.Name = dt.Rows[i]["Name"].ToString();
                teacher.Address= dt.Rows[i]["Address"].ToString();
                teacher.ContactNo = dt.Rows[i]["ContactNo"].ToString();
                teacher.CreditToTaken=Convert.ToInt32(dt.Rows[i]["CreditToTaken"]);
                teacher.Designation = teacher.Designation;
                teacher.DepartmentId = Convert.ToInt32(dt.Rows[i]["DepartmentId"]);
                teacher.Email = dt.Rows[i]["Email"].ToString();
                teachers.Add(teacher);
            }
            return teachers;
        }
    }
}
