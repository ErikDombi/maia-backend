using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maia
{
    public class SymtomTokenizer
    {
        public PredictionEngine<TextData, TransformedTextData> PredictionEngine;
        public SymtomTokenizer()
        {
            // Create a new ML context, for ML.NET operations. It can be used for
            // exception tracking and logging, as well as the source of randomness.
            var mlContext = new MLContext();
        }

        public TransformedTextData Predict(string input)
        {
            var data = new TextData() { Text = input};
            var prediction = PredictionEngine.Predict(data);
            return prediction;

        }

        public class TextData
        {
            public string Text { get; set; }
        }

        public class TransformedTextData : TextData
        {
            public string[] Words { get; set; }
        }
    }
}
