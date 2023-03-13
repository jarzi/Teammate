using Azure.AI.Language.Conversations;
using Azure;
using Azure.Core;
using System.Text.Json;
using Teammate.Data.CognitiveServices.Data;

namespace Teammate.Data.CognitiveServices;

public class ConversationalLanguageUnderstandingService
{
    private readonly ConversationAnalysisClient _client;

    public const string ProjectName = "CluQuestionApp";
    public const string DeploymentName = "QuestionTeamsDeploy";

    public ConversationalLanguageUnderstandingService(IConfiguration configuration)
    {
        var apiKey = configuration.GetValue<string>("AzureCognitive:ApiKey")!;
        var endpointUrl = configuration.GetValue<string>("AzureCognitive:EndpointUrl")!;

        var endpoint = new Uri(endpointUrl);
        var credential = new AzureKeyCredential(apiKey);

        _client = new ConversationAnalysisClient(endpoint, credential);
    }

    public async Task<AnalysisResult?>? AnalyzeAsync(string inputText, string id)
    {
        if (string.IsNullOrWhiteSpace(inputText) || string.IsNullOrWhiteSpace(id)) return null;

        var response =
            await _client.AnalyzeConversationAsync(
                RequestContent.Create(RequestContentData.Content(ProjectName, DeploymentName, inputText, id)));

        if (response.ContentStream == null) return null;

        using var result = await JsonDocument.ParseAsync(response.ContentStream);
        var conversationalTaskResult = result.RootElement;
        var conversationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

        var analysisResult = new AnalysisResult
        {
            TopIntent = conversationPrediction.GetProperty("topIntent").GetString() ?? string.Empty,
            Intents = new List<Intent>(),
            ConversationEntities = new List<ConversationEntity>()
        };

        foreach (var intent in conversationPrediction.GetProperty("intents").EnumerateArray())
        {
            analysisResult.Intents.Add(new Intent
            {
                Category = intent.GetProperty("category").GetString() ?? string.Empty,
                ConfidenceScore = intent.GetProperty("confidenceScore").GetSingle()
            });
        }

        foreach (var entity in conversationPrediction.GetProperty("entities").EnumerateArray())
        {
            analysisResult.ConversationEntities.Add(new ConversationEntity
            {
                Category = entity.GetProperty("category").GetString() ?? string.Empty,
                ConfidenceScore = entity.GetProperty("confidenceScore").GetSingle(),
                Text = entity.GetProperty("text").GetString() ?? string.Empty
            });
        }

        analysisResult.Score = analysisResult.Intents.FirstOrDefault(i => i.Category == analysisResult.TopIntent)?
            .ConfidenceScore ?? 0;
        
        return analysisResult;
    }
}