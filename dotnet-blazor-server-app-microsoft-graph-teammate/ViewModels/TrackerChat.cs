namespace Teammate.ViewModels
{
    public class TrackerChat
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }

        public IList<TrackerChatMember> TrackerChatMembers { get; set; }
        public IList<TrackerChatMessage> TrackerChatMessages { get; set; }

        public TrackerChat(string id, string displayName)
        {
            Id = id;
            DisplayName = displayName;
        }
    }
}
