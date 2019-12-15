using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using maia.Models;
using Newtonsoft.Json;

namespace maia
{
    public class Storage
    {
        public static List<Patient> Patients
        {
            get
            {
                return JsonConvert.DeserializeObject<List<Patient>>(PatientsJSON);
            }
            set => File.WriteAllText("patients.json", JsonConvert.SerializeObject(value, Formatting.Indented));
        }

        public static void AddPatient(Patient patient)
        {
            List<Patient> _patients = Patients;
            _patients.Add(patient);
            Patients = _patients;
        }

        public static string PatientsJSON
        {
            get
            {
                return File.ReadAllText("patients.json");
            }
            set
            {
                File.WriteAllText("patients.json", value);
            }
        }
    }
}
