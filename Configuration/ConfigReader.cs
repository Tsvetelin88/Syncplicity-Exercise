using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncplicityUIFramework.Configuration
{
    public class ConfigReader
    {
        private static ConfigurationManager configuration;

        public static ConfigurationManager Configuration
        {
            get
            {
                if (configuration == null)
                {
                    configuration = new ConfigurationManager();
                    configuration.AddJsonFile("appsettings.json", false, false);
                }
                return configuration;
            }
        }
    }
}