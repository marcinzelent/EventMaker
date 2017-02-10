using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EventMaker.Model;
using System.Windows.Input;
using EventMaker.Annotations;
using EventMaker.Common;

namespace EventMaker.ViewModel
{
    public class EventViewModel : INotifyPropertyChanged
    {
        private static Event _eventTemplate = new Event();
        public EventCatalogSingleton EventCatalogSingleton { get; set; } = EventCatalogSingleton.Instance;
        public static int SelectedEventIndex { get; set; }
        public static DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
        public static TimeSpan Time { get; set; }
        public ICommand CreateEventCommand { get; set; }
        public ICommand DeleteEventCommand { get; set; }
        public ICommand LoadEventCommand { get; set; }
        public ICommand UpdateEventCommand { get; set; }
        public ICommand CleanTemplateCommand { get; set; }

        public Event EventTemplate
        {
            get { return _eventTemplate; }
            set
            {
                _eventTemplate = value;
                OnPropertyChanged(nameof(EventTemplate));
            }
        }

        public EventViewModel()
        {
            CreateEventCommand = new RelayCommand(CreateEvent);
            DeleteEventCommand = new RelayCommand(DeleteEvent);
            LoadEventCommand = new RelayCommand(LoadEvent);
            UpdateEventCommand = new RelayCommand(UpdateEvent);
            CleanTemplateCommand = new RelayCommand(CleanTemplate);
        }

        private void CreateEvent()
        {
            EventTemplate.DateTime = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hours, Time.Minutes, Time.Seconds);
            EventCatalogSingleton.Add(EventTemplate);
            CleanTemplate();
        }

        private void DeleteEvent()
        {
            EventCatalogSingleton.Remove(SelectedEventIndex);
        }

        private void LoadEvent()
        {
            EventTemplate = EventCatalogSingleton.Events[SelectedEventIndex];
            Date = new DateTimeOffset(EventTemplate.DateTime);
            Time = new TimeSpan(EventTemplate.DateTime.Ticks);
        }

        private void UpdateEvent()
        {
            EventTemplate.DateTime = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hours, Time.Minutes, Time.Seconds);
            EventCatalogSingleton.Update(SelectedEventIndex,EventTemplate);
            CleanTemplate();
        }

        private void CleanTemplate()
        {
            EventTemplate = new Event();
            Date = DateTimeOffset.Now;
            Time = TimeSpan.Zero;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
