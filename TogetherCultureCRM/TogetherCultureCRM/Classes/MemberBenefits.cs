using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    //This is the MemberBenefits class
    internal class MemberBenefits
    {
        //Property is of type Guid to store the memberBenefitsId loaded from db
        public Guid memberBenefitsId { get; set; }

        //Property is of type string to store the benefitsDescription loaded from db
        public string benefitsDescription { get; set; }
    }
}
