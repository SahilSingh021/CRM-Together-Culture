using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    internal class UsedMemberBenefits
    {
        public Guid usedMemberBenefitsId { get; set; }
        public Guid memberId { get; set; }
        public Guid memberBenefitsId { get; set; }
        public DateTime usageDate { get; set; }
    }
}
