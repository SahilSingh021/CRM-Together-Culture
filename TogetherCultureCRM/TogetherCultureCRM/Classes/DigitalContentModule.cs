using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    //This is the DigitalContentModule class
    public class DigitalContentModule
    {
        //Property is of type Guid to store the digitalContentModuleId loaded from db
        public Guid digitalContentModuleId { get; set; }

        //Property is of type Guid to store the tagId loaded from db
        public Guid tagId { get; set; }

        //Property is of type string to store the moduleName loaded from db
        public string moduleName { get; set; }
    }
}
