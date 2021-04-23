using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;
using System.Threading;

namespace OMSamples.Samples
{
    [SampleCode("ext_line_rule_update")]
    [SampleParam("arg1", "Virtual extension number of the line")]
    [SampleWarning("This sample will modify destination of existing rules. Line should be recreated after this test")]
    [SampleDescription("This sample shows how to change destination of ExternalLineRule")]
    class ExternalLineRuleUpdateSample : ISample
    {
        public void Run(params string[] args)
        {
            ExternalLine _extLine = PhoneSystem.Root.GetDNByNumber(args[1]) as ExternalLine;
            if (_extLine != null)
            {
                bool bEndCall = false;
                for (; ; )
                {
                    ExternalLineRule lineRuleOff = null;
                    ExternalLineRule lineRuleOutOff = null;
                    foreach (ExternalLineRule extLineRule in _extLine.RoutingRules)
                    {
                        if (extLineRule.Conditions.Condition.Type == RuleConditionType.ForwardAll
                            && extLineRule.Conditions.Hours.Type == RuleHoursType.OfficeHours
                            && extLineRule.Conditions.CallType.Type == RuleCallTypeType.AllCalls)
                        {
                            lineRuleOff = extLineRule;
                        }
                        if (extLineRule.Conditions.Condition.Type == RuleConditionType.ForwardAll
                            && extLineRule.Conditions.Hours.Type == RuleHoursType.OutOfOfficeHours
                            && extLineRule.Conditions.CallType.Type == RuleCallTypeType.AllCalls)
                        {
                            lineRuleOutOff = extLineRule;
                        }
                    }
                    if (lineRuleOff != null)
                    {
                        if (!bEndCall)
                        {
                            lineRuleOff.Forward.To = DestinationType.Extension;
                            lineRuleOff.Forward.Internal = PhoneSystem.Root.GetTenants()[0].GetExtensions()[0];
                        }
                        else
                        {
                            lineRuleOff.Forward.To = DestinationType.None;
                        }
                    }
                    if (lineRuleOutOff != null)
                    {
                        if (!bEndCall)
                        {
                            lineRuleOutOff.Forward.To = DestinationType.Extension;
                            lineRuleOutOff.Forward.Internal = PhoneSystem.Root.GetTenants()[0].GetExtensions()[0];
                        }
                        else
                        {
                            lineRuleOutOff.Forward.To = DestinationType.None;
                        }
                    }
                    _extLine.Save();
                    bEndCall = !bEndCall;
                    Thread.Sleep(5000);
                }
            }
            else
            {
                Console.WriteLine(args[1] + " is not ExternalLine");
            }
        }
    }
}
