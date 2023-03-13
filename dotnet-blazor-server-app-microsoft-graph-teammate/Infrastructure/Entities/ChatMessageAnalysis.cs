namespace Teammate.Infrastructure.Entities
{
    public class ChatMessageAnalysis
    {
        public string Id { get; set; }
        public string AnalysisJson { get; set; }

        public ChatMessageAnalysis()
        {
        }

        public ChatMessageAnalysis(string id, string analysisJson)
        {
            Id = id;
            AnalysisJson = analysisJson;
        }
    }
}
