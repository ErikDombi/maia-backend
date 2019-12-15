using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaiaML.Model.Core;

namespace maia.Controllers
{
    public class PredictionController : Controller
    {
        SymtomTokenizer tokenizer;
        public PredictionController(SymtomTokenizer symtomTokenizer)
        {
            tokenizer = symtomTokenizer;
        }

        public IActionResult Index(string symptoms)
        {
            // Add input data
            var input = new ModelInput();

            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(input);

            return Content($"{result.Prediction}");
        }
    }
}