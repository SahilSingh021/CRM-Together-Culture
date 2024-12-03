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
            SubscribedMemberBenefits = new List<MemberBenefits>();
            UsedMemberBenefits = new List<UsedMemberBenefits>();
            MembershipTypes = new List<MembershipType>();
            Events = new List<Event>();
            VisitorLogs = new List<VisitorLog>();
        }

        public static User User { get; set; }
        public static Admin Admin { get; set; }
        public static Member Member {  get; set; }
        public static MembershipType ActiveMembership { get; set; }
        public static MemberKeyIntrest MemberKeyIntrest { get; set; }
        public static List<MemberBenefits> SubscribedMemberBenefits { get; set; }
        public static List<UsedMemberBenefits> UsedMemberBenefits { get; set; }
        public static List<MembershipType> MembershipTypes { get; set; }
        public static List<Event> Events { get; set; }
        public static List<VisitorLog> VisitorLogs { get; set; }
    }
}
