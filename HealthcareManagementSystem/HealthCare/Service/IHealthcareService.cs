using HealthCare.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCare.Service
{
    public interface IHealthcareService
    {
        // insert
        Task AddPatientAsync(Healthcare healthCare);
        // uodate
        Task UpdatePatientAsync(int id, Healthcare healthCare);

        // delete
        Task DeletePatientAsync(int id);

        // list
        Task<List<Healthcare>> GetAllPatientsAsync();
    }
}
