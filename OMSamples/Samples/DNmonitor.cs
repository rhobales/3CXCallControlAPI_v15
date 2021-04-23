using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("dn_monitor")]
    [SampleDescription("Shows status of all DNs in the system(including active connections) and show all notifications about changes made in PBX configuration")]
    class DNmonitorSample : ISample
    {
        public void Run(params string[] args)
        {
            {
                MyListener aa = new MyListener(null);
                PhoneSystem.Root.Updated += new NotificationEventHandler(aa.ps_Updated);
                PhoneSystem.Root.Inserted += new NotificationEventHandler(aa.ps_Inserted);
                PhoneSystem.Root.Deleted += new NotificationEventHandler(aa.ps_Deleted);
            }

            foreach (DN dn in PhoneSystem.Root.GetDN())
            {
                System.Console.WriteLine(dn + " " + (dn.IsRegistered ? "REGISTERED" : "NOT REGISTERED") + "VMB(" + dn.VoiceMailBox.ToString() + ")");
                ActiveConnection[] a = dn.GetActiveConnections();
                ActiveConnection[] ab = dn.GetActiveConnections();
                if (dn.IsRegistered || a.Length > 0)
                {
                    foreach (ActiveConnection ac in a)
                    {
                        System.Console.WriteLine(ac.CallID);
                        System.Console.WriteLine(ac.InternalParty);
                        System.Console.WriteLine(ac.IsInbound);
                        System.Console.WriteLine(ac.IsOutbound);
                        System.Console.WriteLine(ac.Status);
                        System.Console.WriteLine(DateTime.Now - ac.LastChangeStatus);
                        System.Console.WriteLine(ac.ExternalParty);
                        System.Console.WriteLine("AttachedData(" + ac.AttachedData.Count.ToString() + "):");
                        foreach (KeyValuePair<String, String> kvp in ac.AttachedData)
                        {
                            System.Console.WriteLine(kvp.Key + "=" + kvp.Value);
                        }
                    }
                }
            }

            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}