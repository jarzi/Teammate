using Teammate.Data.CognitiveServices.Data;

namespace Teammate.ViewModels
{
    public class TrackerChatMessage
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public bool AmIOwner { get; set; }
        public DateTime DateTime { get; set; }
        public AnalysisResult? Analysis { get; set; }
    }
}
