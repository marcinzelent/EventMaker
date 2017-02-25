using System.Collections.ObjectModel;
using EventMaker.Persistency;

namespace EventMaker.Model
{
    public class EventCatalogSingleton
    {
        private static EventCatalogSingleton _instance;

        private EventCatalogSingleton()
        {
            LoadEventsAsync();
        }

        public ObservableCollection<Event> Events { get; set; }

        public static EventCatalogSingleton Instance => _instance ?? (_instance = new EventCatalogSingleton());

        public void Add(Event newEvent)
        {
            Events.Add(newEvent);
            PersistencyService.SaveEventsAsJsonAsync(Events);
        }

        private async void LoadEventsAsync()
        {
            Events = await PersistencyService.LoadEventsFromJsonAsync() ?? new ObservableCollection<Event>();
        }

        public void Remove(int index)
        {
            Events.RemoveAt(index);
            PersistencyService.SaveEventsAsJsonAsync(Events);
        }

        public void Update(int index, Event eventToUpdate)
        {
            Events[index] = eventToUpdate;
            PersistencyService.SaveEventsAsJsonAsync(Events);
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
                        for (var i = 0; i < Events.Count - 1; i++)
                            if (Events[i].DateTime > Events[i + 1].DateTime)
                            {
                                Events.Move(i, i + 1);
                                sorted = true;
                            }
                    } while (sorted);
                    break;
                case "date (descending)":
                    do
                    {
                        sorted = false;
                        for (var i = 0; i < Events.Count - 1; i++)
                            if (Events[i].DateTime < Events[i + 1].DateTime)
                            {
                                Events.Move(i, i + 1);
                                sorted = true;
                            }
                    } while (sorted);
                    break;

                case "name (ascending)":
                    do
                    {
                        sorted = false;
                        for (var i = 0; i < Events.Count - 1; i++)
                            if (string.CompareOrdinal(Events[i].Name, Events[i + 1].Name) > 0)
                            {
                                Events.Move(i, i + 1);
                                sorted = true;
                            }
                    } while (sorted);
                    break;

                case "name (descending)":
                    do
                    {
                        sorted = false;
                        for (var i = 0; i < Events.Count - 1; i++)
                            if (string.CompareOrdinal(Events[i].Name, Events[i + 1].Name) < 0)
                            {
                                Events.Move(i, i + 1);
                                sorted = true;
                            }
                    } while (sorted);
                    break;

                case "place (ascending)":
                    do
                    {
                        sorted = false;
                        for (var i = 0; i < Events.Count - 1; i++)
                            if (string.CompareOrdinal(Events[i].Place, Events[i + 1].Place) > 0)
                            {
                                Events.Move(i, i + 1);
                                sorted = true;
                            }
                    } while (sorted);
                    break;

                case "place (descending)":
                    do
                    {
                        sorted = false;
                        for (var i = 0; i < Events.Count - 1; i++)
                            if (string.CompareOrdinal(Events[i].Place, Events[i + 1].Place) < 0)
                            {
                                Events.Move(i, i + 1);
                                sorted = true;
                            }
                    } while (sorted);
                    break;
            }
        }
    }
}