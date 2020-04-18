using System.Collections.Generic;

namespace ToggleService
{
    public class Toggle
    {
        public string Name { get; set; }
        public bool IsReleased { get; set; }
        public List<string> Viewers { get; set; }
    }
}
