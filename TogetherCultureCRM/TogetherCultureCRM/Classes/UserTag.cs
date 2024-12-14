using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    //This is the UserTag class
    internal class UserTag
    {
        //Property is of type Guid to store the userId loaded from db
        public Guid userId {  get; set; }

        //Property is of type Guid to store the tagId loaded from db
        public Guid tagId { get; set; }

        //Property is of type DateTime to store the userTagCreationDate loaded from db
        public DateTime userTagCreationDate { get; set; }
    }
}
