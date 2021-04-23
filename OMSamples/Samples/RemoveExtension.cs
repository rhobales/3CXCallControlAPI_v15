using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;
using System.Threading;

namespace OMSamples.Samples
{
    [SampleCode("remove_extension")]
    [SampleWarning("It is destructive operation. Please be carefull with arguments")]
    [SampleParam("arg1", "extension number")]
    [SampleDescription("Shows how to remove existing extension")]
    class RemoveExtensionSample : ISample
    {
        public void Run(params string[] args)
        {
            DN to_delete = PhoneSystem.Root.GetDNByNumber(args[1]);
            if (to_delete is Extension)
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