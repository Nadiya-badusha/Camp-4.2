using StudentInformationSystem.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int studentId);
        Task<List<Student>> GetAllStudentsAsync();
    }
}