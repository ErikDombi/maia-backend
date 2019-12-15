using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace maia.Controllers
{
    public class PatientsController : Controller
    {
        [HttpGet]
        [Route("/api/patients/")]
        public IActionResult Index([FromHeader]string Authorization)
        {
            return Content(JsonConvert.SerializeObject(Storage.Patients.Where(t => t.Doctors.Select(c => c.ID).Contains(Authorization)), Formatting.Indented));
        }

        [HttpGet]
        [Route("/api/patients/{id}/")]
        public IActionResult Index(string id, [FromHeader]string Authorization)
        {
            var patient = Storage.Patients.FirstOrDefault(t => t.ID == id);
            return Content(JsonConvert.SerializeObject(patient, Formatting.Indented));
        }

        [HttpPost]
        [Route("/api/patients/")]
        public IActionResult Add([FromForm]string patient)
        {
            patient = patient.Replace("\n", "");
            var pJSON = JsonConvert.DeserializeObject<maia.Models.Patient>(patient);
            pJSON.ID = Guid.NewGuid().ToString().Substring(0, 8);
            Storage.AddPatient(pJSON);
            return Json(pJSON.ID);
        }
        [HttpPut]
        [Route("/api/patients/{id}/")]
        public IActionResult Put(string id, [FromForm]string patient)
        {
            patient = patient.Replace("\n", "");
            var pJSON = JsonConvert.DeserializeObject<maia.Models.Patient>(patient);
            var strg = Storage.Patients;
            var ptn = strg.FirstOrDefault(t => t.ID == id);
            ptn.DateOfBirth = pJSON.DateOfBirth;
            ptn.Doctors = pJSON.Doctors;
            ptn.FirstName = pJSON.FirstName;
            ptn.LastName = pJSON.LastName;
            ptn.History = pJSON.History;
            Storage.Patients = strg;
            return Json(pJSON.ID);
        }
    }
}