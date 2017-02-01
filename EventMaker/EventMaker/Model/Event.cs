using System;

namespace EventMaker.Model
{
    public class Event
    {
        public DateTime DateTime { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
    }
}
