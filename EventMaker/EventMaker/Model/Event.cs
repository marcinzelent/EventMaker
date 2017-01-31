using System;

namespace EventMaker.Model
{
    class Event
    {
        DateTime DateTime { get; set; }
        int Id { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        string Place { get; set; }
    }
}
