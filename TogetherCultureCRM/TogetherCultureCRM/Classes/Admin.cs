using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;            

namespace TogetherCultureCRM.Classes
{
    //This is the Admin class
    public class Admin
    {
        //Property is of type Guid to store the adminId loaded from db
        public Guid adminId { get; set; }

        //Property is of type Guid to store the userId loaded from db
        public Guid userId { get; set; }
    }
} 