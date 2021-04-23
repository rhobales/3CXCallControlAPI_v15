using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;
using System.Threading;

namespace OMSamples.Samples
{
    [SampleCode("remove_ivr")]
    [SampleWarning("It is destructive operation. Please be carefull with arguments")]
    [SampleParam("arg1", "system extension number of IVR")]
    [SampleDescription("Shows how to remove existing IVR")]
    class RemoveIVRSample : ISample
    {
        public void Run(params string[] args)
        {
            DN to_delete = PhoneSystem.Root.GetDNByNumber(args[1]);
            if (to_delete is IVR)
            {
                to_delete.Delete();
                while (PhoneSystem.Root.GetDNByNumber(args[1]) != null)
                {
                    //ObjectModel do not delete object immediatelly. So deleted object
                    //may be alive for some short period of time. Only after receiving
                    //notification event 'Deleted' from Object Model - the object was removed.
                    Console.WriteLine("Extension " + args[1] + " still alive...");
                    Thread.Sleep(500);
                }
                Console.WriteLine("Extension " + args[1] + " now deleted");
            }
        }
    }
}
