using System;
using System.Collections.Generic;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("makecall2")]
    [SampleParam("arg1", "Source of the call")]
    [SampleParam("arg2, arg3 and so on", "Additional parameters for the call. in form paramname=paramvalue")]
    [SampleDescription("Shows how to use extended version of PhoneSystem.MakeCall(string, Dictionary<string, string>) helper")]
    class MakeCall2Sample : ISample
    {
        public void Run(params string[] args)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            for (int i = 2; i < args.Length; i++)
            {
                string[] a = args[i].Split(new char[] { '=' });
                d.Add(a[0], a[1]);
            }
            try
            {
                PhoneSystem.Root.MakeCall(args[1], d);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }
        }
    }
}
