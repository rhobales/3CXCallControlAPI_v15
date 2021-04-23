using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;
using TCX.PBXAPI;

namespace OMSamples.Samples
{
    [SampleCode("divertcall")]
    [SampleParam("arg1", "CallID taken from real active connection")]
    [SampleParam("arg2", "Extension where call is ringing")]
    [SampleParam("arg3", "new destination for the call")]
    [SampleParam("arg4", " optional. if '1' then call will be diverted to voicemail of the destination specified by arg3")]
    [SampleDescription("Shows how to use CallControl API to divert call.")]
    class DivertCallSample : ISample
    {
        public void Run(params string[] args)
        {
            DN dn = PhoneSystem.Root.GetDNByNumber(args[2]);
            ActiveConnection[] conns = dn.GetActiveConnections();
            bool found = false;
            foreach (ActiveConnection ac in conns)
            {
                if (ac.CallID == int.Parse(args[1]) && ac.Status == ConnectionStatus.Ringing)
                {
                    PhoneSystem.Root.DivertCall(ac, args[3], (args.Length > 4 && System.Convert.ToInt32(args[4]) == 1) ? true : false);
                    found = true;
                    break;
                }
            }
            if (!found)
                Console.WriteLine(args[2] + " does not participate in call " + args[1] + " or call is in incorrect state");
        }
    }
}
