using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    public class ChatLog
    {
        public Guid chatId { get; set; }
        public Guid userId { get; set; }
        public string chatMessage { get; set; }
        public DateTime chatDateTime { get; set; }
    }
}
