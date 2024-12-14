using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherCultureCRM
{
    //This is the Data class
    internal class Data
    {
        //This is the Data classes default constructor that gets the connection string from the configuration manager and assigns it to the private string property 'connection_string'
        public Data()
        {
            connection_string = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        }

        //This is a private string property used to store the connection string
        private string connection_string;

        //This property exposes the private string property 'connection_string' so you can access it after creating an instance of this class
        public string ConnectionString { get => connection_string; }

    }
}
