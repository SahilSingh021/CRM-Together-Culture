using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM.Classes
{
    //This is the ChatLog class
    public class ChatLog
    {
        //Property is of type Guid to store the chatId loaded from db
        public Guid chatId { get; set; }

        //Property is of type Guid to store the userId loaded from db
        public Guid userId { get; set; }

        //Property is of type string to store the chatMessage loaded from db
        public string chatMessage { get; set; }

        //Property is of type DateTime to store the chatDateTime loaded from db
        public DateTime chatDateTime { get; set; }
    }
}
