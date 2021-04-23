using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("update_extensions")]
    [SampleDescription("Show how to update one of the Extension property for all extensions in the sysytem. This sample modifies 'PBX delivers audio' setting for all extensions")]
    class UpdateExtensionsSample : ISample
    {
        public void Run(params string[] args)
        {
            PhoneSystem ps = PhoneSystem.Root;
            MyListener the = new MyListener(null);
            ps.Updated += new NotificationEventHandler(the.ps_Updated);
            ps.Inserted += new NotificationEventHandler(the.ps_Inserted);
            ps.Deleted += new NotificationEventHandler(the.ps_Deleted);
            bool audioopt = true;
            while (true)
            {
                audioopt = !audioopt;
                try
                {
                    foreach (Extension a in ps.GetTenants()[0].GetExtensions())
                    {
                        a.DeliverAudio = audioopt;
                        a.Save();
                    }
                }
                catch (Exception)
                {
                    System.Console.WriteLine("Exception in updatetest");
                }
                Thread.Sleep(10000);
            }
        }
    }
}