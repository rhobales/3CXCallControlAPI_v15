using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;
using System.Threading;
namespace OMSamples.Samples
{
    [SampleCode("dnproperty_save_delete")]
    [SampleParam("arg1", "Extension which will be modified")]
    [SampleWarning("modifies configuration of the extension specified by argument 1")]
    [SampleDescription("Shows how to modify(add) and delete DNProperty. each time when script is running it created->modifies->deletes property of dn depending on its value")]
    class DNPropertySaveDeleteSample : ISample
    {
        readonly string propname = "OMTEST_TESTPROP";
        readonly string justadded = "added by OMtest";
        readonly string modified_after_add = "modified by OMtest";
        public void Run(params string[] args)
        {
            Extension ext = PhoneSystem.Root.GetDNByNumber(args[1]) as Extension;
            try
            {
                var propval = ext.GetPropertyValue(propname);
                if (propval == null) //does not exist
                {
                    System.Console.WriteLine(propname+" doest exist. Add it");
                    ext.SetProperty(propname, justadded);
                    ext.Save();
                }
                else if (propval == justadded)
                {

                    System.Console.WriteLine(propname+" just added. Modify it");
                    ext.SetProperty(propname, modified_after_add);
                    ext.Save();
                }
                else if (propval == modified_after_add)
                {
                    System.Console.WriteLine(propname + " is modified. delete it");
                    ext.DeleteProperty(propname);
                    ext.Save();
                }
                else
                {
                    //just to avoid unexpected modifications.
                    System.Console.WriteLine("OMTEST_TESTPROP has unexpected value.");
                }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("Failed to perform test action:{0}", ex);
            }
        }
    }
}