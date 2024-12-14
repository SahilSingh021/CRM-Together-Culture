using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    //This is the UsedMemberBenefits class
    internal class UsedMemberBenefits
    {
        //Property is of type Guid to store the usedMemberBenefitsId loaded from db
        public Guid usedMemberBenefitsId { get; set; }

        //Property is of type Guid to store the memberId loaded from db
        public Guid memberId { get; set; }

        //Property is of type Guid to store the memberBenefitsId loaded from db
        public Guid memberBenefitsId { get; set; }

        //Property is of type DateTime to store the usageDate loaded from db
        public DateTime usageDate { get; set; }
    }
}
