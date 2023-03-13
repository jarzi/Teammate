namespace Teammate.Data.CognitiveServices.Data
{
    public class AnalysisResult
    {
        public string TopIntent { get; set; }
        public List<Intent> Intents { get; set; }
        public List<ConversationEntity> ConversationEntities { get; set; }
        public float Score { get; set; }
    }
}
