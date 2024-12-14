using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    //This is the DigitalContentModule class
    public class MembershipType
    {
        //Property is of type Guid to store the membershipTypeId loaded from db
        public Guid membershipTypeId { get; set; }

        //Property is of type string to store the typeName loaded from db
        public string typeName { get; set; }

        //Property is of type string to store the description loaded from db
        public string description { get; set; }

        //Property is of type decimal to store the cost loaded from db
        public decimal cost { get; set; }

        //Property is of type decimal to store the joiningFee loaded from db
        public decimal joiningFee { get; set; }

        //Property is of type string to store the duration loaded from db
        public string duration { get; set; }
    }
}
