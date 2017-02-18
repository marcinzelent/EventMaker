using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using EventMaker.Model;
using Newtonsoft.Json;

namespace EventMaker.Persistency
{
    internal class PersistencyService
    {
        private static readonly StorageFolder LocalFolder = ApplicationData.Current.LocalFolder;
        private static StorageFile _eventsFile;

        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        {
            _eventsFile = await LocalFolder.CreateFileAsync("events.json", CreationCollisionOption.OpenIfExists);
            File.WriteAllText(_eventsFile.Path, JsonConvert.SerializeObject(events));
        }

        public static async Task<ObservableCollection<Event>> LoadEventsFromJsonAsync()
        {
            try
            {
                _eventsFile = await LocalFolder.GetFileAsync("events.json");
            }
            catch (FileNotFoundException)
            {
                _eventsFile = await LocalFolder.CreateFileAsync("events.json", CreationCollisionOption.OpenIfExists);
            }
            return JsonConvert.DeserializeObject<ObservableCollection<Event>>(File.ReadAllText(_eventsFile.Path));
        }
    }
}