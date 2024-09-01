using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using sentimental_analysis.Models;
using System.Diagnostics;

namespace sentimental_analysis.Controllers
{
    public class HomeController : Controller
    {
        private static readonly string modelPath = Path.Combine(Environment.CurrentDirectory, "wwwroot/models/sentiment_model.zip");

        [HttpPost]
        public JsonResult AnalyzeSentiment([FromBody] SentimentData input)
        {
            MLContext mlContext = new MLContext();
            

            ITransformer trainedModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(trainedModel);
            var result = predEngine.Predict(input);

            return Json(new { sentiment = result.Sentiment ? "Positive" : "Negative" });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}



