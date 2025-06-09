using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareManagementSystetm.Model
{
    public class Patient
    {
        public int PatientID { get; set; }

     
        public string PatientName { get; set; }

      
        public int Age { get; set; }

      
        public string Diagnosis { get; set; }

        public string TreatmentPlan { get; set; }
    }
}
