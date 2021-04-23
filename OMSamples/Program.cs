using System;
using System.Collections.Generic;
using System.Text;
using TCX.Configuration;
using TCX.PBXAPI;
using System.Threading;
using System.IO;
using System.Reflection;

namespace OMSamples
{
    class Program
    {

        static void Bootstrap(string filePath, string[] args)
        {
            {
                var a = new Random(Environment.TickCount);
                //unique name PhoneSystem.ApplicationName = "TestApi";//any name
                PhoneSystem.ApplicationName = PhoneSystem.ApplicationName + a.Next().ToString();
            }

            #region phone system initialization(init db server)
            var value = Utilities.GetKeyValue("ConfService", "ConfPort", filePath);
            var port = 0;
            PhoneSystem.CfgServerHost = "127.0.0.1";
            if (!string.IsNullOrEmpty(value))
            {
                int.TryParse(value.Trim(), out port);
                PhoneSystem.CfgServerPort = port;
            }
            value = Utilities.GetKeyValue("ConfService", "confUser", filePath);
            if (!string.IsNullOrEmpty(value))
                PhoneSystem.CfgServerUser = value;
            value = Utilities.GetKeyValue("ConfService", "confPass", filePath);
            if (!string.IsNullOrEmpty(value))
                PhoneSystem.CfgServerPassword = value;
            #endregion
            var dns = PhoneSystem.Root.GetDN(); //Access PhoneSystem.Root to initialize ObjectModel
            SampleStarter.StartSample(args);
            PhoneSystem.Root.Disconnect();
        }

        static string instanceBinPath;

        static void Main(string[] args)
        {
            try
            {
                var filePath = @".\3CXPhoneSystem.ini";
                if (!File.Exists(filePath))
                {
                    //this code expects 3CXPhoneSystem.ini in current directory.
                    //it can be taken from the installation folder (find it in Program Files/3CXPhone System/instance1/bin for in premiss installation)
                    //or this application can be run with current directory set to location of 3CXPhoneSystem.ini

                    //v14 (cloud and in premiss) installation has changed folder structure.
                    //3CXPhoneSystem.ini which contains connectio information is located in 
                    //<Program Files>/3CX Phone System/instanceN/Bin folder.
                    //in premiss instance files are located in <Program Files>/3CX Phone System/instance1/Bin
                    throw new Exception("Cannot find 3CXPhoneSystem.ini");
                }
                instanceBinPath = Path.Combine(Utilities.GetKeyValue("General", "AppPath", filePath), "Bin");

                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
                Bootstrap(filePath, args);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var name = new AssemblyName(args.Name).Name;
            if (name == "3cxpscomcpp2")
                return Assembly.LoadFrom(Path.Combine(instanceBinPath, name + ".dll"));
            else
                throw new FileNotFoundException();
        }
    }
}
