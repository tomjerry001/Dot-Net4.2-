using HealthCare.Model;
using HealthCare.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCare.Service
{
    public class HealthcareServiceImpli : IHealthcareService
    {
        // field
        private readonly IHealthcareRepository _healthcareRepository;

        // constructor injection
        public HealthcareServiceImpli(IHealthcareRepository healthcareRepository)
        {
            _healthcareRepository = healthcareRepository;
        }

        public async Task AddPatientAsync(Healthcare healthCare)
        {
            await _healthcareRepository.AddPatientAsync(healthCare);
        }

        public async Task UpdatePatientAsync(int id, Healthcare healthCare)
        {
            await _healthcareRepository.UpdatePatientAsync(id, healthCare);
        }

        public async Task DeletePatientAsync(int id)
        {
            await _healthcareRepository.DeletePatientAsync(id);
        }

        public async Task<List<Healthcare>> GetAllPatientsAsync()
        {
            return await _healthcareRepository.GetAllPatientsAsync();
        }
    }
}
