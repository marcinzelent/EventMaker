using System.Collections.ObjectModel;

namespace EventMaker.Model
{
    public class EventCatalogSingleton
    {
        private static EventCatalogSingleton _instance;

        private EventCatalogSingleton()
        {
            Events = new ObservableCollection<Event>();
            LoadEventsAsync();
        }
        public static EventCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventCatalogSingleton();
                }
                return _instance;
            }
        }
        public void Add(Event newEvent)
        {
            Events.Add(newEvent);
            Persistency.PersistencyService.SaveEventsAsJsonAsync(Events);
        }
        public async void LoadEventsAsync()
        {
            Events = await Persistency.PersistencyService.LoadEventsFromJsonAsync();
        }
        public void Remove(Event eventToBeRemoved)
        {
            Events.Remove(eventToBeRemoved);
            Persistency.PersistencyService.SaveEventsAsJsonAsync(Events);
        }
        public ObservableCollection<Event> Events { get; set; }
    }
}
