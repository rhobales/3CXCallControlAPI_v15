using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;
using System.Threading;

namespace OMSamples.Samples
{
    [SampleCode("notifications_monitor")]
    [SampleParam("arg1", "Object type name")]
    [SampleDescription("Shows update notifications of specified type of the objects. All notifications will be shown if arg1 is not specified")]
    class NotificationsMonitorSample : ISample
    {
        public void Run(params string[] args)
        {
            PhoneSystem ps = PhoneSystem.Root;
            String filter = null;
            if (args.Length > 1)
                filter = args[1];
            MyListener a = new MyListener(filter);
            ps.Updated += new NotificationEventHandler(a.ps_Updated);
            ps.Inserted += new NotificationEventHandler(a.ps_Inserted);
            ps.Deleted += new NotificationEventHandler(a.ps_Deleted);
            while (true)
            {
                Thread.Sleep(5000);
            }
        }
    }
}