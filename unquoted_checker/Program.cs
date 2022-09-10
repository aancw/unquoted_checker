// Copyright (c) 2022 Petruknisme
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace unquoted_checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetUnquotedServices();
        }
        private static void GetUnquotedServices()
        {
            ServiceController[] scServices;
            scServices = ServiceController.GetServices();

            // Display the list of services currently running on this computer.

            Console.WriteLine("Checking Unquoted Service Path for Privilege Escalation...");
            foreach (ServiceController scTemp in scServices)
            {

                ManagementObject wmiService;
                wmiService = new ManagementObject("Win32_Service.Name='" + scTemp.ServiceName + "'");
                wmiService.Get();
                if (wmiService["PathName"] != null)
                {
                    string pathName = wmiService["PathName"].ToString();
                    List<string> cleanPathName = new List<string>(
                        pathName.Split(new string[] { " -", " /" }, StringSplitOptions.None));

                    if (!cleanPathName[0].Contains("\"") && cleanPathName[0].Contains(" "))
                    {
                        Console.WriteLine("    Service name:    {0}", wmiService["Name"]);
                        Console.WriteLine("    Path:            {0}", wmiService["PathName"]);
                        Console.WriteLine("    Started:         {0}", wmiService["Started"]);
                        Console.WriteLine("    State:           {0}", wmiService["State"]);
                        Console.WriteLine("    Status:          {0}", wmiService["Status"]);
                    }
                    
                }

            }
        }
    }
}
