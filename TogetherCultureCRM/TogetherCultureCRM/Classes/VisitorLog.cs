using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    //This is the VisitorLog class
    internal class VisitorLog
    {
        //Property is of type Guid to store the visitorId loaded from db
        public Guid visitorId { get; set; }

        //Property is of type Guid to store the userId loaded from db
        public Guid userId { get; set; }

        //Property is of type DateTime to store the visitDate loaded from db
        public DateTime visitDate { get; set; }
    }
}
