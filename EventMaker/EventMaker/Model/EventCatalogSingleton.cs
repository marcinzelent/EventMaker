using System.Collections.ObjectModel;
using System;

namespace EventMaker.Model
{
    public class EventCatalogSingleton
    {
        private static EventCatalogSingleton instance;
        private ObservableCollection<Event> _events;
        private EventCatalogSingleton()
        {
            _events = new ObservableCollection<Event>();
            LoadEventsAsync();
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
        public ObservableCollection<Event> Events
        {
            get { return _events; }
            set { _events = value; }
        }
    }
}
