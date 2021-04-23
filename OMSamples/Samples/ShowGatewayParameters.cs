using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("show_gateway_parameters")]
    [SampleDescription("")]
    class ShowGatewayParametersSample : ISample
    {
        public void Run(params string[] args)
        {
            foreach (GatewayParameter p in PhoneSystem.Root.GetGatewayParameters())
            {
                System.Console.WriteLine(p.Name);
                System.Console.WriteLine("\tSourceID");
                foreach (GatewayParameterValue v in p.PossibleValuesAsSourceID)
                {
                    System.Console.WriteLine("\t\t" + v.Name);
                }
                System.Console.WriteLine("\tInbound");
                foreach (GatewayParameterValue v in p.PossibleValuesAsInbound)
                {
                    System.Console.WriteLine("\t\t" + v.Name);
                }
                System.Console.WriteLine("\tOutbound");
                foreach (GatewayParameterValue v in p.PossibleValuesAsOutbound)
                {
                    System.Console.WriteLine("\t\t" + v.Name);
                }
                System.Console.Write(".");
            }
        }
    }
}
