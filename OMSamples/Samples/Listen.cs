using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.PBXAPI;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("listen")]
    [SampleParam("arg1", "Specifies extension which will barge in to the call.")]
    [SampleParam("arg2", "Specifies extension which participate in a call")]
    [SampleDescription("Shows how to use PhoneSystem.BargeIn to listen a call")]
    class ListenSample : ISample
    {
        public void Run(params string[] args)
        {
            Extension e = PhoneSystem.Root.GetDNByNumber(args[2]) as Extension;
            if (e != null)
            {
                //in sample, we take first available connection of the specified extension.
                ActiveConnection ac = PhoneSystem.Root.GetDNByNumber(args[2]).GetActiveConnections()[0];
                PhoneSystem.Root.BargeinCall(args[1], ac, PBXConnection.BargeInMode.Listen);
            }
        }
    }
}
