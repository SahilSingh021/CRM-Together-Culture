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
            Admin = new Admin();
            Member = new Member();
            ActiveMembership = new MembershipType();
            ActiveMemberBenefits = new List<MemberBenefits>();
            MembershipTypes = new List<MembershipType>();
        }

        public static User User { get; set; }
        public static Admin Admin { get; set; }
        public static Member Member {  get; set; }
        public static MembershipType ActiveMembership { get; set; }
        public static List<MemberBenefits> ActiveMemberBenefits { get; set; }
        public static List<MembershipType> MembershipTypes { get; set; }
    }
}
