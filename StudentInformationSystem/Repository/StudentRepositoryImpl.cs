using StudentInformationSystem.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    public class StudentRepositoryImpl : IStudentRepository
    {
        private readonly string constring = ConfigurationManager.ConnectionStrings["CsWin"].ConnectionString;

        public async Task AddStudentAsync(Student student)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(constring);
                await connection.OpenAsync();

                string query = "INSERT INTO Students (StudentName, Course, EnrollmentDate, GPA) " +
                               "VALUES (@StudentName, @Course, @EnrollmentDate, @GPA)";

                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                cmd.Parameters.AddWithValue("@Course", student.Course);
                cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
                cmd.Parameters.AddWithValue("@GPA", student.GPA);

                int rows = await cmd.ExecuteNonQueryAsync();
                Console.WriteLine($"{rows} student(s) added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding student to database");
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateStudentAsync(Student student)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(constring);
                await connection.OpenAsync();

                string query = "UPDATE Students SET StudentName=@StudentName, Course=@Course, EnrollmentDate=@EnrollmentDate, GPA=@GPA WHERE StudentID=@StudentID";

                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                cmd.Parameters.AddWithValue("@Course", student.Course);
                cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
                cmd.Parameters.AddWithValue("@GPA", student.GPA);

                int rows = await cmd.ExecuteNonQueryAsync();
                Console.WriteLine($"{rows} student(s) updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating student in database");
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(constring);
                await connection.OpenAsync();

                string query = "DELETE FROM Students WHERE StudentID = @StudentID";

                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StudentID", studentId);

                int rows = await cmd.ExecuteNonQueryAsync();
                Console.WriteLine($"{rows} student(s) deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting student from database");
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> students = new();

            try
            {
                using SqlConnection connection = new SqlConnection(constring);
                await connection.OpenAsync();

                string query = "SELECT StudentID, StudentName, Course, EnrollmentDate, GPA FROM Students";

                using SqlCommand cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    students.Add(new Student(
                        Convert.ToInt32(reader["StudentID"]),
                        reader["StudentName"].ToString(),
                        reader["Course"].ToString(),
                        Convert.ToDateTime(reader["EnrollmentDate"]),
                        Convert.ToDouble(reader["GPA"])
                    ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving students from database");
                Console.WriteLine(ex.Message);
            }

            return students;
        }
    }
}
