using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    //This is the UserSession class
    internal static class UserSession
    {
        //This is the UserSession classes default constructor that assings empty values or lists of the correct type to the classes members
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
            DigitalContentModules = new List<DigitalContentModule>();
            InterestTagList = new List<InterestTag>();
        }

        //Property is of type User to store the user table information loaded from db
        public static User User { get; set; }

        //Property is of type Admin to store the admin table information loaded from db
        public static Admin Admin { get; set; }

        //Property is of type Member to store the member table information loaded from db
        public static Member Member {  get; set; }

        //Property is of type MembershipType to store the active membership details of the current user loaded from db
        public static MembershipType ActiveMembership { get; set; }

        //Property is of type MemberKeyInterest to store the key interest details of the current user loaded from db
        public static MemberKeyInterest MemberKeyInterest { get; set; }

        //This property is a list of the MemberBenefits class and it stores all the benefitst the current user has subscribed to 
        public static List<MemberBenefits> SubscribedMemberBenefits { get; set; }

        //This property is a list of the UsedMemberBenefits class and it stores all the used benefitst the current user has in the db 
        public static List<UsedMemberBenefits> UsedMemberBenefits { get; set; }

        //This property is a list of the MembershipType class and it stores all the membership types in the db 
        public static List<MembershipType> MembershipTypes { get; set; }

        //This property is a list of the Event class and it stores all the events in the db
        public static List<Event> Events { get; set; }

        //This property is a list of the VisitorLog class and it stores all the visitor logs for the current user in the db
        public static List<VisitorLog> VisitorLogs { get; set; }

        //This property is a list of the DigitalContentModule class and it stores all the digital content modules in the db
        public static List<DigitalContentModule> DigitalContentModules { get; set; }

        //This property is a list of the InterestTag class and it stores all the interest tags in the db 
        public static List<InterestTag> InterestTagList { get; set; }
    }
}
