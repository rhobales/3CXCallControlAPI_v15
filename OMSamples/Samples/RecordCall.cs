using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;
using TCX.PBXAPI;

namespace OMSamples.Samples
{
    [SampleCode("record_call")]
    [SampleParam("arg1", "CallID taken from ActiveConnection")]
    [SampleParam("arg2", "who initiate record. (must be participant of the call")]
    [SampleParam("arg3", "1/0 - start/stop")]
    [SampleDescription("Shows how to start/stop recording of the call")]
    class RecordCallSample : ISample
    {
        public void Run(params string[] args)
        {
            DN dn = PhoneSystem.Root.GetDNByNumber(args[2]);
            ActiveConnection[] conns = dn.GetActiveConnections();
            bool found = false;
            foreach (ActiveConnection ac in conns)
            {
                if (ac.CallID == int.Parse(args[1]) && ac.Status == ConnectionStatus.Connected)
                {
                    PhoneSystem.Root.RecordCall(System.Convert.ToInt32(args[1]), args[2], System.Convert.ToInt32(args[3]) != 0);
                    found = true;
                    break;
                }
            }
            if (!found)
                Console.WriteLine(args[2] + " does not participate in call " + args[1] + " or call is in incorrect state");
        }
    }
}
