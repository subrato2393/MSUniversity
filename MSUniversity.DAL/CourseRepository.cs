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
    public class CourseRepository
    {
        string connectionStrings = ConfigurationManager.ConnectionStrings["MSUniversity"].ConnectionString;

        public bool Add(Course course)
        {
            SqlConnection connection = new SqlConnection(connectionStrings);
            SqlCommand command = new SqlCommand("AddCourse",connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Code",course.Code);
            command.Parameters.AddWithValue("@Name",course.Name);
            command.Parameters.AddWithValue("@Credit",course.Credit);
            command.Parameters.AddWithValue("@Description",course.Description);
            command.Parameters.AddWithValue("@Semester", course.Semester);
            command.Parameters.AddWithValue("@DepartmentId",course.DepartmentId);
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
