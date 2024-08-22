using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Model
{
    public class Healthcare
    {
        // fields/ date members
        private int id;

        public string PatientName {  get; set; }

        public int PatientAge { get; set;}

        public string Diagnosis { get; set;}

        public string TreatmentPlan { get; set;}

        // def constructor
        public Healthcare()
        {
            
        }

        // Parameterized constructor
        public Healthcare(string patientName, int patientAge, string diagnosis, string treatmentPlan)
        {
            this.PatientName = patientName;
            this.PatientAge = patientAge;
            this.Diagnosis = diagnosis;
            this.TreatmentPlan = treatmentPlan;
        }
    }
}
