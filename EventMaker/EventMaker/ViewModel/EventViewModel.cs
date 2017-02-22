using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EventMaker.Annotations;
using EventMaker.Common;
using EventMaker.Model;

namespace EventMaker.ViewModel
{
    public class EventViewModel : INotifyPropertyChanged
    {
        private static Event _eventTemplate = new Event();
        private static string _selectedSortValue = "date (ascending)";

        public EventViewModel()
        {
            CreateEventCommand = new RelayCommand(CreateEvent);
            RemoveEventCommand = new RelayCommand(RemoveEvent);
            LoadEventCommand = new RelayCommand(LoadEvent);
            UpdateEventCommand = new RelayCommand(UpdateEvent);
            CleanTemplateCommand = new RelayCommand(CleanTemplate);
        }

        public EventCatalogSingleton EventCatalogSingleton { get; set; } = EventCatalogSingleton.Instance;
        public static int SelectedEventIndex { get; set; }

        public static ObservableCollection<string> SortValues { get; set; } = new ObservableCollection<string>
        {
            "date (ascending)",
            "date (descending)",
            "name (ascending)",
            "name (descending)",
            "place (ascending)",
            "place (descending)"
        };

        public static DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
        public static TimeSpan Time { get; set; }
        public ICommand CreateEventCommand { get; set; }
        public ICommand RemoveEventCommand { get; set; }
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

        public string SelectedSortValue
        {
            get { return _selectedSortValue; }
            set
            {
                _selectedSortValue = value;
                OnPropertyChanged(nameof(SelectedSortValue));
                SortEvents();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void CreateEvent()
        {
            if (string.IsNullOrWhiteSpace(EventTemplate.Name) || string.IsNullOrWhiteSpace(EventTemplate.Description) ||
                string.IsNullOrWhiteSpace(EventTemplate.Place)) return;
            EventTemplate.Id = (int) (DateTime.Now - new DateTime(1970, 01, 01, 0, 0, 0)).TotalSeconds;
            EventTemplate.DateTime = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hours, Time.Minutes,
                Time.Seconds);
            EventCatalogSingleton.Add(EventTemplate);
            CleanTemplate();
            SortEvents();
        }

        private void RemoveEvent()
        {
            EventCatalogSingleton.Remove(SelectedEventIndex);
        }

        private void LoadEvent()
        {
            EventTemplate.Name = EventCatalogSingleton.Instance.Events[SelectedEventIndex].Name;
            EventTemplate.Description = EventCatalogSingleton.Instance.Events[SelectedEventIndex].Description;
            EventTemplate.Place = EventCatalogSingleton.Instance.Events[SelectedEventIndex].Place;
            EventTemplate.DateTime = EventCatalogSingleton.Instance.Events[SelectedEventIndex].DateTime;
            Date = new DateTimeOffset(EventTemplate.DateTime);
            Time = new TimeSpan(EventTemplate.DateTime.Ticks);
        }

        private void UpdateEvent()
        {
            if (string.IsNullOrWhiteSpace(EventTemplate.Name) || string.IsNullOrWhiteSpace(EventTemplate.Description) ||
                string.IsNullOrWhiteSpace(EventTemplate.Place)) return;
            EventTemplate.DateTime = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hours, Time.Minutes,
                Time.Seconds);
            EventCatalogSingleton.Update(SelectedEventIndex, EventTemplate);
            CleanTemplate();
            SortEvents();
        }

        private void CleanTemplate()
        {
            EventTemplate = new Event();
            Date = DateTimeOffset.Now;
            Time = TimeSpan.Zero;
        }

        private void SortEvents()
        {
            EventCatalogSingleton.Sort(SelectedSortValue);
            OnPropertyChanged(nameof(EventCatalogSingleton));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}