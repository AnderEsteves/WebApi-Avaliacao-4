using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebApi_Avaliacao_4.Utils
{
    public class Logger
    {
        
        public static void WriteExpection(string fullPatch, Exception e)
        {

            using (StreamWriter sw = new StreamWriter(fullPatch, true))
            {
                sw.Write("Data: ");
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sw.Write("Mensagem:");
                sw.Write(e.Message);
                sw.WriteLine("StackTrace:");
                sw.Write(e.StackTrace);
                sw.WriteLine("\n\n");
            }

        }


    }
}