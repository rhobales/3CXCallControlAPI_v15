using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("add_ivr")]
    [SampleParam("arg1", "System extension number of new Digital receptionist")]
    [SampleDescription("Creates Digital Receptionist 'TestIVR' which has empty prompt and redirects call to Voicemail of the extension after 20 seconds")]
    class AddIVRSample : ISample
    {
        public void Run(params string[] args)
        {
            IVR ivradd = PhoneSystem.Root.GetTenants()[0].CreateIVR(args[1]);
            ivradd.Name = "TestIVR";
            ivradd.PromptFilename = "empty.wav";
            ivradd.Timeout = 30;
            ivradd.TimeoutForwardType = IVRForwardType.VoiceMail;
            ivradd.TimeoutForwardDN = PhoneSystem.Root.GetTenants()[0].GetExtensions()[0];
            ivradd.Save();
            Console.WriteLine(ivradd);
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }
    }
}
