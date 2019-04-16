using System.Collections.Generic;

namespace GacBootcampWebsite.Models
{
    public class LogViewModel
    {
        public LogViewModel()
        {
            Entries = new List<string>();
        }

        public List<string> Entries { get; set; }
    }
}
