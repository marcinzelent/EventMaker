using System.Collections.ObjectModel;

namespace EventMaker.Model
{
    public class EventCatalogSingleton
    {
        private static EventCatalogSingleton _instance;
        public ObservableCollection<Event> Events { get; set; }

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
        private async void LoadEventsAsync()
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

        public void Sort(string sortValue)
        {
            bool sorted;
            switch (sortValue)
            {
                case "date (ascending)":
                do
                    {
                        sorted = false;
                        for (int i = 0; i < Events.Count - 1; i++)
                        {
                            if (Events[i].DateTime > Events[i + 1].DateTime)
                            {
                                Events.Move(i, i + 1);
                                sorted = true;
                            }
                        }
                    } while (sorted);
                    break;
                case "date (descending)":
                    do
                    {
                        sorted = false;
                        for (int i = 0; i < Events.Count - 1; i++)
                        {
                            if (Events[i].DateTime < Events[i + 1].DateTime)
                            {
                                Events.Move(i, i + 1);
                                sorted = true;
                            }
                        }
                    } while (sorted);
                    break;

                case "name (ascending)":
                    do
                    {
                        sorted = false;
                        for (int i = 0; i < Events.Count - 1; i++)
                        {
                            if (string.CompareOrdinal(Events[i].Name, Events[i + 1].Name) >= 0 )
                            {
                                Events.Move(i, i + 1);
                                sorted = true;
                            }
                        }
                    } while (sorted);
                    break;

                case "name (descending)":
                    do
                    {
                        sorted = false;
                        for (int i = 0; i < Events.Count - 1; i++)
                        {
                            if (string.CompareOrdinal(Events[i].Name, Events[i + 1].Name) <= 0)
                            {
                                Events.Move(i, i + 1);
                                sorted = true;
                            }
                        }
                    } while (sorted);
                    break;

                case "place (ascending)":
                    do
                    {
                        sorted = false;
                        for (int i = 0; i < Events.Count - 1; i++)
                        {
                            if (string.CompareOrdinal(Events[i].Place, Events[i + 1].Place) >= 0)
                            {
                                Events.Move(i, i + 1);
                                sorted = true;
                            }
                        }
                    } while (sorted);
                    break;

                case "place (descending)":
                    do
                    {
                        sorted = false;
                        for (int i = 0; i < Events.Count - 1; i++)
                        {
                            if (string.CompareOrdinal(Events[i].Place, Events[i + 1].Place) <= 0)
                            {
                                Events.Move(i, i + 1);
                                sorted = true;
                            }
                        }
                    } while (sorted);
                    break;
            }

        }
    }
}
