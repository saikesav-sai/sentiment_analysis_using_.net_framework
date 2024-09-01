using Microsoft.ML.Data;

namespace sentimental_analysis.Models
{

    public class SentimentData
    {
        [LoadColumn(0)]
        public string Text { get; set; }
    }

    public class SentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Sentiment { get; set; }

        public float Probability { get; set; }
        public float Score { get; set; }
    }

}
