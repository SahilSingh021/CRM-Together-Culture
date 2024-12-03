using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    internal class MemberKeyIntrest
    {
        public Guid memberId { get; set; }
        public Guid intrestId { get; set; }
        public string keyIntrestName { get; set; }
        public DateTime memberKeyIntrestDate { get; set; }
    }
}
