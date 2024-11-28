using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    internal class Member
    {
        public Guid memberId {  get; set; }
        public Guid userId { get; set; }
        public Guid membershipTypeId { get; set; }
        public Guid interestId { get; set; }
    }
}
