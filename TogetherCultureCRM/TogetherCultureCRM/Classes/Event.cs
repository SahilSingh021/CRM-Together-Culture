using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    internal class Event
    {
        public Guid eventId { get; set; }
        public Guid tagId { get; set; }
        public string eventName { get; set; }
        public DateTime eventDate { get; set; }
    }
}
