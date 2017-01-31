using System.Collections.ObjectModel;

namespace EventMaker.Model
{
    class EventCatalogSingleton
    {
        private static EventCatalogSingleton instance;
        ObservableCollection<Event> Events;
        private EventCatalogSingleton()
        {
            Events = new ObservableCollection<Event>();
        }
        public static EventCatalogSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventCatalogSingleton();
                }
                return instance;
            }
        }
        public void Add(Event newEvent)
        {
            Events.Add(newEvent);
        }
        public async void LoadEventsAsync()
        {

        }
        public void Remove(Event eventToBeRemoved)
        {
            Events.Remove(eventToBeRemoved);
        }
    }
}
