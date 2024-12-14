using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    //This is the MemberKeyInterest class
    internal class MemberKeyInterest
    {
        //Property is of type Guid to store the memberId loaded from db
        public Guid memberId { get; set; }

        //Property is of type Guid to store the interestId loaded from db
        public Guid interestId { get; set; }

        //Property is of type string to store the keyInterestId loaded from db
        public string keyInterestName { get; set; }

        //Property is of type DateTime to store the memberKeyInterestDate loaded from db
        public DateTime memberKeyInterestDate { get; set; }
    }
}
