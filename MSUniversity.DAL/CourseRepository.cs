using MSUniversity.Models;
using MSUniversity.ViewModels;
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
        //Course course = new Course();
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
        public List<Course> GetAll()
        {
            SqlConnection connection = new SqlConnection(connectionStrings);
            SqlCommand command = new SqlCommand("GetAllCourse", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            connection.Open();
            da.Fill(dt);
            connection.Close();
            var courses = new List<Course>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var course = new Course();
                course.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                course.Name = dt.Rows[i]["Name"].ToString();
                course.Code = dt.Rows[i]["Code"].ToString();
                course.Credit = Convert.ToInt32(dt.Rows[i]["Credit"]);
                course.Description = dt.Rows[i]["Description"].ToString();
                course.Semester = course.Semester;
                course.DepartmentId =Convert.ToInt32(dt.Rows[i]["DepartmentId"]);
                courses.Add(course);
            }
            return courses;
        }
        public List<CourseTeacherVM> GetCourseStatics()
        {
            SqlConnection connection = new SqlConnection(connectionStrings);
            SqlCommand command = new SqlCommand("GetCourseStatics", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            connection.Open();
            da.Fill(dt);
            connection.Close();
            var courses = new List<CourseTeacherVM>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var course = new CourseTeacherVM();
                course.DepartmentId = Convert.ToInt32(dt.Rows[i]["DepartmentId"]);
                course.CourseName = dt.Rows[i]["CName"].ToString();
                course.Code = dt.Rows[i]["Code"].ToString();
                course.Semester = course.Semester;
                course.TeacherName = dt.Rows[i]["TName"].ToString();
                courses.Add(course);
            }
            return courses;
        }
    }
}
