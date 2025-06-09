using StudentInformationSystem.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInformationSystem.Service
{
    public interface IStudentService
    {
        Task AddStudentServiceAsync(Student student);
        Task UpdateStudentServiceAsync(Student student);
        Task DeleteStudentServiceAsync(int studentId);
        Task<List<Student>> GetAllStudentsServiceAsync();
    }
}

