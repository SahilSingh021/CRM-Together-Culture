using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    //This is the AdminRequests class
    internal class AdminRequests
    {
        //Property is of type Guid to store the adminRequestId loaded from db
        public Guid adminRequestId { get; set; }

        //Property is of type Guid to store the userId loaded from db
        public Guid userId { get; set; }

        //Property is of type string to store the requestDescription loaded from db
        public string requestDescription { get; set; }

        //Property is of type DateTime to store the requestTime loaded from db
        public DateTime requestTime { get; set; }
    }
}
