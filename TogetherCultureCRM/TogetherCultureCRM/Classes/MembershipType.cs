using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    public class MembershipType
    {
        public Guid membershipTypeId { get; set; }
        public string typeName { get; set; }
        public string description { get; set; }
        public decimal cost { get; set; }
        public decimal joiningFee { get; set; }
        public string duration { get; set; }
    }
}
