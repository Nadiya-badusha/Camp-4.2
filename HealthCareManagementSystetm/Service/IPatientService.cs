using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareManagementSystetm.Model;

namespace HealthCareManagementSystetm.Service
{
    public interface IPatientService
    {
        Task AddPatientAsync(Patient patient);
        Task<List<Patient>> GetPatientsAsync();
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(int id);
    }
}
