using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.PBXAPI;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("whisper")]
    [SampleParam("arg1", "Specifies extension which will \"barge in\" to the call.")]
    [SampleParam("arg2", "Specifies participant who will hear the extension added to the call.")]
    [SampleDescription("Shows how to use PBXAPI.BargeIn() to listen call and whisper to specific call participant.")]
    class WhisperSample : ISample
    {
        public void Run(params string[] args)
        {
            //in sample, we take first available connection of the specified extension and then whisper to it.
            ActiveConnection ac = PhoneSystem.Root.GetDNByNumber(args[2]).GetActiveConnections()[0];
            PhoneSystem.Root.BargeinCall(args[1], ac, PBXConnection.BargeInMode.Whisper);
        }
    }
}
