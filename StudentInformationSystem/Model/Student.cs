using System;

namespace StudentInformationSystem.Model
{
    public class Student
    {
        public int StudentID { get; set; }  // Assuming auto-increment in DB
        public string StudentName { get; set; }
        public string Course { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public double GPA { get; set; }

        public Student() { }

        public Student(int studentID, string studentName, string course, DateTime enrollmentDate, double gpa)
        {
            StudentID = studentID;
            StudentName = studentName;
            Course = course;
            EnrollmentDate = enrollmentDate;
            GPA = gpa;
        }
    }
}
