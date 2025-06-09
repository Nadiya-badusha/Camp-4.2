using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareManagementSystetm.Model;
using HealthCareManagementSystetm.Repository;

namespace HealthCareManagementSystetm.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;

        public PatientService(IPatientRepository repo)
        {
            _repo = repo;
        }

        public async Task AddPatientAsync(Patient patient)
        {
            Validate(patient);
            await _repo.CreateAsync(patient);
        }

        public async Task<List<Patient>> GetPatientsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            Validate(patient);
            await _repo.UpdateAsync(patient);
        }

        public async Task DeletePatientAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        private void Validate(Patient patient)
        {
            var context = new ValidationContext(patient);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(patient, context, results, true))
            {
                throw new ValidationException("Validation failed: " + string.Join(", ", results));
            }
        }
    }
}
