using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;

namespace PalmSecure
{
    public static class StaticClasses
    {
        public static string ReadSetting(string key)
        {
            string result = "";
            //try
            //{
                NameValueCollection appSettings = ConfigurationManager.AppSettings;

                result = appSettings[key] ?? "Not Found";

            //}
            //catch (ConfigurationErrorsException)
            //{
            //    Console.WriteLine("Error reading app settings");
            //}
            return result;
        }


    }
}
