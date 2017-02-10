using System.Collections.ObjectModel;

namespace EventMaker.Model
{
    public class EventCatalogSingleton
    {
        private static EventCatalogSingleton _instance;

        private EventCatalogSingleton()
        {
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
            Events = await Persistency.PersistencyService.LoadEventsFromJsonAsync() ?? new ObservableCollection<Event>();
        }
        public void Remove(int index)
        {
            Events.RemoveAt(index);
            Persistency.PersistencyService.SaveEventsAsJsonAsync(Events);
        }
        public void Update(int index, Event eventToUpdate)
        {
            Events[index] = eventToUpdate;
            Persistency.PersistencyService.SaveEventsAsJsonAsync(Events);
        }
        public ObservableCollection<Event> Events { get; set; }
    }
}
