using Microsoft.Graph;

namespace Teammate.Data.Chats;

public class ChatService
{
    public async Task<IList<Chat>> GetChatsAsync(GraphServiceClient graphServiceClient)
    {
        var chats = new List<Chat>();
        var chatsCollectionPage = await graphServiceClient.Me.Chats.Request().GetAsync();
        if (chatsCollectionPage is null) return chats;
        var pageIterator = PageIterator<Chat>.CreatePageIterator(graphServiceClient,
            chatsCollectionPage, chat =>
            {
                if (chat.ChatType == ChatType.OneOnOne)
                    chats.Add(chat);
                return true;
            });

        await pageIterator.IterateAsync();

        return chats;
    }
}