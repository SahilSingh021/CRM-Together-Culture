using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    //This is the InterestTag class
    internal class InterestTag
    {
        //Property is of type Guid to store the tagId loaded from db
        public Guid tagId { get; set; }

        //Property is of type string to store the tagName loaded from db
        public string tagName { get; set; }
    }
}
