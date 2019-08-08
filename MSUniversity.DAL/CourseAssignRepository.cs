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
    public class CourseAssignRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MSUniversity"].ToString();
        public bool Add(CourseAssign courseAssign)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("CourseAssigns", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CourseId", courseAssign.CourseId);
            command.Parameters.AddWithValue("@TeacherId", courseAssign.TeacherId);
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
        public int GetRemainningCredit()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("GetRemainingCredit", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            connection.Open();
            da.Fill(dt);
            connection.Close();
            var courseAssigns = new List<CourseAssign>();
            int credit = 0;
            int remainingCredit = 0;
            int creditToTaken = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var courseAssign = new CourseAssign();
                var course = new Course();
                var teacher = new Teacher();
                courseAssign.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                course.Credit=Convert.ToInt32(dt.Rows[i]["Credit"]);
                teacher.CreditToTaken =Convert.ToInt32(dt.Rows[i]["CreditToTaken"]);
                credit = credit + course.Credit;
                creditToTaken = teacher.CreditToTaken;
            }
            remainingCredit = creditToTaken - credit;
            return remainingCredit;
        }
    }
}

