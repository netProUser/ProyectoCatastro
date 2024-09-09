using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MSI.Catastros.DataAccess
{
    public class NetworkLocal
    {
        //string IPAddress = GetLocalIPAddress();

        //public static string GetLocalIPAddress()
        //{
        //    IPHostEntry Host = default(IPHostEntry);
        //    string Hostname = null;
        //    Hostname = System.Environment.MachineName;
        //    Host = Dns.GetHostEntry(Hostname);
        //    foreach (IPAddress IP in Host.AddressList)
        //    {
        //        if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
        //        {
        //            IPAddress = Convert.ToString(IP);
        //        }
        //    }
        //    return IPAddress;
        //    //var host = Dns.GetHostEntry(Dns.GetHostName());
        //    //foreach (var ip in host.AddressList)
        //    //{
        //    //    if (ip.AddressFamily == AddressFamily.InterNetwork)
        //    //    {
        //    //        return ip.ToString();
        //    //    }
        //    //}
        //    throw new Exception("No network adapters with an IPv4 address in the system!");
        //}



        public static string GetLocalIPAddress()
        {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null; string IPAddressA = null;
            //Hostname = System.Environment.MachineName;
            Hostname = Dns.GetHostName();
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                        IPAddressA = Convert.ToString(IP);
                }
            }
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }
            string ipRoot = context.Request.ServerVariables["REMOTE_ADDR"];

            return ipRoot;
        }
        public static string GetLocalMachineName()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }
            string host = context.Request.ServerVariables["REMOTE_HOST"];
            host = context.Request.UserHostAddress;
            return host;
        }

    }
}
