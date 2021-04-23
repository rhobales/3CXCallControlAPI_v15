using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("create_fax_extension")]
    [SampleParam("arg1", "System extension number for new FaxExtension")]
    [SampleParam("arg2", "SIP authentication ID. It can be different form the FaxExtension number")]
    [SampleParam("arg3", "Authentication password. must be secure")]
    [SampleDescription("Creates FAX extension.")]
    class CreateFaxExtensionSample : ISample
    {
        public void Run(params string[] args)
        {
            FaxExtension fe = PhoneSystem.Root.GetTenants()[0].CreateFaxExtension(args[1]);
            fe.AuthID = args[2];
            fe.AuthPassword = args[3];
            fe.Save();
        }
    }
}