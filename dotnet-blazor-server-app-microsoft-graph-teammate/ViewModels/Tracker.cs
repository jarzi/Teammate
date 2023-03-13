namespace Teammate.ViewModels
{
    public class Tracker
    {
        public ICollection<TrackerChat> TrackerChats { get; set; }

        public Tracker(ICollection<TrackerChat> trackerChats)
        {
            TrackerChats = trackerChats;
        }
    }
}
