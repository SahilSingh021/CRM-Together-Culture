using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM
{
    public class User
    {
        public Guid userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool bIsAdmin { get; set; }
        public bool bIsBanned { get; set; }
    }
}
