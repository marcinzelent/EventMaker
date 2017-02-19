using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using EventMaker.Model;
using EventMaker.ViewModel;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void AddingTestMethod()
        {
            EventCatalogSingleton eventCatalogSingleton = EventCatalogSingleton.Instance;
            eventCatalogSingleton.Events=new ObservableCollection<Event>();
            eventCatalogSingleton.Add(new Event());
            Assert.AreEqual(1, eventCatalogSingleton.Events.Count);
        }

        [TestMethod]
        public void RemovingTestMethod()
        {
            EventCatalogSingleton eventCatalogSingleton = EventCatalogSingleton.Instance;
            eventCatalogSingleton.Events = new ObservableCollection<Event>();
            eventCatalogSingleton.Add(new Event());
            Assert.AreEqual(1,eventCatalogSingleton.Events.Count);
            eventCatalogSingleton.Remove(0);
            Assert.AreEqual(0,eventCatalogSingleton.Events.Count);
        }

        [TestMethod]
        public void EditTestMethod()
        {
            EventCatalogSingleton eventCatalogSingleton = EventCatalogSingleton.Instance;
            eventCatalogSingleton.Events = new ObservableCollection<Event>();
            eventCatalogSingleton.Add(new Event() {Id=0});
            Assert.AreEqual(1, eventCatalogSingleton.Events.Count);
            Assert.AreEqual(0,eventCatalogSingleton.Events[0].Id);
            eventCatalogSingleton.Update(0,new Event() {Id=1});
            Assert.AreEqual(1,eventCatalogSingleton.Events[0].Id);
        }
            
    }
}
