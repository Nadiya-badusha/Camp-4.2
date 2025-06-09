using StudentInformationSystem.Model;
using StudentInformationSystem.Repository;
using StudentInformationSystem.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInformationSystem
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IStudentRepository repo = new StudentRepositoryImpl();
            IStudentService service = new StudentServiceImpl(repo);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Student Information System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. List All Students");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await AddStudentInput(service);
                        break;
                    case "2":
                        await UpdateStudentInput(service);
                        break;
                    case "3":
                        await DeleteStudentInput(service);
                        break;
                    case "4":
                        await DisplayAllStudents(service);
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static async Task AddStudentInput(IStudentService service)
        {
            Console.WriteLine("\nEnter Student Details:");

            Console.Write("Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Course: ");
            string course = Console.ReadLine();

            Console.Write("Enrollment Date (yyyy-MM-dd): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime enrollmentDate);

            Console.Write("GPA: ");
            double.TryParse(Console.ReadLine(), out double gpa);

            Student student = new Student(0, name, course, enrollmentDate, gpa);
            await service.AddStudentServiceAsync(student);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static async Task UpdateStudentInput(IStudentService service)
        {
            Console.WriteLine("\nUpdate Student Details:");

            Console.Write("Student ID to update: ");
            int.TryParse(Console.ReadLine(), out int studentId);

            Console.Write("New Student Name: ");
            string name = Console.ReadLine();

            Console.Write("New Course: ");
            string course = Console.ReadLine();

            Console.Write("New Enrollment Date (yyyy-MM-dd): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime enrollmentDate);

            Console.Write("New GPA: ");
            double.TryParse(Console.ReadLine(), out double gpa);

            Student student = new Student(studentId, name, course, enrollmentDate, gpa);
            await service.UpdateStudentServiceAsync(student);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static async Task DeleteStudentInput(IStudentService service)
        {
            Console.WriteLine("\nDelete Student:");

            Console.Write("Enter Student ID to delete: ");
            int.TryParse(Console.ReadLine(), out int studentId);

            await service.DeleteStudentServiceAsync(studentId);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static async Task DisplayAllStudents(IStudentService service)
        {
            Console.WriteLine("\nList of Students:");

            List<Student> students = await service.GetAllStudentsServiceAsync();

            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
            }
            else
            {
                Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-15} | {4,5}", "StudentID", "StudentName", "Course", "EnrollmentDate", "GPA");
                Console.WriteLine(new string('-', 75));

                foreach (var s in students)
                {
                    Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-15:yyyy-MM-dd} | {4,5:F2}",
                        s.StudentID, s.StudentName, s.Course, s.EnrollmentDate, s.GPA);
                }
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
