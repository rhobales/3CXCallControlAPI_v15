using System;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("makecall")]
    [SampleParam("arg1", "Source of the call")]
    [SampleParam("arg2", "Destination of the call")]
    [SampleDescription("Shows how to use MakeCall helper. call will come to the source and after answer source will be transferred to destination number")]
    class MakeCallSample : ISample
    {
        public void Run(params string[] args)
        {
            for (; ; )
            {
                try
                {
                    PhoneSystem.Root.MakeCall(args[1], args[2]);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.ToString());
                }
                ConsoleKeyInfo k = System.Console.ReadKey(false);
                if (k.KeyChar == 'e')
                {
                    break;
                }
            }
        }
    }
}
