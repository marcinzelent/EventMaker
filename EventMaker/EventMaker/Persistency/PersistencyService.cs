using EventMaker.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;

namespace EventMaker.Persistency
{
    class PersistencyService
    {
        private static StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        private static StorageFile eventsFile;
        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        {
            eventsFile = await localFolder.CreateFileAsync("events.json",CreationCollisionOption.OpenIfExists);
            File.WriteAllText(eventsFile.Path, JsonConvert.SerializeObject(events));
        }
        public static async Task<ObservableCollection<Event>> LoadEventsFromJsonAsync()
        {
            try
            {
                eventsFile = await localFolder.GetFileAsync("events.json");
            }
            catch(FileNotFoundException)
            {
                eventsFile = await localFolder.CreateFileAsync("events.json", CreationCollisionOption.OpenIfExists);
            }
            return JsonConvert.DeserializeObject<ObservableCollection<Event>>(File.ReadAllText(eventsFile.Path));
        }
        
    }
}
