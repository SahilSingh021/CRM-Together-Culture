using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM
{
    //This is the User class
    public class User
    {
        //Property is of type Guid to store the userId loaded from db
        public Guid userId { get; set; }

        //Property is of type string to store the username loaded from db
        public string username { get; set; }

        //Property is of type string to store the password loaded from db
        public string password { get; set; }

        //Property is of type string to store the email loaded from db
        public string email { get; set; }

        //Property is of type bool to store the bIsAdmin loaded from db
        public bool bIsAdmin { get; set; }

        //Property is of type bool to store the bIsBanned loaded from db
        public bool bIsBanned { get; set; }

        //Property is of type bool to store the bIsMember loaded from db
        public bool bIsMember { get; set; }

    }
}
