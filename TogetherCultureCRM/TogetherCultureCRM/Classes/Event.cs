using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    //This is the Event class
    public class Event
    {
        //Property is of type Guid to store the eventId loaded from db
        public Guid eventId { get; set; }

        //Property is of type Guid to store the tagId loaded from db
        public Guid tagId { get; set; }

        //Property is of type string to store the eventName loaded from db
        public string eventName { get; set; }

        //Property is of type DateTime to store the eventDate loaded from db
        public DateTime eventDate { get; set; }
    }
}
