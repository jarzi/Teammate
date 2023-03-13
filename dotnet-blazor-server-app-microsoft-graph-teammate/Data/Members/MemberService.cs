using Microsoft.Graph;

namespace Teammate.Data.Members;

public class MemberService
{
    public async Task<List<ConversationMember>> GetChatMembersAsync(GraphServiceClient graphServiceClient,
        string chatId)
    {
        var me = await graphServiceClient.Me.Request().GetAsync();

        var conversationMembers = new List<ConversationMember>();
        var chatMembersCollectionPage =
            await graphServiceClient.Me.Chats[chatId].Members.Request().GetAsync();
        if (chatMembersCollectionPage is null) return conversationMembers;
        var pageIterator = PageIterator<ConversationMember>.CreatePageIterator(
            graphServiceClient,
            chatMembersCollectionPage, member =>
            {
                if (me?.Id != ((AadUserConversationMember)member).UserId)
                    conversationMembers.Add(member);
                return true;
            });

        await pageIterator.IterateAsync();

        return conversationMembers;
    }
}