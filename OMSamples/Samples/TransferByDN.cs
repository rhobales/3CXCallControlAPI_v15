using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;
using TCX.PBXAPI;

namespace OMSamples.Samples
{
    [SampleCode("transfer_by_dn")]
    [SampleParam("arg1", "CallID taken from ActiveConnection")]
    [SampleParam("arg2", "participant which will be replaced in the call")]
    [SampleParam("arg3", "new participant who should replace participant specified by agr2")]
    [SampleDescription("Shows how to use PBXAPI.TransferCall()")]
    class TransferByDNSample : ISample
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
                    PhoneSystem.Root.TransferCall(System.Convert.ToInt32(args[1]), args[2], args[3]);
                    found = true;
                    break;
                }
            }
            if (!found)
                Console.WriteLine(args[2] + " does not participate in call " + args[1] + " or call is in incorrect state");
        }
    }
}
