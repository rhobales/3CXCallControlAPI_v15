using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;
using System.Threading;

namespace OMSamples.Samples
{
    [SampleCode("phonebook")]
    [SampleDescription("Shows how to create PhoneBookEntry for company and personal phonebooks")]
    class PhoneBookSample : ISample
    {
        public void Run(params string[] args)
        {
            Tenant t = PhoneSystem.Root.GetTenants()[0];
            DN e = null;
            foreach (DN dn in t.GetDN())
            {
                if (dn.Number == "108")
                {
                    e = dn;
                }
            }
            PhoneBookEntry a = t.CreatePhoneBookEntry();
            a.FirstName = "TenantFN";
            a.LastName = "TenantLN";
            a.PhoneNumber = "54321";
            a.Save();
            a = e.CreatePhoneBookEntry();
            a.FirstName = "ExtFN";
            a.LastName = "ExtLN";
            a.PhoneNumber = "7890";
            a.Save();
            Thread.Sleep(2000);
            t.Refresh();
            e.Refresh();
            foreach (PhoneBookEntry pbe in t.GetPhoneBookEntries())
            {
                System.Console.WriteLine(pbe.ToString());
            }
            foreach (PhoneBookEntry pbe in e.GetPhoneBookEntries())
            {
                System.Console.WriteLine(pbe.ToString());
            }
        }
    }
}