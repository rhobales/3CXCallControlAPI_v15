using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using TCX.Configuration;

namespace OMSamples
{
    public static class Utilities
    {
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA")]
        static extern int GetKeyValueA(string strSection, string strKeyName, string strNull, StringBuilder RetVal, int nSize, string strFileName);
        static public string GetKeyValue(string Section, string KeyName, string FileName)
        {
            //Reading The KeyValue Method
            try
            {
                StringBuilder JStr = new StringBuilder(255);
                int i = GetKeyValueA(Section, KeyName, String.Empty, JStr, 255, FileName);
                return JStr.ToString();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static string GetParameterValue(string name, string DefaultValue, ref bool exists)
        {
            try
            {
                exists = true;
                return TCX.Configuration.PhoneSystem.Root.GetParameterByName(name).Value;
            }
            catch
            {
                exists = false;
                return DefaultValue;
            }
        }
    }
}
