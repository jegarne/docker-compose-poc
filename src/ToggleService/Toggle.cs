using System.Collections.Generic;

namespace toggle_service
{
    public class Toggle
    {
        public string Name { get; set; }
        public bool IsReleased { get; set; }
        public List<string> Viewers { get; set; }
    }
}
