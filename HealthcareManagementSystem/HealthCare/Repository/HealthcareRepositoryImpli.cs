using HealthCare.Model;
using SqlServerConnectionLibrary;
using System.Collections.Generic;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HealthCare.Repository
{
    public class HealthcareRepositoryImpli : IHealthcareRepository
    {
        //Get Database connection
        string winconnString = ConfigurationManager.ConnectionStrings["CsWin"].ConnectionString;

        public async Task AddPatientAsync(Healthcare healthCare)
        {
            using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(winconnString))
            {
                // insert query
                string query = "INSERT INTO Patient(PatientName, PatientAge, Diagnosis, TreatmentPlan)" +
                               "VALUES(@PatName, @PatAge, @Diag, @TrePla)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@PatName", healthCare.PatientName);
                    command.Parameters.AddWithValue("@PatAge", healthCare.PatientAge);
                    command.Parameters.AddWithValue("@Diag", healthCare.Diagnosis);
                    command.Parameters.AddWithValue("@TrePla", healthCare.TreatmentPlan);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdatePatientAsync(int patientId, Healthcare healthCare)
        {
            using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(winconnString))
            {
                // update query
                string query = "UPDATE Patient SET PatientName = @PatName, PatientAge = @PatAge, " +
                               "Diagnosis = @Diag, TreatmentPlan = @TrePla WHERE PatientId = @PatId";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@PatId", patientId);
                    command.Parameters.AddWithValue("@PatName", healthCare.PatientName);
                    command.Parameters.AddWithValue("@PatAge", healthCare.PatientAge);
                    command.Parameters.AddWithValue("@Diag", healthCare.Diagnosis);
                    command.Parameters.AddWithValue("@TrePla", healthCare.TreatmentPlan);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeletePatientAsync(int patientId)
        {
            using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(winconnString))
            {
                // delete query
                string query = "DELETE FROM Patient WHERE PatientId = @PatId";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@PatId", patientId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Healthcare>> GetAllPatientsAsync()
        {
            var patients = new List<Healthcare>();

            using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(winconnString))
            {
                // list
                string query = "SELECT PatientId, PatientName, PatientAge, Diagnosis, TreatmentPlan FROM Patient";

                using (SqlCommand command = new SqlCommand(query, conn))
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var patient = new Healthcare
                        {
                            PatientName = reader["PatientName"].ToString(),
                            PatientAge = Convert.ToInt32(reader["PatientAge"]),
                            Diagnosis = reader["Diagnosis"].ToString(),
                            TreatmentPlan = reader["TreatmentPlan"].ToString(),
                        };
                        patients.Add(patient);
                    }
                }
            }
            return patients;
        }
    }
}
