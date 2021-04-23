using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;
using System.Threading;
using TCX.PBXAPI;

namespace OMSamples.Samples
{
    [SampleCode("recordivrprompt")]
    [SampleParam("arg1", "IVR number")]
    [SampleParam("arg2", "Extension number")]
    [SampleParam("arg3", "(optional) name of the file. File will be stored in standard IVR prompt path and will be appended with .wav extension")]
    [SampleDescription("If IVR and extension exist, are not busy and extension is registered then PBX will contact extension to record file and will set it as a new prompt for the IVR")]
    class RecordIVRPrompt : ISample
    {
        public void Run(params string[] args)
        {
            PhoneSystem ps = PhoneSystem.Root;
            IVR ivr = ps.GetDNByNumber(args[1]) as IVR;
            Extension ext = ps.GetDNByNumber(args[2]) as Extension;
            String filename;
            if(ivr==null||ivr.GetActiveConnections().Length!=0)
            {
                Console.WriteLine("ERROR: IVR "+ args[1]+" does not exist or currently active");
                return;
            }

            if(ext==null||!ext.IsRegistered||ext.GetActiveConnections().Length!=0)
            {
                Console.WriteLine("ERROR: Extension "+ args[2]+" does not exist, is busy or is not registered");
                return;
            }
            bool checkUpdateOfFile=false;
            if(args.Length<4)
            {
                filename = Path.GetFileNameWithoutExtension(ivr.PromptFilename).ToLowerInvariant();
            }
            else
            {
                filename = args[3].ToLowerInvariant();
            }
            String fileNameToRecord = Path.Combine(ps.GetParameterByName("IVRPROMPTPATH").Value, filename+".wav");
            if(args.Length>3&&File.Exists(fileNameToRecord)&&Path.GetFileNameWithoutExtension(ivr.PromptFilename).ToLowerInvariant()!=filename)
            {
                Console.WriteLine("ERROR: File already exist but not selected for IVR:" + ivr.Number + "(" + ivr.Name + ")");
                return;
            }
            DateTime filedt=DateTime.UtcNow;
            if(File.Exists(fileNameToRecord))
            {
                checkUpdateOfFile = true;
                filedt = File.GetLastWriteTimeUtc(fileNameToRecord);
            }

            
            Dictionary<String, String> a=new Dictionary<string,string>();
            a["extension"]=args[2];
            a["filename"] = fileNameToRecord;
            
            PhoneSystem.Root.MakeCall("RecordFile", a);
            Console.Write("Wait for the call.");
            for(int i=0 ; i<20&&ext.GetActiveConnections().Length==0; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            if(ext.GetActiveConnections().Length==0)
            {
                Console.WriteLine("FAILED");
                return;
            }
            Console.WriteLine("Done");
            Console.Write("Wait for the end of the call.");
            while(ext.GetActiveConnections().Length>0)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Done");
            if (checkUpdateOfFile)
            {
                Console.Write("Waiting for file update.");
                for(int i=0 ; i<20&&File.GetLastWriteTimeUtc(fileNameToRecord)==filedt; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
                if(File.GetLastWriteTimeUtc(fileNameToRecord)==filedt)
                {
                    Console.WriteLine("FAILED");
                    return;
                }
                else
                {
                    Console.WriteLine("Done");
                }
            }
            else
            {
                Console.Write("Waiting for new file.");
                for(int i=0 ; i<20&&!File.Exists(fileNameToRecord); i++)
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }

                if(!File.Exists(fileNameToRecord))
                {
                    Console.WriteLine("FAILED");
                    return;
                }
                else
                {
                    Console.WriteLine("Done");
                }
            }
            ivr.PromptFilename = filename+".wav";
            ivr.Save();
            Console.WriteLine("Prompt successfuly changed on IVR:" + ivr.Number + "(" + ivr.Name + ")");
        }
    }
}
