using HealthCare.Model;
using HealthCare.Repository;
using HealthCare.Service;
using System;
using System.Threading.Tasks;

namespace HealthCare
{
    public class HealthApp
    {
        static async Task Main(string[] args)
        {
            // create an instance of service
            IHealthcareService healthcareService = new HealthcareServiceImpli(new HealthcareRepositoryImpli());

            bool exit = false;
            while (!exit)
            {
                // menu driven  
                Console.WriteLine("Healthcare Management System");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Update Patient");
                Console.WriteLine("3. Get All Patients");
                Console.WriteLine("4. Delete Patient");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        //add patient
                        await AddPatient(healthcareService);
                        break;
                    case "2":
                        //update patient
                        await UpdatePatient(healthcareService);
                        break;
                    case "3":
                        //list patient
                        await ListPatients(healthcareService);
                        break;
                    case "4":
                        //delete patient
                        await DeletePatient(healthcareService);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        //add patient 
        private static async Task AddPatient(IHealthcareService healthcareService)
        {
            var health = new Healthcare();

            Console.Write("Enter Patient Name: ");
            health.PatientName = Console.ReadLine();

            Console.Write("Enter Patient Age: ");
            health.PatientAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Diagnosis: ");
            health.Diagnosis = Console.ReadLine();

            Console.Write("Enter Treatment Plan: ");
            health.TreatmentPlan = Console.ReadLine();

            await healthcareService.AddPatientAsync(health);
            Console.WriteLine("Patient added successfully.");
        }

        //update patient
        private static async Task UpdatePatient(IHealthcareService healthcareService)
        {
            Console.Write("Enter Patient ID to update: ");
            int patientId = Convert.ToInt32(Console.ReadLine());

            var health = new Healthcare();

            Console.Write("Enter Patient Name: ");
            health.PatientName = Console.ReadLine();

            Console.Write("Enter Patient Age: ");
            health.PatientAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Diagnosis: ");
            health.Diagnosis = Console.ReadLine();

            Console.Write("Enter Treatment Plan: ");
            health.TreatmentPlan = Console.ReadLine();

            await healthcareService.UpdatePatientAsync(patientId, health);
            Console.WriteLine("Patient updated successfully.");
        }

        //list patient
        private static async Task ListPatients(IHealthcareService healthcareService)
        {
            var patients = await healthcareService.GetAllPatientsAsync();

            foreach (var patient in patients)
            {
                Console.WriteLine($"Name: {patient.PatientName}, Age: {patient.PatientAge}, Diagnosis: {patient.Diagnosis}, Treatment Plan: {patient.TreatmentPlan}");
            }
        }

        // delete patient
        private static async Task DeletePatient(IHealthcareService healthcareService)
        {
            Console.Write("Enter Patient ID to delete: ");
            int patientId = Convert.ToInt32(Console.ReadLine());

            await healthcareService.DeletePatientAsync(patientId);
            Console.WriteLine("Patient deleted successfully.");
        }
    }
}
