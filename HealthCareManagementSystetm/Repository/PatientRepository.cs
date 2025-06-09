using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareManagementSystetm.Model;
using Microsoft.Data.SqlClient;

namespace HealthCareManagementSystetm.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly string _connectionString;

        public PatientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CreateAsync(Patient patient)
        {
            string query = "INSERT INTO Patients (PatientName, Age, Diagnosis, TreatmentPlan) VALUES (@name, @age, @diagnosis, @treatment)";
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", patient.PatientName);
            cmd.Parameters.AddWithValue("@age", patient.Age);
            cmd.Parameters.AddWithValue("@diagnosis", patient.Diagnosis);
            cmd.Parameters.AddWithValue("@treatment", patient.TreatmentPlan);
            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            string query = "SELECT * FROM Patients";
            var patients = new List<Patient>();
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(query, conn);
            await conn.OpenAsync();
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                patients.Add(new Patient
                {
                    PatientID = reader.GetInt32(0),
                    PatientName = reader.GetString(1),
                    Age = reader.GetInt32(2),
                    Diagnosis = reader.GetString(3),
                    TreatmentPlan = reader.GetString(4)
                });
            }
            return patients;
        }

        public async Task UpdateAsync(Patient patient)
        {
            string query = "UPDATE Patients SET PatientName=@name, Age=@age, Diagnosis=@diagnosis, TreatmentPlan=@treatment WHERE PatientID=@id";
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", patient.PatientID);
            cmd.Parameters.AddWithValue("@name", patient.PatientName);
            cmd.Parameters.AddWithValue("@age", patient.Age);
            cmd.Parameters.AddWithValue("@diagnosis", patient.Diagnosis);
            cmd.Parameters.AddWithValue("@treatment", patient.TreatmentPlan);
            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(int patientId)
        {
            string query = "DELETE FROM Patients WHERE PatientID=@id";
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", patientId);
            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
