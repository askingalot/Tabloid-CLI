using System;

namespace Tabloid
{
    public class Entry
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}