using Microsoft.Graph;

namespace Teammate.Data.Messages;

public class MessageService
{
    public const int RecentMessagesLimit = 10;

    public async Task<IList<ChatMessage>> GetChatMessagesAsync(GraphServiceClient graphServiceClient,
        string chatId)
    {
        var chatMessages = new List<ChatMessage>();
        var chatMessagesCollectionPage =
            await graphServiceClient.Me.Chats[chatId].Messages.Request().Top(RecentMessagesLimit).GetAsync();
        if (chatMessagesCollectionPage is null) return chatMessages;
        var pageIterator = PageIterator<ChatMessage>.CreatePageIterator(
            graphServiceClient,
            chatMessagesCollectionPage, message =>
            {
                chatMessages.Add(message);
                return true;
            });

        await pageIterator.IterateAsync();

        return chatMessages;
    }
}