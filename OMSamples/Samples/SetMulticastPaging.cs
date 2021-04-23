using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("set_multicast_paging")]
    [SampleParam("arg1", "Paging group")]
    [SampleParam("arg2", "Multicast address")]
    [SampleParam("arg3", "Multicast port")]
    [SampleParam("arg4", "codec. (PCMU, PCMA, GSM, G729 etc..)")]
    [SampleParam("arg5", "ptime for RTP packets. use 20")]
    [SampleDescription("Shows how to set 'multicast' options for paging group. If only arg1 is provided then multicast settings will be removed and paging group will work as in 'multicall' mode")]
    class SetMulticastPagingSample : ISample
    {
        public void Run(params string[] args)
        {
            RingGroup dn = PhoneSystem.Root.GetDNByNumber(args[1]) as RingGroup;
            if (dn != null && dn.RingStrategy == RingGroup.StrategyType.Paging)
            {
                if (args.Length > 2)
                {
                    dn.SetProperty("MULTICASTADDR", args[2], PropertyType.String, "");
                    dn.SetProperty("MULTICASTPORT", args[3], PropertyType.String, "");
                    dn.SetProperty("MULTICASTCODEC", args[4], PropertyType.String, "");
                    dn.SetProperty("MULTICASTPTIME", args[5], PropertyType.String, "");
                }
                else
                {
                    dn.DeleteProperty("MULTICASTADDR");
                    dn.DeleteProperty("MULTICASTPORT");
                    dn.DeleteProperty("MULTICASTCODEC");
                    dn.DeleteProperty("MULTICASTPTIME");
                }
                dn.Save();
            }
        }
    }
}
