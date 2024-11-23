using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    internal class AdminRequests
    {
        public Guid adminRequestId { get; set; }
        public Guid userId { get; set; }
        public string requestDescription { get; set; }
        public DateTime requestTime { get; set; }
    }
}
