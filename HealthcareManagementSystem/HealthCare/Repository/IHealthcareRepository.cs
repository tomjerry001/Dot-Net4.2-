using HealthCare.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCare.Repository
{
    public interface IHealthcareRepository
    {
        
        // insert
        Task AddPatientAsync(Healthcare healthCare);
        // update
        Task UpdatePatientAsync(int id, Healthcare healthCare);

        // delete
        Task DeletePatientAsync(int id);

        // list
        Task<List<Healthcare>> GetAllPatientsAsync();
    }
}
