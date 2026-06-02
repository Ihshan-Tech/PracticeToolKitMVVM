using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeToolKitMVVM.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Disease { get; set; }
        public string DoctorName { get; set; }
    }
}
