using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    internal class VisitorLog
    {
        public Guid visitorId { get; set; }
        public Guid userId { get; set; }
        public DateTime visitDate { get; set; }
    }
}
