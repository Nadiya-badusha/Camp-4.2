using StudentInformationSystem.Model;
using StudentInformationSystem.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInformationSystem.Service
{
    public class StudentServiceImpl : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentServiceImpl(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task AddStudentServiceAsync(Student student)
        {
            await _studentRepository.AddStudentAsync(student);
        }

        public async Task UpdateStudentServiceAsync(Student student)
        {
            await _studentRepository.UpdateStudentAsync(student);
        }

        public async Task DeleteStudentServiceAsync(int studentId)
        {
            await _studentRepository.DeleteStudentAsync(studentId);
        }

        public async Task<List<Student>> GetAllStudentsServiceAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }
    }
}

