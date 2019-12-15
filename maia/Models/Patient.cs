using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maia.Models
{
    public class Patient
    {
        public string FirstName;
        public string LastName;
        public string ID = Guid.NewGuid().ToString().Substring(0, 8);
        public string DateOfBirth;
        public int age => (int)Math.Floor(DateTime.Now.Subtract(DateTime.Parse(this.DateOfBirth)).TotalDays / 365);
        public List<Visit> History = new List<Visit>();
        public List<Doctor> Doctors = new List<Doctor>();
    }

    public class Visit
    {
        public string Date;
        public string Doctor;
        public List<string> Symptoms = new List<string>();
        public string FirstDiagnosis;
        public string FinalDiagnosis;
    }

    public class Doctor
    {
        public string ID;
    }
}
