using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    internal static class UserSession
    {
        static UserSession()
        {
            User = new User();
            Member = new Member();
            MembershipType = new MembershipType();
        }

        public static User User { get; set; }
        public static Member Member {  get; set; } 
        public static MembershipType MembershipType {  get; set; } 
    }
}
