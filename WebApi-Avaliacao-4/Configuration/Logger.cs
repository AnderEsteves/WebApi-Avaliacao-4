using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebApi_Avaliacao_4.Configuration
{
    public class Logger
    {
        private static string GetPath()
        {
            return System.Configuration.ConfigurationManager.AppSettings["caminhoLog"];
        }


        private static string GetArchiveName()
        {
            return $"{DateTime.Now.ToString("yyyy-MM-dd")} - Log.txt";
        }


        public static string GetFullPath()
        {
            return Path.Combine(GetPath(), GetArchiveName());
        }

    }
}