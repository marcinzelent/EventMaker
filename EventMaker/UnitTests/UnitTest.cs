using System;
using Windows.UI.Popups;
using EventMaker.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddingTestMethod()
        {
            EventCatalogSingleton eventCatalogSingleton = EventCatalogSingleton.Instance;
            EventCatalogSingleton.Instance.Add(new Event() { Id = 1, Name = "Party", Description = "Best party ever!", Place = "Roskilde" });
        }
    }
}
