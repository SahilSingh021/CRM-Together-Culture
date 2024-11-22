using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM
{
    internal class Data
    {
        public Data()
        {
            connection_string = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        }

        private string connection_string;

        public string ConnectionString { get => connection_string; }

    }
}
