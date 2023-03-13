using System.Text.Json;

namespace Teammate.Data.CognitiveServices.Data;

public static class RequestContentData
{
    private const string ParticipantId = "1";
    private const string StringIndexType = "Utf16CodeUnit";
    private const string Kind = "Conversation";

    public static string Content(string projectName, string deploymentName, string text, string id)
    {
        var data = new
        {
            analysisInput = new
            {
                conversationItem = new
                {
                    text,
                    id,
                    participantId = ParticipantId
                }
            },
            parameters = new
            {
                projectName,
                deploymentName,
                stringIndexType = StringIndexType
            },
            kind = Kind,
        };

        return JsonSerializer.Serialize(data);
    }
}