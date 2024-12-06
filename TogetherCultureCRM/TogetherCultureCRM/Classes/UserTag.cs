using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    internal class UserTag
    {
        public Guid userId {  get; set; }
        public Guid tagId { get; set; }
        public DateTime userTagCreationDate { get; set; }
    }
}
