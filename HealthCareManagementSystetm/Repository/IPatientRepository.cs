using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareManagementSystetm.Model;

namespace HealthCareManagementSystetm.Repository
{
    public interface IPatientRepository
    {
        Task CreateAsync(Patient patient);
        Task<List<Patient>> GetAllAsync();
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(int patientId);
    }
}
