using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace smpsDebugUART
{
    [System.Runtime.InteropServices.GuidAttribute("3952432A-6B37-4A47-8A68-A42D879C5A0D")]
    class clsINIFileHandler
    {
        // Settings file handling
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString", CallingConvention = CallingConvention.StdCall)]
        static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString", CallingConvention = CallingConvention.StdCall)]
        static extern int WritePrivateProfileString(string lpAppName, string lpKeyName, StringBuilder lpString, int nSize, string lpFileName);
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString", CallingConvention = CallingConvention.StdCall)]
        static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
        [DllImport("Kernel32.dll")]
        static extern bool Beep(Int32 dwFreq, Int32 dwDuration);


        private string _default_directory = "";
        public string DefaultDirectory
        {
            get {
                string sdum = "";

                sdum = Application.StartupPath;
                if (sdum.Substring(sdum.Length - 1, 1) != "\\")
                { sdum = sdum + "\\"; }
                _default_directory = sdum;
                return (_default_directory); 
            }
            //            set { _directory = value; return; }
        }

        private string _directory = "";
        public string Directory
        {
            get { return (_directory); }
//            set { _directory = value; return; }
        }

        private string _filename = "";
        public string FileName
        {
            get { return (_filename); }
//            set { _filename = value; return; }
        }

        private string _file_title = "";
        public string FileTitle
        {
            get { return (_file_title); }
//            set { _file_title = value; return; }
        }

        private string _file_extension = "";
        public string FileExtension
        {
            get { return (_file_extension); }
//            set { _file_extension = value; return; }
        }

        // ========================================================================================
        // File operation handling functions
        // ========================================================================================

        public bool Create(string FileName, string InitialSection, string InitialKey, string InitialValue)
        {
            bool fres=false;
            fres = WritePrivateProfileString(InitialSection, InitialKey, InitialValue, FileName);
            if(fres)
                fres &= SetFilename(FileName);
            return (fres);
        }

        public bool SetFilename(string FileName)
        {
            string sdum = "";

            sdum = GetDirectory(FileName);

            if (System.IO.Directory.Exists(sdum))
            {
                _directory = sdum;
                _filename = FileName.Trim();
                _file_title = GetFileName(FileName);
                _file_extension = GetFileExtension(FileName);
                return (true);
            }
            else
            {
                _directory = "";
                _filename = "";
                _file_title = "";
                _file_extension = "";
                return (false);
            }
    
        }

        public bool FileExists(string FileName)
        {
            return (System.IO.File.Exists(FileName));
        }

        private string GetDirectory(string NewDirectory)
        {
            string str_dum = "";
            string[] str_arr;
            string[] dum_sep = new string[1];

            // If parameter 'directory' is empty, return default application path 
            if (NewDirectory.Trim().Length == 0)
            {
                str_dum = Application.StartupPath;
                if (str_dum.Substring(str_dum.Length - 1, 1) != "\\") 
                {
                    str_dum = str_dum + "\\"; 
                }
            }
            // If parameter 'directory' i snot empty, extract the path information  
            else
            {
                dum_sep[0] = ("\\");
                str_arr = NewDirectory.Split(dum_sep, StringSplitOptions.RemoveEmptyEntries);
                str_dum = NewDirectory.Substring(0, NewDirectory.Length - str_arr[str_arr.Length - 1].Length);
            }

            return (str_dum.Trim());
        }

        private string GetFileName(string FilePathString)
        {
            string str_dum = "";
            string[] str_arr;
            string[] dum_sep = new string[1];

            dum_sep[0] = ("\\");
            str_arr = FilePathString.Split(dum_sep, StringSplitOptions.RemoveEmptyEntries);
            str_dum = str_arr[Convert.ToInt32(str_arr.GetUpperBound(0))];

            return (str_dum.Trim());
        }

        private string GetFileExtension(string FileNameString)
        {
            string str_dum = "";
            string[] str_arr;
            string[] dum_sep = new string[1];

            dum_sep[0] = (".");
            str_arr = FileNameString.Split(dum_sep, StringSplitOptions.RemoveEmptyEntries);
            str_dum = str_arr[Convert.ToInt32(str_arr.GetUpperBound(0))];

            return (str_dum.Trim());
        }

        // ========================================================================================
        // INI file structure handling functions
        // ========================================================================================
        public string ReadKey(string Section, string Key, string DefaultValue)
        {
            int rc;
            StringBuilder sb = new StringBuilder(65536);
            rc = GetPrivateProfileString(Section, Key, DefaultValue, sb, 65535, _filename);
            if (rc > 0)
                return sb.ToString();
            else
                return DefaultValue;
        }

        public bool WriteKey(string Section, string Key, string Value)
        {
            bool rc;
            rc = WritePrivateProfileString(Section, Key, Value, _filename);

            return rc;
        }

        public bool DeleteKey(string Section, string Key)
        {
            bool rc;
            rc = WritePrivateProfileString(Section, Key, null, _filename);

            return rc;
        }

        public bool KeyExists(string Section, string Key)
        {
            int rc;
            StringBuilder sb = new StringBuilder(65536);
            rc = GetPrivateProfileString(Section, Key, "", sb, 65535, _filename);
            if (rc > 0)
                return (true);
            else
                return (false);
        }


    }
}
