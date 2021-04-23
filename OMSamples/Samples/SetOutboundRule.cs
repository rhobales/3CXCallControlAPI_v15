using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("set_outboundrule")]
    [SampleDescription("Shows how to configure outbound rules. Requires at least one gateway configured on PBX.")]
    class SetOutboundRuleSample : ISample
    {
        public void Run(params string[] args)
        {
            PhoneSystem ps = PhoneSystem.Root;
            Tenant t = ps.GetTenants()[0];
            OutboundRule r = t.CreateOutboundRule();
            r.Name = "OMSamples Test Rule";
            r.NumberOfRoutes = 5;  //must be set to specify 5 routes. otherwise it is only 3 routes.
            r.Priority = t.GetOutboundRules().Max(x => x.Priority) + 1; //lowest priority of rule. must be unique.
            r.OutboundRoutes[0].Gateway = ps.GetGateways()[0]; //make first route to any gateway object available in configuration.
            try
            {
                //should fail.
                r.OutboundRoutes[5].Gateway = ps.GetGateways()[0];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Number of available routes is " + r.OutboundRoutes.Length);
                r.OutboundRoutes[4].Gateway = ps.GetGateways()[0]; //it is fifth route of outbound rule.
            }
            r.Save();
            Console.WriteLine(r);
        }
    }
}
