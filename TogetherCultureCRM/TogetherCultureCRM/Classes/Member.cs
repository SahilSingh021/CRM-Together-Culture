using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    //This is the Member class
    internal class Member
    {
        //Property is of type Guid to store the memberId loaded from db
        public Guid memberId {  get; set; }

        //Property is of type Guid to store the userId loaded from db
        public Guid userId { get; set; }

        //Property is of type Guid to store the membershipTypeId loaded from db
        public Guid membershipTypeId { get; set; }
    }
}
