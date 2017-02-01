using System;
using EventMaker.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EventMaker.Annotations;
using EventMaker.Common;

namespace EventMaker.ViewModel
{
    public class EventViewModel : INotifyPropertyChanged
    {
        private EventCatalogSingleton _eventCatalogSingleton;
        public Handler.EventHandler EventHandler { get; set; }
        private ICommand _createEventCommand;
        private ICommand _deleteEventCommand;
        public static int SelectedEventIndex { get; set; }
        private int _id;
        private string _name, _place, _description;
        private DateTimeOffset _date;
        private TimeSpan _time;
        public EventCatalogSingleton EventCatalogSingleton
        {
            get { return _eventCatalogSingleton; }
            set { _eventCatalogSingleton = value; }
        }

        public ICommand CreateEventCommand
        {
            get { return _createEventCommand; }
            set { _createEventCommand = value; }
        }

        public ICommand DeleteEventCommand
        {
            get { return _deleteEventCommand; }
            set { _deleteEventCommand = value; }
        }
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value; 
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Place
        {
            get { return _place; }
            set { _place = value;
                OnPropertyChanged(nameof(Place));
            }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public DateTimeOffset Date
        {
            get { return _date; }
            set { _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        public TimeSpan Time
        {
            get { return _time; }
            set { _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
        public EventViewModel()
        {
            _eventCatalogSingleton = EventCatalogSingleton.Instance;
            EventHandler = new Handler.EventHandler(this);
            _createEventCommand=new RelayCommand(EventHandler.CreateEvent);
            _deleteEventCommand = new RelayCommand(EventHandler.DeleteEvent);
            DateTime dt = DateTime.Now;
            _date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            _time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
