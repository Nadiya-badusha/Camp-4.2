using HealthCareManagementSystetm.Model;
using HealthCareManagementSystetm.Repository;
using HealthCareManagementSystetm.Service;

namespace HealthCareManagementSystetm
{
    public class Program
    {
        static async Task Main()
        {
            string connectionString = "Your_Connection_String_Here";
            IPatientRepository repo = new PatientRepository(connectionString);
            IPatientService service = new PatientService(repo);

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Healthcare Management System ---");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. View All Patients");
                Console.WriteLine("3. Update Patient");
                Console.WriteLine("4. Delete Patient");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        await AddPatientAsync(service);
                        break;

                    case "2":
                        await ViewPatientsAsync(service);
                        break;

                    case "3":
                        await UpdatePatientAsync(service);
                        break;

                    case "4":
                        await DeletePatientAsync(service);
                        break;

                    case "5":
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static async Task AddPatientAsync(IPatientService service)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            int.TryParse(Console.ReadLine(), out int age);

            Console.Write("Enter diagnosis: ");
            string diagnosis = Console.ReadLine();

            Console.Write("Enter treatment plan: ");
            string treatment = Console.ReadLine();

            var patient = new Patient
            {
                PatientName = name,
                Age = age,
                Diagnosis = diagnosis,
                TreatmentPlan = treatment
            };

            try
            {
                await service.AddPatientAsync(patient);
                Console.WriteLine("Patient added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static async Task ViewPatientsAsync(IPatientService service)
        {
            var patients = await service.GetPatientsAsync();

            Console.WriteLine("\nPatients:");
            Console.WriteLine("{0,-10} {1,-20} {2,-5} {3,-20} {4,-25}", "ID", "Name", "Age", "Diagnosis", "Treatment");
            Console.WriteLine(new string('-', 80));

            foreach (var p in patients)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-5} {3,-20} {4,-25}",
                    p.PatientID, p.PatientName, p.Age, p.Diagnosis, p.TreatmentPlan);
            }
        }

        static async Task UpdatePatientAsync(IPatientService service)
        {
            Console.Write("Enter Patient ID to update: ");
            int.TryParse(Console.ReadLine(), out int id);

            Console.Write("Enter new name: ");
            string name = Console.ReadLine();

            Console.Write("Enter new age: ");
            int.TryParse(Console.ReadLine(), out int age);

            Console.Write("Enter new diagnosis: ");
            string diagnosis = Console.ReadLine();

            Console.Write("Enter new treatment plan: ");
            string treatment = Console.ReadLine();

            var patient = new Patient
            {
                PatientID = id,
                PatientName = name,
                Age = age,
                Diagnosis = diagnosis,
                TreatmentPlan = treatment
            };

            try
            {
                await service.UpdatePatientAsync(patient);
                Console.WriteLine("Patient updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static async Task DeletePatientAsync(IPatientService service)
        {
            Console.Write("Enter Patient ID to delete: ");
            int.TryParse(Console.ReadLine(), out int id);

            try
            {
                await service.DeletePatientAsync(id);
                Console.WriteLine("Patient deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}