using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaiaML.Model.Core;

namespace maia.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index(string id, string symptoms = null)
        {
            var ptn = Storage.Patients.FirstOrDefault(t => t.ID.ToLower() == id.Replace("\"", "").ToLower());
            // Add input data
            ModelOutput result = null;
            if (symptoms != null)
            {
                var input = new ModelInput();
                input.Symptoms = symptoms;
                // Load model and predict output of sample data
                result = ConsumeModel.Predict(input);
            }
            if (result == null)
                return View(model: new ProfileModel() { patient = ptn, Prediction = null});
            else
                return View(model: new ProfileModel() { patient = ptn, Prediction = result.Prediction });
        }
    }

    public class ProfileModel
    {
        public Models.Patient patient;
        public string Prediction;
    }
}