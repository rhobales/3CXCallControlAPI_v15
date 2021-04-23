using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;
using System.Threading;

namespace OMSamples.Samples
{
    [SampleCode("display")]
    [SampleDescription("Shows information about all Parameters, Codecs, predefined conditions of the rules, IVRs and Extensions.")]
    class DisplayAllSample : ISample
    {
        public void Run(params string[] args)
        {
            PhoneSystem ps = PhoneSystem.Root;
            System.Console.WriteLine("Parameters:");
            foreach (Parameter p in ps.GetParameters())
            {
                System.Console.WriteLine("\t" + p.ToString());
            }
            System.Console.WriteLine("Codecs:");
            foreach (Codec c in ps.GetCodecs())
            {
                System.Console.WriteLine("\t" + c.ToString());
            }
            System.Console.WriteLine("Conditions:");
            foreach (RuleCondition rc in ps.GetRuleConditions())
            {
                System.Console.WriteLine("\t" + rc.ToString());
            }
            System.Console.WriteLine("RuleHours:");
            foreach (RuleHours rh in ps.GetRuleHourTypes())
            {
                System.Console.WriteLine("\t" + rh.ToString());
            }
            System.Console.WriteLine("RuleCalltype:");
            foreach (RuleCallType rct in ps.GetRuleCallTypes())
            {
                System.Console.WriteLine("\t" + rct.ToString());
            }
            foreach (Tenant t in ps.GetTenants())
            {
                System.Console.WriteLine(t.ToString());
                System.Console.WriteLine("\tOfficeHours:");
                foreach (HoursRange hr in t.OfficeHoursRanges)
                {
                    System.Console.WriteLine("\t\t" + hr);
                }
                System.Console.WriteLine("\tExtensions:");
                foreach (Extension e in t.GetExtensions())
                {
                    System.Console.WriteLine("\t\t" + e);
                    System.Console.WriteLine("\t\t\tProperties:");
                    foreach (DNProperty d in e.GetProperties())
                    {
                        System.Console.WriteLine("\t\t\t\t" + d);
                    }
                    System.Console.WriteLine("\t\t\tForwarding:");
                    foreach (ExtensionRule er in e.ForwardingRules)
                    {
                        System.Console.WriteLine("\t\t\t\t" + er);
                    }
                }
                foreach (IVR ivr in t.GetIVRs())
                {
                    System.Console.WriteLine("\t\t" + ivr.Name);
                    System.Console.WriteLine("\t\t\t" + ivr.Number);
                    System.Console.WriteLine("\t\t\t" + ivr.PromptFilename);
                    System.Console.WriteLine("\t\t\t" + ivr.Timeout);
                    System.Console.WriteLine("\t\t\t" + ivr.TimeoutForwardType.ToString());
                    DN dn = ivr.TimeoutForwardDN;
                    if (dn != null)
                        System.Console.WriteLine("\t\t\t" + dn.ToString());
                    else
                        System.Console.WriteLine("\t\t\t" + "not specified");
                }
            }
        }
    }
}
