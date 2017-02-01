using EventMaker.Annotations;
using EventMaker.Model;
using EventMaker.ViewModel;

namespace EventMaker.Handler
{
    public class EventHandler
    {
        public EventViewModel EventViewModel { get; set; }
        public EventHandler(EventViewModel eventViewModel)
        {
            EventViewModel=eventViewModel;
        }

        public void CreateEvent()
        {
            EventViewModel.EventCatalogSingleton.Add(new Event()
            {
                Id = EventViewModel.Id,
                Name = EventViewModel.Name,
                Description = EventViewModel.Description,
                DateTime = Converter.Converter.DateTimeOffsetAndTimeSetToDateTime(EventViewModel.Date,EventViewModel.Time),
                Place = EventViewModel.Place
            });
        }

        public void DeleteEvent()
        {
            EventViewModel.EventCatalogSingleton.Remove(EventViewModel.EventCatalogSingleton.Events[EventViewModel.SelectedEventIndex]);
        }
    }
}
